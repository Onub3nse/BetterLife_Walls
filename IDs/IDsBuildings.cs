//using static BetterLife.Prototypes.blRoadEntity;
using BetterLife.RoadsAndSigns;
using Mafi.Base;
using Mafi.Base.Prototypes.Buildings;
using Mafi.Core.Entities.Static;
using Mafi.Core.Factory.Transports;
using Mafi.Core.Ports.Io;
using Mafi.Core.Roads;
using Mafi.Core.Trains;
using static BetterLife.Prototypes.CustomEntity;
using MachineID = Mafi.Core.Factory.Machines.MachineProto.ID;

namespace BetterLife_Walls
{
    public partial class BetterLIDs
    {
        public partial class dPath
        {
            public dPath(string v1, string v2)
            {
                asset = v1;
                icon = v2;
            }

            public string asset { get; set; }
            public string icon { get; set; }

            public static dPath wall1straight = new dPath("Assets/BetterLife/Walls/WallA/wall1_straight.prefab", "Assets/BetterLife/Icons/Walls/WallA_Straight.png");
            public static dPath wall1cross = new dPath("Assets/BetterLife/Walls/WallA/wall1_cross.prefab", "Assets/BetterLife/Icons/Walls/WalLA_Cross.png");
            public static dPath wall1tee = new dPath("Assets/BetterLife/Walls/WallA/wall1_tee.prefab", "Assets/BetterLife/Icons/Walls/WallA_Tee.png");
            public static dPath wall1corner = new dPath("Assets/BetterLife/Walls/WallA/wall1_corner.prefab", "Assets/BetterLife/Icons/Walls/WallA_Corner.png");
        }





        public partial class Tools
        {
            //       public static readonly CustomEntityPrototype.ID Tool1 = new CustomEntityPrototype.ID("eTool1");
        }

        public partial class Walls
        {
            public static RetainingWallProto.ID wall1_straight = new RetainingWallProto.ID("wall1_straight");
            public static RetainingWallProto.ID wall1_corner = new RetainingWallProto.ID("wall1_corner");
            public static RetainingWallProto.ID wall1_cross = new RetainingWallProto.ID("wall1_cross");
            public static RetainingWallProto.ID wall1_tee = new RetainingWallProto.ID("wall1_tee");
        }

    }
}