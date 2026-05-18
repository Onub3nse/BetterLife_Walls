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
                //.AddLayoutEntityToUnlock(BetterLIDs.Walls.wall1_block)
                .AddLayoutEntityToUnlock(BetterLIDs.Walls.wall1_straight)
                //.AddLayoutEntityToUnlock(BetterLIDs.Walls.wall1_straight2x)
                .AddLayoutEntityToUnlock(BetterLIDs.Walls.wall1_corner)
                //.AddLayoutEntityToUnlock(BetterLIDs.Walls.wall1_cross)
                //.AddLayoutEntityToUnlock(BetterLIDs.Walls.wall1_tee)
                //.AddLayoutEntityToUnlock(BetterLIDs.Walls.wall1_slope1)
                //.AddLayoutEntityToUnlock(BetterLIDs.Walls.wall1_slope2)
                //.AddLayoutEntityToUnlock(BetterLIDs.Walls.wall1_gate1)

                //.AddLayoutEntityToUnlock(BetterLIDs.Walls.lwall1_block)
                //.AddLayoutEntityToUnlock(BetterLIDs.Walls.lwall1_straight)
                //.AddLayoutEntityToUnlock(BetterLIDs.Walls.lwall1_straight2x)
                //.AddLayoutEntityToUnlock(BetterLIDs.Walls.lwall1_corner)
                //.AddLayoutEntityToUnlock(BetterLIDs.Walls.lwall1_cross)
                //.AddLayoutEntityToUnlock(BetterLIDs.Walls.lwall1_tee)
                //.AddLayoutEntityToUnlock(BetterLIDs.Walls.lwall1_slope1)
                //.AddLayoutEntityToUnlock(BetterLIDs.Walls.lwall1_slope2)

                //.AddLayoutEntityToUnlock(BetterLIDs.Walls.seawall1_straight)
                //.AddLayoutEntityToUnlock(BetterLIDs.Walls.seawall1_cornerIN)
                //.AddLayoutEntityToUnlock(BetterLIDs.Walls.seawall1_cornerOUT)
                .AddRequiredProto(Ids.Research.Cp2Packing)
                .AddRequirementForLifetimeProduction(Ids.Products.ConcreteSlab, 10)

                .BuildAndAdd(); 

            nodeProto.GridPosition = new Vector2i(4, -8);
            nodeProto.AddParent(registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(Ids.Research.CpPacking));

        }
    }
}
 