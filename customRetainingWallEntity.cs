using Mafi.Base.Prototypes.Buildings;
using Mafi.Core;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Terrain;
using Mafi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterLife_Walls
{
    [GenerateSerializer(false, null, 0, null)]
    public class customRetainingWallEntity : LayoutEntityBase
    {
        TerrainOccupancyManager m_occupancyManager;
        public customRetainingWallEntity(EntityId id, customRetainingWallProto proto, TileTransform transform, EntityContext context, TerrainOccupancyManager terrainOccupancyManager)
            : base(id, proto, transform, context)
        {
            this.Prototype = proto;
            m_occupancyManager = terrainOccupancyManager;
        }

        protected override void OnAddedToWorld(EntityAddReason reason)

        {
            base.OnAddedToWorld(reason);
        }
        public static void Serialize(customRetainingWallEntity value, BlobWriter writer)
        {
            if (writer.TryStartClassSerialization<customRetainingWallEntity>(value))
            {
                writer.EnqueueDataSerialization(value, customRetainingWallEntity.s_serializeDataDelayedAction);
            }
        }
        protected override void SerializeData(BlobWriter writer)
        {
            base.SerializeData(writer);
            writer.WriteGeneric<customRetainingWallProto>(this.Prototype);
        }

        public static customRetainingWallEntity Deserialize(BlobReader reader)
        {
            customRetainingWallEntity retainingWallEntity;
            if (reader.TryStartClassDeserialization<customRetainingWallEntity>(out retainingWallEntity, null, null, false))
            {
                reader.EnqueueDataDeserialization(retainingWallEntity, customRetainingWallEntity.s_deserializeDataDelayedAction, null);
            }
            return retainingWallEntity;
        }
        protected override void DeserializeData(BlobReader reader)
        {
            base.DeserializeData(reader);
            reader.SetField<customRetainingWallEntity>(this, "Prototype", reader.ReadGenericAs<customRetainingWallProto>());
        }
        public override bool CanBePaused
        {
            get
            {
                return false;
            }
        }
        static customRetainingWallEntity()
        {
            customRetainingWallEntity.s_serializeDataDelayedAction = delegate (object obj, BlobWriter writer)
            {
                ((customRetainingWallEntity)obj).SerializeData(writer);
            };
            customRetainingWallEntity.s_deserializeDataDelayedAction = delegate (object obj, BlobReader reader)
            {
                ((customRetainingWallEntity)obj).DeserializeData(reader);
            };
        }
        private static readonly Action<object, BlobWriter> s_serializeDataDelayedAction;
        private static readonly Action<object, BlobReader> s_deserializeDataDelayedAction;
        public new readonly customRetainingWallProto Prototype;
    }
}
