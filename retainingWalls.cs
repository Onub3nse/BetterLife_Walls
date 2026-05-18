using Mafi;
using Mafi.Base;
using Mafi.Base.Prototypes.Buildings;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Animations;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Factory.Machines;
using Mafi.Core.Factory.Zippers;
using Mafi.Core.Mods;
using Mafi.Core.Prototypes;
using Mafi.Core.Terrain.Trees;
using Mafi.Localization;
using Mafi.Unity.Ui;
using Mafi.Unity.Ui.Library.Inspectors;
using Mafi.Unity.UiToolkit.Component;
using Mafi.Unity.UiToolkit.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.UIElements;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

namespace BetterLife_Walls
{ 
    internal class retainingWalls : IModData
    {
        public void RegisterData(ProtoRegistrator registrator)
        {
            string[] vertLayoutWall1aBlock =
            {
                ".",
                ".",
                "#",

            };
            string[] vertLayoutWall1AOneBlock =
            {
                "..",
                "..",
                "##",
            };
            string[] vertLayoutWall1Corner =
            {
                "..",
                ".#",
                "##"
            }; 
            //string[] vertLayoutWall1Corner =
            //{
            //    ".#.",
            //    ".##",
            //    "..."
            //};
            string[] lay_Wall1OneBlock =
            {
                "(W)(W)",
                "(W)(W)" 
            };
            string[] vertLayoutWall1ATwoBlock =
            {
                "....",
                "....",
                "####",
            };
            string[] lay_Wall1TwoBlock =
            {
                "(W)(W)(W)(W)",
                "(W)(W)(W)(W)"
            };
            string[] vertLayoutWall1AGate1 =
            {
                "   -w-                     -w-   ",
            };
            string[] vertLayoutWall1Cross =
            {
                ".#.",
                "###",
                ".#."
            };
            string[] vertLayoutWall1Tee =
            {
                ".#.",
                "###",
                "..." 
            };
            string[] vseawall_straight =
            {
                "..",
                "..",
                "##",
            };
            string[] vseawall_corners =
            {
                ".##..",
                ".####",
                "....."
            };

            string[] lay_Wall1Block =
            {
                "(W)",
                "(W)"
            };
            string[] vertLayoutWall1ABlock =
            {
                "..",
                "..",
                "##", 
            };



            // Extended Walls Proto Creation

            //RetainingWallProto wall1Block = CreateWall(registrator, BetterLIDs.Walls.wall1_block, "Retaining Wall Block", BetterLIDs.ToolBars.toolWallExtended,
            //    BLCosts.Walls.Wall1, 1, 0, vertLayoutWall1aBlock, BetterLIDs.dPath.wall1block, -26);

            RetainingWallProto wall1aOneBlock = CreateWall(registrator, BetterLIDs.Walls.wall1_straight, "Retaining Wall Straight", BetterLIDs.ToolBars.toolWallExtended,
                BLCosts.Walls.Wall1, 2, 1, vertLayoutWall1AOneBlock, BetterLIDs.dPath.wall1straight, Fix32.Zero, Fix32.Zero, Fix32.Zero);

            RetainingWallProto wall1aCorner = CreateWall(registrator, BetterLIDs.Walls.wall1_corner, "Retaining Wall Corner", BetterLIDs.ToolBars.toolWallExtended,
                BLCosts.Walls.Wall1, 1, 0, vertLayoutWall1Corner, BetterLIDs.dPath.wall1corner, Fix32.Zero, Fix32.Half, Fix32.Zero);

            //RetainingWallProto wall1aTwoBlock = CreateWall(registrator, BetterLIDs.Walls.wall1_straight2x, "Retaining Wall Straight 2x", BetterLIDs.ToolBars.toolWallExtended,
            //    BLCosts.Walls.Wall1, 4, 1, vertLayoutWall1ATwoBlock, BetterLIDs.dPath.wall1straight2x, -26);

            //RetainingWallProto wall1aCross = CreateWall(registrator, BetterLIDs.Walls.wall1_cross, "Retaining Wall Cross", BetterLIDs.ToolBars.toolWallExtended,
            //    BLCosts.Walls.Wall1, 2, 1, vertLayoutWall1Cross, BetterLIDs.dPath.wall1cross, -26);

            //RetainingWallProto wall1aTee = CreateWall(registrator, BetterLIDs.Walls.wall1_tee, "Retaining Wall Tee", BetterLIDs.ToolBars.toolWallExtended,
            //    BLCosts.Walls.Wall1, 2, 1, vertLayoutWall1Tee, BetterLIDs.dPath.wall1tee, -26);


            //RetainingWallProto wall1aSlope1 = CreateWall(registrator, BetterLIDs.Walls.wall1_slope1, "Retaining Wall Slope 1", BetterLIDs.ToolBars.toolWallExtended,
            //    BLCosts.Walls.Wall1, 4, 3, vertLayoutWall1ATwoBlock, BetterLIDs.dPath.wall1slope1, -26);

            //RetainingWallProto wall1aSlope2 = CreateWall(registrator, BetterLIDs.Walls.wall1_slope2, "Retaining Wall Slope 2", BetterLIDs.ToolBars.toolWallExtended,
            //    BLCosts.Walls.Wall1, 4, 3, vertLayoutWall1ATwoBlock, BetterLIDs.dPath.wall1slope2, -26);

            //simpleEntityProto wall1aGate1 = createSimpleProto(registrator, BetterLIDs.Walls.wall1_gate1, "Retaining Wall Gate", "Simple Gate (no retaining)", BLCosts.Walls.Wall1, Electricity.Zero, vertLayoutWall1AGate1,
            //    BetterLIDs.dPath.wall1gate1.asset, BetterLIDs.dPath.wall1gate1.icon, BetterLIDs.ToolBars.toolWallsParent);

            //simpleEntityProto wall1aGate12 = createSimpleProto(registrator, BetterLIDs.Walls.wall1_gate12, "Retaining Wall Gate 2", "Simple Gate (no retaining)", BLCosts.Walls.Wall1, Electricity.Zero, vertLayoutWall1AGate1,
            //    BetterLIDs.dPath.wall1gate12.asset, BetterLIDs.dPath.wall1gate12.icon, BetterLIDs.ToolBars.HiddenProto);

            //simpleEntityProto wall1aGate13 = createSimpleProto(registrator, BetterLIDs.Walls.wall1_gate13, "Retaining Wall Gate 3", "Simple Gate (no retaining)", BLCosts.Walls.Wall1, Electricity.Zero, vertLayoutWall1AGate1,
            //    BetterLIDs.dPath.wall1gate13.asset, BetterLIDs.dPath.wall1gate13.icon, BetterLIDs.ToolBars.HiddenProto);
               
             

            // Legacy Walls Proto Creation

            //RetainingWallProto lwall1aBlock = CreateWallLegacy(registrator, BetterLIDs.Walls.lwall1_block, "Retaining Wall Block", BetterLIDs.ToolBars.toolWallLegacy,
            //    BLCosts.Walls.Wall1, 1, 2, vertLayoutWall1ABlock, BetterLIDs.dPath.lwall1block, -26);

            //RetainingWallProto lwall1aOneBlock = CreateWallLegacy(registrator, BetterLIDs.Walls.lwall1_straight, "Retaining Wall Straight", BetterLIDs.ToolBars.toolWallLegacy,
            //    BLCosts.Walls.Wall1, 2, 3, vertLayoutWall1AOneBlock, BetterLIDs.dPath.lwall1straight, -26);

            //RetainingWallProto lwall1aTwoBlock = CreateWallLegacy(registrator, BetterLIDs.Walls.lwall1_straight2x, "Retaining Wall Straight 2x", BetterLIDs.ToolBars.toolWallLegacy,
            //    BLCosts.Walls.Wall1, 4, 3, vertLayoutWall1ATwoBlock, BetterLIDs.dPath.lwall1straight2x, -26);

            //RetainingWallProto lwall1aCross = CreateWallLegacy(registrator, BetterLIDs.Walls.lwall1_cross, "Retaining Wall Cross", BetterLIDs.ToolBars.toolWallLegacy,
            //    BLCosts.Walls.Wall1, 2, 0, vertLayoutWall1Cross, BetterLIDs.dPath.lwall1cross, -26);

            //RetainingWallProto lwall1aTee = CreateWallLegacy(registrator, BetterLIDs.Walls.lwall1_tee, "Retaining Wall Tee", BetterLIDs.ToolBars.toolWallLegacy,
            //    BLCosts.Walls.Wall1, 2, 0, vertLayoutWall1Tee, BetterLIDs.dPath.lwall1tee, -26);

            //RetainingWallProto lwall1aCorner = CreateWallLegacy(registrator, BetterLIDs.Walls.lwall1_corner, "Retaining Wall Corner", BetterLIDs.ToolBars.toolWallLegacy,
            //    BLCosts.Walls.Wall1, 2, 0, vertLayoutWall1Corner, BetterLIDs.dPath.lwall1corner, -26);

            //RetainingWallProto lwall1aSlope1 = CreateWallLegacy(registrator, BetterLIDs.Walls.lwall1_slope1, "Retaining Wall Slope 1", BetterLIDs.ToolBars.toolWallLegacy,
            //    BLCosts.Walls.Wall1, 4, 3, vertLayoutWall1ATwoBlock, BetterLIDs.dPath.lwall1slope1, -26);

            //RetainingWallProto lwall1aSlope2 = CreateWallLegacy(registrator, BetterLIDs.Walls.lwall1_slope2, "Retaining Wall Slope 2", BetterLIDs.ToolBars.toolWallLegacy,
            //    BLCosts.Walls.Wall1, 4, 3, vertLayoutWall1ATwoBlock, BetterLIDs.dPath.lwall1slope2, -26);

            //// Sea Walls Proto Creation
            //RetainingWallProto seawall_Straight = CreateWall(registrator, BetterLIDs.Walls.seawall1_straight, "Sea Wall Straight", BetterLIDs.ToolBars.toolWallSeaWalls,
            //    BLCosts.Walls.Wall1, 1, 2, vseawall_straight, BetterLIDs.dPath.seawall1_straight, -26);

            //RetainingWallProto seawall_cornerIN = CreateWall(registrator, BetterLIDs.Walls.seawall1_cornerIN, "Sea Wall Corner IN", BetterLIDs.ToolBars.toolWallSeaWalls,
            //    BLCosts.Walls.Wall1, 5, 4, vseawall_corners, BetterLIDs.dPath.seawall1_cornerIN, -26);

            //RetainingWallProto seawall_cornerOUT = CreateWall(registrator, BetterLIDs.Walls.seawall1_cornerOUT, "Sea Wall Corner OUT", BetterLIDs.ToolBars.toolWallSeaWalls,
            //    BLCosts.Walls.Wall1, 5, 4, vseawall_corners, BetterLIDs.dPath.seawall1_cornerOUT, -26);


            

            //registrator.PrototypesDb.Add(lwall1aBlock);
            //registrator.PrototypesDb.Add(lwall1aOneBlock);
            //registrator.PrototypesDb.Add(lwall1aTwoBlock);
            //registrator.PrototypesDb.Add(lwall1aCorner);
            //registrator.PrototypesDb.Add(lwall1aCross);
            //registrator.PrototypesDb.Add(lwall1aTee);
            //registrator.PrototypesDb.Add(lwall1aSlope1);
            //registrator.PrototypesDb.Add(lwall1aSlope2);

            //registrator.PrototypesDb.Add(wall1Block);
            registrator.PrototypesDb.Add(wall1aOneBlock);
            //registrator.PrototypesDb.Add(wall1aTwoBlock);
            registrator.PrototypesDb.Add(wall1aCorner);
            //registrator.PrototypesDb.Add(wall1aCross);
            //registrator.PrototypesDb.Add(wall1aTee);
            //registrator.PrototypesDb.Add(wall1aSlope1);
            //registrator.PrototypesDb.Add(wall1aSlope2);
            //registrator.PrototypesDb.Add(wall1aGate1);

            //registrator.PrototypesDb.Add(seawall_Straight);
            //registrator.PrototypesDb.Add(seawall_cornerIN);
            //registrator.PrototypesDb.Add(seawall_cornerOUT);

            wall1aOneBlock.AddParam(new DrawArrowWileBuildingProtoParam(1f, 0f));
            wall1aCorner.AddParam(new DrawArrowWileBuildingProtoParam(1f, 0f));

             
        }
        public simpleEntityProto createSimpleProto(ProtoRegistrator registrator, StaticEntityProto.ID id, string name, string description, EntityCostsTpl costs, Electricity electricityConsumption
            , string[] layout, string prefabPath, string customIconPath, Fix32 oriX, Fix32 oriY, Fix32 oriZ, Proto.ID toolbarID, simpleEntityProto tier)
        {
            Predicate<LayoutTile> predicate = null;
            CustomLayoutToken[] array = new CustomLayoutToken[1];
            Proto.Str assemblyName = Proto.CreateStr(id, name, description);
            array[0] = new CustomLayoutToken("-w-", delegate (EntityLayoutParams p, int h)
            {
                return new LayoutTokenSpec(-26, 26, LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse, minTerrainHeight: new int?(-25), maxTerrainHeight: new int?(25));
            });
            EntityLayoutParams entityLayoutParams = new EntityLayoutParams(predicate, array, false, null, null, null, null, null, null, default, false, null, null);
            EntityLayout assemblyLayout = registrator.LayoutParser.ParseLayoutOrThrow(entityLayoutParams, layout);

            if (toolbarID != BetterLIDs.ToolBars.HiddenProto)
            {
                simpleEntityProto.Gfx assemblyGfx = new simpleEntityProto.Gfx
                (
                    prefabPath: prefabPath,
                    prefabOrigin: new RelTile3f(oriX, oriY, oriZ),
                    customIconPath: customIconPath,
                    useInstancedRendering: false,
                    useSemiInstancedRendering: false,
                    categories: registrator.GetCategoriesProtos(toolbarID)
                );
                simpleEntityProto cpAssembly = new simpleEntityProto
                    (
                        id,
                        assemblyName,
                        assemblyLayout,
                        costs.MapToEntityCosts(registrator),
                        assemblyGfx,
                        ImmutableArray.Create<AnimationParams>(AnimationParams.Loop(null, false, null))
                    );
                if (tier != null) cpAssembly.SetNextTierIndirect<simpleEntityProto>(tier, false, false);
                return cpAssembly;
            }
            else
            {
                simpleEntityProto.Gfx assemblyGfx = new simpleEntityProto.Gfx
                (
                    prefabPath: prefabPath,
                    customIconPath: customIconPath,
                    useInstancedRendering: false,
                    useSemiInstancedRendering: false,
                    categories: ImmutableArray<ToolbarEntryData>.Empty
                );
                simpleEntityProto cpAssembly = new simpleEntityProto
                    (
                        id,
                        assemblyName,
                        assemblyLayout,
                        costs.MapToEntityCosts(registrator),
                        assemblyGfx,
                        ImmutableArray.Create<AnimationParams>(AnimationParams.Loop(null, false, null))
                    );
                if (tier != null) cpAssembly.SetNextTierIndirect<simpleEntityProto>(tier, false, false);
                return cpAssembly;
            }
        }

        public RetainingWallProto CreateWall(ProtoRegistrator registrator, StaticEntityProto.ID iD, string locstr, Proto.ID toolbarID, EntityCostsTpl costs,
            int wallLength, int collapseThreshold, string[] retainingVertices, BetterLIDs.dPath dPath, Fix32 oriX, Fix32 oriY, Fix32 oriZ)
        {
            ProtosDb prototypesDb = registrator.PrototypesDb;
            ImmutableArray<ToolbarEntryData> categoriesProtos = registrator.GetCategoriesProtos(toolbarID);
            LocStr1 locStr1 = Loc.Str1(iD.ToString() + "__desc", locstr, "description of retaining wall");
            LocStr alreadyLocalizedStr = LocalizationManager.CreateAlreadyLocalizedStr(iD.ToString() + "_formatted", locStr1.Format(5.ToString()).Value);
            ProtosDb protosDb1 = prototypesDb;
            StaticEntityProto.ID retainingWall = iD;
            Proto.Str str1 = Proto.CreateStr((Proto.ID)iD, locstr, alreadyLocalizedStr);
            EntityLayout layout1 = createLayout(registrator, wallLength, collapseThreshold, retainingVertices);
            foreach(var laytile in layout1.LayoutTiles)
            {
                Log.Info($"Constraint: {laytile.Constraint.ToString()} {laytile.ToString()}");

            }
            EntityCosts entityCosts1 = costs.MapToEntityCosts(registrator);
            ImmutableArray<ToolbarEntryData>? categories = new ImmutableArray<ToolbarEntryData>?(categoriesProtos);
            LayoutEntityProto.Gfx graphics1 = new LayoutEntityProto.Gfx(
                prefabPath: dPath.asset,
                prefabOrigin: new RelTile3f(oriX, oriY, oriZ),
                customIconPath: dPath.icon,
                categories: categories, useInstancedRendering: true);
            return new RetainingWallProto(retainingWall, str1, layout1, entityCosts1, graphics1);
        } 
        internal static EntityLayout createLayout(ProtoRegistrator registrator, int wallLengthTiles, int collapseThreshold, string[] retainingVerticesLayout)
		{

            string text = "(W)".RepeatString(wallLengthTiles);
            IEntityLayoutParser layoutParser = registrator.LayoutParser;
            Predicate<LayoutTile> predicate = null;
            CustomLayoutToken[] array = new CustomLayoutToken[1];
            array[0] = new CustomLayoutToken("(W)", delegate (EntityLayoutParams p, int h)
			{
				int num2 = -26;
                int num3 = 1;
                LayoutTileConstraint layoutTileConstraint = LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse;
                int? num4 = new int?(-25);
                int? num5 = new int?(2);

				return new LayoutTokenSpec(num2, num3, layoutTileConstraint, null, num4, num5, null, Ids.TerrainMaterials.GrassLush, null, false, false, 0);
            });
			bool flag = false;
            int? num = new int?(collapseThreshold);
			return layoutParser.ParseLayoutOrThrow(new EntityLayoutParams(predicate, array, flag, null, retainingVerticesLayout, delegate (TerrainVertexRel v, char c)
			{ 
				if (c != '#')
				{
					return v;
				}
            return v.WithExtraConstraint(LayoutTileConstraint.DisableTerrainPhysics);
            //}, null, num, null, default(Option<IEnumerable<KeyValuePair<char, int>>>), false, null, null), entityLayout);
        }, null, num, null, default(Option<IEnumerable<KeyValuePair<char, int>>>), false, null, null), new string[] {text,text });
}

        public RetainingWallProto CreateWallLegacy(ProtoRegistrator registrator, StaticEntityProto.ID iD, string locstr, Proto.ID toolbarID, EntityCostsTpl costs,
            int wallLength, int collapseThreshold, string[] retainingVertices, BetterLIDs.dPath dPath, int minHeight)
        {
            ProtosDb prototypesDb = registrator.PrototypesDb;
            ImmutableArray<ToolbarEntryData> categoriesProtos = registrator.GetCategoriesProtos(toolbarID);
            LocStr1 locStr1 = Loc.Str1(iD.ToString() + "__desc", locstr, "description of retaining wall");
            LocStr alreadyLocalizedStr = LocalizationManager.CreateAlreadyLocalizedStr(iD.ToString() + "_formatted", locStr1.Format(5.ToString()).Value);
            ProtosDb protosDb1 = prototypesDb;
            StaticEntityProto.ID retainingWall = iD;
            Proto.Str str1 = Proto.CreateStr((Proto.ID)iD, locstr, alreadyLocalizedStr);
            EntityLayout layout1 = createLayoutLegacy(registrator, wallLength, collapseThreshold, retainingVertices, minHeight);
            EntityCosts entityCosts1 = costs.MapToEntityCosts(registrator);
            ImmutableArray<ToolbarEntryData>? categories = new ImmutableArray<ToolbarEntryData>?(categoriesProtos);
            LayoutEntityProto.Gfx graphics1 = new LayoutEntityProto.Gfx(
                prefabPath: dPath.asset,
                customIconPath: dPath.icon,
                categories: categories, useInstancedRendering: true);
            return new RetainingWallProto(retainingWall, str1, layout1, entityCosts1, graphics1);
        }
        EntityLayout createLayoutLegacy(ProtoRegistrator registrator, int wallLengthTiles, int collapseThreshold, string[] retainingVerticesLayout, int minHeight)
        {
            int mHeight = minHeight;
            string str = "(W)".RepeatString(wallLengthTiles);
            EntityLayoutParser layoutParser = (EntityLayoutParser)registrator.LayoutParser;
            CustomLayoutToken[] customTokens = new CustomLayoutToken[1]

            {
                new CustomLayoutToken("(W)", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) => new LayoutTokenSpec(-6, 1, LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse | LayoutTileConstraint.Ocean, minTerrainHeight: -5, maxTerrainHeight: 0)))
            };
            string[] strArray1 = retainingVerticesLayout;
            int? nullable = new int?(collapseThreshold);
            Proto.ID? hardenedFloorSurfaceId = new Proto.ID?();
            string[] customVertexDataLayout = strArray1;
            int? customCollapseVerticesThreshold = nullable;
            ThicknessIRange? customPlacementRange = new ThicknessIRange?();
            Option<IEnumerable<KeyValuePair<char, int>>> customPortHeights = new Option<IEnumerable<KeyValuePair<char, int>>>();
            EntityLayoutParams layoutParams = new EntityLayoutParams(customTokens: (IEnumerable<CustomLayoutToken>)customTokens, hardenedFloorSurfaceId: hardenedFloorSurfaceId, customVertexDataLayout: customVertexDataLayout, customVertexTransformFn: (Func<TerrainVertexRel, char, TerrainVertexRel>)((v, c) => c != '#' ? v : v.WithExtraConstraint(LayoutTileConstraint.DisableTerrainPhysics)), customCollapseVerticesThreshold: customCollapseVerticesThreshold, customPlacementRange: customPlacementRange, customPortHeights: customPortHeights);
            string[] strArray2 = new string[2] { str, str };
            return layoutParser.ParseLayoutOrThrow(layoutParams, strArray2);

        }

    }

}