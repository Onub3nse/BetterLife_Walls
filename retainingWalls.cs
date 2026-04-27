using Mafi;
using Mafi.Base.Prototypes.Buildings;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Mods;
using Mafi.Core.Prototypes;
using Mafi.Localization;
using System;
using System.Collections.Generic;

namespace BetterLife_Walls
{
    internal class retainingWalls : IModData
    {
        public void RegisterData(ProtoRegistrator registrator)
        {
            string[] vertLayoutWall1AOneBlock =
            {
                "..",
                "##",
                ".."
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
            string[] vertLayoutWall1Corner =
            {
                ".#.",
                ".##",
                "..."
            };


            RetainingWallProto wall1aOneBlock = CreateWall(registrator, BetterLIDs.Walls.wall1_straight, "Retaining Wall Type A", BetterLIDs.ToolBars.toolWall1,
                BLCosts.Walls.Wall1, 2, 1, vertLayoutWall1AOneBlock, BetterLIDs.dPath.wall1straight);

            RetainingWallProto wall1aCross = CreateWall(registrator, BetterLIDs.Walls.wall1_cross, "Retaining Wall Cross Type A", BetterLIDs.ToolBars.toolWall1,
                BLCosts.Walls.Wall1, 2, 0, vertLayoutWall1Cross, BetterLIDs.dPath.wall1cross);

            RetainingWallProto wall1aTee = CreateWall(registrator, BetterLIDs.Walls.wall1_tee, "Retaining Wall Tee Type A", BetterLIDs.ToolBars.toolWall1,
                BLCosts.Walls.Wall1, 2, 0, vertLayoutWall1Tee, BetterLIDs.dPath.wall1tee);

            RetainingWallProto wall1aCorner = CreateWall(registrator, BetterLIDs.Walls.wall1_corner, "Retaining Wall Corner Type A", BetterLIDs.ToolBars.toolWall1,
                BLCosts.Walls.Wall1, 2, 0, vertLayoutWall1Corner, BetterLIDs.dPath.wall1corner);

            registrator.PrototypesDb.Add(wall1aOneBlock);
            registrator.PrototypesDb.Add(wall1aCorner);
            registrator.PrototypesDb.Add(wall1aCross);
            registrator.PrototypesDb.Add(wall1aTee);


        }
        public RetainingWallProto CreateWall(ProtoRegistrator registrator, StaticEntityProto.ID iD, string locstr, Proto.ID toolbarID, EntityCostsTpl costs,
            int wallLength, int collapseThreshold, string[] retainingVertices, BetterLIDs.dPath dPath)
        {
            ProtosDb prototypesDb = registrator.PrototypesDb;
            ImmutableArray<ToolbarEntryData> categoriesProtos = registrator.GetCategoriesProtos(toolbarID);
            LocStr1 locStr1 = Loc.Str1(iD.ToString() + "__desc", locstr, "description of retaining wall");
            LocStr alreadyLocalizedStr = LocalizationManager.CreateAlreadyLocalizedStr(iD.ToString() + "_formatted", locStr1.Format(5.ToString()).Value);
            ProtosDb protosDb1 = prototypesDb;
            StaticEntityProto.ID retainingWall = iD;
            Proto.Str str1 = Proto.CreateStr((Proto.ID)iD, locstr, alreadyLocalizedStr);
            EntityLayout layout1 = createLayout(registrator, wallLength, collapseThreshold, retainingVertices);
            EntityCosts entityCosts1 = costs.MapToEntityCosts(registrator);
            ImmutableArray<ToolbarEntryData>? categories = new ImmutableArray<ToolbarEntryData>?(categoriesProtos);
            LayoutEntityProto.Gfx graphics1 = new LayoutEntityProto.Gfx(
                prefabPath: dPath.asset,
                customIconPath: dPath.icon,
                categories: categories, useInstancedRendering: true);
            return new RetainingWallProto(retainingWall, str1, layout1, entityCosts1, graphics1);
        }
        EntityLayout createLayout(ProtoRegistrator registrator, int wallLengthTiles, int collapseThreshold, string[] retainingVerticesLayout)
        {
            string str = "(W)".RepeatString(wallLengthTiles);
            EntityLayoutParser layoutParser = (EntityLayoutParser)registrator.LayoutParser;
            CustomLayoutToken[] customTokens = new CustomLayoutToken[1]
            {
                new CustomLayoutToken("(W)", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) => new LayoutTokenSpec(-6, 1, LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse, minTerrainHeight: new int?(-5), maxTerrainHeight: new int?(0))))
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