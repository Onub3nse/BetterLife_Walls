//using Mafi.Core;
//using Mafi.Collections.ImmutableCollections;
//using Mafi.Core.Entities.Static.Layout;
//using Mafi.Core.Entities.Static;
//using Mafi;
//using Mafi.Core.Mods;
//using Mafi.Core.Ports.Io;
//using Mafi.Core.Prototypes;
//using System;
//using Mafi.Core.Factory.Zippers;
//using Mafi.Core.Entities;
//using Mafi.Serialization;
//using Mafi.Core.Ports;
//using Mafi.Collections;
//using Mafi.Core.Simulation;
//using Mafi.Core.Economy;
//using Mafi.Core.Factory.Transports;
//using System.Collections.Generic;
//using static BetterLife.Prototypes.nTransP;
//using Mafi.Unity;
//using Mafi.Unity.Entities;
//using Mafi.Unity.Entities.Static;
//using UnityEngine;
//using Mafi.Core.Products;
//using Mafi.Core.Environment;
//using System.Diagnostics.Eventing.Reader;
//using Mafi.Unity.Ports.Io;
//using Mafi.Core.Factory.Machines;
//using System.Linq;
//using static BetterLife.Prototypes.transTeleport;
//namespace BetterLife.Prototypes
//{
//    //public class BetterAssembly1Mb : StaticEntityMb, IEntityMbWithSyncUpdate, IEntityMb, IDestroyableEntityMb
//    //{
//    //    private GameObject insideGo;
//    //    private Material gameObjectMaterial;
//    //    private Color currentColor = Color.black;
//    //    private AssetsDb m_assetsDb;
//    //    private ProtosDb m_protoDb;
//    //    Option(Proto) thisEntity = ;
//    //    public void SyncUpdate(GameTime time)
//    //    {
//    //        if (time.IsGamePaused) return;

//    //    }
//    //    public void Initialize(AssetsDb assetsDb, ProtosDb protosDb)
//    //    {
//    //        thisEntity = protosDb.Get<Proto>(BetterLIDs.Machines.AssemblyBlt1);

//    //        Initialize((ILayoutEntity)transPEntity);
//    //        thisEntity = transPEntity;
//    //        m_assetsDb = assetsDb;
//    //        m_protoDb = protosDb;
//    //        //Animator component2;
//    //        //if (this.gameObject.TryFindChild("Column", out insideGo) && insideGo.TryGetComponent<Animator>(out component2))
//    //        //if (this.gameObject.TryFindChild("color", out insideGo))
//    //        //{
//    //        //    gameObjectMaterial = insideGo.GetComponent<Renderer>().material;
//    //        //}
//    //        //else
//    //        //{
//    //        //    Log.Debug("Error, fix that, couldn't access gameobject's color material...'");
//    //        //}

//    //    }
//    //}

//    //[GlobalDependency(RegistrationMode.AsSelf, false, false)]
//    //public class BetterAssembly1ProtoModelFactory : IDisposable
//    //{
//    //    private readonly DependencyResolver m_resolver;
//    //    private readonly IoPortModelFactory m_portsFactory;
//    //    private readonly Dict<IProto, GameObjectPool> m_goPools;

//    //    public EntityMb Create(MachineProto mbFactory)
//    //    {
//    //        Assert.That(mbFactory).IsNotNull();
//    //        GameObject gameObject = CreateModelFor(mbFactory);
//    //        BetterAssembly1Mb trMb = gameObject.AddComponent<BetterAssembly1Mb>();
//    //        trMb.Initialize(mbFactory);
//    //        return trMb;
//    //    }

//    //    public BetterAssembly1ProtoModelFactory(DependencyResolver resolver, IoPortModelFactory portsFactory)
//    //    {
//    //        this.m_goPools = new Dict<IProto, GameObjectPool>();
//    //        this.m_resolver = resolver.CheckNotNull<DependencyResolver>();
//    //        this.m_portsFactory = portsFactory.CheckNotNull<IoPortModelFactory>();
//    //    }
//    //    public void Dispose()
//    //    {
//    //        foreach (GameObjectPool gameObjectPool in this.m_goPools.Values)
//    //            gameObjectPool.Dispose();
//    //        this.m_goPools.Clear();
//    //    }
//    //    public GameObject CreateModelFor<TProto>(TProto proto) where TProto : IProto
//    //    {
//    //        GameObjectPool pool = this.getPool((IProto)proto, false);
//    //        return pool == null || pool.IsEmpty ? this.m_resolver.InvokeFactoryHierarchy<GameObject>((object)proto) : pool.GetInstance();
//    //    }
//    //    private GameObjectPool getPool(IProto proto, bool createPool)
//    //    {
//    //        GameObjectPool gameObjectPool;
//    //        if (this.m_goPools.TryGetValue(proto, out gameObjectPool))
//    //        {
//    //            return gameObjectPool;
//    //        }
//    //        if (!createPool)
//    //        {
//    //            return null;
//    //        }
//    //        gameObjectPool = new GameObjectPool(proto.Id.Value, 4, delegate
//    //        {
//    //            throw new InvalidOperationException();
//    //        }, delegate (GameObject x)
//    //        {
//    //        });
//    //        this.m_goPools[proto] = gameObjectPool;
//    //        return gameObjectPool;
//    //    }

//    //}
//    internal class ntransPORT : IModData
//    {
//        public void RegisterData(ProtoRegistrator registrator)
//        {
//            IoPortShapeProto shapeFlat = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.FlatConveyor);
//            IoPortShapeProto shapeLoose = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.LooseMaterialConveyor);
//            IoPortShapeProto shapePipe = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.Pipe);
//            IoPortShapeProto shapeMolten = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.MoltenMetalChannel);
//            IoPortShapeProto shapeShaft = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.Shaft);

//            Proto.Str pf = Proto.CreateStr(BetterLIDs.PortShapes.portFlat, "shapeFlat");
//            Proto.Str pl = Proto.CreateStr(BetterLIDs.PortShapes.portLoose, "shapeLoosse");
//            Proto.Str pp = Proto.CreateStr(BetterLIDs.PortShapes.portPipe, "shapePipe");
//            Proto.Str pm = Proto.CreateStr(BetterLIDs.PortShapes.portMolten, "shapeMolten");
//            Proto.Str ps = Proto.CreateStr(BetterLIDs.PortShapes.portShaft, "shapeSshaft");

//            string[] transPORT10 =
//            {
//                "-6-                        -6-"
//            };
//            string[] transPORT20 =
//            { //"111222333444555666777888999000111222333444555666777888999000"
//                "-6-                                                      -6-"
//            };
//            string[] transPORT100 =
//            { //"111222333444555666777888999000111222333444555666777888999000111222333444555666777888999000111222333444555666777888999000111222333444555666777888999000"
//                "-6-                                                                                                                                                -6-"
//            };
//            string[] transFIX =
//            {
//                            "-1-"
//            };
//            string[] balancer0 =
//            {
//                            "-1-"
//            };
//            string[] balancer1 =
//            {
//                            "-1-"
//            };
//            string[] balancer2 =
//            {
//                            "-2-"
//            };
//            string[] balancer3 =
//            {
//                            "-3-"
//            };
//            string[] balancer4 =
//            {
//                            "-4-"
//            };
//            string[] balancer5 =
//            {
//                            "-5-"
//            };
//            string[] loader1 =
//            {
//                            "-1-   -1-   -1-"
//            };
//            string[] trBar2m =
//            {
//                            "-1--1-"
//            };
//            string[] trBar4m =
//            {
//                            "-1-      -1-"
//            };
//            string[] trBar10m =
//            {
//                            "-1-                        -1-"
//            };

//            CreateProto(registrator, BetterLIDs.transPorts.trans10, "Straight 20m", transPORT10, BLCosts.transPORTs.transPortCosts.transp10m,
//                "Assets/BetterLife/Transports/transport20/transport20.prefab", "Assets/BetterLife/Icons/transport/trans20countable.png",
//                BetterLIDs.ToolBars.TransPORT, 0, 0, 0, true, portTemplates.transPORTshapes.shapeTrans10(shapeFlat), false);
//            CreateProto(registrator, BetterLIDs.transPorts.trans20, "Straight 40m", transPORT20, BLCosts.transPORTs.transPortCosts.transp10m, 
//                "Assets/BetterLife/Transports/transport40/transport40.prefab", "Assets/BetterLife/Icons/transport/trans40countable.png",
//                BetterLIDs.ToolBars.TransPORT, 0, 0, 0, true, portTemplates.transPORTshapes.shapeTrans20(shapeFlat), false);
//            CreateProto(registrator, BetterLIDs.transPorts.trans100, "Straight 100m", transPORT100, BLCosts.transPORTs.transPortCosts.transp10m,
//                "Assets/BetterLife/Transports/bigboy/bigboy.prefab", "Assets/BetterLife/Icons/transport/trans100countable.png",
//                BetterLIDs.ToolBars.TransPORT, 25, 0, 0, true, portTemplates.transPORTshapes.shapeTrans100(shapeFlat), false);

//            CreateProto(registrator, BetterLIDs.transPorts.balancer0, "Balancer 0h", balancer0, BLCosts.transPORTs.balancerCosts.balancer0,
//                "Assets/BetterLife/Transports/balancer0/balancer0.prefab", "Assets/BetterLife/Icons/transport/balancer0.png",
//                BetterLIDs.ToolBars.TransPORT, 0, 0, 0,  true, portTemplates.balancersShapes.shapeBalancer(shapeFlat,0), false);

//            CreateProto(registrator, BetterLIDs.transPorts.balancer1, "Balancer 1h", balancer1, BLCosts.transPORTs.balancerCosts.balancer1,
//                "Assets/BetterLife/Transports/balancer1/balancer1.prefab", "Assets/BetterLife/Icons/transport/balancer1.png",
//                BetterLIDs.ToolBars.TransPORT, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeFlat, 1), false);

//            CreateProto(registrator, BetterLIDs.transPorts.balancer2, "Balancer 2h", balancer2, BLCosts.transPORTs.balancerCosts.balancer2,
//                "Assets/BetterLife/Transports/balancer2/balancer2.prefab", "Assets/BetterLife/Icons/transport/balancer2.png",
//                BetterLIDs.ToolBars.TransPORT, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeFlat, 2), false);

//            CreateProto(registrator, BetterLIDs.transPorts.balancer3, "Balancer 3h", balancer3, BLCosts.transPORTs.balancerCosts.balancer3,
//                "Assets/BetterLife/Transports/balancer3/balancer3.prefab", "Assets/BetterLife/Icons/transport/balancer3.png",
//                BetterLIDs.ToolBars.TransPORT, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeFlat, 3), false);

//            CreateProto(registrator, BetterLIDs.transPorts.balancer4, "Balancer 4h", balancer4, BLCosts.transPORTs.balancerCosts.balancer4,
//                "Assets/BetterLife/Transports/balancer4/balancer4.prefab", "Assets/BetterLife/Icons/transport/balancer3.png",
//                BetterLIDs.ToolBars.TransPORT, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeFlat, 4), false);

//            CreateProto(registrator, BetterLIDs.transPorts.balancer5, "Balancer 5h", balancer5, BLCosts.transPORTs.balancerCosts.balancer5,
//                "Assets/BetterLife/Transports/balancer5/balancer5.prefab", "Assets/BetterLife/Icons/transport/balancer5.png",
//                BetterLIDs.ToolBars.TransPORT, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeFlat, 5), false);

//            CreateProto(registrator, BetterLIDs.transPorts.trloader1, "Loader A", loader1, BLCosts.transPORTs.transBarCosts.Loader1,
//                "Assets/BetterLife/Transports/loader1/loader1.prefab", "Assets/BetterLife/Icons/transport/loader1.png",
//                BetterLIDs.ToolBars.TransPORT, 0, 0, 0, true, portTemplates.transPORTshapes.shapeLoader1(shapeFlat), false);

//            CreateProto(registrator, BetterLIDs.transPorts.transBar2m, "Trans Bar 2m", trBar2m, BLCosts.transPORTs.transBarCosts.bar2m,
//                "Assets/BetterLife/Transports/transportbars/bar2m/transPORTbar2m.prefab", "Assets/BetterLife/Icons/transport/transBar2m.png",
//                BetterLIDs.ToolBars.TransPORT, 0, 0, 0, true, portTemplates.transPORTshapes.shapeTransBar2m(shapeFlat), false);

//            CreateProto(registrator, BetterLIDs.transPorts.transBar4m, "Trans Bar 4m", trBar4m, BLCosts.transPORTs.transBarCosts.bar4m,
//                "Assets/BetterLife/Transports/transportbars/bar4m/transPORTbar4m.prefab", "Assets/BetterLife/Icons/transport/transBar4m.png",
//                BetterLIDs.ToolBars.TransPORT, 0, 0, 0, true, portTemplates.transPORTshapes.shapeTransBar4m(shapeFlat), false);

//            CreateProto(registrator, BetterLIDs.transPorts.transBar10m, "Trans Bar 20m", trBar10m, BLCosts.transPORTs.transBarCosts.bar10m,
//                "Assets/BetterLife/Transports/transportbars/bar10m/transPORTbar10m.prefab", "Assets/BetterLife/Icons/transport/transBar10m.png",
//                BetterLIDs.ToolBars.TransPORT, 0, 0, 0, true, portTemplates.transPORTshapes.shapeTransBar10m(shapeFlat), false);

//        }
//        public void CreateProto(ProtoRegistrator registrato, StaticEntityProto.ID id, string coment, string[] el, EntityCostsTpl ecTpl, string asp, string ico, Proto.ID cat, Fix32 nX, Fix32 nY, Fix32 nZ, bool isRamp, IoPortTemplate[] ports, bool locked)
//        {


//            Predicate<LayoutTile> predicate = null;
//            CustomLayoutToken[] array = new CustomLayoutToken[5];
//            array[0] = new CustomLayoutToken("<0<", delegate (EntityLayoutParams p, int h)
//            {
//                int heightFrom = h - 1;
//                int? maxTerrainHeight3 = new int?(h - 1);
//                Fix32? vehicleHeight2 = new Fix32?(h - 1);
//                int? minTerrainHeight3 = new int?(-5);
//                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.NoRubbleAfterCollapse | LayoutTileConstraint.None, null, minTerrainHeight3, maxTerrainHeight3, vehicleHeight2, null, BetterLIDs.Surfaces.speed1r, false, false, 0);
//            });
//            array[1] = new CustomLayoutToken(">0>", delegate (EntityLayoutParams p, int h)
//            {
//                int heightFrom = h - 1;
//                int? maxTerrainHeight4 = new int?(h - 1);
//                Fix32? vehicleHeight2 = new Fix32?(h - 1);
//                int? minTerrainHeight4 = new int?(-5);
//                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.NoRubbleAfterCollapse | LayoutTileConstraint.None, null, minTerrainHeight4, maxTerrainHeight4, vehicleHeight2, null, BetterLIDs.Surfaces.speed1l, false, false, 0);
//            });
//            array[2] = new CustomLayoutToken("<0>", delegate (EntityLayoutParams p, int h)
//            {
//                int heightFrom = h - 1;
//                int? maxTerrainHeight5 = new int?(h - 1);
//                Fix32? vehicleHeight2 = new Fix32?(h - 1);
//                int? minTerrainHeight5 = new int?(-5);
//                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.NoRubbleAfterCollapse | LayoutTileConstraint.None, null, minTerrainHeight5, maxTerrainHeight5, vehicleHeight2, null, BetterLIDs.Surfaces.speed1n, false, false, 0);
//            });
//            array[3] = new CustomLayoutToken("-0-", delegate (EntityLayoutParams p, int h)
//            {
//                return new LayoutTokenSpec(0, h);
//            });
//            array[4] = new CustomLayoutToken("_-_", delegate (EntityLayoutParams p, int h)
//            {
//                return new LayoutTokenSpec(0, h);
//            });

//            EntityLayoutParams entityLayoutParams = new EntityLayoutParams(predicate, array, false, null, null, null, null, new ThicknessIRange(new ThicknessTilesI(0), new ThicknessTilesI(0)), default(Option<IEnumerable<KeyValuePair<char, int>>>), false);
//            //EntityLayoutParams entityLayoutParams = new EntityLayoutParams(null, null, false, Ids.TerrainTileSurfaces.Metal1, null, null, null, null, default(Option<IEnumerable<KeyValuePair<char, int>>>), false);

//            string[] initLayoutString = el;

//            EntityLayout ltemp = registrato.LayoutParser.ParseLayoutOrThrow(entityLayoutParams, el);



//            if (isRamp == true)
//            {
//                EntityLayout entLayout = new EntityLayout(el.ToString(), ltemp.LayoutTiles, ltemp.TerrainVertices, ports.ToImmutableArray(), entityLayoutParams, ltemp.CollapseVerticesThreshold, null);
//                Proto.Str ps1 = Proto.CreateStr(id, coment);
//                EntityCosts ec1 = ecTpl.MapToEntityCosts(registrato);
//                LayoutEntityProto.Gfx lg1 = new LayoutEntityProto.Gfx(
//                    prefabPath: asp,
//                    prefabOrigin: new RelTile3f(nX, nY, nZ),
//                    customIconPath: ico,
//                    categories: registrato.GetCategoriesProtos(cat),
//                    hideBlockedPortsIcon: false


//                    );

//                registrato.PrototypesDb.Add<transSendProto>(new transSendProto(id, ps1, entLayout, ec1, Electricity.OneKw, true, lg1), locked);
//            }
//            else
//            {
//                Proto.Str ps = Proto.CreateStr(id, coment);
//                EntityCosts ec = ecTpl.MapToEntityCosts(registrato);
//                LayoutEntityProto.Gfx lg = new LayoutEntityProto.Gfx(
//                    prefabPath: asp,
//                    prefabOrigin: new RelTile3f(nX, nY, nZ),
//                    customIconPath: ico,
//                    categories: registrato.GetCategoriesProtos(cat)
//                    );
//                registrato.PrototypesDb.Add<transSendProto>(new transSendProto(id, ps, ltemp, ec, Electricity.OneKw, true, lg), locked);
//            }
//        }

//    }
//    [GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
//    public class TransPMbFactory : IEntityMbFactory<transSend>, IFactory<transSend, EntityMb>
//    {

//        private readonly ProtoModelFactory modelFactory;
//        private readonly AssetsDb m_assetsDb;
//        private readonly ProtosDb m_protoDb;
//        public TransPMbFactory(ProtoModelFactory mFactory, AssetsDb assetsDb, ProtosDb protosDb)
//        {
//            modelFactory = mFactory;
//            m_assetsDb = assetsDb;
//            m_protoDb = protosDb;
//        }

//        public EntityMb Create(transSend transpa)
//        {
//            Assert.That(transpa).IsNotNull();
//            GameObject gameObject = modelFactory.CreateModelFor(transpa.Prototype);
//            TransPMb trMb = gameObject.AddComponent<TransPMb>();
//            trMb.Initialize(transpa);
//            return trMb;
//        }
//    }
//    public class TransPMb : StaticEntityMb, IEntityMbWithSyncUpdate, IEntityMb, IDestroyableEntityMb
//    {
//        private GameObject insideGo;
//        private Material gameObjectMaterial;
//        private Color currentColor = Color.black;
//        private AssetsDb m_assetsDb;
//        private ProtosDb m_protoDb;
//        transSend thisEntity;
//        public void SyncUpdate(GameTime time)
//        {
//            if (time.IsGamePaused) return;
//            try
//            {
//                if (thisEntity.currentProduct != null)
//                {

//                    ProductProto pProto = this.m_protoDb.GetOrThrow<ProductProto>(thisEntity.currentProduct.Id);
//                    String pName = pProto.Strings.Name.ToString();
//                    string pType = pProto.Type.ToString();
//                    Texture pMaterial = gameObjectMaterial.mainTexture;
//                    if (thisEntity.myColor != currentColor)
//                    {
//                        gameObjectMaterial.color = thisEntity.myColor;
//                        currentColor = thisEntity.myColor;
//                        Log.Info("BETTERLIFE: --------------------------> Changing color...");
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                 Log.Debug($"{e.Message}");
//            };

//        }
//        public void Initialize(transSend transPEntity, AssetsDb assetsDb, ProtosDb protosDb)
//        {
//            Initialize((ILayoutEntity)transPEntity);
//            thisEntity = transPEntity;
//            m_assetsDb = assetsDb;
//            m_protoDb = protosDb;
//            //Animator component2;
//            //if (this.gameObject.TryFindChild("Column", out insideGo) && insideGo.TryGetComponent<Animator>(out component2))
//            if (this.gameObject.TryFindChild("color", out insideGo))
//            {
//                gameObjectMaterial = insideGo.GetComponent<Renderer>().material;
//            }
//            else
//            {
//                Log.Debug("Error, fix that, couldn't access gameobject's color material...'");
//            }

//        }
//    }

//    public class nTranspProto : LayoutEntityProto, IProto
//    {

//        public nTranspProto(nTranspProto.ID id, Proto.Str strings, EntityLayout layout, EntityCosts costs, LayoutEntityProto.Gfx graphics)
//        : base(id, strings, layout, costs, graphics)
//        {

//        }
//        public override Type EntityType => typeof(transSend);
//    }

//    [GenerateSerializer(false, null, 0)]
//    public class nTransP: LayoutEntity, IEntityWithPorts, IStaticEntity, IEntityWithPosition, IAreaSelectableEntity, IRenderedEntity, IEntity, IObjectWithTitle, IIsSafeAsHashKey, IEntityWithSimUpdate
//    {
//        public ProductProto currentProduct;
//        public Color myColor = Color.cyan;
//        public static ProductColorManager PColors;
//        public nTranspProto m_proto;
//        private readonly ITransportsPredicates m_transportsPredicates;
//        private readonly ISimLoopEvents m_simLoopEvents;
//        private readonly TransportsManager m_transportsManager;
//        private readonly Queueue<ZipBuffProduct> m_outputBuffer;
//        private Quantity m_quantityInInputBuffer;
//        private Quantity m_quantityInOutputBuffer;
//        private Quantity m_maxBufferSize;
//        private Duration m_delay;
//        private int m_lastUsedInputPortIndex;
//        private int m_lastUsedOutputPortIndex;
//        private readonly EntitiesManager m_entitiesManager;
//        private readonly ProductQuantity[] m_inputBuffer;
//        private ProtosDb m_protosDb;
//        [DoNotSave(0, null)]
//        private ImmutableArray<IoPortData> m_connectedInputPortsCache;
//        [DoNotSave(0, null)]
//        private ImmutableArray<IoPortData> m_connectedOutputPortsCache;
//        private static readonly Action<object, BlobWriter> s_serializeDataDelayedAction;
//        private static readonly Action<object, BlobReader> s_deserializeDataDelayedAction;
//        private StaticEntityProto.ID m_protoId;
////        private ImmutableArray<IoPort> ports;

//        [DoNotSave(0, null)]
//        public new nTranspProto Prototype
//        {
//            get
//            {
//                return m_proto;
//            }
//            protected set
//            {
//                m_proto = value;
//                m_protoId = m_proto.Id;
//                base.Prototype = value;
//            }
//        }

//        public override bool CanBePaused => false;

//        //public ImmutableArray<IoPort> Ports { get => ports; private set => ports = value; }

//        public Quantity TotalQuantityInBuffers
//        {
//            get => this.m_quantityInInputBuffer + this.m_quantityInOutputBuffer;
//        }

//        public Quantity MaxBufferSize
//        {
//            get => this.m_maxBufferSize + this.m_connectedInputPortsCache.Length.Quantity();
//        }

//        public int OutputPortsConnected => this.m_connectedOutputPortsCache.Length;

//        public nTransP(EntityId id, nTranspProto proto, TileTransform transform, EntityContext context, ITransportsPredicates transportsPredicates, ISimLoopEvents simLoopEvents,
//          TransportsManager transportsManager, ProductColorManager pcm, ProtosDb protosDb, EntitiesManager entitiesManager) : base(id,proto,transform,context)
//        {
//            PColors = pcm;
//            PColors.Init();
//            currentProduct = base.Context.ProtosDb.GetOrThrow<ProductProto>(IdsCore.Products.ConcreteSlab);
//            m_outputBuffer = new Queueue<ZipBuffProduct>();
//            Prototype = proto.CheckNotNull();
//            m_transportsPredicates = transportsPredicates;
//            m_simLoopEvents = simLoopEvents;
//            m_entitiesManager = entitiesManager;
//            this.m_transportsManager = transportsManager;
//            m_protosDb = protosDb;
//            this.createPorts();
//            m_inputBuffer = new ProductQuantity[this.Ports.Length];
//            for (int index = 0; index < this.m_inputBuffer.Length; ++index)
//                this.m_inputBuffer[index] = ProductQuantity.None;
//            this.recomputePortInfo();
//        }

//        [InitAfterLoad(InitPriority.Normal)]
//        private void initialize()
//        {
//            this.recomputePortInfo();
//            PColors.Init();
//            currentProduct = base.Context.ProtosDb.GetOrThrow<ProductProto>(IdsCore.Products.ConcreteSlab);
//            myColor = Color.cyan;
//        }

//        private void createPorts()
//        {
//            this.Ports = this.Prototype.Ports.Map<IoPort>((Func<IoPortTemplate, int, IoPort>)((x, i) => IoPort.CreateFor<nTransP>(this.Context.PortIdFactory.GetNextId(), this, this.Prototype.Layout, this.Transform, x, i, new IoPortType?(IoPortType.Any))));
//        }

//        protected override void OnUpgradeDone(IEntityProto oldProto, IEntityProto newProto)
//        {
//            base.OnUpgradeDone(oldProto, newProto);
//            foreach (IoPort port in this.Ports)
//                this.Context.IoPortsManager.DisconnectAndRemove(port);
//            this.createPorts();
//            foreach (IoPort port in this.Ports)
//                this.Context.IoPortsManager.AddPortAndTryConnect(port);
//        }

//        protected override void OnAddedToWorld(EntityAddReason reason)
//        {
//            base.OnAddedToWorld(reason);
//            string tit = DefaultTitle.Value;
//            IoPortTemplate[] newTemplate = null;
//            IoPort chkPort = null;
//            IoPort ourPort = null;
//            bool portfound = false;

//            foreach (IoPort pt in Ports)
//            {

//                chkPort = null;

//                int di = pt.Direction.DirectionIndex;

//                if (di == 0)
//                {
//                    Context.IoPortsManager.TryGetPortAt(pt.Position.AddX(1), new Direction903d(3), out chkPort);
//                }
//                if (di == 1)
//                {
//                    Context.IoPortsManager.TryGetPortAt(pt.Position.AddY(1), new Direction903d(4), out chkPort);
//                }
//                if (di == 3)
//                {
//                    Context.IoPortsManager.TryGetPortAt(pt.Position.AddX(-1), new Direction903d(0), out chkPort);
//                }
//                if (di == 4)
//                {
//                    Context.IoPortsManager.TryGetPortAt(pt.Position.AddY(-1), new Direction903d(1), out chkPort);
//                }
//                if (chkPort != null)
//                {
//                    newTemplate = portTemplates.transPORTshapes.shapeAuto(tit, chkPort.ShapePrototype);
//                    if (newTemplate != null)
//                    {
//                        portfound = true;
//                        ourPort = pt;
//                        break;
//                    } else { break; }
//                }
//            }
//            if (portfound == true)
//            {
//                Upgrade(newTemplate);
//                MakeFullyConstructed();
//                OnPortConnectionChanged(chkPort, ourPort);
//                recomputePortInfo();
//                tryReleaseFirstProduct();
//                int entities = m_protosDb.All<nTranspProto>().Count();
//                Log.Info($"{entities} transPorts in world...");
//            }
//            if (this.ConstructionState != ConstructionState.NotInitialized)
//                return;
//            foreach (IoPort port in this.Ports)
//            {
//                if (port.ConnectedPort.HasValue && port.ConnectedPort.Value.OwnerEntity.IsConstructed)
//                {
//                    this.StartConstructionIfNotStarted();
//                    break;
//                }
//            }
//        }
//        private void createPorts(IoPortTemplate[] newTemp)
//        {
//            IEntityWithPorts thisWithPorts = this as IEntityWithPorts;
//            if (thisWithPorts != null)
//            {
//                this.Ports = base.Prototype.Ports.Map<IoPort>((IoPortTemplate x, int i) => IoPort.CreateFor<IEntityWithPorts>(this.Context.PortIdFactory.GetNextId(), thisWithPorts, this.Prototype.Layout, this.Transform, newTemp[i], i, this.PortTypeOverride));
//                return;
//            }
//            this.Ports = ImmutableArray<IoPort>.Empty;
//            Assert.That<bool>(this.Ports.IsEmpty).IsTrue(string.Format("{0} ({1}) has '{2}' ports ", base.Prototype, base.GetType().Name, this.Ports.Length) + "but does not implement 'IEntityWithPorts' interface");
//        }

//        public void Upgrade(IoPortTemplate[] newTemp)
//        {
//            foreach (IoPort port in this.Ports)
//                this.Context.IoPortsManager.DisconnectAndRemove(port);
//            this.createPorts(newTemp);
//            foreach (IoPort port in this.Ports)
//                this.Context.IoPortsManager.AddPortAndTryConnect(port);
//        }

//        public new void OnPortConnectionChanged(IoPort ourPort, IoPort otherPort)
//        {
//            this.recomputePortInfo();
//            if (!ourPort.IsNotConnected)
//                return;
//            int portIndex = (int)ourPort.PortIndex;
//            if (!this.m_inputBuffer[portIndex].IsNotEmpty)
//                return;
//            this.moveInputToOutBuffer(portIndex);
//        }

//        private void recomputePortInfo()
//        {
//            ImmutableArray<IoPort> immutableArray = this.Ports;
//            immutableArray = immutableArray.Filter((Predicate<IoPort>)(x => x.IsConnectedAsInput));
//            this.m_connectedInputPortsCache = immutableArray.Map<IoPortData>((Func<IoPort, IoPortData>)(x => new IoPortData(x)));
//            immutableArray = this.Ports;
//            immutableArray = immutableArray.Filter((Predicate<IoPort>)(x => x.IsConnectedAsOutput));
//            this.m_connectedOutputPortsCache = immutableArray.Map<IoPortData>((Func<IoPort, IoPortData>)(x => new IoPortData(x)));
//            this.recomputeBufferSizeAndThresholds();
//        }

//        public void SimUpdate()
//        {
//            if (this.IsNotEnabled || this.m_connectedOutputPortsCache.IsEmpty)
//                return;
//            if (this.m_quantityInOutputBuffer < this.MaxBufferSize)
//            {
//                int num = 0;
//                for (int length = this.m_connectedInputPortsCache.Length; num < length; ++num)
//                {
//                    int index = (this.m_lastUsedInputPortIndex + 1) % length;
//                    this.m_lastUsedInputPortIndex = index;
//                    IoPortData ioPortData = this.m_connectedInputPortsCache[index];
//                    if (!this.m_inputBuffer[(int)ioPortData.PortIndex].IsEmpty)
//                    {
//                        this.moveInputToOutBuffer((int)ioPortData.PortIndex);
//                        if (this.m_quantityInOutputBuffer >= this.MaxBufferSize)
//                            break;
//                    }
//                }
//            }
//            if (this.m_quantityInOutputBuffer.IsNotPositive)
//                return;
//            this.tryReleaseFirstProduct();
//        }

//        Quantity IEntityWithPorts.ReceiveAsMuchAsFromPort(ProductQuantity pq, IoPortToken sourcePort)
//        {
//            if (this.IsNotEnabled)
//            {
//                if (this.ConstructionState == ConstructionState.NotInitialized)
//                {
//                    Log.Warning("Mini-zipper was not constructed when it received products.");
//                    this.StartConstructionIfNotStarted();
//                    Assert.That<ConstructionState>(this.ConstructionState).IsNotEqualTo<ConstructionState>(ConstructionState.NotInitialized);
//                }
//                return pq.Quantity;
//            }
//            if (this.m_inputBuffer[(int)sourcePort.PortIndex].IsNotEmpty)
//                return pq.Quantity;
//            this.m_inputBuffer[(int)sourcePort.PortIndex] = pq;
//            this.m_quantityInInputBuffer += pq.Quantity;
//            return Quantity.Zero;
//        }

//private void moveInputToOutBuffer(int index)
//{
//    ProductQuantity productQuantity = this.m_inputBuffer[index];
//    this.m_quantityInInputBuffer -= productQuantity.Quantity;
//    this.m_quantityInOutputBuffer += productQuantity.Quantity;
//    this.m_inputBuffer[index] = ProductQuantity.None;
//    if (this.m_outputBuffer.IsNotEmpty)
//    {
//        ZipBuffProduct last = this.m_outputBuffer.Last;
//        if (last.EnqueuedAtStep == this.m_simLoopEvents.CurrentStep && (Proto)last.ProductQuantity.Product == (Proto)productQuantity.Product)
//        {
//            this.m_outputBuffer.PopLast();
//            productQuantity = productQuantity.WithNewQuantity(last.ProductQuantity.Quantity + productQuantity.Quantity);
//        }
//    }
//    this.m_outputBuffer.Enqueue(new ZipBuffProduct(productQuantity, this.m_simLoopEvents.CurrentStep));
//}

//        internal void PushProductsToBuffer(ProductQuantity pq)
//        {
//            this.m_outputBuffer.Enqueue(new ZipBuffProduct(pq, this.m_simLoopEvents.CurrentStep));
//        }

//        private void tryReleaseFirstProduct()
//        {
//            if (this.m_outputBuffer.IsEmpty)
//            {
//                Log.Error(string.Format("Invalid state, m_outputBuffer is empty but quantityInOutputBuffer is {0}", (object)this.m_quantityInOutputBuffer));
//                m_quantityInOutputBuffer = Quantity.Zero;
//            }
//            else
//            {
//                ZipBuffProduct zipBuffProduct = this.m_outputBuffer.Peek();
//                if (this.m_simLoopEvents.CurrentStep - zipBuffProduct.EnqueuedAtStep < this.m_delay)
//                    return;
//                ImmutableArray<IoPortData> outputPortsCache = this.m_connectedOutputPortsCache;
//                ProductQuantity productQuantity = zipBuffProduct.ProductQuantity;

//                currentProduct = productQuantity.Product;

//                try
//                {
//                    if (PColors != null)
//                        myColor = PColors.GetColor(productQuantity.Product.Id, true);
//                }
//                catch (Exception ex) { Log.Info($"Message: {ex.Message}"); }

//                int num = 0;
//                for (int length = outputPortsCache.Length; num < length; ++num)
//                {
//                    int index = (this.m_lastUsedOutputPortIndex + 1) % length;
//                    this.m_lastUsedOutputPortIndex = index;
//                    outputPortsCache[index].SendAsMuchAs(ref productQuantity);
//                    if (productQuantity.IsEmpty)
//                    {
//                        this.m_quantityInOutputBuffer -= zipBuffProduct.ProductQuantity.Quantity;
//                        this.m_outputBuffer.Dequeue();
//                        return;
//                    }
//                }
//                Assert.That<Quantity>(productQuantity.Quantity).IsLessOrEqual(zipBuffProduct.ProductQuantity.Quantity);
//                if (!(productQuantity.Quantity < zipBuffProduct.ProductQuantity.Quantity))
//                {
//                    myColor = PColors.GetColor(productQuantity.Product.Id, false);
//                    return;
//                }

//                this.m_outputBuffer.GetRefFirst() = new ZipBuffProduct(productQuantity, zipBuffProduct.EnqueuedAtStep);
//                this.m_quantityInOutputBuffer -= zipBuffProduct.ProductQuantity.Quantity - productQuantity.Quantity;
//            }
//        }

//        private void recomputeBufferSizeAndThresholds()
//        {
//            PartialQuantity zero1 = PartialQuantity.Zero;
//            PartialQuantity zero2 = PartialQuantity.Zero;
//            foreach (IoPort port in this.Ports)
//            {
//                if (port.IsConnected)
//                {
//                    PartialQuantity throughputPerTick = port.GetMaxThroughputPerTick();
//                    if (port.IsConnectedAsInput)
//                        zero1 += throughputPerTick;
//                    else if (port.IsConnectedAsOutput)
//                        zero2 += throughputPerTick;
//                    else
//                        Log.Error("Port connected but is not input or output.");
//                }
//            }
//            PartialQuantity partialQuantity = zero1.Min(zero2);
//            this.m_delay = !(partialQuantity.Value <= Fix32.One) ? (!(partialQuantity.Value <= Fix32.Three) ? 2.Ticks() : 5.Ticks()) : 10.Ticks();
//            this.m_maxBufferSize = (3 * this.m_delay.Ticks / 2 * partialQuantity).ToQuantityCeiled();
//        }

//        public void GetAllBufferedProducts(Lyst<ProductQuantity> aggregated)
//        {
//            foreach (ProductQuantity pq in this.m_inputBuffer)
//            {
//                if (pq.IsNotEmpty)
//                    aggregate(pq);
//            }
//            foreach (ZipBuffProduct zipBuffProduct in this.m_outputBuffer)
//                aggregate(zipBuffProduct.ProductQuantity);

//            void aggregate(ProductQuantity pq)
//            {
//                for (int index = 0; index < aggregated.Count; ++index)
//                {
//                    if ((Proto)aggregated[index].Product == (Proto)pq.Product)
//                    {
//                        aggregated[index] += pq.Quantity;
//                        return;
//                    }
//                }
//                aggregated.Add(pq);
//            }
//        }

//        public Upoints GetQuickRemoveCost(out bool canAfford)
//        {
//            canAfford = false;
//            Quantity zero = Quantity.Zero;
//            for (int index = 0; index < this.m_inputBuffer.Length; ++index)
//                zero += this.m_inputBuffer[index].Quantity;
//            foreach (ZipBuffProduct zipBuffProduct in this.m_outputBuffer)
//                zero += zipBuffProduct.ProductQuantity.Quantity;
//            Upoints unity = QuickDeliverCostHelper.QuantityToUnityCost(zero.Value, this.Context.UpointsManager.QuickActionCostMultiplier) ?? Upoints.Zero;
//            canAfford = this.Context.UpointsManager.CanConsume(unity);
//            return unity;
//        }

//        public void QuickRemoveAllProducts()
//        {
//            bool canAfford;
//            Upoints quickRemoveCost = this.GetQuickRemoveCost(out canAfford);
//            if (quickRemoveCost.IsNotPositive || !canAfford)
//                return;
//            this.Context.UpointsManager.ConsumeExactly(IdsCore.UpointsCategories.QuickRemove, quickRemoveCost);
//            this.clearAllProducts();
//        }

//        private void clearAllProducts()
//        {
//            IAssetTransactionManager transactionManager = this.Context.AssetTransactionManager;
//            for (int index = 0; index < this.m_inputBuffer.Length; ++index)
//            {
//                transactionManager.StoreClearedProduct(this.m_inputBuffer[index]);
//                this.m_inputBuffer[index] = ProductQuantity.None;
//            }
//            foreach (ZipBuffProduct zipBuffProduct in this.m_outputBuffer)
//            {
//                if (zipBuffProduct.ProductQuantity.IsNotEmpty)
//                    transactionManager.StoreClearedProduct(zipBuffProduct.ProductQuantity);
//            }
//            this.m_outputBuffer.Clear();
//        }

//        protected override void OnDestroy()
//        {
//            this.clearAllProducts();
//            base.OnDestroy();
//        }

//        public static void Serialize(nTransP value, BlobWriter writer)
//        {
//            if (!writer.TryStartClassSerialization<nTransP>(value))
//                return;
//            writer.EnqueueDataSerialization((object)value, nTransP.s_serializeDataDelayedAction);
//        }

//        protected override void SerializeData(BlobWriter writer)
//        {
//            base.SerializeData(writer);

//            writer.WriteString(m_protoId.Value);

//            ColorRgba.Serialize(new ColorRgba(myColor.r, myColor.g, myColor.b, myColor.a), writer);

//            Duration.Serialize(this.m_delay, writer);
//            writer.WriteArray<ProductQuantity>(this.m_inputBuffer);
//            writer.WriteInt(this.m_lastUsedInputPortIndex);
//            writer.WriteInt(this.m_lastUsedOutputPortIndex);
//            Quantity.Serialize(this.m_maxBufferSize, writer);
//            Queueue<ZipBuffProduct>.Serialize(this.m_outputBuffer, writer);
//            Quantity.Serialize(this.m_quantityInInputBuffer, writer);
//            Quantity.Serialize(this.m_quantityInOutputBuffer, writer);
//            writer.WriteGeneric<ISimLoopEvents>(this.m_simLoopEvents);
//            TransportsManager.Serialize(this.m_transportsManager, writer);
//            writer.WriteGeneric<ITransportsPredicates>(this.m_transportsPredicates);
//            ImmutableArray<IoPort>.Serialize(this.Ports, writer);
//            writer.WriteGeneric(Prototype);
//        }

//        public static nTransP Deserialize(BlobReader reader)
//        {
//            nTransP miniZipper;
//            if (reader.TryStartClassDeserialization<nTransP>(out miniZipper))
//                reader.EnqueueDataDeserialization((object)miniZipper, nTransP.s_deserializeDataDelayedAction);
//            return miniZipper;
//        }

//        protected override void DeserializeData(BlobReader reader)
//        {
//            base.DeserializeData(reader);

//            m_protoId = new StaticEntityProto.ID(reader.ReadString());
//            ColorRgba mcolor = ColorRgba.Deserialize(reader);
//            this.myColor = mcolor.ToColor32();
//            this.m_delay = Duration.Deserialize(reader);
//            reader.SetField<nTransP>(this, "m_inputBuffer", (object)reader.ReadArray<ProductQuantity>());
//            this.m_lastUsedInputPortIndex = reader.ReadInt();
//            this.m_lastUsedOutputPortIndex = reader.ReadInt();
//            this.m_maxBufferSize = Quantity.Deserialize(reader);
//            reader.SetField<nTransP>(this, "m_outputBuffer", (object)Queueue<ZipBuffProduct>.Deserialize(reader));
//            this.m_quantityInInputBuffer = Quantity.Deserialize(reader);
//            this.m_quantityInOutputBuffer = Quantity.Deserialize(reader);
//            reader.SetField<nTransP>(this, "m_simLoopEvents", (object)reader.ReadGenericAs<ISimLoopEvents>());
//            reader.SetField<nTransP>(this, "m_transportsManager", (object)TransportsManager.Deserialize(reader));
//            reader.SetField<nTransP>(this, "m_transportsPredicates", (object)reader.ReadGenericAs<ITransportsPredicates>());
//            this.Ports = ImmutableArray<IoPort>.Deserialize(reader);
//            reader.SetField(this, "Prototype", reader.ReadGenericAs<nTranspProto>());
//            reader.RegisterInitAfterLoad(this, nameof(initContexts), InitPriority.High);
//        }
//        private void initContexts(int saveVersion, DependencyResolver resolver)
//        {
//            Log.Info($"Initialize context after load");
//            Prototype = Context.ProtosDb.Get<nTranspProto>(m_protoId).ValueOrThrow("Invalid transport proto: " + m_protoId);
//            recomputePortInfo();
//            //resolver.Resolve<MbBasedEntitiesRenderer>();
//        }

//        static nTransP()
//        {
//            //nTransP.s_serializeDataDelayedAction = (Action<object, BlobWriter>)((obj, writer) => ((Entity)obj).SerializeData(writer));
//            //nTransP.s_deserializeDataDelayedAction = (Action<object, BlobReader>)((obj, reader) => ((Entity)obj).DeserializeData(reader));
//            nTransP.s_serializeDataDelayedAction = delegate (object obj, BlobWriter writer)
//            {
//                ((nTransP)obj).SerializeData(writer);
//            };
//            nTransP.s_deserializeDataDelayedAction = delegate (object obj, BlobReader reader)
//            {
//                ((nTransP)obj).DeserializeData(reader);
//            };

//        }
//    }

//}