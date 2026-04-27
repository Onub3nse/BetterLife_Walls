using BetterLife;
using Mafi;
using Mafi.Collections;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Economy;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Factory.Transports;
using Mafi.Core.Factory.Zippers;
using Mafi.Core.Ports;
using Mafi.Core.Ports.Io;
using Mafi.Core.Products;
using Mafi.Core.Prototypes;
using Mafi.Core.Simulation;
using Mafi.Serialization;
using Mafi.Unity;
using Mafi.Unity.Entities;
using Mafi.Unity.Entities.Static;
using System;
using UnityEngine;


namespace BetterLife_Walls
{
    [GlobalDependency(RegistrationMode.AsAllInterfaces)]
    public class btBalancerMbFactory : IEntityMbFactory<btBalancer>, IFactory<btBalancer, EntityMb>
    {

        private readonly ProtoModelFactory modelFactory;
        private readonly AssetsDb m_assetsDb;
        private readonly ProtosDb m_protoDb;

        public btBalancerMbFactory(ProtoModelFactory mFactory, AssetsDb assetsDb, ProtosDb protosDb)
        {
            modelFactory = mFactory;
            m_assetsDb = assetsDb;
            m_protoDb = protosDb;
        }

        public EntityMb Create(btBalancer balancerEnt)
        {
            Assert.That(balancerEnt).IsNotNull();
            GameObject gameObject = modelFactory.CreateModelFor(balancerEnt.Prototype);
            btBalancerMb trMb = gameObject.AddComponent<btBalancerMb>();
            trMb.Initialize(balancerEnt, m_assetsDb, m_protoDb);
            //Log.Info("MB for transport created...");
            return trMb;
        }
    }

    public class btBalancerMb : StaticEntityMb, IDestroyableEntityMb, IEntityMb, IEntityMbWithSyncUpdate
    {
        private GameObject insideGo;
        private Material gameObjectMaterial;
        private ColorRgba currentColor = ColorRgba.Magenta;
        private AssetsDb m_assetsDb;
        private ProtosDb m_protoDb;
        private btBalancer thisEntity;
        private bool isInitialized;

        public btBalancerMb()
        : base()
        {
        }

        public void Initialize(btBalancer btBalancerEntity, AssetsDb assetsDb, ProtosDb protosDb)
        {
            Assert.That(btBalancerEntity).IsNotNull();
            Initialize(btBalancerEntity);
            thisEntity = btBalancerEntity;
            m_assetsDb = assetsDb;
            m_protoDb = protosDb;
            if (this.gameObject.TryFindChild("color", out insideGo))
            {
                var renderer = insideGo.GetComponent<Renderer>();
                if (renderer != null)
                {
                    gameObjectMaterial = renderer.material;
                    //Log.Info("gameObjectMaterial retrieved successfully.");
                }
                else
                {
                    //Log.Info("Child 'color' found, but it has no Renderer component in prefab: ");
                }
            }
            else
            {
                //Log.Info("Failed to find child GameObject named 'color' in prefab: ");
            }
            isInitialized = true;
            //Log.Info("isInitialized.. true");
            Assert.That(thisEntity).IsNotNull("thisEntity must be set after Initialize.");
        }

        public void SyncUpdate(GameTime time)
        {
            if (time.IsGamePaused || !isInitialized) return;
            try
            {
                if (thisEntity == null)
                {
                    //Log.Info("thisEntity is null in SyncUpdate.");
                    return;
                }
                //Log.Info("getting main texture...");
                if (gameObjectMaterial == null)
                {
                    //Log.Info("gameObjectMaterial is null, cannot access mainTexture.");
                    return;
                }
                Texture pMaterial = gameObjectMaterial.mainTexture;
                //Log.Info("checking color...");
                gameObjectMaterial.color = thisEntity.myColor.ToColor();
                currentColor = thisEntity.myColor;
                //Log.Info("color changed in mb...");

            }
            catch (Exception e)
            {
                Log.Info($"MB->{e.Message} {e.Source} {e.InnerException} {e.TargetSite}");
            }
        }
    }

    public class btBalancerProto : LayoutEntityProto, ILayoutEntityProtoWithElevation // IStaticEntityProto, IEntityProto, IProto
    {
        public bool CanBeElevated { get; }
        public bool CanPillarsPassThrough { get; }

        public readonly string Value;
        //        public new StaticEntityProto.ID Id { get; }
        public btBalancerProto(ID id, Str strings, EntityLayout layout, EntityCosts costs, Gfx graphics, IoPortTemplate[] portTemplates)
                    : base(id, strings, layout, costs, graphics)
        {
            m_portTemplates = portTemplates;
        }
        public override Type EntityType => typeof(btBalancer);

        public IoPortTemplate[] m_portTemplates;
    }


    [GenerateSerializer(false, null, 0)]
    public class btBalancer : LayoutEntity, IAreaSelectableEntity, IEntity, IEntityWithPosition, IIsSafeAsHashKey, IObjectWithTitle,
                                            IRenderedEntity, IStaticEntity, IEntityWithPorts, IEntityWithSimUpdate
    {



        private btBalancerProto m_proto;
        private StaticEntityProto.ID m_protoId;
        private readonly Queueue<ZipBuffProduct> m_outputBuffer;
        private readonly ProductQuantity[] m_inputBuffer;
        public Quantity m_quantityInInputBuffer;
        public Quantity m_quantityInOutputBuffer;
        private ImmutableArray<IoPortData> m_connectedInputPortsCache;
        private ImmutableArray<IoPortData> m_connectedOutputPortsCache;
        private int m_lastUsedInputPortIndex;
        private int m_lastUsedOutputPortIndex;
        private ISimLoopEvents m_simLoopEvents;
        private readonly ITransportsPredicates m_transportsPredicates;
        private readonly TransportsManager m_transportsManager;
        private Quantity m_maxBufferSize;
        private Duration m_delay;
        private ProductColorManager m_productColorManager;
        public ColorRgba myColor = ColorRgba.Magenta;
        private ProductQuantity currentProduct = ProductQuantity.None;
        public Quantity TotalQuantityInBuffers => m_quantityInInputBuffer + m_quantityInOutputBuffer;

        public Quantity MaxBufferSize => m_maxBufferSize + m_connectedInputPortsCache.Length.Quantity();

        public int OutputPortsConnected => m_connectedOutputPortsCache.Length;

        public Option<ProductProto> ProvidedProduct { get; private set; }

        public Quantity MaxProvidedPerTick { get; private set; }

        public Quantity ProvidedLastTick { get; private set; }

        //        public override AssetValue Value => Prototype.Costs.Price;

        public new btBalancerProto Prototype
        {
            get
            {
                return m_proto;
            }
            protected set
            {
                m_proto = value;
                m_protoId = m_proto.Id;
                base.Prototype = value;
            }
        }
        public btBalancer(EntityId id, btBalancerProto proto, TileTransform transform, EntityContext context, SimLoopEvents simLoopEvents,
                        ITransportsPredicates transportsPredicates, TransportsManager transportsManager, ProductColorManager productColorManager)
                : base(id, proto, transform, context)
        {

            Prototype = proto.CheckNotNull();
            m_outputBuffer = new Queueue<ZipBuffProduct>();
            m_simLoopEvents = simLoopEvents;
            MaxProvidedPerTick = 10.Quantity();
            m_transportsPredicates = transportsPredicates;
            m_transportsManager = transportsManager;
            m_productColorManager = productColorManager;
            //IoPortTemplate[] fakeTemplate = null;
            //fakeTemplate = portTemplates.transPORTshapes.shapeTransBar4m(Ports[0].ShapePrototype);
            //createPorts(fakeTemplate);
            createPorts(Prototype.m_portTemplates);
            m_inputBuffer = new ProductQuantity[Ports.Length];
            for (int i = 0; i < m_inputBuffer.Length; i++)
            {
                m_inputBuffer[i] = ProductQuantity.None;
            }
            recomputePortInfo();

        }
        public Upoints GetQuickRemoveCost(out bool canAfford)
        {
            canAfford = false;
            Quantity zero = Quantity.Zero;
            for (int i = 0; i < this.m_inputBuffer.Length; i++)
            {
                zero += this.m_inputBuffer[i].Quantity;
            }
            Queueue<ZipBuffProduct>.Enumerator enumerator = this.m_outputBuffer.GetEnumerator();
            while (enumerator.MoveNext())
            {
                zero += enumerator.Current.ProductQuantity.Quantity;
            }
            Upoints upoints = QuickDeliverCostHelper.QuantityToUnityCost(zero.Value, base.Context.UpointsManager.QuickActionCostMultiplier, true) ?? Upoints.Zero;
            canAfford = base.Context.UpointsManager.CanConsume(upoints);
            return upoints;
        }

        public void GetAllBufferedProducts(Lyst<ProductQuantity> aggregated)
        {
            ProductQuantity[] inputBuffer = this.m_inputBuffer;
            for (int i = 0; i < inputBuffer.Length; i++)
            {
                ProductQuantity pq = inputBuffer[i];
                if (pq.IsNotEmpty)
                {
                    aggregate(pq);
                }
            }
            Queueue<ZipBuffProduct>.Enumerator enumerator = this.m_outputBuffer.GetEnumerator();
            while (enumerator.MoveNext())
            {
                aggregate(enumerator.Current.ProductQuantity);
            }
            void aggregate(ProductQuantity item)
            {
                for (int j = 0; j < aggregated.Count; j++)
                {
                    if (aggregated[j].Product == item.Product)
                    {
                        aggregated[j] += item.Quantity;
                        return;
                    }
                }
                aggregated.Add(item);
            }
        }

        Quantity IEntityWithPorts.ReceiveAsMuchAsFromPort(ProductQuantity pq, IoPortToken sourcePort)
        {
            if (base.IsNotEnabled)
            {
                if (base.ConstructionState == ConstructionState.NotInitialized)
                {
                    StartConstructionIfNotStarted();
                    Assert.That(base.ConstructionState).IsNotEqualTo(ConstructionState.NotInitialized);
                }
                return pq.Quantity;
            }
            if (m_inputBuffer[sourcePort.PortIndex].IsNotEmpty)
            {
                return pq.Quantity;
            }
            m_inputBuffer[sourcePort.PortIndex] = pq;
            m_quantityInInputBuffer += pq.Quantity;
            currentProduct = pq;
            if (currentProduct.IsNotEmpty == true) myColor = m_productColorManager.GetColor(currentProduct.Product.Id, true);
            return Quantity.Zero;
        }
        protected override void OnDestroy()
        {
            clearAllProducts();
            base.OnDestroy();
        }
        private void clearAllProducts()
        {
            IAssetTransactionManager assetTransactionManager = base.Context.AssetTransactionManager;
            for (int i = 0; i < m_inputBuffer.Length; i++)
            {
                assetTransactionManager.StoreClearedProduct(m_inputBuffer[i]);
                m_inputBuffer[i] = ProductQuantity.None;
            }
            Queueue<ZipBuffProduct>.Enumerator enumerator = m_outputBuffer.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ZipBuffProduct current = enumerator.Current;
                if (current.ProductQuantity.IsNotEmpty)
                {
                    assetTransactionManager.StoreClearedProduct(current.ProductQuantity);
                }
            }
            m_outputBuffer.Clear();
        }

        private void moveInputToOutBuffer(int index)
        {
            ProductQuantity productQuantity = m_inputBuffer[index];
            m_quantityInInputBuffer -= productQuantity.Quantity;
            m_quantityInOutputBuffer += productQuantity.Quantity;
            m_inputBuffer[index] = ProductQuantity.None;
            if (m_outputBuffer.IsNotEmpty)
            {
                ZipBuffProduct last = m_outputBuffer.Last;
                if (last.EnqueuedAtStep == m_simLoopEvents.CurrentStep && last.ProductQuantity.Product == productQuantity.Product)
                {
                    m_outputBuffer.PopLast();
                    productQuantity = productQuantity.WithNewQuantity(last.ProductQuantity.Quantity + productQuantity.Quantity);
                }
            }

            m_outputBuffer.Enqueue(new ZipBuffProduct(productQuantity, m_simLoopEvents.CurrentStep));
        }

        internal void PushProductsToBuffer(ProductQuantity pq)
        {
            m_outputBuffer.Enqueue(new ZipBuffProduct(pq, m_simLoopEvents.CurrentStep));
        }

        private void tryReleaseFirstProduct()
        {
            if (m_outputBuffer.IsEmpty)
            {
                //Log.Error($"Invalid state, m_outputBuffer is empty but quantityInOutputBuffer is {m_quantityInOutputBuffer}");
                m_quantityInOutputBuffer = Quantity.Zero;
                return;
            }
            ZipBuffProduct zipBuffProduct = m_outputBuffer.Peek();
            if (m_simLoopEvents.CurrentStep - zipBuffProduct.EnqueuedAtStep < m_delay)
            {
                return;
            }
            ImmutableArray<IoPortData> connectedOutputPortsCache = m_connectedOutputPortsCache;
            ProductQuantity pq = zipBuffProduct.ProductQuantity;
            int i = 0;
            for (int length = connectedOutputPortsCache.Length; i < length; i++)
            {
                connectedOutputPortsCache[m_lastUsedOutputPortIndex = (m_lastUsedOutputPortIndex + 1) % length].SendAsMuchAs(ref pq);
                if (pq.IsEmpty)
                {
                    m_quantityInOutputBuffer -= zipBuffProduct.ProductQuantity.Quantity;
                    m_outputBuffer.Dequeue();
                    return;
                }
            }
            Assert.That(pq.Quantity).IsLessOrEqual(zipBuffProduct.ProductQuantity.Quantity);
            if (pq.Quantity < zipBuffProduct.ProductQuantity.Quantity)
            {
                m_outputBuffer.GetRefFirst() = new ZipBuffProduct(pq, zipBuffProduct.EnqueuedAtStep);
                m_quantityInOutputBuffer -= zipBuffProduct.ProductQuantity.Quantity - pq.Quantity;
            }
        }

        private void recomputeBufferSizeAndThresholds()
        {
            PartialQuantity zero = PartialQuantity.Zero;
            PartialQuantity zero2 = PartialQuantity.Zero;
            ImmutableArray<IoPort>.Enumerator enumerator = Ports.GetEnumerator();
            while (enumerator.MoveNext())
            {
                IoPort current = enumerator.Current;
                if (current.IsConnected)
                {
                    PartialQuantity maxThroughputPerTick = current.GetMaxThroughputPerTick();
                    if (current.IsConnectedAsInput)
                    {
                        zero += maxThroughputPerTick;
                    }
                    else if (current.IsConnectedAsOutput)
                    {
                        zero2 += maxThroughputPerTick;
                    }
                    else
                    {
                        Log.Error("Port connected but is not input or output.");
                    }
                }
            }
            PartialQuantity partialQuantity = zero.Min(zero2);
            if (partialQuantity.Value <= Fix32.One)
            {
                m_delay = 10.Ticks();
            }
            else if (partialQuantity.Value <= Fix32.Three)
            {
                m_delay = 5.Ticks();
            }
            else
            {
                m_delay = 2.Ticks();
            }
            int num = 3 * m_delay.Ticks / 2;
            m_maxBufferSize = (num * partialQuantity).ToQuantityCeiled();
        }

        //private void createPorts()
        //{
        //    Ports = Prototype.Ports.Map((IoPortTemplate x, int i) => IoPort.CreateFor(base.Context.PortIdFactory.GetNextId(), this, Prototype.Layout, base.Transform, x, i, IoPortType.Any));
        //}
        private void createPorts(IoPortTemplate[] newTemp)
        {
            IEntityWithPorts thisWithPorts = this as IEntityWithPorts;
            if (thisWithPorts != null)
            {
                this.Ports = base.Prototype.Ports.Map<IoPort>((IoPortTemplate x, int i) => IoPort.CreateFor<IEntityWithPorts>(this.Context.PortIdFactory.GetNextId(), thisWithPorts, this.Prototype.Layout, this.Transform, newTemp[i], i, this.PortTypeOverride));
                return;
            }
            this.Ports = ImmutableArray<IoPort>.Empty;
            Assert.That<bool>(this.Ports.IsEmpty).IsTrue(string.Format("{0} ({1}) has '{2}' ports ", base.Prototype, base.GetType().Name, this.Ports.Length) + "but does not implement 'IEntityWithPorts' interface");
        }

        public void SimUpdate()
        {
            if (base.IsNotEnabled || m_connectedOutputPortsCache.IsEmpty)
            {
                return;
            }
            if (m_quantityInOutputBuffer < MaxBufferSize)
            {
                if (currentProduct.IsNotEmpty == true) myColor = m_productColorManager.GetColor(currentProduct.Product.Id, false);
                int i = 0;
                for (int length = m_connectedInputPortsCache.Length; i < length; i++)
                {
                    int index = (m_lastUsedInputPortIndex = (m_lastUsedInputPortIndex + 1) % length);
                    IoPortData ioPortData = m_connectedInputPortsCache[index];
                    if (!m_inputBuffer[ioPortData.PortIndex].IsEmpty)
                    {
                        moveInputToOutBuffer(ioPortData.PortIndex);
                        if (m_quantityInOutputBuffer >= MaxBufferSize)
                        {
                            break;
                        }
                    }
                }
            }
            if (!m_quantityInOutputBuffer.IsNotPositive)
            {
                tryReleaseFirstProduct();
            }
        }
        public new void OnPortConnectionChanged(IoPort ourPort, IoPort otherPort)
        {
            recomputePortInfo();
            if (ourPort.IsNotConnected)
            {
                int portIndex = ourPort.PortIndex;
                if (m_inputBuffer[portIndex].IsNotEmpty)
                {
                    moveInputToOutBuffer(portIndex);
                }
            }
        }
        private void recomputePortInfo()
        {
            m_connectedInputPortsCache = Ports.Filter((IoPort x) => x.IsConnectedAsInput).Map((IoPort x) => new IoPortData(x));
            m_connectedOutputPortsCache = Ports.Filter((IoPort x) => x.IsConnectedAsOutput).Map((IoPort x) => new IoPortData(x));
            recomputeBufferSizeAndThresholds();
        }

        protected override void OnAddedToWorld(EntityAddReason reason)
        {
            if (!Prototype.DoNotStartConstructionAutomatically)
            {
                StartConstructionIfNotStarted();
            }

            string tit = DefaultTitle.Value;
            IoPortTemplate[] newTemplate = null;
            IoPort chkPort = null;
            IoPort ourPort = null;
            bool portfound = false;
            Tile3i position = this.Position3f.Tile3i;
            //long num = long.MaxValue;
            //ImmutableArray<IoPort>.Enumerator enumerator = Ports.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    IoPort current = enumerator.Current;
            //        long num2 = current.Position.DistanceSqrTo(position);
            //        if (num2 < num)
            //        {
            //            num = num2;
            //            chkPort = current;
            //            newTemplate = portTemplates.transPORTshapes.shapeAuto(tit, chkPort.ShapePrototype);
            //            if (newTemplate != null)
            //            {
            //                portfound = true;
            //                ourPort = current;
            //                continue;
            //            }
            //            else { continue; }
            //        }
            //}

            foreach (IoPort pt in Ports)
            {

                chkPort = null;

                int di = pt.Direction.DirectionIndex;

                if (di == 0)
                {
                    Context.IoPortsManager.TryGetPortAt(pt.Position.AddX(1), new Direction903d(3), out chkPort);
                }
                if (di == 1)
                {
                    Context.IoPortsManager.TryGetPortAt(pt.Position.AddY(1), new Direction903d(4), out chkPort);
                }
                if (di == 3)
                {
                    Context.IoPortsManager.TryGetPortAt(pt.Position.AddX(-1), new Direction903d(0), out chkPort);
                }
                if (di == 4)
                {
                    Context.IoPortsManager.TryGetPortAt(pt.Position.AddY(-1), new Direction903d(1), out chkPort);
                }
                if (chkPort != null)
                {
                    newTemplate = portTemplates.transPORTshapes.shapeAuto(tit, chkPort.ShapePrototype);
                    if (newTemplate != null)
                    {
                        portfound = true;
                        ourPort = pt;
                        break;
                    }
                    else { break; }
                }
            }
            if (portfound == true)
            {
                Upgrade(newTemplate);
                MakeFullyConstructed();
                OnPortConnectionChanged(chkPort, ourPort);
                tryReleaseFirstProduct();
            }
            if (this.ConstructionState != ConstructionState.NotInitialized)
                return;
            foreach (IoPort port in this.Ports)
            {
                if (port.ConnectedPort.HasValue && port.ConnectedPort.Value.OwnerEntity.IsConstructed)
                {
                    this.StartConstructionIfNotStarted();
                    break;
                }
            }


        }
        public void Upgrade(IoPortTemplate[] newTemp)
        {
            foreach (IoPort port in this.Ports)
                this.Context.IoPortsManager.DisconnectAndRemove(port);
            this.createPorts(newTemp);
            foreach (IoPort port in this.Ports)
                this.Context.IoPortsManager.AddPortAndTryConnect(port);
        }

        public override bool CanBePaused
        {
            get
            {
                return true;
            }
        }
        protected override void SerializeData(BlobWriter writer)
        {
            base.SerializeData(writer);
            writer.WriteString(m_protoId.Value);
            Duration.Serialize(m_delay, writer);
            writer.WriteArray(m_inputBuffer);
            writer.WriteInt(m_lastUsedInputPortIndex);
            writer.WriteInt(m_lastUsedOutputPortIndex);
            Quantity.Serialize(m_maxBufferSize, writer);
            Queueue<ZipBuffProduct>.Serialize(m_outputBuffer, writer);
            Quantity.Serialize(m_quantityInInputBuffer, writer);
            Quantity.Serialize(m_quantityInOutputBuffer, writer);
            writer.WriteGeneric(m_simLoopEvents);
            TransportsManager.Serialize(m_transportsManager, writer);
            writer.WriteGeneric(m_transportsPredicates);
            ImmutableArray<IoPort>.Serialize(Ports, writer);
            ProductColorManager.Serialize(m_productColorManager, writer);
            //            writer.WriteGeneric(Prototype);

        }

        protected override void DeserializeData(BlobReader reader)
        {
            base.DeserializeData(reader);
            m_protoId = new StaticEntityProto.ID(reader.ReadString());
            m_delay = Duration.Deserialize(reader);
            reader.SetField(this, "m_inputBuffer", reader.ReadArray<ProductQuantity>());
            m_lastUsedInputPortIndex = reader.ReadInt();
            m_lastUsedOutputPortIndex = reader.ReadInt();
            m_maxBufferSize = Quantity.Deserialize(reader);
            reader.SetField(this, "m_outputBuffer", Queueue<ZipBuffProduct>.Deserialize(reader));
            m_quantityInInputBuffer = Quantity.Deserialize(reader);
            m_quantityInOutputBuffer = Quantity.Deserialize(reader);
            reader.SetField(this, "m_simLoopEvents", reader.ReadGenericAs<ISimLoopEvents>());
            reader.SetField(this, "m_transportsManager", TransportsManager.Deserialize(reader));
            reader.SetField(this, "m_transportsPredicates", reader.ReadGenericAs<ITransportsPredicates>());
            Ports = ImmutableArray<IoPort>.Deserialize(reader);
            reader.SetField(this, "m_productColorManager", ProductColorManager.Deserialize(reader));
            reader.RegisterInitAfterLoad(this, "initialize", InitPriority.Normal);
        }
        private static readonly Action<object, BlobReader> s_deserializeDataDelayedAction;
        private static readonly Action<object, BlobWriter> s_serializeDataDelayedAction;
        public static void Serialize(btBalancer value, BlobWriter writer)
        {
            if (writer.TryStartClassSerialization<btBalancer>(value))
            {
                writer.EnqueueDataSerialization(value, s_serializeDataDelayedAction);
            }
        }
        public static btBalancer Deserialize(BlobReader reader)
        {
            btBalancer btbalancer;
            if (reader.TryStartClassDeserialization<btBalancer>(out btbalancer, null))
            {
                reader.EnqueueDataDeserialization(btbalancer, s_deserializeDataDelayedAction, null);
            }
            return btbalancer;
        }

        [InitAfterLoad(InitPriority.Normal)]
        [OnlyForSaveCompatibility(null)]
        private void initialize()
        {
            Prototype = base.Context.ProtosDb.Get<btBalancerProto>(m_protoId).ValueOrThrow("Invalid transPORT proto: " + m_protoId);
            myColor = ColorRgba.Black;
            recomputePortInfo();
        }
        static btBalancer()
        {
            s_serializeDataDelayedAction = delegate (object obj, BlobWriter writer)
            {
                ((btBalancer)obj).SerializeData(writer);
            };
            s_deserializeDataDelayedAction = delegate (object obj, BlobReader reader)
            {
                ((btBalancer)obj).DeserializeData(reader);

            };

        }
    }
    //[GlobalDependency(RegistrationMode.AsEverything, false, false)]
    //public class btBalancerBuildController : IHotReloadUi
    //{
    //    public void DisposeForHotReload()
    //    {
    //        this.m_unlockedProtosDb.OnUnlockedSetChanged.RemoveNonSaveable(this, onProtosChanged);
    //        this.m_context.GameLoopEvents.SyncUpdate.RemoveNonSaveable(this, syncUpdate);
    //    }

    //    public readonly Tile3i Position;
    //    private enum State
    //    {
    //        NoProtoSelected,
    //        SelectingFirstPivot,
    //        SelectingContinuationPivot,
    //        AwaitingTransportCreation
    //    }
    //    private readonly UiContext m_context;
    //    private readonly IInputScheduler m_inputScheduler;
    //    private readonly TerrainCursor m_terrainCursor;
    //    private readonly CursorPickingManager m_picker;
    //    private readonly IoPortsRenderer m_portsRenderer;
    //    private readonly ShortcutsManager m_shortcutsManager;
    //    private readonly UnlockedProtosDb m_unlockedProtosDb;
    //    private readonly ImmutableArray<IoPortShapeProto> m_managedPortShapes;
    //    private readonly Lyst<IoPortShapeProto> m_unlockedPortShapes;
    //    private bool m_unlockedTransportsChanged;
    //    private readonly Toolbox m_toolbox;
    //    private readonly TerrainCursorVisual m_terrainCursorVisual;
    //    public readonly Predicate<IoPort> NonConnectedAndUnlockedPortsPredicate;
    //    private State m_state;
    //    private readonly Cursoor m_cursor;
    //    private Vector3 m_lastMousePos;
    //    private Tile2i m_lastMouseTile;
    //    private HighlightId? m_currentPortsHighlight;
    //    private Predicate<IoPort> m_compatiblePortPredicate;
    //    private Option<IStaticEntity> m_onlyForEntity;
    //    private readonly ToolboxItem m_tieBreakBtn;
    //    private readonly ToolboxItem m_snappingBtn;
    //    private readonly ToolboxItem m_portBlockBtn;
    //    private readonly ToolboxItem m_noTurnBtn;
    //    private Option<TransportProto> m_currTransportProto;
    //    public bool IsActive { get; private set; }
    //    public bool TransportProtoSelected => this.m_currTransportProto != null;
    //    public event Action<Option<TransportProto>> OnProtoSelected;
    //    private Option<BuildTransportCmd> m_ongoingCmd;
    //    private readonly PathFindingTransportPreview m_transportPreview;
    //    private PickResult m_previousPickResult;
    //    private struct PickResult
    //    {
    //        public readonly Tile3i Position;

    //        public readonly Option<TransportProto> TransportProto;

    //        public readonly Direction903d? Direction;

    //        public readonly Direction903d? ForcedDirection;

    //        public readonly bool MustBeFlat;

    //        public PickResult(Tile3i position, Option<TransportProto>? transportProto = null, Direction903d? direction = null, Direction903d? forcedDirection = null, bool mustBeFlat = false)
    //        {
    //            this.Position = position;
    //            this.ForcedDirection = forcedDirection;
    //            this.MustBeFlat = mustBeFlat;
    //            this.TransportProto = transportProto ?? Option<global::Mafi.Core.Factory.Transports.TransportProto>.None;
    //            this.Direction = direction;
    //        }
    //    }


    //    public btBalancerBuildController(ToolbarHud toolbar, UiContext uiContext, NewInstanceOf<TerrainCursor> terrainCursor, CursorPickingManager picker, IoPortsRenderer portsRenderer,
    //                    CursorManager cursorManager, UnlockedProtosDb unlockedProtosDb, TerrainCursorVisual terrainCursorVisual, PathFindingTransportPreview transportPreview)
    //    {
    //        this.m_unlockedPortShapes = new Lyst<IoPortShapeProto>();
    //        this.m_context = uiContext;
    //        this.m_inputScheduler = uiContext.InputScheduler;
    //        this.m_terrainCursor = terrainCursor.Instance;
    //        this.m_picker = picker;
    //        this.m_portsRenderer = portsRenderer;
    //        this.m_shortcutsManager = uiContext.ShortcutsManager;
    //        this.m_unlockedProtosDb = unlockedProtosDb;
    //        this.m_terrainCursorVisual = terrainCursorVisual;
    //        this.m_managedPortShapes = uiContext.ProtosDb.All<IoPortShapeProto>().ToImmutableArray();
    //        this.m_cursor = cursorManager.RegisterCursor(CursorsStyles.Build);
    //        this.m_unlockedTransportsChanged = true;
    //        this.m_transportPreview = transportPreview;
    //        unlockedProtosDb.OnUnlockedSetChanged.AddNonSaveable(this, onProtosChanged);
    //        uiContext.GameLoopEvents.SyncUpdate.AddNonSaveable(this, syncUpdate);

    //    }
    //    private void syncUpdate(GameTime time)
    //    {
    //        if (this.m_unlockedTransportsChanged)
    //        {
    //            this.m_unlockedTransportsChanged = false;
    //            this.m_unlockedPortShapes.Clear();
    //            this.m_unlockedPortShapes.AddRange(from p in this.m_unlockedProtosDb.AllUnlocked<TransportProto>()
    //                                               select p.PortsShape);
    //        }
    //    }
    //    public void Activate(IStaticEntity onlyForEntity = null)
    //    {
    //        Assert.That(this.m_currTransportProto).IsNone();
    //        Assert.That(this.m_currentPortsHighlight).IsNull();
    //        if (this.IsActive)
    //        {
    //            Log.Warning("TransportBuildController is already activated!");
    //            return;
    //        }
    //        this.IsActive = true;
    //        this.resetState(State.NoProtoSelected);
    //        this.m_onlyForEntity = Option.Create(onlyForEntity);
    //        this.m_transportPreview.Activate();
    //        this.m_lastMousePos = Vector3.zero;
    //        this.m_previousPickResult = default(PickResult);
    //        this.m_terrainCursor.Activate();
    //        this.m_terrainCursor.RelativeHeight = ThicknessTilesI.Zero;
    //        Log.Info("Controller active...");
    //    }
    //    public void Deactivate()
    //    {
    //        if (!this.IsActive)
    //        {
    //            Log.Warning("TransportBuildController is already deactivated!");
    //            return;
    //        }
    //        this.IsActive = false;
    //        this.cancelTransport(invokeEvents: false);
    //        this.m_transportPreview.Deactivate();
    //        this.m_terrainCursorVisual.Deactivate();
    //        this.m_terrainCursor.Deactivate();
    //        if (this.m_currentPortsHighlight.HasValue)
    //        {
    //            this.m_portsRenderer.ClearPortsHighlight(this.m_currentPortsHighlight.Value);
    //            this.m_currentPortsHighlight = null;
    //            this.m_compatiblePortPredicate = null;
    //        }
    //        this.m_toolbox.Hide();
    //        this.m_onlyForEntity = Option<IStaticEntity>.None;
    //        Log.Info("Controller inactive...");
    //    }
    //    private void cancelTransport(bool invokeEvents)
    //    {
    //        this.m_terrainCursor.RelativeHeight = ThicknessTilesI.Zero;
    //        this.m_currTransportProto = Option<TransportProto>.None;
    //        if (invokeEvents)
    //        {
    //            this.OnProtoSelected?.Invoke(Option.None);
    //        }
    //        this.resetState(State.NoProtoSelected);
    //        this.m_toolbox.Hide();
    //        this.m_cursor.Hide();
    //    }

    //    private void resetState(State newState)
    //    {
    //        this.m_ongoingCmd = Option<BuildTransportCmd>.None;
    //        if (this.m_currentPortsHighlight.HasValue)
    //        {
    //            this.m_portsRenderer.ClearPortsHighlight(this.m_currentPortsHighlight.Value);
    //            this.m_currentPortsHighlight = null;
    //            this.m_compatiblePortPredicate = null;
    //        }
    //        this.m_picker.ClearPicked();
    //        this.m_terrainCursorVisual.Hide();
    //        this.m_state = newState;
    //    }

    //    private void onProtosChanged()
    //    {
    //        this.m_unlockedTransportsChanged = true;
    //    }


    //}

}
