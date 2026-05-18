using Mafi.Base.Prototypes.Buildings;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Prototypes;
using Mafi.Core.Terrain.Designation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterLife_Walls
{
    public class customRetainingWallProto : LayoutEntityProto, ITerrainDesignationBlockingEntityNoEdgeProto, ILayoutEntityProto, IStaticEntityProto, IEntityProto, IProto, IProtoWithTiers, IProtoWithIcon
    {
        public override Type EntityType
        {
            get
            {
                return typeof(customRetainingWallEntity);
            }
        }
        public ITierData TierData { get; }

        public customRetainingWallProto(StaticEntityProto.ID id, Proto.Str strings, EntityLayout layout, EntityCosts costs, LayoutEntityProto.Gfx graphics)
            : base(id, strings, layout, costs, graphics, null, null, false, false, false, true, false, false, false, false, null, null, null)
        {
//            base..ctor(id, strings, layout, costs, graphics, null, null, false, false, false, true, false, false, false, false, null, null, null);
            this.TierData = new TierData(this, -1);
        }
    }
}
