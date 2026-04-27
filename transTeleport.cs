using BetterLife;
using Mafi;
using Mafi.Base;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Mods;
using Mafi.Core.Ports.Io;
using Mafi.Core.Prototypes;
using System;
using System.Reflection;
using System.Text;

namespace BetterLife_Walls
{
    internal class transTeleport : IModData
    {
        public void RegisterData(ProtoRegistrator registrator)
        {

            IoPortShapeProto shapeFlat = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Ids.IoPortShapes.FlatConveyor);
            IoPortShapeProto shapeLoose = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Ids.IoPortShapes.LooseMaterialConveyor);
            IoPortShapeProto shapePipe = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Ids.IoPortShapes.Pipe);
            IoPortShapeProto shapeMolten = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Ids.IoPortShapes.MoltenMetalChannel);
            IoPortShapeProto shapeShaft = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Ids.IoPortShapes.Shaft);

            //registrator.PrototypesDb.TryRemove(Ids.IoPortShapes.FlatConveyor);
            //registrator.PrototypesDb.TryRemove(Ids.IoPortShapes.LooseMaterialConveyor);
            //registrator.PrototypesDb.TryRemove(Ids.IoPortShapes.Pipe);
            //registrator.PrototypesDb.TryRemove(Ids.IoPortShapes.MoltenMetalChannel);
            //registrator.PrototypesDb.TryRemove(Ids.IoPortShapes.Shaft);

            var disconnectedField1 = shapeFlat.Graphics.GetType().GetField("DisconnectedPortPrefabPath", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            disconnectedField1.SetValue(shapeFlat.Graphics, "Assets/BetterLife/Transports/ports/port.prefab");
            var disconnectedField2 = shapeFlat.Graphics.GetType().GetField("DisconnectedPortPrefabPathLod3", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            disconnectedField2.SetValue(shapeFlat.Graphics, "Assets/BetterLife/Transports/ports/port.prefab");


            // Mafi Original
            //registrator.PrototypesDb.Add<IoPortShapeProto>(new IoPortShapeProto(Ids.IoPortShapes.FlatConveyor, shapeFlat.Strings, '#', CountableProductProto.ProductType, new IoPortShapeProto.Gfx("Assets/BetterLife/Transports/ports/port.prefab", "Assets/Base/Transports/ConveyorUnit/Port-Lod3.prefab", false, "Assets/Base/Transports/ConveyorUnit/PortEnd.prefab", "Assets/Base/Transports/ConveyorUnit/PortEnd-Lod3.prefab"), null), false);
            //registrator.PrototypesDb.Add<IoPortShapeProto>(new IoPortShapeProto(Ids.IoPortShapes.LooseMaterialConveyor, shapeLoose.Strings, '~', LooseProductProto.ProductType, new IoPortShapeProto.Gfx("Assets/BetterLife/Transports/ports/loose/port.prefab", "Assets/Base/Transports/ConveyorLoose/Port-Lod3.prefab", false, "Assets/Base/Transports/ConveyorLoose/PortEnd.prefab", "Assets/Base/Transports/ConveyorLoose/PortEnd-Lod3.prefab"), null), false);
            //registrator.PrototypesDb.Add<IoPortShapeProto>(new IoPortShapeProto(Ids.IoPortShapes.MoltenMetalChannel, shapePipe.Strings, '\'', MoltenProductProto.ProductType, new IoPortShapeProto.Gfx("Assets/BetterLife/Transports/ports/port.prefab", "Assets/Base/Transports/MoltenChannel/Port-Lod3.prefab", false, "Assets/Base/Transports/MoltenChannel/PortEnd.prefab", "Assets/Base/Transports/MoltenChannel/PortEnd-Lod3.prefab"), null), false);
            //registrator.PrototypesDb.Add<IoPortShapeProto>(new IoPortShapeProto(Ids.IoPortShapes.Pipe, shapeMolten.Strings, '@', FluidProductProto.ProductType, new IoPortShapeProto.Gfx("Assets/BetterLife/Transports/ports/port.prefab", "Assets/Base/Transports/Pipes/Port-Lod3.prefab", true, default(Option<string>), default(Option<string>)), null), false);
            //registrator.PrototypesDb.Add<IoPortShapeProto>(new IoPortShapeProto(Ids.IoPortShapes.Shaft, shapeShaft.Strings, '|', ProductType.NONE, new IoPortShapeProto.Gfx("Assets/BetterLife/Transports/ports/port.prefab", "Assets/Base/Transports/Shaft/Port-Lod3.prefab", false, default(Option<string>), default(Option<string>)), new Tag[] { CoreProtoTags.MechanicalShaft }), false);

            // Mafi Original
            //registrator.PrototypesDb.Add<IoPortShapeProto>(new IoPortShapeProto(Ids.IoPortShapes.FlatConveyor, Proto.Str.Empty, '#', CountableProductProto.ProductType, new IoPortShapeProto.Gfx("Assets/Base/Transports/ConveyorUnit/Port.prefab", "Assets/Base/Transports/ConveyorUnit/Port-Lod3.prefab", false, "Assets/Base/Transports/ConveyorUnit/PortEnd.prefab", "Assets/Base/Transports/ConveyorUnit/PortEnd-Lod3.prefab"), null), false);
            //registrator.PrototypesDb.Add<IoPortShapeProto>(new IoPortShapeProto(Ids.IoPortShapes.LooseMaterialConveyor, Proto.Str.Empty, '~', LooseProductProto.ProductType, new IoPortShapeProto.Gfx("Assets/Base/Transports/ConveyorLoose/Port.prefab", "Assets/Base/Transports/ConveyorLoose/Port-Lod3.prefab", false, "Assets/Base/Transports/ConveyorLoose/PortEnd.prefab", "Assets/Base/Transports/ConveyorLoose/PortEnd-Lod3.prefab"), null), false);
            //registrator.PrototypesDb.Add<IoPortShapeProto>(new IoPortShapeProto(Ids.IoPortShapes.MoltenMetalChannel, Proto.Str.Empty, '\'', MoltenProductProto.ProductType, new IoPortShapeProto.Gfx("Assets/Base/Transports/MoltenChannel/Port.prefab", "Assets/Base/Transports/MoltenChannel/Port-Lod3.prefab", false, "Assets/Base/Transports/MoltenChannel/PortEnd.prefab", "Assets/Base/Transports/MoltenChannel/PortEnd-Lod3.prefab"), null), false);
            //registrator.PrototypesDb.Add<IoPortShapeProto>(new IoPortShapeProto(Ids.IoPortShapes.Pipe, Proto.Str.Empty, '@', FluidProductProto.ProductType, new IoPortShapeProto.Gfx("Assets/Base/Transports/Pipes/Port.prefab", "Assets/Base/Transports/Pipes/Port-Lod3.prefab", true, default(Option<string>), default(Option<string>)), null), false);
            //registrator.PrototypesDb.Add<IoPortShapeProto>(new IoPortShapeProto(Ids.IoPortShapes.Shaft, Proto.Str.Empty, '|', ProductType.NONE, new IoPortShapeProto.Gfx("Assets/Base/Transports/Shaft/Port.prefab", "Assets/Base/Transports/Shaft/Port-Lod3.prefab", false, default(Option<string>), default(Option<string>)), new Tag[] { CoreProtoTags.MechanicalShaft }), false);




            //registrator.PrototypesDb.Add<IoPortShapeProto>(new IoPortShapeProto(BetterLIDs.PortShapes.mFlat, Proto.Str.Empty, '&', CountableProductProto.ProductType, new IoPortShapeProto.Gfx("Assets/BetterLife/Transports/ports/port.prefab", "Assets/BetterLife/Transports/ports/port.prefab", false, "Assets/Base/Transports/ConveyorUnit/PortEnd.prefab", "Assets/Base/Transports/ConveyorUnit/PortEnd-Lod3.prefab"), null), false);
            //registrator.PrototypesDb.Add<IoPortShapeProto>(new IoPortShapeProto(BetterLIDs.PortShapes.mLoose, Proto.Str.Empty, '¬', LooseProductProto.ProductType, new IoPortShapeProto.Gfx("Assets/BetterLife/Transports/ports/port.prefab", "Assets/BetterLife/Transports/ports/port.prefab", false, "Assets/Base/Transports/ConveyorLoose/PortEnd.prefab", "Assets/Base/Transports/ConveyorLoose/PortEnd-Lod3.prefab"), null), false);
            //registrator.PrototypesDb.Add<IoPortShapeProto>(new IoPortShapeProto(BetterLIDs.PortShapes.mMolten, Proto.Str.Empty, 'ç', MoltenProductProto.ProductType, new IoPortShapeProto.Gfx("Assets/BetterLife/Transports/ports/port.prefab", "Assets/BetterLife/Transports/ports/port.prefab", false, "Assets/Base/Transports/MoltenChannel/PortEnd.prefab", "Assets/Base/Transports/MoltenChannel/PortEnd-Lod3.prefab"), null), false);
            //registrator.PrototypesDb.Add<IoPortShapeProto>(new IoPortShapeProto(BetterLIDs.PortShapes.mPipe, Proto.Str.Empty, '*', FluidProductProto.ProductType, new IoPortShapeProto.Gfx("Assets/BetterLife/Transports/ports/port.prefab", "Assets/BetterLife/Transports/ports/port.prefab", true, default(Option<string>), default(Option<string>)), null), false);
            //registrator.PrototypesDb.Add<IoPortShapeProto>(new IoPortShapeProto(BetterLIDs.PortShapes.mShaft, Proto.Str.Empty, '$', ProductType.NONE, new IoPortShapeProto.Gfx("Assets/BetterLife/Transports/ports/port.prefab", "Assets/BetterLife/Transports/ports/port.prefab", false, default(Option<string>), default(Option<string>)), new Tag[] { CoreProtoTags.MechanicalShaft }), false);

            //IoPortShapeProto shapeFlat = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(BetterLIDs.PortShapes.mFlat);
            //IoPortShapeProto shapeLoose = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(BetterLIDs.PortShapes.mLoose);
            //IoPortShapeProto shapePipe = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(BetterLIDs.PortShapes.mPipe);
            //IoPortShapeProto shapeMolten = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(BetterLIDs.PortShapes.mMolten);
            //IoPortShapeProto shapeShaft = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(BetterLIDs.PortShapes.mFlat);

            //TransportProto transportFlat = registrator.PrototypesDb.GetOrThrow<TransportProto>(Ids.Transports.FlatConveyor);

            //LocStr locStr = Loc.Str(Ids.Transports.FlatConveyor.Value + "BT__name", "BT Flat conveyor", "flat conveyor belt for transportation of unit products");
            //LocStr locStr2 = Loc.Str("FlatConveyorFormattedFirst__desc", "Transports unit or packaged products. Can carry multiple product types at the same time.", "description of flat conveyor belt");
            //Proto.Str str = Proto.CreateStrFromLocalized(BetterLIDs.newTransports.newtransFlat, locStr.AppendRomanNumeral(3), locStr2);
            //Option<TerrainTileSurfaceProto> option = registrator.PrototypesDb.Get<TerrainTileSurfaceProto>(Ids.TerrainTileSurfaces.DefaultConcrete);
            //TransportProto mTransportFlat = new TransportProto(BetterLIDs.newTransports.newtransFlat, str,
            //    transportFlat.SurfaceRelativeHeight,
            //    transportFlat.MaxQuantityPerTransportedProduct,
            //    transportFlat.TransportedProductsSpacing,
            //    transportFlat.SpeedPerTick,
            //    transportFlat.ZStepLength,
            //    transportFlat.NeedsPillarsAtGround,
            //    transportFlat.CanBeBuried,
            //    option,
            //    transportFlat.MaxPillarSupportRadius,
            //    shapeFlat,
            //    transportFlat.BaseElectricityCost,
            //    transportFlat.CornersSharpnessPercent,
            //    transportFlat.AllowMixedProducts,
            //    transportFlat.IsBuildable,
            //    transportFlat.Costs,
            //    transportFlat.ConstructionDurationPerProduct,
            //    transportFlat.Graphics);
            //registrator.PrototypesDb.Add(mTransportFlat);







            string[] transPORT10 =
            {
                            "-6-                        -6-"
                        };
            string[] transPORT20 =
            { //"111222333444555666777888999000111222333444555666777888999000"
                            "-6-                                                      -6-"
                        };
            string[] transPORT100 =
            { //"111222333444555666777888999000111222333444555666777888999000111222333444555666777888999000111222333444555666777888999000111222333444555666777888999000"
                            "-6-                                                                                                                                                -6-"
                        };
            string[] transFIX =
            {
                                        "-1-"
                        };
            string[] balancer0 =
            {
                                        "-1-"
                        };
            string[] balancer1 =
            {
                                        "-1-"
                        };
            string[] balancer2 =
            {
                                        "-2-"
                        };
            string[] balancer3 =
            {
                                        "-3-"
                        };
            string[] balancer4 =
            {
                                        "-4-"
                        };
            string[] balancer5 =
            {
                                        "-5-"
                        };
            string[] loader1 =
            {
                                        "-1-   -1-   -1-"
                        };
            string[] trBar2m =
            {
                                        "-1--1-"
                        };
            string[] trBar4m =
            {
                                        "-1-      -1-"
                        };
            string[] trBar10m =
            {
                                        "-1-                        -1-"
                        };


            blZipperProto bal5_flat = CreateProto(registrator, BetterLIDs.transPorts.balancer5flat, "Balancer 5h", balancer5, BLCosts.BalancerCosts(5),
                BetterLIDs.dPath.balancer5_flat.asset, BetterLIDs.dPath.balancer5_flat.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeFlat, 5), false, null);
            blZipperProto bal4_flat = CreateProto(registrator, BetterLIDs.transPorts.balancer4flat, "Balancer 4h", balancer4, BLCosts.BalancerCosts(4),
                BetterLIDs.dPath.balancer4_flat.asset, BetterLIDs.dPath.balancer4_flat.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeFlat, 4), false, bal5_flat);
            blZipperProto bal3_flat = CreateProto(registrator, BetterLIDs.transPorts.balancer3flat, "Balancer Flat", balancer3, BLCosts.BalancerCosts(3),
                BetterLIDs.dPath.balancer3_flat.asset, BetterLIDs.dPath.balancer3_flat.icon,
                BetterLIDs.ToolBars.Balancers_Flat, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeFlat, 3), false, bal4_flat);
            blZipperProto bal2_flat = CreateProto(registrator, BetterLIDs.transPorts.balancer2flat, "Balancer 2h", balancer2, BLCosts.BalancerCosts(2),
                BetterLIDs.dPath.balancer2_flat.asset, BetterLIDs.dPath.balancer2_flat.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeFlat, 2), false, bal3_flat);
            blZipperProto bal1_flat = CreateProto(registrator, BetterLIDs.transPorts.balancer1flat, "Balancer 1h", balancer1, BLCosts.BalancerCosts(1),
                BetterLIDs.dPath.balancer1_flat.asset, BetterLIDs.dPath.balancer1_flat.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeFlat, 1), false, bal2_flat);
            blZipperProto bal0_flat = CreateProto(registrator, BetterLIDs.transPorts.balancer0flat, "Balancer Flat", balancer0, BLCosts.BalancerCosts(0),
                BetterLIDs.dPath.balancer0_flat.asset, BetterLIDs.dPath.balancer0_flat.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeFlat, 0), false, bal1_flat);


            blZipperProto bal5_loose = CreateProto(registrator, BetterLIDs.transPorts.balancer5loose, "Balancer 5h", balancer5, BLCosts.BalancerCosts(5),
                BetterLIDs.dPath.balancer5_loose.asset, BetterLIDs.dPath.balancer5_loose.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeLoose, 5), false, null);
            blZipperProto bal4_loose = CreateProto(registrator, BetterLIDs.transPorts.balancer4loose, "Balancer 4h", balancer4, BLCosts.BalancerCosts(4),
                BetterLIDs.dPath.balancer4_loose.asset, BetterLIDs.dPath.balancer4_loose.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeLoose, 4), false, bal5_loose);

            blZipperProto bal3_loose = CreateProto(registrator, BetterLIDs.transPorts.balancer3loose, "Balancer Loose", balancer3, BLCosts.BalancerCosts(3),
                BetterLIDs.dPath.balancer3_loose.asset, BetterLIDs.dPath.balancer3_loose.icon,
                BetterLIDs.ToolBars.Balancers_Loose, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeLoose, 3), false, bal4_loose);

            blZipperProto bal2_loose = CreateProto(registrator, BetterLIDs.transPorts.balancer2loose, "Balancer 2h", balancer2, BLCosts.BalancerCosts(2),
                BetterLIDs.dPath.balancer2_loose.asset, BetterLIDs.dPath.balancer2_loose.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeLoose, 2), false, bal3_loose);
            blZipperProto bal1_loose = CreateProto(registrator, BetterLIDs.transPorts.balancer1loose, "Balancer 1h", balancer1, BLCosts.BalancerCosts(1),
                BetterLIDs.dPath.balancer1_loose.asset, BetterLIDs.dPath.balancer1_loose.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeLoose, 1), false, bal2_loose);
            blZipperProto bal0_loose = CreateProto(registrator, BetterLIDs.transPorts.balancer0loose, "Balancers Loose", balancer0, BLCosts.BalancerCosts(0),
                BetterLIDs.dPath.balancer0_loose.asset, BetterLIDs.dPath.balancer0_loose.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeLoose, 0), false, bal1_loose);


            blZipperProto bal5_pipe = CreateProto(registrator, BetterLIDs.transPorts.balancer5pipe, "Balancer 5h", balancer5, BLCosts.BalancerCosts(5),
                BetterLIDs.dPath.balancer5_pipe.asset, BetterLIDs.dPath.balancer5_pipe.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapePipe, 5), false, null);

            blZipperProto bal4_pipe = CreateProto(registrator, BetterLIDs.transPorts.balancer4pipe, "Balancer 4h", balancer4, BLCosts.BalancerCosts(4),
                BetterLIDs.dPath.balancer4_pipe.asset, BetterLIDs.dPath.balancer4_pipe.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapePipe, 4), false, bal5_pipe);

            blZipperProto bal3_pipe = CreateProto(registrator, BetterLIDs.transPorts.balancer3pipe, "Balancer 3h", balancer3, BLCosts.BalancerCosts(3),
                BetterLIDs.dPath.balancer3_pipe.asset, BetterLIDs.dPath.balancer3_pipe.icon,
                BetterLIDs.ToolBars.Balancers_Pipe, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapePipe, 3), false, bal4_pipe);

            blZipperProto bal2_pipe = CreateProto(registrator, BetterLIDs.transPorts.balancer2pipe, "Balancer 2h", balancer2, BLCosts.BalancerCosts(2),
                BetterLIDs.dPath.balancer2_pipe.asset, BetterLIDs.dPath.balancer2_pipe.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapePipe, 2), false, bal3_pipe);

            blZipperProto bal1_pipe = CreateProto(registrator, BetterLIDs.transPorts.balancer1pipe, "Balancer 1h", balancer1, BLCosts.BalancerCosts(1),
                BetterLIDs.dPath.balancer1_pipe.asset, BetterLIDs.dPath.balancer1_pipe.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapePipe, 1), false, bal2_pipe);

            blZipperProto bal0_pipe = CreateProto(registrator, BetterLIDs.transPorts.balancer0pipe, "Balancers Pipe", balancer0, BLCosts.BalancerCosts(0),
                BetterLIDs.dPath.balancer0_pipe.asset, BetterLIDs.dPath.balancer0_pipe.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapePipe, 0), false, bal1_pipe);


            blZipperProto bal5_molten = CreateProto(registrator, BetterLIDs.transPorts.balancer5molten, "Balancer 5h", balancer5, BLCosts.BalancerCosts(5),
                BetterLIDs.dPath.balancer5_molten.asset, BetterLIDs.dPath.balancer5_molten.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeMolten, 5), false, null);

            blZipperProto bal4_molten = CreateProto(registrator, BetterLIDs.transPorts.balancer4molten, "Balancer 4h", balancer4, BLCosts.BalancerCosts(4),
                BetterLIDs.dPath.balancer4_molten.asset, BetterLIDs.dPath.balancer4_molten.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeMolten, 4), false, bal5_molten);

            blZipperProto bal3_molten = CreateProto(registrator, BetterLIDs.transPorts.balancer3molten, "Balancer 3h", balancer3, BLCosts.BalancerCosts(3),
                BetterLIDs.dPath.balancer3_molten.asset, BetterLIDs.dPath.balancer3_molten.icon,
                BetterLIDs.ToolBars.Balancers_Molten, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeMolten, 3), false, bal4_molten);

            blZipperProto bal2_molten = CreateProto(registrator, BetterLIDs.transPorts.balancer2molten, "Balancer 2h", balancer2, BLCosts.BalancerCosts(2),
                BetterLIDs.dPath.balancer2_molten.asset, BetterLIDs.dPath.balancer2_molten.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeMolten, 2), false, bal3_molten);

            blZipperProto bal1_molten = CreateProto(registrator, BetterLIDs.transPorts.balancer1molten, "Balancer 1h", balancer1, BLCosts.BalancerCosts(1),
                BetterLIDs.dPath.balancer1_molten.asset, BetterLIDs.dPath.balancer1_molten.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeMolten, 1), false, bal2_molten);

            blZipperProto bal0_molten = CreateProto(registrator, BetterLIDs.transPorts.balancer0molten, "Balancers Molten", balancer0, BLCosts.BalancerCosts(0),
                BetterLIDs.dPath.balancer0_molten.asset, BetterLIDs.dPath.balancer0_molten.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeMolten, 0), false, bal1_molten);



            blZipperProto bal5_shaft = CreateProto(registrator, BetterLIDs.transPorts.balancer5shaft, "Balancer 5h", balancer5, BLCosts.BalancerCosts(5),
                BetterLIDs.dPath.balancer5_shaft.asset, BetterLIDs.dPath.balancer5_shaft.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeShaft, 5), false, null);

            blZipperProto bal4_shaft = CreateProto(registrator, BetterLIDs.transPorts.balancer4shaft, "Balancer 4h", balancer4, BLCosts.BalancerCosts(4),
                BetterLIDs.dPath.balancer4_shaft.asset, BetterLIDs.dPath.balancer4_shaft.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeShaft, 4), false, bal5_shaft);

            blZipperProto bal3_shaft = CreateProto(registrator, BetterLIDs.transPorts.balancer3shaft, "Balancer 3h", balancer3, BLCosts.BalancerCosts(3),
                BetterLIDs.dPath.balancer3_shaft.asset, BetterLIDs.dPath.balancer3_shaft.icon,
                BetterLIDs.ToolBars.Balancers_Shaft, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeShaft, 3), false, bal4_shaft);

            blZipperProto bal2_shaft = CreateProto(registrator, BetterLIDs.transPorts.balancer2shaft, "Balancer 2h", balancer2, BLCosts.BalancerCosts(2),
                BetterLIDs.dPath.balancer2_shaft.asset, BetterLIDs.dPath.balancer2_shaft.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeShaft, 2), false, bal3_shaft);

            blZipperProto bal1_shaft = CreateProto(registrator, BetterLIDs.transPorts.balancer1shaft, "Balancer 1h", balancer1, BLCosts.BalancerCosts(1),
                BetterLIDs.dPath.balancer1_shaft.asset, BetterLIDs.dPath.balancer1_shaft.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeShaft, 1), false, bal2_shaft);

            blZipperProto bal0_shaft = CreateProto(registrator, BetterLIDs.transPorts.balancer0shaft, "Balancers Shaft", balancer0, BLCosts.BalancerCosts(0),
                BetterLIDs.dPath.balancer0_shaft.asset, BetterLIDs.dPath.balancer0_shaft.icon,
                BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, true, portTemplates.balancersShapes.shapeBalancer(shapeShaft, 0), false, bal1_shaft);

            // Automated transPORTS prefab naming (7 models) FLAT
            blZipperProto prevProto1 = null;
            blZipperProto prevProto2 = null;
            int maxElements = 10;

            maxElements = 7;
            for (int i = maxElements; i >= 0; i--)
            {

                string protoIDprefab = $"Assets/BetterLife/Transports/transportbars/prefabs/flat/transbar{i:D2}flat.prefab";
                string protoIDName = $"transBAR{i:D2}";
                StringBuilder protoLayout1 = new StringBuilder();
                //protoLayout1.Append("-1-");
                //for (int g = i + 2; g > 0; g--)
                //{
                //    protoLayout1.Append("   ");
                //}
                protoLayout1.Append("-1-");
                string[] protoLayout2 = new string[1]; protoLayout2[0] = protoLayout1.ToString();

                IoPortTemplate[] temp = new IoPortTemplate[]
                {
                            new IoPortTemplate(new PortSpec('A', IoPortType.Input, shapeFlat, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                            new IoPortTemplate(new PortSpec('B', IoPortType.Input, shapeFlat, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('C', IoPortType.Input, shapeFlat, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

                            new IoPortTemplate(new PortSpec('D', IoPortType.Output, shapeFlat, false), new RelTile3i(i + 3  , 0, 0), Direction90.PlusX),
                            new IoPortTemplate(new PortSpec('E', IoPortType.Output, shapeFlat, false), new RelTile3i(i + 3  , 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('F', IoPortType.Output, shapeFlat, false), new RelTile3i(i + 3  , 0, 0), Direction90.PlusY),

                };
                //blZipperProto.ID idTransPort = new StaticEntityProto.ID(protoIDName);
                Proto.ID toolbarID = BetterLIDs.ToolBars.HiddenProto;
                string toolbarTitle = $"TransBAR flat {i:D2}";
                if (i == 3)
                {
                    toolbarID = BetterLIDs.ToolBars.Balancers_Flat;
                }
                if (i == maxElements)
                {
                    prevProto2 = CreateProto(registrator, new StaticEntityProto.ID(protoIDName), toolbarTitle, protoLayout2, BLCosts.BalancerCosts(3),
                        protoIDprefab, BetterLIDs.dPath.transBar4flat.icon,
                    toolbarID, 0, 0, 0, true, temp, false, null);
                    prevProto1 = prevProto2;
                }
                else
                {
                    prevProto2 = CreateProto(registrator, new StaticEntityProto.ID(protoIDName), toolbarTitle, protoLayout2, BLCosts.BalancerCosts(3),
                        protoIDprefab, BetterLIDs.dPath.transBar4flat.icon,
                    toolbarID, 0, 0, 0, true, temp, false, prevProto1);
                    prevProto1 = prevProto2;
                }
            }

            maxElements = 7;
            for (int i = maxElements; i >= 0; i--)
            {

                string protoIDprefab = $"Assets/BetterLife/Transports/transportbars/prefabs/loose/transbar{i:D2}loose.prefab";
                string protoIDName = $"transBAR{i:D2}loose";
                StringBuilder protoLayout1 = new StringBuilder();
                protoLayout1.Append("-1-");
                //for (int g = i + 2; g > 0; g--)
                //{
                //    protoLayout1.Append("   ");
                //}
                protoLayout1.Append("-1-");
                string[] protoLayout2 = new string[1]; protoLayout2[0] = protoLayout1.ToString();

                IoPortTemplate[] temp = new IoPortTemplate[]
                {
                            new IoPortTemplate(new PortSpec('A', IoPortType.Input, shapeLoose, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                            new IoPortTemplate(new PortSpec('B', IoPortType.Input, shapeLoose, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('C', IoPortType.Input, shapeLoose, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

                            new IoPortTemplate(new PortSpec('D', IoPortType.Output, shapeLoose, false), new RelTile3i(i + 3, 0, 0), Direction90.PlusX),
                            new IoPortTemplate(new PortSpec('E', IoPortType.Output, shapeLoose, false), new RelTile3i(i + 3, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('F', IoPortType.Output, shapeLoose, false), new RelTile3i(i + 3, 0, 0), Direction90.PlusY),

                };
                //blZipperProto.ID idTransPort = new StaticEntityProto.ID(protoIDName);
                Proto.ID toolbarID = BetterLIDs.ToolBars.HiddenProto;
                string toolbarTitle = $"TransBAR loose {i:D2}";
                if (i == 3)
                {
                    toolbarID = BetterLIDs.ToolBars.Balancers_Loose;
                }
                if (i == maxElements)
                {
                    prevProto2 = CreateProto(registrator, new StaticEntityProto.ID(protoIDName), toolbarTitle, protoLayout2, BLCosts.BalancerCosts(3),
                        protoIDprefab, BetterLIDs.dPath.transBar4flat.icon,
                    toolbarID, 0, 0, 0, true, temp, false, null);
                    prevProto1 = prevProto2;
                }
                else
                {
                    prevProto2 = CreateProto(registrator, new StaticEntityProto.ID(protoIDName), toolbarTitle, protoLayout2, BLCosts.BalancerCosts(3),
                        protoIDprefab, BetterLIDs.dPath.transBar4flat.icon,
                    toolbarID, 0, 0, 0, true, temp, false, prevProto1);
                    prevProto1 = prevProto2;
                }
            }
            maxElements = 7;
            for (int i = maxElements; i >= 0; i--)
            {

                string protoIDprefab = $"Assets/BetterLife/Transports/transportbars/prefabs/pipe/transbar{i:D2}pipe.prefab";
                string protoIDName = $"transBAR{i:D2}pipe";
                StringBuilder protoLayout1 = new StringBuilder();
                protoLayout1.Append("-1-");
                //for (int g = i + 2; g > 0; g--)
                //{
                //    protoLayout1.Append("   ");
                //}
                protoLayout1.Append("-1-");
                string[] protoLayout2 = new string[1]; protoLayout2[0] = protoLayout1.ToString();

                IoPortTemplate[] temp = new IoPortTemplate[]
                {
                            new IoPortTemplate(new PortSpec('A', IoPortType.Input, shapePipe, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                            new IoPortTemplate(new PortSpec('B', IoPortType.Input, shapePipe, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('C', IoPortType.Input, shapePipe, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

                            new IoPortTemplate(new PortSpec('D', IoPortType.Output, shapePipe, false), new RelTile3i(i + 3, 0, 0), Direction90.PlusX),
                            new IoPortTemplate(new PortSpec('E', IoPortType.Output, shapePipe, false), new RelTile3i(i + 3, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('F', IoPortType.Output, shapePipe, false), new RelTile3i(i + 3, 0, 0), Direction90.PlusY),

                };
                //blZipperProto.ID idTransPort = new StaticEntityProto.ID(protoIDName);
                Proto.ID toolbarID = BetterLIDs.ToolBars.HiddenProto;
                string toolbarTitle = $"TransBAR pipe {i:D2}";
                if (i == 3)
                {
                    toolbarID = BetterLIDs.ToolBars.Balancers_Pipe;
                }
                if (i == maxElements)
                {
                    prevProto2 = CreateProto(registrator, new StaticEntityProto.ID(protoIDName), toolbarTitle, protoLayout2, BLCosts.BalancerCosts(3),
                        protoIDprefab, BetterLIDs.dPath.transBar4pipe.icon,
                    toolbarID, 0, 0, 0, true, temp, false, null);
                    prevProto1 = prevProto2;
                }
                else
                {
                    prevProto2 = CreateProto(registrator, new StaticEntityProto.ID(protoIDName), toolbarTitle, protoLayout2, BLCosts.BalancerCosts(3),
                        protoIDprefab, BetterLIDs.dPath.transBar4pipe.icon,
                    toolbarID, 0, 0, 0, true, temp, false, prevProto1);
                    prevProto1 = prevProto2;
                }
            }
            maxElements = 7;
            for (int i = maxElements; i >= 0; i--)
            {

                string protoIDprefab = $"Assets/BetterLife/Transports/transportbars/prefabs/molten/transbar{i:D2}molten.prefab";
                string protoIDName = $"transBAR{i:D2}molten";
                StringBuilder protoLayout1 = new StringBuilder();
                protoLayout1.Append("-1-");
                //for (int g = i + 2; g > 0; g--)
                //{
                //    protoLayout1.Append("   ");
                //}
                //protoLayout1.Append("-1-");
                string[] protoLayout2 = new string[1]; protoLayout2[0] = protoLayout1.ToString();

                IoPortTemplate[] temp = new IoPortTemplate[]
                {
                            new IoPortTemplate(new PortSpec('A', IoPortType.Input, shapeMolten, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                            new IoPortTemplate(new PortSpec('B', IoPortType.Input, shapeMolten, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('C', IoPortType.Input, shapeMolten, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

                            new IoPortTemplate(new PortSpec('D', IoPortType.Output, shapeMolten, false), new RelTile3i(i + 3 , 0, 0), Direction90.PlusX),
                            new IoPortTemplate(new PortSpec('E', IoPortType.Output, shapeMolten, false), new RelTile3i(i + 3 , 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('F', IoPortType.Output, shapeMolten, false), new RelTile3i(i + 3 , 0, 0), Direction90.PlusY),

                };
                //blZipperProto.ID idTransPort = new StaticEntityProto.ID(protoIDName);
                Proto.ID toolbarID = BetterLIDs.ToolBars.HiddenProto;
                string toolbarTitle = $"TransBAR molten {i:D2}";
                if (i == 3)
                {
                    toolbarID = BetterLIDs.ToolBars.Balancers_Molten;
                }
                if (i == maxElements)
                {
                    prevProto2 = CreateProto(registrator, new StaticEntityProto.ID(protoIDName), toolbarTitle, protoLayout2, BLCosts.BalancerCosts(3),
                        protoIDprefab, BetterLIDs.dPath.transBar4molten.icon,
                    toolbarID, 0, 0, 0, true, temp, false, null);
                    prevProto1 = prevProto2;
                }
                else
                {
                    prevProto2 = CreateProto(registrator, new StaticEntityProto.ID(protoIDName), toolbarTitle, protoLayout2, BLCosts.BalancerCosts(3),
                        protoIDprefab, BetterLIDs.dPath.transBar4molten.icon,
                    toolbarID, 0, 0, 0, true, temp, false, prevProto1);
                    prevProto1 = prevProto2;
                }
            }

            maxElements = 7;
            for (int i = maxElements; i >= 0; i--)
            {

                string protoIDprefab = $"Assets/BetterLife/Transports/transportbars/prefabs/shaft/transbar{i:D2}shaft.prefab";
                string protoIDName = $"transBAR{i:D2}shaft";
                StringBuilder protoLayout1 = new StringBuilder();
                protoLayout1.Append("-1-");
                //for (int g = i + 2; g > 0; g--)
                //{
                //    protoLayout1.Append("   ");
                //}
                //protoLayout1.Append("-1-");


                string[] protoLayout2 = new string[1]; protoLayout2[0] = protoLayout1.ToString();

                IoPortTemplate[] temp = new IoPortTemplate[]
                {
                            new IoPortTemplate(new PortSpec('A', IoPortType.Input, shapeShaft, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                            new IoPortTemplate(new PortSpec('B', IoPortType.Input, shapeShaft, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('C', IoPortType.Input, shapeShaft, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

                            new IoPortTemplate(new PortSpec('D', IoPortType.Output, shapeShaft, false), new RelTile3i(i + 3 , 0, 0), Direction90.PlusX),
                            new IoPortTemplate(new PortSpec('E', IoPortType.Output, shapeShaft, false), new RelTile3i(i + 3 , 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('F', IoPortType.Output, shapeShaft, false), new RelTile3i(i + 3 , 0, 0), Direction90.PlusY),

                };
                //blZipperProto.ID idTransPort = new StaticEntityProto.ID(protoIDName);
                Proto.ID toolbarID = BetterLIDs.ToolBars.HiddenProto;
                string toolbarTitle = $"TransBAR shaft {i:D2}";
                if (i == 3)
                {
                    toolbarID = BetterLIDs.ToolBars.Balancers_Shaft;
                }
                if (i == maxElements)
                {
                    prevProto2 = CreateProto(registrator, new StaticEntityProto.ID(protoIDName), toolbarTitle, protoLayout2, BLCosts.BalancerCosts(3),
                        protoIDprefab, BetterLIDs.dPath.transBar4shaft.icon,
                    toolbarID, 0, 0, 0, true, temp, false, null);
                    prevProto1 = prevProto2;
                }
                else
                {
                    prevProto2 = CreateProto(registrator, new StaticEntityProto.ID(protoIDName), toolbarTitle, protoLayout2, BLCosts.BalancerCosts(3),
                        protoIDprefab, BetterLIDs.dPath.transBar4shaft.icon,
                    toolbarID, 0, 0, 0, true, temp, false, prevProto1);
                    prevProto1 = prevProto2;
                }
            }

        }



        public blZipperProto CreateProto(ProtoRegistrator registrato, StaticEntityProto.ID id, string coment, string[] el, EntityCostsTpl ecTpl, string asp, string ico, Proto.ID cat, Fix32 nX, Fix32 nY, Fix32 nZ, bool isRamp, IoPortTemplate[] ports, bool locked, blZipperProto tier)
        {

            Predicate<LayoutTile> predicate = null;
            CustomLayoutToken[] array = new CustomLayoutToken[5];
            array[0] = new CustomLayoutToken("<0<", delegate (EntityLayoutParams p, int h)
            {
                int heightFrom = h - 1;
                int? maxTerrainHeight3 = new int?(h - 1);
                Fix32? vehicleHeight2 = new Fix32?(h - 1);
                int? minTerrainHeight3 = new int?(-5);
                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.NoRubbleAfterCollapse | LayoutTileConstraint.None, null, minTerrainHeight3, maxTerrainHeight3, vehicleHeight2, null, BetterLIDs.Surfaces.speed1r, false, false, 0);
            });
            array[1] = new CustomLayoutToken(">0>", delegate (EntityLayoutParams p, int h)
            {
                int heightFrom = h - 1;
                int? maxTerrainHeight4 = new int?(h - 1);
                Fix32? vehicleHeight2 = new Fix32?(h - 1);
                int? minTerrainHeight4 = new int?(-5);
                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.NoRubbleAfterCollapse | LayoutTileConstraint.None, null, minTerrainHeight4, maxTerrainHeight4, vehicleHeight2, null, BetterLIDs.Surfaces.speed1l, false, false, 0);
            });
            array[2] = new CustomLayoutToken("<0>", delegate (EntityLayoutParams p, int h)
            {
                int heightFrom = h - 1;
                int? maxTerrainHeight5 = new int?(h - 1);
                Fix32? vehicleHeight2 = new Fix32?(h - 1);
                int? minTerrainHeight5 = new int?(-5);
                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.NoRubbleAfterCollapse | LayoutTileConstraint.None, null, minTerrainHeight5, maxTerrainHeight5, vehicleHeight2, null, BetterLIDs.Surfaces.speed1n, false, false, 0);
            });
            array[3] = new CustomLayoutToken("-0-", delegate (EntityLayoutParams p, int h)
            {
                return new LayoutTokenSpec(0, h);
            });
            array[4] = new CustomLayoutToken("_-_", delegate (EntityLayoutParams p, int h)
            {
                return new LayoutTokenSpec(0, h);
            });

            EntityLayoutParams entityLayoutParams = new EntityLayoutParams(predicate, array, false, null, null, null, null, null, null, default);
            //EntityLayoutParams entityLayoutParams = new EntityLayoutParams(null, null, false, Ids.TerrainTileSurfaces.Metal1, null, null, null, null, default(Option<IEnumerable<KeyValuePair<char, int>>>), false);

            string[] initLayoutString = el;

            EntityLayout ltemp = registrato.LayoutParser.ParseLayoutOrThrow(entityLayoutParams, el);


            EntityLayout entLayout = new EntityLayout(el.ToString(), ltemp.LayoutTiles, ltemp.TerrainVertices, ports.ToImmutableArray(), entityLayoutParams, ltemp.CollapseVerticesThreshold, null);
            Proto.Str ps1 = Proto.CreateStr(id, coment);
            EntityCosts ec1 = ecTpl.MapToEntityCosts(registrato);
            if (cat != BetterLIDs.ToolBars.HiddenProto)
            {
                LayoutEntityProto.Gfx lg1 = new LayoutEntityProto.Gfx(
                    prefabPath: asp,
                    prefabOrigin: new RelTile3f(nX, nY, nZ),
                    customIconPath: ico,
                    categories: registrato.GetCategoriesProtos(cat),
                    hideBlockedPortsIcon: true
                );
                blZipperProto regProto = new blZipperProto(id, ps1, entLayout, ec1, Electricity.OneKw, true, lg1);
                if (tier != null) regProto.SetNextTierIndirect(tier);

                regProto.AddParam(new DrawArrowWileBuildingProtoParam(2f));
                registrato.PrototypesDb.Add<blZipperProto>(regProto);
                return regProto;

            }
            else
            {
                LayoutEntityProto.Gfx lg1 = new LayoutEntityProto.Gfx(
                    prefabPath: asp,
                    prefabOrigin: new RelTile3f(nX, nY, nZ),
                    customIconPath: ico,
                    categories: ImmutableArray<ToolbarEntryData>.Empty,
                    hideBlockedPortsIcon: true
                );
                blZipperProto regProto = new blZipperProto(id, ps1, entLayout, ec1, Electricity.OneKw, true, lg1);
                if (tier != null) regProto.SetNextTierIndirect(tier);
                regProto.AddParam(new DrawArrowWileBuildingProtoParam(2f));
                registrato.PrototypesDb.Add<blZipperProto>(regProto);
                return regProto;
            }
        }

    }
}

