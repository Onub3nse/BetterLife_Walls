
using BetterLife.RoadsAndSigns;
using Mafi;
using Mafi.Base;
using Mafi.Collections;
using Mafi.Core;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Factory.Transports;
using Mafi.Core.Mods;
using Mafi.Core.Notifications;
using Mafi.Core.Products;
using Mafi.Core.Prototypes;
using Mafi.Core.Syncers;
using Mafi.Core.Terrain;
using Mafi.Localization;
using Mafi.Serialization;
using Mafi.Unity;
using Mafi.Unity.Entities;
using Mafi.Unity.Entities.Static;
using Mafi.Unity.InputControl;
using Mafi.Unity.Ui;
using Mafi.Unity.Ui.Library.Inspectors;
using Mafi.Unity.UiStatic.Inspectors.Vehicles;
using Mafi.Unity.UiToolkit.Component;
using Mafi.Unity.UiToolkit.Library;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;
using static BetterLife.Prototypes.Buildings.autoSign;
using Color = UnityEngine.Color;


namespace BetterLife.Prototypes.Buildings
{

    internal class CustomBuildings : IModData
    {
        public static EntityCostsTpl.Builder Build => new EntityCostsTpl.Builder();

        public void RegisterData(ProtoRegistrator registrator)
        {
            string[] autoSignLayout =
            {
                "_1=",
            };
            Predicate<LayoutTile> predicate = null;
            CustomLayoutToken[] array = new CustomLayoutToken[1];
            array[0] = new CustomLayoutToken("_0=", delegate (EntityLayoutParams param, int height)
            {
                return new LayoutTokenSpec(0, height, LayoutTileConstraint.None | LayoutTileConstraint.NoRubbleAfterCollapse, null, null, null);
            });

            EntityLayoutParams entityLayoutParams = new EntityLayoutParams(predicate, array, false, null, null, null, null, null, null, default);



            EntityCostsTpl costs = Build.CP(5);


            EntityLayout ltemp = registrator.LayoutParser.ParseLayoutOrThrow(entityLayoutParams, autoSignLayout);


            Proto.Str ps = Proto.CreateStr(BetterLIDs.Signs.Sign_Display, "Auto Sign", "First nearby transPORT product will be displayed on this sign.");
            EntityCosts ec = costs.MapToEntityCosts(registrator);

            LayoutEntityProto.Gfx lg = new LayoutEntityProto.Gfx
                (
                    prefabPath: "Assets/BetterLife/Signs/autoSign.prefab",
                    useInstancedRendering: false,
                    useSemiInstancedRendering: false,
                    customIconPath: "Assets/BetterLife/Icons/Signs/autoSign.png",
                    prefabOrigin: new RelTile3f(0, 0, 1.ToFix32()),
                    categories: registrator.GetCategoriesProtos(BetterLIDs.ToolBars.Signs)

                );
            registrator.PrototypesDb.Add<autoSignPrototype>(new autoSignPrototype(BetterLIDs.Signs.Sign_Display, ps, ltemp, ec, lg));
        }

    }

    [GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
    public class autoSignMbFactory :
        IEntityMbFactory<autoSign>,
        IFactory<autoSign, EntityMb>
    {
        private readonly TerrainOccupancyManager m_terrainOccupancyManager;
        private readonly TerrainManager m_TerrainManager;
        private readonly EntitiesManager m_EntitiesManager;
        private readonly ProductsSlimIdManager m_productsSlimManager;
        private readonly ProtoModelFactory modelFactory;
        public autoSignMbFactory(ProtoModelFactory mFactory, TerrainOccupancyManager terrainOccupancyManager, TerrainManager terrainManager,
                EntitiesManager entitiesManager, ProductsSlimIdManager productsSlimIdManager)
        {
            modelFactory = mFactory;
            m_TerrainManager = terrainManager;
            m_terrainOccupancyManager = terrainOccupancyManager;
            m_EntitiesManager = entitiesManager;
            m_productsSlimManager = productsSlimIdManager;
        }

        public EntityMb Create(autoSign transp)
        {
            autoSignMb transpMb = modelFactory.CreateModelFor<autoSignPrototype>(transp.Prototype).AddComponent<autoSignMb>();
            transpMb.Initialize(transp, m_terrainOccupancyManager, m_TerrainManager, m_EntitiesManager, m_productsSlimManager);
            return (EntityMb)transpMb;
        }
    }
    public class autoSignMb : StaticEntityMb, IEntityMbWithSyncUpdate, IEntityMb, IDestroyableEntityMb
    {
        private GameObject insideGo;
        private Option<TextMeshPro> m_signTextMeshA;
        private Option<TextMeshPro> m_signTextMeshB;
        autoSign thisEntity;
        private Color currentColor = Color.black;
        private bool txtFrontFound = false;
        private bool txtBackFound = false;
        private TerrainOccupancyManager m_terrainOccupancyManager;
        private TerrainManager m_terrainManager;
        private EntitiesManager m_entitiesManager;
        private ProductsSlimIdManager m_productsSlimIdManager;
        private readonly Lyst<IStaticEntity> m_entityCache = [];
        private IEnumerable<blZipper> m_foundEntities = [];
        private IEnumerable<StaticEntity> m_foundTransports = [];
        private Tile2f startPosition;

        private int everyFrames = 0;

        public void SyncUpdate(GameTime time)
        {
            if (txtFrontFound == true && txtBackFound == true)
            {
                if (everyFrames < 25)
                {
                    everyFrames += 1;
                    return;
                }
                everyFrames = 0;

                startPosition = thisEntity.CenterTile.Tile2i.CenterTile2f;

                m_foundEntities = m_entitiesManager.GetAllEntitiesOfType<blZipper>();

                if (m_foundEntities.Count() == 0) return;

                Transport currentTransport = null;
                Fix64 minDistance = Fix64.MaxValue; // Track the smallest distance
                blZipper closestZipper = null;
                Transport closestTransport = null;   // Track the closest transport
                if (m_foundEntities != null)
                {
                    foreach (blZipper entity in m_foundEntities)
                    {
                        Fix32 relativeX = (startPosition.X - entity.Position2f.X);
                        Fix32 relativeY = (startPosition.Y - entity.Position2f.Y);
                        Fix64 distancesqr = startPosition.DistanceSqrTo(entity.Position2f);
                        if (distancesqr < minDistance)
                        {
                            minDistance = distancesqr;
                            closestZipper = entity;
                        }
                    }
                }
                if (minDistance <= 16)
                {
                    if (closestZipper != null)
                    {
                        if (closestZipper.currentProduct.IsNotEmpty == true)
                        {
                            string txt = closestZipper.currentProduct.Product.Strings.Name.ToString();
                            TextInfo txtInfo = CultureInfo.CurrentCulture.TextInfo;
                            m_signTextMeshA.Value.text = txtInfo.ToTitleCase(txt.ToLower());
                            m_signTextMeshB.Value.text = txtInfo.ToTitleCase(txt.ToLower());
                            thisEntity.m_targetEntityZipper = closestZipper;

                            return;
                        }
                        else
                        {
                            m_signTextMeshA.Value.text = "Waiting for products.";
                            m_signTextMeshB.Value.text = "Waiting for products.";
                            return;
                        }
                    }
                }
                else
                {
                    m_signTextMeshA.Value.text = "COI - Not in range!";
                    m_signTextMeshB.Value.text = $"Min Dist. {minDistance}";
                }

                m_foundTransports = m_entitiesManager.GetAllEntitiesOfType<Transport>();

                if (m_foundTransports.Count() == 0) return;

                minDistance = Fix64.MaxValue;
                closestTransport = null;   // Track the closest transport

                foreach (Transport entity in m_foundTransports)
                {

                    Fix64 relativeX = (startPosition.X.ToFix64() - entity.Position2f.X);
                    Fix64 relativeY = (startPosition.Y.ToFix64() - entity.Position2f.Y);
                    Fix64 distancesqr = startPosition.DistanceSqrTo(entity.Position2f);
                    //Log.Info($"distance transport sqr {distancesqr}");

                    if (distancesqr < minDistance)
                    {

                        minDistance = distancesqr;
                        closestTransport = entity;
                    }
                }
                currentTransport = closestTransport;

                if (minDistance <= 16 && currentTransport != null)
                {
                    TransportedProductMutable productMutable = currentTransport.TransportedProducts.First();
                    ProductProto key = m_productsSlimIdManager.ResolveOrPhantom(productMutable.SlimId);

                    String Txt = key.Strings.Name.ToString();
                    TextInfo txtInfo = CultureInfo.CurrentCulture.TextInfo;

                    m_signTextMeshA.Value.text = txtInfo.ToTitleCase(Txt.ToLower());
                    m_signTextMeshB.Value.text = txtInfo.ToTitleCase(Txt.ToLower());

                    thisEntity.m_targetTransPort = currentTransport.Position3f;
                    thisEntity.m_targetTransportEntity = currentTransport;
                }
                else
                {
                    m_signTextMeshA.Value.text = "COI - Not in range!";
                    m_signTextMeshB.Value.text = $"Min Dist. {minDistance}";
                    thisEntity.m_targetTransPort = new Tile3f(startPosition.X, startPosition.Y, thisEntity.Position3f.Z);

                }
            }

        }
        public void Initialize(autoSign aSign, TerrainOccupancyManager terrainOccupancyManager, TerrainManager terrainManager,
                EntitiesManager entitiesManager, ProductsSlimIdManager productsSlimIdManager)
        {
            this.Initialize((ILayoutEntity)aSign);
            thisEntity = aSign;
            //Animator component2;
            //if (this.gameObject.TryFindChild("logoani", out insideGo) && insideGo.TryGetComponent<Animator>(out component2))

            m_terrainOccupancyManager = terrainOccupancyManager;
            m_terrainManager = terrainManager;
            m_entitiesManager = entitiesManager;
            m_productsSlimIdManager = productsSlimIdManager;
            if (this.gameObject.TryFindChild("txtFront", out insideGo))
            {
                if (insideGo.TryGetComponent<TextMeshPro>(out var component))
                {
                    m_signTextMeshA = insideGo.GetComponent<TextMeshPro>();
                    txtFrontFound = true;
                }
            }
            else
            {
                Log.Info("Error, fix that, couldn't access gameobject...");
            }

            if (this.gameObject.TryFindChild("txtBack", out insideGo))
            {
                if (insideGo.TryGetComponent<TextMeshPro>(out var component))
                {
                    m_signTextMeshB = insideGo.GetComponent<TextMeshPro>();
                    txtBackFound = true;
                }
            }
            else
            {
                Log.Info("Error, fix that, couldn't access gameobject...");
            }

        }
        static autoSignMb()
        {

        }
    }

    [GenerateSerializer(false, null, 0)]
    public class autoSign : LayoutEntity, IEntity, ILayoutEntity

    {
        private autoSignPrototype _proto;
        public IEntitiesManager EntitiesManager { get; private set; }
        public INotificationsManager NotificationsManager { get; private set; }

        public blZipper m_targetEntityZipper { get; set; }

        public Tile3f m_targetTransPort { get; set; }
        public Transport m_targetTransportEntity { get; set; }

        public AssetsDb AssetsDb { get; set; }
        public autoSign(EntityId id, autoSignPrototype proto, TileTransform transform, EntityContext context,
                            IEntitiesManager entitiesManager, INotificationsManager notificationsManager, AssetsDb assetsDb)
            : base(id, proto, transform, context)
        {
            _proto = proto;
            EntitiesManager = entitiesManager;
            NotificationsManager = notificationsManager;
            m_targetEntityZipper = null;
            m_targetTransPort = new Tile3f();
            m_targetTransportEntity = null;
            AssetsDb = assetsDb;




        }
        public class autoSignPrototype : LayoutEntityProto, IProto
        {


            public autoSignPrototype(ID id, Str strings, EntityLayout layout, EntityCosts costs, Gfx graphics)
                 : base(id, strings, layout, costs, graphics)
            {
                //AnimationParams = ap;
            }
            public override Type EntityType => typeof(autoSign);
            public int actionDuration;

        }
        protected override void OnAddedToWorld(EntityAddReason reason)
        {
            base.OnAddedToWorld(reason);

        }
        public new autoSignPrototype Prototype
        {
            get
            {
                return _proto;

            }
            protected set
            {
                _proto = value;
                base.Prototype = value;
            }
        }

        public override bool CanBePaused => true;


        private static readonly Action<object, BlobWriter> s_serializeDataDelayedAction;

        private static readonly Action<object, BlobReader> s_deserializeDataDelayedAction;

        public static void Serialize(autoSign value, BlobWriter writer)
        {
            if (writer.TryStartClassSerialization(value))
            {
                writer.EnqueueDataSerialization(value, s_serializeDataDelayedAction);
            }
        }

        protected override void SerializeData(BlobWriter writer)
        {
            base.SerializeData(writer);
            writer.WriteGeneric<autoSignPrototype>(_proto);
        }

        public static autoSign Deserialize(BlobReader reader)
        {
            if (reader.TryStartClassDeserialization(out autoSign obj, (Func<BlobReader, Type, autoSign>)null))
            {
                reader.EnqueueDataDeserialization(obj, s_deserializeDataDelayedAction);
            }
            return obj;
        }

        protected override void DeserializeData(BlobReader reader)
        {
            base.DeserializeData(reader);
            reader.SetField(this, "_proto", reader.ReadGenericAs<autoSignPrototype>());
        }

        static autoSign()
        {
            s_serializeDataDelayedAction = delegate (object obj, BlobWriter writer)
            {
                ((autoSign)obj).SerializeData(writer);
            };
            s_deserializeDataDelayedAction = delegate (object obj, BlobReader reader)
            {
                ((autoSign)obj).DeserializeData(reader);
            };
        }
    }
    [GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
    internal class autoSignInspector : BaseInspector<autoSign>
    {
        private readonly LineOverlayRendererHelper m_goalLineRenderer;
        public EntityHighlighter m_EntityHighlighter { get; }
        public CursorPickingManager m_cursorPickingManager { get; }

        public autoSignInspector(UiContext context, NewInstanceOf<EntityHighlighter> entityHighlighter, CursorPickingManager cursorPickingManager) : base(context)
        {
            this.m_goalLineRenderer = LineOverlayRendererHelper.NewForVehicleGoal(context.LinesFactory);

            m_EntityHighlighter = entityHighlighter.Instance;
            m_cursorPickingManager = cursorPickingManager;
            Label upointsLabel = new Label().FontBold();
            WindowSize(400.px(), Px.Auto);
            AddPanelWithHeader(upointsLabel)
                .Title("AutoSign Information".AsLoc());



            base.OnDeactivatedEvent += delegate
            {
                if (Entity.m_targetTransportEntity != null) { m_EntityHighlighter.RemoveHighlight(base.Entity.m_targetTransportEntity); }
                if (Entity.m_targetEntityZipper != null) { m_EntityHighlighter.RemoveHighlight(base.Entity.m_targetEntityZipper); }

                m_goalLineRenderer.HideLine();
                base.OnDeactivated();
            };

            this.Observe(() => base.Entity.m_targetTransportEntity)
            .Do(delegate (Transport entity)
            {
                if (this.IsActive)
                {
                    if (entity != null)
                    {
                        m_EntityHighlighter.HighlightOnly(entity, new ColorRgba(255, 128, 0));
                        m_goalLineRenderer.SetColor(new Color(255, 127, 0));
                        m_goalLineRenderer.SetWidth(0.3f);
                        m_goalLineRenderer.ShowLine(base.Entity.Position3f, entity.Position3f);
                    }
                }
            });
            this.Observe(() => base.Entity.m_targetEntityZipper)
                .Do(delegate (blZipper entity)
                {
                    if (this.IsActive)
                    {
                        if (entity != null)
                        {
                            m_EntityHighlighter.HighlightOnly(entity, new ColorRgba(255, 128, 0));
                            m_goalLineRenderer.SetColor(new Color(255, 127, 0));
                            m_goalLineRenderer.SetWidth(0.3f);
                            m_goalLineRenderer.ShowLine(base.Entity.Position3f, entity.Position3f);
                        }
                    }
                });

        }
    }
}