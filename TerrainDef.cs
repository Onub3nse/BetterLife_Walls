using Mafi;
using Mafi.Base;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Mods;
using Mafi.Core.Products;
using Mafi.Core.Prototypes;
using Mafi.Core.Terrain;
using System.Linq;


namespace BetterLife.Prototypes;

internal class TerrainDef : IModData

{
    public static EntityCostsTpl.Builder Build => new EntityCostsTpl.Builder();



    public void RegisterData(ProtoRegistrator registrator)
    {

        ProtosDb protosDb = registrator.PrototypesDb;

        TileSurfacesEdgesSpec tileSurfacesEdgesSpec = new TileSurfacesEdgesSpec
            (
                "Assets/Base/Terrain/Surfaces/ConcreteEdges/A-albedo.png",
                "Assets/Base/Terrain/Surfaces/ConcreteEdges/A-normals.png",
                "Assets/Base/Terrain/Surfaces/ConcreteEdges/A-smoothmetal.png",
                "Assets/Base/Terrain/Surfaces/ConcreteEdges/B-albedo.png",
                "Assets/Base/Terrain/Surfaces/ConcreteEdges/B-normals.png",
                "Assets/Base/Terrain/Surfaces/ConcreteEdges/B-smoothmetal.png",
                "Assets/Base/Terrain/Surfaces/ConcreteEdges/C-albedo.png",
                "Assets/Base/Terrain/Surfaces/ConcreteEdges/C-normals.png",
                "Assets/Base/Terrain/Surfaces/ConcreteEdges/C-smoothmetal.png",
                "Assets/Base/Terrain/Surfaces/ConcreteEdges/D-albedo.png",
                "Assets/Base/Terrain/Surfaces/ConcreteEdges/D-normals.png",
                "Assets/Base/Terrain/Surfaces/ConcreteEdges/D-smoothmetal.png"
             );

        TileSurfaceTextureSpec tileSurfaceTexureSpec = new TileSurfaceTextureSpec
            (
                Enumerable.Repeat<string>("Assets/Base/Terrain/Surfaces/Concrete/concreteBlock1a-256-albedo.png", 8).ToImmutableArray<string>(),
                Enumerable.Repeat<string>("Assets/Base/Terrain/Surfaces/Concrete/concreteBlock1a-256-normals.png", 8).ToImmutableArray<string>(),
                Enumerable.Repeat<string>("Assets/Base/Terrain/Surfaces/Concrete/concreteBlock1a-256-smoothmetal.png", 8).ToImmutableArray<string>()
                , false

            );

        TerrainTileSurfaceProto.Gfx tileSurfaceGfx = new TerrainTileSurfaceProto.Gfx
            (
                tileSurfaceTexureSpec,
                tileSurfacesEdgesSpec,
                0.25f,
                new ColorRgba(255, 0, 0),
                "Assets/BetterLife/RoadSignsIcons/Toolbar/Toolbar_Signs.png"
            );

        Proto.Str strl = Proto.CreateStr(BetterLIDs.Surfaces.speed1l, "speedTile1l");
        Proto.Str strr = Proto.CreateStr(BetterLIDs.Surfaces.speed1r, "speedTile1r");
        Proto.Str strn = Proto.CreateStr(BetterLIDs.Surfaces.speed1n, "speedTile1n");


        BetterLIDs.Surfaces.surface1l = new TerrainTileSurfaceProto(
            BetterLIDs.Surfaces.speed1l,
            strl,
            Percent.FromPercentVal(80),
            new ProductQuantity(protosDb.GetOrThrow<ProductProto>(Ids.Products.Dirt), new Quantity(5)), false,
            ImmutableArray<Proto.ID>.Empty,
            tileSurfaceGfx
            );
        BetterLIDs.Surfaces.surface1r = new TerrainTileSurfaceProto(
            BetterLIDs.Surfaces.speed1r,
            strr,
            Percent.FromPercentVal(80),
            new ProductQuantity(protosDb.GetOrThrow<ProductProto>(Ids.Products.Dirt), new Quantity(5)), false,
            ImmutableArray<Proto.ID>.Empty,
            tileSurfaceGfx
            );
        BetterLIDs.Surfaces.surface1n = new TerrainTileSurfaceProto(
            BetterLIDs.Surfaces.speed1n,
            strn,
            Percent.FromPercentVal(80),
            new ProductQuantity(protosDb.GetOrThrow<ProductProto>(Ids.Products.Dirt), new Quantity(5)), false,
            ImmutableArray<Proto.ID>.Empty,
            tileSurfaceGfx
            );

        protosDb.Add<TerrainTileSurfaceProto>(BetterLIDs.Surfaces.surface1l, false);
        protosDb.Add<TerrainTileSurfaceProto>(BetterLIDs.Surfaces.surface1r, false);
        protosDb.Add<TerrainTileSurfaceProto>(BetterLIDs.Surfaces.surface1n, false);

    }
}