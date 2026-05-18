using Mafi;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Bridges;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Animations;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Entities.Validators;
using Mafi.Core.Population;
using Mafi.Core.Prototypes;
using Mafi.Core.Roads;
using Mafi.Core.Syncers;
using Mafi.Core.Trains;
using Mafi.Localization;
using Mafi.Serialization;
using Mafi.Unity;
using Mafi.Unity.Entities;
using Mafi.Unity.Entities.Static;
using Mafi.Unity.Ui;
using Mafi.Unity.Ui.Library;
using Mafi.Unity.Ui.Library.Inspectors;
using Mafi.Unity.UiToolkit.Component;
using Mafi.Unity.UiToolkit.Library;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Component = UnityEngine.Component;


namespace BetterLife_Walls
{
    [GenerateSerializer(false, null, 0)]
    public class simpleEntity : LayoutEntity, IEntityWithSimUpdate, IStaticEntity

    {
        private simpleEntityProto _proto;
        public string signText = "";
        public ColorRgba signColor = ColorRgba.White;
        public bool txtChanged = false;
        public bool colChanged = false;

        void IEntityWithSimUpdate.SimUpdate()
        {
//            CurrentState = updateState();
        }
        public simpleEntity(EntityId id, simpleEntityProto proto, TileTransform transform, EntityContext context) : base(id, proto, transform, context)

        {
            _proto = proto;
        }

        public new simpleEntityProto Prototype
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

        public static void Serialize(simpleEntity value, BlobWriter writer)
        {
            if (writer.TryStartClassSerialization(value))
            {
                writer.EnqueueDataSerialization(value, s_serializeDataDelayedAction);
            }
        }
        public void SetSignText(string text)
        {
            signText = text?.Substring(0, Math.Min(32, text.Length)) ?? "";
            txtChanged = true;
        }
        public void SetSignColor(ColorRgba col)
        {
            signColor = col;
            colChanged = true;
            
        }
        protected override void SerializeData(BlobWriter writer)
        {
            base.SerializeData(writer);
            writer.WriteGeneric(_proto);
            writer.WriteString(signText);
            writer.WriteGeneric(signColor);
        }

        public static simpleEntity Deserialize(BlobReader reader)
        {
            if (reader.TryStartClassDeserialization(out simpleEntity obj, (Func<BlobReader, Type, simpleEntity>)null))
            {
                reader.EnqueueDataDeserialization(obj, s_deserializeDataDelayedAction);
            }
            return obj;
        }

        protected override void DeserializeData(BlobReader reader)
        {
            base.DeserializeData(reader);
            reader.SetField(this, "_proto", reader.ReadGenericAs<simpleEntityProto>());
            reader.SetField(this, "signText", reader.ReadString());
            reader.SetField(this, "signColor", reader.ReadGenericAs<ColorRgba>());
        }

        static simpleEntity()
        {
            s_serializeDataDelayedAction = delegate (object obj, BlobWriter writer)
            {
                ((simpleEntity)obj).SerializeData(writer);
            };
            s_deserializeDataDelayedAction = delegate (object obj, BlobReader reader)
            {
                ((simpleEntity)obj).DeserializeData(reader);
            };
        }
    }
    public class simpleEntityProto : LayoutEntityProto, IProto, IProtoWithAnimation, IProtoWithTiers
    {

        public simpleEntityProto(ID id, Str strings, EntityLayout layout, EntityCosts costs, Gfx graphics, ImmutableArray<AnimationParams> ap)
             : base(id, strings, layout, costs, graphics)
        {
            this.TierData = new TierData(this);
            _animationParameters = ap;
        }

        ImmutableArray<AnimationParams> IProtoWithAnimation.AnimationParams => _animationParameters;
        private ImmutableArray<AnimationParams> _animationParameters;

        public override Type EntityType => typeof(simpleEntity);
        public int actionDuration;
        public ITierData TierData { get; }

    }
    [GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
    public class simpleEntityMbFactory :
        IEntityMbFactory<simpleEntity>,
        IFactory<simpleEntity, EntityMb>
    {

        private readonly ProtoModelFactory modelFactory;
        private EntitiesManager m_entitiesManager;

        public simpleEntityMbFactory(ProtoModelFactory mFactory, EntitiesManager entitiesManager)
        {
            modelFactory = mFactory;
            m_entitiesManager = entitiesManager;
        }

        public EntityMb Create(simpleEntity transp)
        {
            simpleEntityMb transpMb = modelFactory.CreateModelFor<simpleEntityProto>(transp.Prototype).AddComponent<simpleEntityMb>();
            transpMb.Initialize(transp, m_entitiesManager);
            return (EntityMb)transpMb;
        }
    }
    public class simpleEntityMb : StaticEntityMb, IEntityMbWithSyncUpdate, IEntityMb, IDestroyableEntityMb
    {
        simpleEntity thisEntity;
        private EntitiesManager m_entitiesManager;
        private Option<TextMeshPro> m_signTextMeshA;
        private Option<TextMeshPro> m_signTextMeshB;

        public void SyncUpdate(GameTime time)
        {
            if (thisEntity.txtChanged == true)
            {
                thisEntity.txtChanged = false;
                if (m_signTextMeshA != null)
                {
                    m_signTextMeshA.Value.text = thisEntity.signText;
                    m_signTextMeshB.Value.text = thisEntity.signText;
                }
            }
            if ( thisEntity.signText != "")
            {
                thisEntity.txtChanged = false;
                if (m_signTextMeshA != null)
                {
                    m_signTextMeshA.Value.text = thisEntity.signText;
                    m_signTextMeshB.Value.text = thisEntity.signText;
                }
            }
            if (thisEntity.signColor != ColorRgba.White)
                {
                thisEntity.colChanged = false;
                m_signTextMeshA.Value.color = thisEntity.signColor.ToColor();
                m_signTextMeshB.Value.color = thisEntity.signColor.ToColor();
            }
            ;
            if (thisEntity.colChanged == true)
            {
                thisEntity.colChanged = false;
                m_signTextMeshA.Value.color = thisEntity.signColor.ToColor();
                m_signTextMeshB.Value.color = thisEntity.signColor.ToColor();
            }
        }
        public void Initialize(simpleEntity simpleEnt, EntitiesManager entitiesManager)
        {
            base.Initialize((ILayoutEntity)simpleEnt);
            thisEntity = simpleEnt;
            Component txtA = gameObject.FindComponentByName("txt1", true);
            Component txtB = gameObject.FindComponentByName("txt2", true);
            m_entitiesManager = entitiesManager;
            if (txtA != null)
            {
                m_signTextMeshA = txtA.GetComponent<TextMeshPro>();
                m_signTextMeshB = txtB.GetComponent<TextMeshPro>();
            }

        }
        static simpleEntityMb() 
        {

        }
    }
    [GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
    [GenerateSerializer(false, null, 0)]
    public class simpleEntityValidator : IEntityAdditionValidator<LayoutEntityAddRequest>, IEntityAdditionValidator
    {
        private static EntitiesManager entitiesManager;

        public simpleEntityValidator(EntitiesManager em)
        {
            entitiesManager = em;
        }

        public EntityValidationResult CanAdd(LayoutEntityAddRequest addRequest)
        {

            if (!(addRequest.Proto is simpleEntityProto))
                return EntityValidationResult.Success;

            if (entitiesManager.GetAllEntitiesOfType<simpleEntity>().Count() >= 50)
            {
                return EntityValidationResult.CreateError("Max of 50 signs are allowed.".AsLoc());
            }
            return EntityValidationResult.Success;
        }

        public EntityValidatorPriority Priority => EntityValidatorPriority.Default;
    }
    [GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
    internal class simpleEntityInspector : BaseInspector<simpleEntity>
    {
        
        public simpleEntityInspector(UiContext context) : base(context)
        {
            TextField _textField;
            Label header_label;
            RgbColorPicker _gbColorPicker = new RgbColorPicker("Gate Color Picker".AsLoc());
            // Set window size
            WindowSize(600.px(), Px.Auto);

            //Panel main_panel;
            // Title
            header_label = new Label("Custom text for Gate".AsLoc()).FontSize(18).FontBold().MarginBottom(8.px());
            _textField = new TextField()
                .Text("");
            _textField.CharLimit(32);
            _textField.OnValueChanged(txt => Entity?.SetSignText(txt));
            
            _gbColorPicker.OnColorChanged(col => Entity?.SetSignColor(col));
            base.AddRootPanelWithHeader(header_label).Add(new UiComponent[]
            {
                _textField,
                _gbColorPicker
            });

            this.Observe(() => Entity.signText)
                .Do(uText => _textField.Text(uText));
            this.Observe(() => Entity.signColor)
                .Do(uColor => _gbColorPicker.Color(uColor));
             
            
               

            // Textfield with max length 32
            //.OnValueChanged(OnTextChanged);
            //main_panel = new Panel();
            //main_panel.AlignItemsAuto();
            //main_panel.Add(header_label);
            //main_panel.Add(_textField);
            //base.Add(main_panel);

        }
    }
    public static class insideGOUtility
    {
        /// <summary>
        /// Finds the first material with the specified name from MeshRenderer components in a GameObject and its children.
        /// </summary>
        /// <param name="parent">The root GameObject to start the search from.</param>
        /// <param name="materialName">The name of the material to find.</param>
        /// <param name="includeInactive">Whether to include MeshRenderers on inactive GameObjects.</param>
        /// <returns>The first matching Material, or null if not found.</returns>

        public static Material FindMaterialByName(this GameObject parent, string materialName, bool includeInactive = false)
        {

            MeshRenderer[] renderers = parent.GetComponentsInChildren<MeshRenderer>(includeInactive);
            //Log.Info($"FindMaterialByName: Found {renderers.Length} MeshRenderers in {parent.name}.");



            string searchNameLower = materialName.Trim().ToLower();
            foreach (MeshRenderer renderer in renderers)
            {
                if (renderer != null && renderer.materials != null)
                {
                    //      Log.Info($"FindMaterialByName: Processing MeshRenderer on {renderer.gameObject.name} with {renderer.sharedMaterials.Length} materials.");

                    foreach (Material material in renderer.materials)
                    {
                        if (material != null && material.name != null)
                        {
                            // Handle Unity's potential "(Instance)" suffix and trim whitespace
                            string materialNameLower = material.name.Replace("(Instance)", "").Trim().ToLower();
                            //            Log.Info($"FindMaterialByName: Checking material '{material.name}' (normalized: '{materialNameLower}') against search '{searchNameLower}'.");

                            if (materialNameLower.Contains(searchNameLower))
                            {
                                //              Log.Info($"FindMaterialByName: Matched material '{material.name}' on GameObject '{renderer.gameObject.name}'.");
                                return material;
                            }
                        }
                        else
                        {
                            //        Log.Info($"FindMaterialByName: Skipping null material or null material name in {renderer.gameObject.name}.");
                        }
                    }
                }
                else
                {
                    //    Log.Info($"FindMaterialByName: Skipping null MeshRenderer or sharedMaterials in {renderer?.gameObject.name ?? "null"}.");
                }
            }
            // Log.Info($"FindMaterialByName: Found {materials.Count} matching materials for '{materialName}'.");
            return null;
        }
        /// <summary>
        /// Finds the first component on a GameObject with the specified name in a GameObject and its children.
        /// </summary>
        /// <param name="parent">The root GameObject to start the search from.</param>
        /// <param name="gameObjectName">The name of the GameObject containing the component to find.</param>
        /// <param name="includeInactive">Whether to include components on inactive GameObjects.</param>
        /// <returns>The first matching Component, or null if not found.</returns>
        public static Component FindComponentByName(this GameObject parent, string gameObjectName, bool includeInactive = false)
        {
            // Validate input
            if (parent == null || string.IsNullOrEmpty(gameObjectName))
            {
                //Log.Info("FindComponentByName: Invalid input - null parent or empty GameObject name.");
                return null;
            }

            // Get all components of any type in the parent and its children
            Component[] components = parent.GetComponentsInChildren<Component>(includeInactive);
            //Log.Info($"FindComponentByName: Found {components.Length} components in {parent.name}.");

            string searchNameLower = gameObjectName.Trim().ToLower();
            foreach (Component component in components)
            {
                if (component != null)
                {
                    // Get the GameObject's name and normalize it
                    string goNameLower = component.gameObject.name.Trim().ToLower();
                    //Log.Info($"FindComponentByName: Checking GameObject '{component.gameObject.name}' (normalized: '{goNameLower}') against search '{searchNameLower}'.");

                    if (goNameLower.Contains(searchNameLower))
                    {
                        //Log.Info($"FindComponentByName: Matched component '{component.GetType().Name}' on GameObject '{component.gameObject.name}'.");
                        return component;
                    }
                }
                else
                {
                    //Log.Info("FindComponentByName: Skipping null component.");
                }
            }

            //Log.Info($"FindComponentByName: No matching component found for GameObject name '{gameObjectName}'.");
            return null;
        }
    }

}