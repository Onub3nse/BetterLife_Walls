using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Products;
using Mafi.Core.Prototypes;
using ProductID = Mafi.Core.Products.ProductProto.ID;

namespace BetterLife_Walls
{
    public partial class BetterLIDs
    {
        public partial class Products
        {
            public static readonly ProductID pTar = Ids.Products.CreateId("iTar");
        }
    }
    internal class productData : IModData
    {
        public void RegisterData(ProtoRegistrator registrator)
        {
            Proto.Str tarStrings = Proto.CreateStr(
                BetterLIDs.Products.pTar,
                "Tar",
                "A dark, thick flammable liquid distilled from wood or coal, consisting of a mixture of hydrocarbons, resins, alcohols, and other compounds. It is used in road-making and for coating and preserving timber.",
                null
            );
            CountableProductProto.Gfx tarGFX = new CountableProductProto.Gfx(
                "Assets/BetterLife/Products/tar.prefab",
                "Assets/BetterLife/RoadSignsIcons/Products/tar.png",
                CountableProductStackingMode.Auto,
                false,
                false
            );
            CountableProductProto tarProduct = new CountableProductProto(
                BetterLIDs.Products.pTar,
                tarStrings,
                new Quantity(3),
                true,
                tarGFX,
                0, // Base price
                false, // Can be sold
                true, // Can be bought
                false, // Is tradable
                null, // Upgraded from
                new PartialQuantity(1.ToFix32()), // Upgrade quantity
                null // Custom order proto
            );
            registrator.PrototypesDb.Add(tarProduct, false);
        }
    }
}