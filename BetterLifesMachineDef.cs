
using Mafi;
using Mafi.Base;
using Mafi.Base.Prototypes.Buildings;
using Mafi.Base.Prototypes.Trains;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Animations;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Factory.Machines;
using Mafi.Core.Factory.Transports;
using Mafi.Core.Mods;
using Mafi.Core.Ports.Io;
using Mafi.Core.Prototypes;
using Mafi.Core.Roads;
using Mafi.Core.Trains;
using Mafi.Curves;
using Mafi.Localization;
using System;
using System.Reflection;
//using static BetterLife.Prototypes.blRoadEntity;
using static BetterLife.Prototypes.CustomEntity;

namespace BetterLife_Walls;

internal class BetterLifeWalls : IModData
{
    public static EntityCostsTpl.Builder Build => new EntityCostsTpl.Builder();

    public CustomEntityPrototype CreateProto(ProtoRegistrator registrato, StaticEntityProto.ID id, string coment, string[] el, EntityCostsTpl ecTpl, string asp, string ico, Proto.ID cat, Fix32 nX, Fix32 nY, Fix32 nZ, ImmutableArray<AnimationParams> ap)
    {
        //Predicate<LayoutTile> predicate = null;
        CustomLayoutToken[] array = new CustomLayoutToken[6];
        array[0] = new CustomLayoutToken("=0=", delegate (EntityLayoutParams p, int h)
        {
            int heightFrom = h - 1;
            int? maxTerrainHeight3 = new int?(h - 1);
            Fix32? vehicleHeight2 = new Fix32?(h - 1);
            return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse, 0, null, maxTerrainHeight3, vehicleHeight2, null, null, false, false, 0);
        });
        array[1] = new CustomLayoutToken("(W)", delegate (EntityLayoutParams p0, int p1)
        {
            int? minTerrainHeight = new int?(-10);
            int? maxTerrainHeight = new int?(3);
            int num = -9;
            int num2 = 3;
            LayoutTileConstraint layoutTileConstraint = LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse;
            int? num3 = minTerrainHeight;
            int? num4 = maxTerrainHeight;
            return new LayoutTokenSpec(num, num2, layoutTileConstraint, null, num3, num4, null, null, null, false, false, 0);
        });
        array[2] = new CustomLayoutToken("-0-", delegate (EntityLayoutParams p0, int h)
        {
            LayoutTileConstraint layoutTileConstraint = LayoutTileConstraint.None;
            return new LayoutTokenSpec(0, h, layoutTileConstraint, null, null, new int?(h-1), null, null, null, false, false, 0);
        });
        array[3] = new CustomLayoutToken("_0=", delegate (EntityLayoutParams p, int h)
        {
            int heightFrom = h - 1;
            int? maxTerrainHeight3 = new int?(h - 1);
            Fix32? vehicleHeight2 = new Fix32?(h - 1);
            return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.UsingPillar, null, null, maxTerrainHeight3, vehicleHeight2, null, null, false, false, 0);
        });

        array[4] = new CustomLayoutToken("|0|", (param, height) =>
        {
            return new LayoutTokenSpec(
                constraint: LayoutTileConstraint.UsingPillar,
                heightFrom: 0,
                heightToExcl: height,
                maxTerrainHeight: 0,
                minTerrainHeight: 0
            );
        });
        array[5] = new CustomLayoutToken("h0.", delegate (EntityLayoutParams p, int h)
        {
            return new LayoutTokenSpec(h-1, h, LayoutTileConstraint.None, null, null, h-1,h-1, null, null, false, false, 0);
        });



        EntityLayoutParams entityLayoutParams = new EntityLayoutParams(
            customPlacementRange: new ThicknessIRange(0, TransportPillarProto.MAX_PILLAR_HEIGHT.Value - 1),
            customTokens: array
            );

        //EntityLayoutParams entityLayoutParams = new EntityLayoutParams(null, null, false, Ids.TerrainTileSurfaces.Metal1, null, null, null, null, default(Option<IEnumerable<KeyValuePair<char, int>>>), false);


        string[] initLayoutString = el;
        EntityLayout ltemp = registrato.LayoutParser.ParseLayoutOrThrow(entityLayoutParams, el);

        ImmutableArray<ToolbarEntryData> categories = ImmutableArray<ToolbarEntryData>.Empty;
        if (cat != BetterLIDs.ToolBars.HiddenProto)
        {
            categories = ImmutableArray.Create(registrato.GetCategory(cat));
        }


        Proto.Str ps = Proto.CreateStr(id, coment);
        EntityCosts ec = ecTpl.MapToEntityCosts(registrato);
        LayoutEntityProto.Gfx lg = new LayoutEntityProto.Gfx(
            prefabPath: asp,
            prefabOrigin: new RelTile3f(nX, nY, nZ),
            customIconPath: ico,
            categories: categories



            );
        //LayoutEntityProto.Gfx lg = new LayoutEntityProto.Gfx(asp, default(RelTile3f), ico, default(ColorRgba), false, null, new ImmutableArray<ToolbarCategoryProto>?(registrato.GetCategoriesProtos(cat)), false, false, null, null, default(ImmutableArray<string>), int.MaxValue, false);

        //registrato.PrototypesDb.Add<CustomEntityPrototype>(new CustomEntityPrototype(id, ps, ltemp, ec, lg, ap));
        return new CustomEntityPrototype(id, ps, ltemp, ec, lg, ap);
    }

    public void RegisterData(ProtoRegistrator registrator)
    {
        ImmutableArray<AnimationParams> noLoop2 = ImmutableArray.Create(new AnimationParams[]
        {
            AnimationParams.RepeatAutoTimes(Duration.FromYears(1))
        });

        ProtosDb prototypesDb = registrator.PrototypesDb;


        EntityCostsTpl wallCosts1 = Build.MaintenanceT1(0).Priority(8).Workers(2).CP(10).Product(15, Ids.Products.ConcreteSlab);
        EntityCostsTpl wallCosts2 = Build.MaintenanceT1(0).Priority(8).Workers(2).CP(20).Product(15, Ids.Products.ConcreteSlab);


        ImmutableArray<AnimationParams> noLoop = ImmutableArray.Create(new AnimationParams[]
        {
            AnimationParams.RepeatAutoTimes(Duration.FromYears(1))
        });
        ImmutableArray<AnimationParams> Loop = ImmutableArray.Create(new AnimationParams[]
        {
            AnimationParams.Loop(100.Percent(),true,"Rotating")
        });

    }




    public void CreateWallProto(ProtoRegistrator registrato, StaticEntityProto.ID staticId, string protoString, string coment, string[] el, string asp, string ico, Proto.ID cat)
    {
        ProtosDb prototypesDb = registrato.PrototypesDb;
        Predicate<LayoutTile> predicate = null;
        CustomLayoutToken[] array = new CustomLayoutToken[1];
        LocStr1 locStr = Loc.Str1(staticId.ToString() + "__desc", coment, "description of Retaining Wall");
        LocStr locStr2 = LocalizationManager.LoadOrCreateLocalizedString0(staticId.ToString() + "_formatted", locStr.Format(5.ToString()).Value);
        Proto.Str str = Proto.CreateStr(staticId, protoString, locStr2, null);
        StaticEntityProto.ID wallId = staticId;
        ImmutableArray<ToolbarEntryData> categoriesProtos = registrato.GetCategoriesProtos(new Proto.ID[] { cat });
        ImmutableArray<ToolbarEntryData>? immutableArray = new ImmutableArray<ToolbarEntryData>?(categoriesProtos);
        ProtosDb protosDb = prototypesDb;
        StaticEntityProto.ID id = wallId;
        Proto.Str str2 = str;
        EntityLayoutParser layoutParser = (EntityLayoutParser)registrato.LayoutParser;
        EntityCosts entityCosts = Costs.Buildings.RetainingWall1.MapToEntityCosts(registrato);


        array[0] = new CustomLayoutToken("(W)", delegate
        {
            int? num = new int?(-14);
            int? num2 = new int?(6);
            int num3 = -13;
            int num4 = 5;
            LayoutTileConstraint layoutTileConstraint = LayoutTileConstraint.None;
            int? num5 = num;
            int? num6 = num2;
            return new LayoutTokenSpec(num3, num4, layoutTileConstraint, null, num5, num6, null, Ids.TerrainMaterials.Slag, null, false, false, 0);
        });

        protosDb.Add<RetainingWallProto>(new RetainingWallProto(id, str2, layoutParser.ParseLayoutOrThrow(new EntityLayoutParams(predicate, array, false, null, null, delegate (TerrainVertexRel v, char c)
        {
            if (c != '#')
            {
                return v;
            }
            return v.WithExtraConstraint(LayoutTileConstraint.DisableTerrainPhysics);

        }, null, null, null, default), el), entityCosts, new LayoutEntityProto.Gfx(asp, new RelTile3f(0, 0, 0), ico, default(ColorRgba), false, null, immutableArray, true, false, null, null, default(ImmutableArray<string>), null, int.MaxValue)), false);
    }
}
internal class MachineDef : IModData
{
    public static EntityCostsTpl.Builder Build => new EntityCostsTpl.Builder();
    public static EntityCosts RoadCosts => new EntityCosts();

    public void RegisterData(ProtoRegistrator registrator)
    {

    }

}
