//using static BetterLife.Prototypes.blRoadEntity;
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
            public static dPath wall1block = new dPath("Assets/BetterLife/Walls/WallA/extWall_block.prefab", "Assets/BetterLife/IconsWalls/Walls/WallA_Straight.png");
            public static dPath wall1straight = new dPath("Assets/BetterLife/Walls/WallA/extWall_straight.prefab", "Assets/BetterLife/IconsWalls/Walls/WallA_Straight.png");
            public static dPath wall1straight2x = new dPath("Assets/BetterLife/Walls/WallA/extWall_straight2x.prefab", "Assets/BetterLife/IconsWalls/Walls/Walla_Straight2x.png");
            public static dPath wall1cross = new dPath("Assets/BetterLife/Walls/WallA/extWall_cross.prefab", "Assets/BetterLife/IconsWalls/Walls/WalLA_Cross.png");
            public static dPath wall1tee = new dPath("Assets/BetterLife/Walls/WallA/extWall_tee.prefab", "Assets/BetterLife/IconsWalls/Walls/WallA_Tee.png");
            public static dPath wall1corner = new dPath("Assets/BetterLife/Walls/WallA/extWall_corner.prefab", "Assets/BetterLife/IconsWalls/Walls/WallA_Corner.png");
            public static dPath wall1slope1 = new dPath("Assets/BetterLife/Walls/WallA/extWall_slope1.prefab", "Assets/BetterLife/IconsWalls/Walls/Wall1_Slope1.png");
            public static dPath wall1slope2 = new dPath("Assets/BetterLife/Walls/WallA/extWall_slope2.prefab", "Assets/BetterLife/IconsWalls/Walls/Wall1_Slope2.png");
            public static dPath wall1gate1 = new dPath("Assets/BetterLife/Walls/WallA/Wall_Gate1.prefab", "Assets/BetterLife/IconsWalls/Walls/WallA_Gate1.png");
            public static dPath wall1gate12 = new dPath("Assets/BetterLife/Walls/Gates/Gate 1/gate12.prefab", "Assets/BetterLife/IconsWalls/Walls/WallA_Gate1.png");
            public static dPath wall1gate13 = new dPath("Assets/BetterLife/Walls/Gates/Gate 1/gate13.prefab", "Assets/BetterLife/IconsWalls/Walls/WallA_Gate1.png");
            public static dPath wall1gate14 = new dPath("Assets/BetterLife/Walls/Gates/Gate 1/gate14.prefab", "Assets/BetterLife/IconsWalls/Walls/WallA_Gate1.png");
            public static dPath wall1gate15 = new dPath("Assets/BetterLife/Walls/Gates/Gate 1/gate15.prefab", "Assets/BetterLife/IconsWalls/Walls/WallA_Gate1.png");
            public static dPath wall1gate16 = new dPath("Assets/BetterLife/Walls/Gates/Gate 1/gate16.prefab", "Assets/BetterLife/IconsWalls/Walls/WallA_Gate1.png");
            public static dPath wall1gate17 = new dPath("Assets/BetterLife/Walls/Gates/Gate 1/gate17.prefab", "Assets/BetterLife/IconsWalls/Walls/WallA_Gate1.png");
            public static dPath wall1gate18 = new dPath("Assets/BetterLife/Walls/Gates/Gate 1/gate18.prefab", "Assets/BetterLife/IconsWalls/Walls/WallA_Gate1.png");

            public static dPath lwall1block = new dPath("Assets/BetterLife/Walls/WallB/legacy_block.prefab", "Assets/BetterLife/IconsWalls/Walls/LWallA_Straight.png");
            public static dPath lwall1straight = new dPath("Assets/BetterLife/Walls/WallB/legacy_straight.prefab", "Assets/BetterLife/IconsWalls/Walls/LWallA_Straight.png");
            public static dPath lwall1straight2x = new dPath("Assets/BetterLife/Walls/WallB/legacy_straight2x.prefab", "Assets/BetterLife/IconsWalls/Walls/LWalla_Straight2x.png");
            public static dPath lwall1cross = new dPath("Assets/BetterLife/Walls/WallB/legacy_cross.prefab", "Assets/BetterLife/IconsWalls/Walls/LWalLA_Cross.png");
            public static dPath lwall1tee = new dPath("Assets/BetterLife/Walls/WallB/legacy_tee.prefab", "Assets/BetterLife/IconsWalls/Walls/LWallA_Tee.png");
            public static dPath lwall1corner = new dPath("Assets/BetterLife/Walls/WallB/legacy_corner.prefab", "Assets/BetterLife/IconsWalls/Walls/LWallA_Corner.png");
            public static dPath lwall1slope1 = new dPath("Assets/BetterLife/Walls/WallB/legacy_slope1.prefab", "Assets/BetterLife/IconsWalls/Walls/LWall1_Slope1.png");
            public static dPath lwall1slope2 = new dPath("Assets/BetterLife/Walls/WallB/legacy_slope2.prefab", "Assets/BetterLife/IconsWalls/Walls/LWall1_Slope2.png");

            public static dPath seawall1_straight = new dPath("Assets/BetterLife/Walls/SeaWall1/seawall_straight.prefab", "TODO");
            public static dPath seawall1_cornerIN = new dPath("Assets/BetterLife/Walls/SeaWall1/seawall_corner_in.prefab", "TODO");
            public static dPath seawall1_cornerOUT = new dPath("Assets/BetterLife/Walls/SeaWall1/seawall_corner_out.prefab", "TODO");
        }





        public partial class Tools
        {
            //       public static readonly CustomEntityPrototype.ID Tool1 = new CustomEntityPrototype.ID("eTool1");
        }
         
        public partial class Walls
        {
            public static RetainingWallProto.ID wall1_block = new RetainingWallProto.ID("wall1_block");
            public static RetainingWallProto.ID wall1_straight = new RetainingWallProto.ID("wall1_straight");
            public static RetainingWallProto.ID wall1_straight2x = new RetainingWallProto.ID("wall1_straight2x");
            public static RetainingWallProto.ID wall1_corner = new RetainingWallProto.ID("wall1_corner");
            public static RetainingWallProto.ID wall1_cross = new RetainingWallProto.ID("wall1_cross");
            public static RetainingWallProto.ID wall1_tee = new RetainingWallProto.ID("wall1_tee");
            public static RetainingWallProto.ID wall1_gate1 = new RetainingWallProto.ID("wall1_gate1");
            public static RetainingWallProto.ID wall1_gate12 = new RetainingWallProto.ID("wall1_gate12");
            public static RetainingWallProto.ID wall1_gate13 = new RetainingWallProto.ID("wall1_gate13");
            public static RetainingWallProto.ID wall1_gate14 = new RetainingWallProto.ID("wall1_gate14");
            public static RetainingWallProto.ID wall1_gate15 = new RetainingWallProto.ID("wall1_gate15");
            public static RetainingWallProto.ID wall1_gate16 = new RetainingWallProto.ID("wall1_gate16");
            public static RetainingWallProto.ID wall1_gate17 = new RetainingWallProto.ID("wall1_gate17");
            public static RetainingWallProto.ID wall1_gate18 = new RetainingWallProto.ID("wall1_gate18");
            public static RetainingWallProto.ID wall1_slope1 = new RetainingWallProto.ID("wall1_slope1");
            public static RetainingWallProto.ID wall1_slope2 = new RetainingWallProto.ID("wall1_slope2");

            public static RetainingWallProto.ID lwall1_block = new RetainingWallProto.ID("lwall1_block");
            public static RetainingWallProto.ID lwall1_straight = new RetainingWallProto.ID("lwall1_straight");
            public static RetainingWallProto.ID lwall1_straight2x = new RetainingWallProto.ID("lwall1_straight2x");
            public static RetainingWallProto.ID lwall1_corner = new RetainingWallProto.ID("lwall1_corner");
            public static RetainingWallProto.ID lwall1_cross = new RetainingWallProto.ID("lwall1_cross");
            public static RetainingWallProto.ID lwall1_tee = new RetainingWallProto.ID("lwall1_tee");
            public static RetainingWallProto.ID lwall1_slope1 = new RetainingWallProto.ID("lwall1_slope1");
            public static RetainingWallProto.ID lwall1_slope2 = new RetainingWallProto.ID("lwall1_slope2");

            public static RetainingWallProto.ID seawall1_straight = new RetainingWallProto.ID("seawall1_straight");
            public static RetainingWallProto.ID seawall1_cornerIN = new RetainingWallProto.ID("seawall1_cornerIN");
            public static RetainingWallProto.ID seawall1_cornerOUT = new RetainingWallProto.ID("seawall1_cornerOUT");
        }

    }
} 