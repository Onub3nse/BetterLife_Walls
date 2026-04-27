using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Research;

namespace BetterLife_Walls

{  
    internal class ResearchDt : IResearchNodesData
    {
        public void RegisterData(ProtoRegistrator registrator)
        {
            ResearchNodeProto nodeProto = registrator.ResearchNodeProtoBuilder

                .Start("Custom Retaining Walls", BetterLIDs.Research.resWalls1, 6)
                .Description("Adds new retraining walls to the game...")
                .AddLayoutEntityToUnlock(BetterLIDs.Walls.wall1_straight)
                .AddLayoutEntityToUnlock(BetterLIDs.Walls.wall1_corner)
                .AddLayoutEntityToUnlock(BetterLIDs.Walls.wall1_cross)
                .AddLayoutEntityToUnlock(BetterLIDs.Walls.wall1_tee)
                .AddRequiredProto(Ids.Research.Cp2Packing)
                .AddRequirementForLifetimeProduction(Ids.Products.Cement, 10)

                .BuildAndAdd();

            nodeProto.GridPosition = new Vector2i(4, -8);
            nodeProto.AddParent(registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(Ids.Research.CpPacking));

        }
    }
}
 