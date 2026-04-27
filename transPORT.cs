//using Mafi.Base;
//using Mafi.Core;
//using Mafi.Collections.ImmutableCollections;
//using Mafi.Core.Entities.Animations;
//using Mafi.Core.Entities.Static.Layout;
//using Mafi.Core.Entities.Static;
//using Mafi;
//using Mafi.Core.Mods;
//using Mafi.Core.Ports.Io;
//using Mafi.Core.Prototypes;
//using System;
//using System.Collections.Generic;
//using Mafi.Core.Factory.Zippers;
//using Mafi.Core.Products;
//using Mafi.Core.Entities;
//using Mafi.Serialization;
//using Mafi.Core.Ports;
//using Mafi.Collections;
//using Mafi.Core.Simulation;
//using Mafi.Core.Economy;
//using UnityEngine;
//using HarmonyLib;
//using Color = UnityEngine.Color;
//using Mafi.Unity;
//using Mafi.Unity.Entities;
//using Mafi.Unity.Entities.Static;
//using Mafi.Collections.ReadonlyCollections;
//using System.Linq;
//using Mafi.Core.Entities.Priorities;
//using Mafi.Core.Factory.ElectricPower;
//using Mafi.Core.PropertiesDb;
//using Mafi.Core.Factory.Transports;
//using Mafi.Localization;
//using Newtonsoft.Json;
//using static Mafi.Base.Assets.Base.Trains;
//using static Mafi.Base.Assets;
//using static UnityEngine.UIElements.UxmlAttributeDescription;
//using System.Drawing.Printing;
//using Unity.VectorGraphics;
//using Mafi.Core.Buildings.Forestry;

//namespace BetterLife.Prototypes
//{
//    internal class transPORT : IModData
//    {
//        public static EntityCostsTpl.Builder Build => new EntityCostsTpl.Builder();
//        public static EntityCosts RoadCosts => new EntityCosts();

//        public IoPortTemplate[] shapeTemp1(IoPortShapeProto shape)
//        {

//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {

//                new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
//                new IoPortTemplate(new PortSpec('B', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('C', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),
//                new IoPortTemplate(new PortSpec('D', IoPortType.Output, shape, false), new RelTile3i(1, 0, 6), Direction90.PlusX),
//                new IoPortTemplate(new PortSpec('E', IoPortType.Output, shape, false), new RelTile3i(1, 0, 6), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('F', IoPortType.Output, shape, false), new RelTile3i(1, 0, 6), Direction90.PlusY),
//            };
//            return temp;
//        }
//        public IoPortTemplate[] shapeTemp2(IoPortShapeProto shape)
//        {
//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {
//            new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.MinusX),
//            new IoPortTemplate(new PortSpec('B', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('C', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.PlusY),
//            new IoPortTemplate(new PortSpec('D', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
//            new IoPortTemplate(new PortSpec('E', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('F', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

//            new IoPortTemplate(new PortSpec('G', IoPortType.Output, shape, false), new RelTile3i(9, 0, 6), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('H', IoPortType.Output, shape, false), new RelTile3i(9, 0, 6), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('I', IoPortType.Output, shape, false), new RelTile3i(9, 0, 6), Direction90.PlusY),
//            new IoPortTemplate(new PortSpec('J', IoPortType.Output, shape, false), new RelTile3i(9, 0, 0), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('K', IoPortType.Output, shape, false), new RelTile3i(9, 0, 0), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('L', IoPortType.Output, shape, false), new RelTile3i(9, 0, 0), Direction90.PlusY),
//            };
//            return temp;
//        }
//        public IoPortTemplate[] shapeTemp3(IoPortShapeProto shape)
//        {
//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {
//            new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.MinusX),
//            new IoPortTemplate(new PortSpec('B', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('C', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.PlusY),
//            new IoPortTemplate(new PortSpec('D', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
//            new IoPortTemplate(new PortSpec('E', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('F', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

//            new IoPortTemplate(new PortSpec('G', IoPortType.Output, shape, false), new RelTile3i(19, 0, 6), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('H', IoPortType.Output, shape, false), new RelTile3i(19, 0, 6), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('I', IoPortType.Output, shape, false), new RelTile3i(19, 0, 6), Direction90.PlusY),
//            new IoPortTemplate(new PortSpec('J', IoPortType.Output, shape, false), new RelTile3i(19, 0, 0), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('K', IoPortType.Output, shape, false), new RelTile3i(19, 0, 0), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('L', IoPortType.Output, shape, false), new RelTile3i(19, 0, 0), Direction90.PlusY),
//            };
//            return temp;
//        }
//        public IoPortTemplate[] shapeTemp6(IoPortShapeProto shape)
//        {
//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {

//            new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.MinusX),
//            new IoPortTemplate(new PortSpec('B', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('C', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.PlusY),
//            new IoPortTemplate(new PortSpec('D', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
//            new IoPortTemplate(new PortSpec('E', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('F', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

//            new IoPortTemplate(new PortSpec('G', IoPortType.Output, shape, false), new RelTile3i(49, 0, 6), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('H', IoPortType.Output, shape, false), new RelTile3i(49, 0, 6), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('I', IoPortType.Output, shape, false), new RelTile3i(49, 0, 6), Direction90.PlusY),
//            new IoPortTemplate(new PortSpec('J', IoPortType.Output, shape, false), new RelTile3i(49, 0, 0), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('K', IoPortType.Output, shape, false), new RelTile3i(49, 0, 0), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('L', IoPortType.Output, shape, false), new RelTile3i(49, 0, 0), Direction90.PlusY),
//            };
//            return temp;
//        }

//        public IoPortTemplate[] shapeTemp4(IoPortShapeProto shape)
//        {
//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {
//            new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.MinusX),
//            new IoPortTemplate(new PortSpec('B', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('C', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.PlusY),

//            new IoPortTemplate(new PortSpec('D', IoPortType.Output, shape, false), new RelTile3i(1, 0, 0), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('F', IoPortType.Output, shape, false), new RelTile3i(1, 0, 0), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('G', IoPortType.Output, shape, false), new RelTile3i(1, 0, 0), Direction90.PlusY),
//            };
//            return temp;
//        }
//        public IoPortTemplate[] shapeTemp5(IoPortShapeProto shape)
//        {
//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {
//            new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 2), Direction90.MinusX),
//            new IoPortTemplate(new PortSpec('B', IoPortType.Input, shape, false), new RelTile3i(0, 0, 3), Direction90.MinusX),

//            new IoPortTemplate(new PortSpec('C', IoPortType.Output, shape, false), new RelTile3i(0, 0, 4), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('D', IoPortType.Output, shape, false), new RelTile3i(0, 0, 4), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('E', IoPortType.Output, shape, false), new RelTile3i(0, 0, 4), Direction90.PlusY),

//            new IoPortTemplate(new PortSpec('F', IoPortType.Output, shape, false), new RelTile3i(0, 0, 5), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('G', IoPortType.Output, shape, false), new RelTile3i(0, 0, 5), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('H', IoPortType.Output, shape, false), new RelTile3i(0, 0, 5), Direction90.PlusY),

//            new IoPortTemplate(new PortSpec('I', IoPortType.Output, shape, false), new RelTile3i(0, 0, 6), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('J', IoPortType.Output, shape, false), new RelTile3i(0, 0, 6), Direction90.PlusY),

//            new IoPortTemplate(new PortSpec('L', IoPortType.Output, shape, false), new RelTile3i(0, 0, 7), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('M', IoPortType.Output, shape, false), new RelTile3i(0, 0, 7), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('N', IoPortType.Output, shape, false), new RelTile3i(0, 0, 7), Direction90.PlusY),

//            new IoPortTemplate(new PortSpec('O', IoPortType.Output, shape, false), new RelTile3i(0, 0, 8), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('P', IoPortType.Output, shape, false), new RelTile3i(0, 0, 8), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('Q', IoPortType.Output, shape, false), new RelTile3i(0, 0, 8), Direction90.PlusY),

//            };
//            return temp;
//        }
//        IoPortTemplate[] multiPort1(IoPortShapeProto shape)
//        {
//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {
//                new IoPortTemplate(new PortSpec('A', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
//                new IoPortTemplate(new PortSpec('B', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('C', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),
//                new IoPortTemplate(new PortSpec('D', IoPortType.Any, shape, false), new RelTile3i(1, 0, 6), Direction90.PlusX),
//                new IoPortTemplate(new PortSpec('E', IoPortType.Any, shape, false), new RelTile3i(1, 0, 6), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('F', IoPortType.Any, shape, false), new RelTile3i(1, 0, 6), Direction90.PlusY),
//            };
//            return temp;
//        }

//        public IoPortTemplate[] sbalancer(IoPortShapeProto shape, int height)
//        {

//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {
//                new IoPortTemplate(new PortSpec('A', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
//                new IoPortTemplate(new PortSpec('B', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('C', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),
//                new IoPortTemplate(new PortSpec('D', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusX),
//                new IoPortTemplate(new PortSpec('E', IoPortType.Any, shape, false), new RelTile3i(0, 0, height), Direction90.PlusX),
//                new IoPortTemplate(new PortSpec('F', IoPortType.Any, shape, false), new RelTile3i(0, 0, height), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('G', IoPortType.Any, shape, false), new RelTile3i(0, 0, height), Direction90.PlusY),
//                new IoPortTemplate(new PortSpec('H', IoPortType.Any, shape, false), new RelTile3i(0, 0, height), Direction90.MinusX),
//            };
//            return temp;
//        }
//        public IoPortTemplate[] shapeLoader1(IoPortShapeProto shape)
//        {
//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {
//            new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
//            new IoPortTemplate(new PortSpec('B', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('C', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

//            new IoPortTemplate(new PortSpec('D', IoPortType.Output, shape, false), new RelTile3i(2, 0, 0), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('F', IoPortType.Output, shape, false), new RelTile3i(2, 0, 0), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('G', IoPortType.Output, shape, false), new RelTile3i(2, 0, 0), Direction90.PlusY),
//            new IoPortTemplate(new PortSpec('H', IoPortType.Output, shape, false), new RelTile3i(4, 0, 0), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('I', IoPortType.Output, shape, false), new RelTile3i(4, 0, 0), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('J', IoPortType.Output, shape, false), new RelTile3i(4, 0, 0), Direction90.PlusY),
//            };
//            return temp;
//        }

//        public IoPortTemplate[] shapeTransBar2m(IoPortShapeProto shape)
//        {
//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {
//                new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
//                new IoPortTemplate(new PortSpec('B', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('C', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

//                new IoPortTemplate(new PortSpec('D', IoPortType.Output, shape, false), new RelTile3i(1, 0, 0), Direction90.PlusX),
//                new IoPortTemplate(new PortSpec('F', IoPortType.Output, shape, false), new RelTile3i(1, 0, 0), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('G', IoPortType.Output, shape, false), new RelTile3i(1, 0, 0), Direction90.PlusY),

//            };
//            return temp;
//        }
//        public IoPortTemplate[] shapeTransBar4m(IoPortShapeProto shape)
//        {
//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {
//                new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
//                new IoPortTemplate(new PortSpec('B', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('C', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

//                new IoPortTemplate(new PortSpec('D', IoPortType.Output, shape, false), new RelTile3i(3, 0, 0), Direction90.PlusX),
//                new IoPortTemplate(new PortSpec('F', IoPortType.Output, shape, false), new RelTile3i(3, 0, 0), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('G', IoPortType.Output, shape, false), new RelTile3i(3, 0, 0), Direction90.PlusY),

//            };
//            return temp;
//        }
//        public IoPortTemplate[] shapeTransBar10m(IoPortShapeProto shape)
//        {
//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {
//                new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
//                new IoPortTemplate(new PortSpec('B', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('C', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

//                new IoPortTemplate(new PortSpec('D', IoPortType.Output, shape, false), new RelTile3i(9, 0, 0), Direction90.PlusX),
//                new IoPortTemplate(new PortSpec('F', IoPortType.Output, shape, false), new RelTile3i(9, 0, 0), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('G', IoPortType.Output, shape, false), new RelTile3i(9, 0, 0), Direction90.PlusY),

//            };
//            return temp;
//        }

//        public void RegisterData(ProtoRegistrator registrator)
//        {
//            IoPortShapeProto shapeFlat = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.FlatConveyor);
//            IoPortShapeProto shapeLoose = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.LooseMaterialConveyor);
//            IoPortShapeProto shapePipe = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.Pipe);
//            IoPortShapeProto shapeMolten = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.MoltenMetalChannel);
//            IoPortShapeProto shapeShaft = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.Shaft);



//            Log.Debug($"Path: {shapeFlat.Graphics.ConnectedPortPrefabPath.ToString()}");
//            Log.Debug($"Path: {shapeFlat.Graphics.DisconnectedPortPrefabPath.ToString()}");

//            //Proto.Str pf = Proto.CreateStr(BetterLIDs.PortShapes.portFlat, "shapeFlat");
//            //Proto.Str pl = Proto.CreateStr(BetterLIDs.PortShapes.portLoose, "shapeLoosse");
//            //Proto.Str pp = Proto.CreateStr(BetterLIDs.PortShapes.portPipe, "shapePipe");
//            //Proto.Str pm = Proto.CreateStr(BetterLIDs.PortShapes.portMolten, "shapeMolten");
//            //Proto.Str ps = Proto.CreateStr(BetterLIDs.PortShapes.portShaft, "shapeSshaft");

//            //registrator.PrototypesDb.RemoveOrThrow(Ids.IoPortShapes.FlatConveyor);
//            //registrator.PrototypesDb.RemoveOrThrow(Ids.IoPortShapes.LooseMaterialConveyor);
//            //registrator.PrototypesDb.RemoveOrThrow(Ids.IoPortShapes.Pipe);
//            //registrator.PrototypesDb.RemoveOrThrow(Ids.IoPortShapes.MoltenMetalChannel);
//            //registrator.PrototypesDb.RemoveOrThrow(Ids.IoPortShapes.Shaft);


//            //IoPortShapeProto protoFlat = new IoPortShapeProto(Ids.IoPortShapes.FlatConveyor, shapeFlat.Strings, shapeFlat.LayoutChar, shapeFlat.AllowedProductType,

//            //    new IoPortShapeProto.Gfx(shapeFlat.Graphics.ConnectedPortPrefabPath, shapeFlat.Graphics.ConnectedPortPrefabPathLod3, false, shapeFlat.Graphics.DisconnectedPortPrefabPath, shapeFlat.Graphics.DisconnectedPortPrefabPathLod3), null
//            //    );

//            //IoPortShapeProto protoLoose = new IoPortShapeProto(Ids.IoPortShapes.LooseMaterialConveyor, pl, shapeLoose.LayoutChar, shapeLoose.AllowedProductType,
//            //    new IoPortShapeProto.Gfx(shapeLoose.Graphics.ConnectedPortPrefabPath, shapeLoose.Graphics.ConnectedPortPrefabPathLod3, false, shapeLoose.Graphics.DisconnectedPortPrefabPath, shapeLoose.Graphics.DisconnectedPortPrefabPathLod3), null


//            //    );
//            //IoPortShapeProto protoPipe = new IoPortShapeProto(Ids.IoPortShapes.Pipe, pp, shapePipe.LayoutChar, shapePipe.AllowedProductType,
//            //    new IoPortShapeProto.Gfx(shapePipe.Graphics.ConnectedPortPrefabPath, shapePipe.Graphics.ConnectedPortPrefabPathLod3, false, shapePipe.Graphics.DisconnectedPortPrefabPath, shapePipe.Graphics.DisconnectedPortPrefabPathLod3), null


//            //    );
//            //IoPortShapeProto protoMolten = new IoPortShapeProto(Ids.IoPortShapes.MoltenMetalChannel, pm, shapeMolten.LayoutChar, shapeMolten.AllowedProductType,
//            //    new IoPortShapeProto.Gfx(shapeMolten.Graphics.ConnectedPortPrefabPath, shapeMolten.Graphics.ConnectedPortPrefabPathLod3, false, shapeMolten.Graphics.DisconnectedPortPrefabPath, shapeMolten.Graphics.DisconnectedPortPrefabPathLod3), null


//            //    );
//            //IoPortShapeProto protoShaft = new IoPortShapeProto(Ids.IoPortShapes.Shaft, ps, shapeShaft.LayoutChar, shapeShaft.AllowedProductType,
//            //    new IoPortShapeProto.Gfx(shapeShaft.Graphics.ConnectedPortPrefabPath, shapeShaft.Graphics.ConnectedPortPrefabPathLod3, false, shapeShaft.Graphics.DisconnectedPortPrefabPath, shapeShaft.Graphics.DisconnectedPortPrefabPathLod3), null


//            //    );

//            //registrator.PrototypesDb.Add<IoPortShapeProto>(protoFlat);
//            //registrator.PrototypesDb.Add<IoPortShapeProto>(protoLoose);
//            //registrator.PrototypesDb.Add<IoPortShapeProto>(protoPipe);
//            //registrator.PrototypesDb.Add<IoPortShapeProto>(protoMolten);
//            //registrator.PrototypesDb.Add<IoPortShapeProto>(protoShaft);

//            //            IoPortShapeProto.ID shapeID = new IoPortShapeProto.ID("cPortA");
//            //            char shapeLayoutChar = '%';

//            //            IoPortShapeProto newShape = new IoPortShapeProto(shapeID, shapeFlat.Strings, shapeLayoutChar, ProductType.ANY, shapeFlat.Graphics, null);

//            string[] transIN =
//            {
//                "-1--6-"
//            };
//            string[] trans5 =
//            {
//                "-6-                        -6-"
//            };
//            string[] trans10 =
//            { //"111222333444555666777888999000111222333444555666777888999000"
//                "-6-                                                      -6-"
//            };
//            string[] trans100 =
//            { //"111222333444555666777888999000111222333444555666777888999000111222333444555666777888999000111222333444555666777888999000111222333444555666777888999000"
//                "-6-                                                                                                                                                -6-"
//            };
//            string[] transOUT =
//            {
//                "-6--1-"
//            };
//            string[] transFIX =
//            {
//                "-1-"
//            };
//            string[] balancer0 =
//            {
//                "-1-"
//            };
//            string[] balancer1 =
//            {
//                "-1-"
//            };
//            string[] balancer2 =
//            {
//                "-2-"
//            };
//            string[] balancer3 =
//            {
//                "-3-"
//            };
//            string[] balancer4 =
//            {
//                "-4-"
//            };
//            string[] balancer5 =
//            {
//                "-5-"
//            };
//            string[] loader1 =
//            {
//                "-1-   -1-   -1-"
//            };
//            string[] trBar2m =
//            {
//                "-1--1-"
//            };
//            string[] trBar4m =
//            {
//                "-1-      -1-"
//            };
//            string[] trBar10m =
//            {
//                "-1-                        -1-"
//            };



//            ImmutableArray<AnimationParams> noLoop = ImmutableArray.Create(new AnimationParams[]
//            {
//                AnimationParams.RepeatAutoTimes(Duration.FromYears(1))
//            });
//            EntityCostsTpl roadCosts2 = Build.Priority(8).CP3(20).Product(10, Ids.Products.Iron);
//            EntityCostsTpl roadCosts3 = Build.Priority(8).CP3(40).Product(20, Ids.Products.Iron);
//            EntityCostsTpl balancerCosts = Build.Priority(8).CP(5).Product(5, Ids.Products.Iron).Product(5, Ids.Products.MechanicalParts);


//            // transPORTS

//            //CreateRoad(registrator, BetterLIDs.transPorts.transIN, "IN", transIN, roadCosts2, "Assets/BetterLife/Transports/transportIN/transportIN.prefab", "Assets/BetterLife/Icons/transport/transIN.png", BetterLIDs.ToolBars.TransPORT, 0, 0, 0, noLoop, true, shapeTemp1(shapeFlat), false);
//            //CreateRoad(registrator, BetterLIDs.transPorts.transINtxt, "INtxt", transIN, roadCosts2, "Assets/BetterLife/Transports/transportIN/transportINwText.prefab", "Assets/BetterLife/Icons/transport/transIN.png", BetterLIDs.ToolBars.TransPORT, 0, 0, 0, noLoop, true, shapeTemp1(shapeFlat), false);
//            CreateRoad(registrator, BetterLIDs.transPorts.trans5, "Straight 20m", trans5, roadCosts2, "Assets/BetterLife/Transports/transport20/transport20.prefab", "Assets/BetterLife/Icons/transport/trans20countable.png", BetterLIDs.ToolBars.TransPORT, 0, 0, 0, noLoop, true, shapeTemp2(shapeFlat), false);
//            CreateRoad(registrator, BetterLIDs.transPorts.trans10, "Straight 40m", trans10, roadCosts2, "Assets/BetterLife/Transports/transport40/transport40.prefab", "Assets/BetterLife/Icons/transport/trans40countable.png", BetterLIDs.ToolBars.TransPORT, 0, 0, 0, noLoop, true, shapeTemp3(shapeFlat), false);
//            CreateRoad(registrator, BetterLIDs.transPorts.trans100, "Straight 100m", trans100, roadCosts3, "Assets/BetterLife/Transports/bigboy/bigboy.prefab", "Assets/BetterLife/Icons/transport/trans100countable.png", BetterLIDs.ToolBars.TransPORT, 25, 0, 0, noLoop, true, shapeTemp6(shapeFlat), false);
//            //CreateRoad(registrator, BetterLIDs.transPorts.transOUT, "OUT", transOUT, roadCosts2, "Assets/BetterLife/Transports/transportOUT/transportOUT.prefab", "Assets/BetterLife/Icons/transport/transOUT.png", BetterLIDs.ToolBars.TransPORT, 0, 0, 0, noLoop, true, shapeTemp4(shapeFlat), false);
//            CreateRoad(registrator, BetterLIDs.transPorts.transfix, "Height Fix", transFIX, roadCosts2, "Assets/BetterLife/Transports/transportHeight/transHeightFix.prefab", "Assets/BetterLife/Icons/transport/heightCountable.png", BetterLIDs.ToolBars.TransPORT, 0, 0, 0, noLoop, true, shapeTemp5(shapeFlat), false);

//            CreateRoad(registrator, BetterLIDs.transPorts.balancer0, "Balancer 0h", balancer0, balancerCosts, "Assets/BetterLife/Transports/balancer0/balancer0.prefab", "Assets/BetterLife/Icons/transport/balancer0.png", BetterLIDs.ToolBars.TransPORT, 0, 0, 0, noLoop, true, sbalancer(shapeFlat, 0), false);
//            CreateRoad(registrator, BetterLIDs.transPorts.balancer1, "Balancer 1h", balancer1, balancerCosts, "Assets/BetterLife/Transports/balancer1/balancer1.prefab", "Assets/BetterLife/Icons/transport/balancer1.png", BetterLIDs.ToolBars.TransPORT, 0, 0, 0, noLoop, true, sbalancer(shapeFlat, 1), false);
//            CreateRoad(registrator, BetterLIDs.transPorts.balancer2, "Balancer 2h", balancer2, balancerCosts, "Assets/BetterLife/Transports/balancer2/balancer2.prefab", "Assets/BetterLife/Icons/transport/balancer2.png", BetterLIDs.ToolBars.TransPORT, 0, 0, 0, noLoop, true, sbalancer(shapeFlat, 2), false);
//            CreateRoad(registrator, BetterLIDs.transPorts.balancer3, "Balancer 3h", balancer3, balancerCosts, "Assets/BetterLife/Transports/balancer3/balancer3.prefab", "Assets/BetterLife/Icons/transport/balancer3.png", BetterLIDs.ToolBars.TransPORT, 0, 0, 0, noLoop, true, sbalancer(shapeFlat, 3), false);
//            CreateRoad(registrator, BetterLIDs.transPorts.balancer4, "Balancer 4h", balancer4, balancerCosts, "Assets/BetterLife/Transports/balancer4/balancer4.prefab", "Assets/BetterLife/Icons/transport/balancer3.png", BetterLIDs.ToolBars.TransPORT, 0, 0, 0, noLoop, true, sbalancer(shapeFlat, 4), false);
//            CreateRoad(registrator, BetterLIDs.transPorts.balancer5, "Balancer 5h", balancer5, balancerCosts, "Assets/BetterLife/Transports/balancer5/balancer5.prefab", "Assets/BetterLife/Icons/transport/balancer5.png", BetterLIDs.ToolBars.TransPORT, 0, 0, 0, noLoop, true, sbalancer(shapeFlat, 5), false);
//            CreateRoad(registrator, BetterLIDs.transPorts.trloader1, "Loader A", loader1, balancerCosts, "Assets/BetterLife/Transports/loader1/loader1.prefab", "Assets/BetterLife/Icons/transport/loader1.png", BetterLIDs.ToolBars.TransPORT, 0, 0, 0, noLoop, true, shapeLoader1(shapeFlat), false);
//            CreateRoad(registrator, BetterLIDs.transPorts.transBar2m, "Trans Bar 2m", trBar2m, balancerCosts, "Assets/BetterLife/Transports/transportbars/bar2m/transPORTbar2m.prefab", "Assets/BetterLife/Icons/transport/transBar2m.png", BetterLIDs.ToolBars.TransPORT, 0, 0, 0, noLoop, true, shapeTransBar2m(shapeFlat), false);
//            CreateRoad(registrator, BetterLIDs.transPorts.transBar4m, "Trans Bar 4m", trBar4m, balancerCosts, "Assets/BetterLife/Transports/transportbars/bar4m/transPORTbar4m.prefab", "Assets/BetterLife/Icons/transport/transBar4m.png", BetterLIDs.ToolBars.TransPORT, 0, 0, 0, noLoop, true, shapeTransBar4m(shapeFlat), false);
//            CreateRoad(registrator, BetterLIDs.transPorts.transBar10m, "Trans Bar 20m", trBar10m, balancerCosts, "Assets/BetterLife/Transports/transportbars/bar10m/transPORTbar10m.prefab", "Assets/BetterLife/Icons/transport/transBar10m.png", BetterLIDs.ToolBars.TransPORT, 0, 0, 0, noLoop, true, shapeTransBar10m(shapeFlat), false);
//            //CreateRoad(registrator, BetterLIDs.transPorts.balancer5, "Balancer 5m", balancer5, balancerCosts, "Assets/BetterLife/Transports/balancer5/balancer5.prefab", "Assets/BetterLife/Icons/transport/balancer3.png", BetterLIDs.ToolBars.TransPORT, 0, 0, 0, noLoop, true, sbalancer(protoFlat, 5), false);

//        }
//        public void CreateRoad(ProtoRegistrator registrato, StaticEntityProto.ID id, string coment, string[] el, EntityCostsTpl ecTpl, string asp, string ico, Proto.ID cat, Fix32 nX, Fix32 nY, Fix32 nZ, ImmutableArray<AnimationParams> ap, bool isRamp, IoPortTemplate[] ports, bool locked)
//        {


//            Predicate<LayoutTile> predicate = null;
//            CustomLayoutToken[] array = new CustomLayoutToken[5];
//            array[0] = new CustomLayoutToken("<0<", delegate (EntityLayoutParams p, int h)
//            {
//                int heightFrom = h - 1;
//                int? maxTerrainHeight3 = new int?(h - 1);
//                Fix32? vehicleHeight2 = new Fix32?(h - 1);
//                int? minTerrainHeight3 = new int?(-5);
//                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.NoRubbleAfterCollapse | LayoutTileConstraint.None, null, minTerrainHeight3, maxTerrainHeight3, vehicleHeight2, null, BetterLIDs.Surfaces.speed1r, false, false, 0);
//            });
//            array[1] = new CustomLayoutToken(">0>", delegate (EntityLayoutParams p, int h)
//            {
//                int heightFrom = h - 1;
//                int? maxTerrainHeight4 = new int?(h - 1);
//                Fix32? vehicleHeight2 = new Fix32?(h - 1);
//                int? minTerrainHeight4 = new int?(-5);
//                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.NoRubbleAfterCollapse | LayoutTileConstraint.None, null, minTerrainHeight4, maxTerrainHeight4, vehicleHeight2, null, BetterLIDs.Surfaces.speed1l, false, false, 0);
//            });
//            array[2] = new CustomLayoutToken("<0>", delegate (EntityLayoutParams p, int h)
//            {
//                int heightFrom = h - 1;
//                int? maxTerrainHeight5 = new int?(h - 1);
//                Fix32? vehicleHeight2 = new Fix32?(h - 1);
//                int? minTerrainHeight5 = new int?(-5);
//                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.NoRubbleAfterCollapse | LayoutTileConstraint.None, null, minTerrainHeight5, maxTerrainHeight5, vehicleHeight2, null, BetterLIDs.Surfaces.speed1n, false, false, 0);
//            });
//            array[3] = new CustomLayoutToken("-0-", delegate (EntityLayoutParams p, int h)
//            {
//                return new LayoutTokenSpec(0, h);
//            });
//            array[4] = new CustomLayoutToken("_-_", delegate (EntityLayoutParams p, int h)
//            {
//                return new LayoutTokenSpec(0, h);
//            });

//            EntityLayoutParams entityLayoutParams = new EntityLayoutParams(predicate, array, false, null, null, null, null, new ThicknessIRange(new ThicknessTilesI(-1), new ThicknessTilesI(0)), default(Option<IEnumerable<KeyValuePair<char, int>>>), false);
//            //EntityLayoutParams entityLayoutParams = new EntityLayoutParams(null, null, false, Ids.TerrainTileSurfaces.Metal1, null, null, null, null, default(Option<IEnumerable<KeyValuePair<char, int>>>), false);
//            EntityCostsTpl costs = Build.MaintenanceT1(0).Priority(8).Workers(4).CP(20).Product(100, Ids.Products.Bricks).Product(50, Ids.Products.Rock);

//            string[] initLayoutString = el;

//            EntityLayout ltemp = registrato.LayoutParser.ParseLayoutOrThrow(entityLayoutParams, el);



//            if (isRamp == true)
//            {
//                EntityLayout entLayout = new EntityLayout(el.ToString(), ltemp.LayoutTiles, ltemp.TerrainVertices, ports.ToImmutableArray(), entityLayoutParams, ltemp.CollapseVerticesThreshold, null);
//                Proto.Str ps1 = Proto.CreateStr(id, coment);
//                EntityCosts ec1 = ecTpl.MapToEntityCosts(registrato);
//                LayoutEntityProto.Gfx lg1 = new LayoutEntityProto.Gfx(
//                    prefabPath: asp,
//                    prefabOrigin: new RelTile3f(nX, nY, nZ),
//                    customIconPath: ico,
//                    categories: registrato.GetCategoriesProtos(cat),
//                    hideBlockedPortsIcon: true


//                    );
//                ImmutableArray<AnimationParams> noLoop = ImmutableArray.Create(new AnimationParams[]
//                {
//                    AnimationParams.RepeatAutoTimes(Duration.FromYears(1))
//                });

//                registrato.PrototypesDb.Add<TransPEntityProto>(new TransPEntityProto(id, ps1, entLayout, ec1, lg1, noLoop), locked);
//            }
//            else
//            {
//                Proto.Str ps = Proto.CreateStr(id, coment);
//                EntityCosts ec = ecTpl.MapToEntityCosts(registrato);
//                LayoutEntityProto.Gfx lg = new LayoutEntityProto.Gfx(
//                    prefabPath: asp,
//                    prefabOrigin: new RelTile3f(nX, nY, nZ),
//                    customIconPath: ico,
//                    categories: registrato.GetCategoriesProtos(cat)
//                    );
//                ImmutableArray<AnimationParams> noLoop = ImmutableArray.Create(new AnimationParams[]
//                {
//                    AnimationParams.RepeatAutoTimes(Duration.FromYears(1))
//                });
//                registrato.PrototypesDb.Add<TransPEntityProto>(new TransPEntityProto(id, ps, ltemp, ec, lg, noLoop), locked);
//            }
//        }

//    }
//    [GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
//    public class TransPMbFactory : IEntityMbFactory<TransPEntity>, IFactory<TransPEntity, EntityMb>
//    {

//        private readonly ProtoModelFactory modelFactory;
//        private readonly AssetsDb m_assetsDb;
//        private readonly ProtosDb m_protoDb;
//        public TransPMbFactory(ProtoModelFactory mFactory, AssetsDb assetsDb, ProtosDb protosDb)
//        {
//            modelFactory = mFactory;
//            m_assetsDb = assetsDb;
//            m_protoDb = protosDb;
//        }

//        public EntityMb Create(TransPEntity transp)
//        {
//            TransPMb transpMb = modelFactory.CreateModelFor<TransPEntityProto>(transp.Prototype).AddComponent<TransPMb>();
//            transpMb.Initialize(transp, m_assetsDb, m_protoDb);
//            //transpMb.Initialize(transp);
//            return (EntityMb)transpMb;
//        }
//    }
//    public class TransPMb : StaticEntityMb, IEntityMbWithSyncUpdate, IEntityMb, IDestroyableEntityMb
//    {
//        private GameObject insideGo;
//        private GameObject insideGo2;
//        private Material gameObjectMaterial;
//        private TextMesh textMesh;
//        private Color currentColor = Color.black;
//        private AssetsDb m_assetsDb;
//        private ProtosDb m_protoDb;
//        TransPEntity thisEntity;
//        public void SyncUpdate(GameTime time)
//        {
//            if (thisEntity.currentProduct != null)
//            {

//                try
//                {
//                    ProductProto pProto = this.m_protoDb.GetOrThrow<ProductProto>(thisEntity.currentProduct.Id);
//                    String pName = pProto.Strings.Name.ToString();
//                    string pType = pProto.Type.ToString();
//                    Texture pMaterial = gameObjectMaterial.mainTexture;
//                    if (thisEntity.myColor != currentColor)
//                    {
//                        gameObjectMaterial.color = thisEntity.myColor;
//                        currentColor = thisEntity.myColor;
//                    }
//                    if (textMesh != null)
//                    {
//                        Log.Debug("Changing text...");
//                        textMesh.text = pName;
//                    }


//                }
//                catch (Exception e) { Log.Debug($"{e.Message}"); };
//            }


//        }
//        public void Initialize(TransPEntity transPEntity, AssetsDb assetsDb, ProtosDb protosDb)
//        {
//            this.Initialize((ILayoutEntity)transPEntity);
//            thisEntity = transPEntity;
//            m_assetsDb = assetsDb;
//            m_protoDb = protosDb;
//            //Animator component2;
//            //if (this.gameObject.TryFindChild("Column", out insideGo) && insideGo.TryGetComponent<Animator>(out component2))
//            if (this.gameObject.TryFindChild("ProductText", out insideGo2))
//            {
//                textMesh = insideGo2.GetComponent<TextMesh>();
//            }
//            else
//            {
//                Log.Debug("Error, fix that, couldn't access gameobject's textbox...");
//            }
//            if (this.gameObject.TryFindChild("color", out insideGo))
//            {
//                gameObjectMaterial = insideGo.GetComponent<Renderer>().material;
//            }
//            else
//            {
//                Log.Debug("Error, fix that, couldn't access gameobject's color material...'");
//            }

//        }
//        static TransPMb()
//        {

//        }
//    }

//    [GenerateSerializer(false, null, 0)]
//    public class TransPEntity : LayoutEntity, IEntityWithSimUpdate, IEntityWithPorts, IRenderedEntity, IAreaSelectableEntity, IObjectWithTitle

//    {
////        public KeyValuePair<IoPortShapeProto, StaticEntityProto.ID>[] protoIDs;
//        public Color myColor = Color.white;
//        public ProductProto currentProduct = null;
//        public ProductColorManager PColors;
//        //public IIndexable<TransportedProductMutable> TransportedProducts
//        //{
//        //    get
//        //    {
//        //        return this.m_products;
//        //    }
//        //}
////        private readonly Queueue<TransportedProductMutable> m_products;

//        public IoPortTemplate[] shapeTemp1(IoPortShapeProto shape)
//        {

//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {

//                new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
//                new IoPortTemplate(new PortSpec('B', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('C', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),
//                new IoPortTemplate(new PortSpec('D', IoPortType.Output, shape, false), new RelTile3i(1, 0, 6), Direction90.PlusX),
//                new IoPortTemplate(new PortSpec('E', IoPortType.Output, shape, false), new RelTile3i(1, 0, 6), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('F', IoPortType.Output, shape, false), new RelTile3i(1, 0, 6), Direction90.PlusY),
//            };
//            return temp;
//        }
//        public IoPortTemplate[] shapeTemp2(IoPortShapeProto shape)
//        {
//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {
//            new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.MinusX),
//            new IoPortTemplate(new PortSpec('B', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('C', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.PlusY),
//            new IoPortTemplate(new PortSpec('D', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
//            new IoPortTemplate(new PortSpec('E', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('F', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

//            new IoPortTemplate(new PortSpec('G', IoPortType.Output, shape, false), new RelTile3i(9, 0, 6), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('H', IoPortType.Output, shape, false), new RelTile3i(9, 0, 6), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('I', IoPortType.Output, shape, false), new RelTile3i(9, 0, 6), Direction90.PlusY),
//            new IoPortTemplate(new PortSpec('J', IoPortType.Output, shape, false), new RelTile3i(9, 0, 0), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('K', IoPortType.Output, shape, false), new RelTile3i(9, 0, 0), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('L', IoPortType.Output, shape, false), new RelTile3i(9, 0, 0), Direction90.PlusY),
//            };
//            return temp;
//        }
//        public IoPortTemplate[] shapeTemp3(IoPortShapeProto shape)
//        {
//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {
//            new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.MinusX),
//            new IoPortTemplate(new PortSpec('B', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('C', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.PlusY),
//            new IoPortTemplate(new PortSpec('D', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
//            new IoPortTemplate(new PortSpec('E', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('F', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

//            new IoPortTemplate(new PortSpec('G', IoPortType.Output, shape, false), new RelTile3i(19, 0, 6), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('H', IoPortType.Output, shape, false), new RelTile3i(19, 0, 6), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('I', IoPortType.Output, shape, false), new RelTile3i(19, 0, 6), Direction90.PlusY),
//            new IoPortTemplate(new PortSpec('J', IoPortType.Output, shape, false), new RelTile3i(19, 0, 0), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('K', IoPortType.Output, shape, false), new RelTile3i(19, 0, 0), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('L', IoPortType.Output, shape, false), new RelTile3i(19, 0, 0), Direction90.PlusY),
//            };
//            return temp;
//        }
//        public IoPortTemplate[] shapeTemp4(IoPortShapeProto shape)
//        {
//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {
//            new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.MinusX),
//            new IoPortTemplate(new PortSpec('B', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('C', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.PlusY),

//            new IoPortTemplate(new PortSpec('D', IoPortType.Output, shape, false), new RelTile3i(1, 0, 0), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('F', IoPortType.Output, shape, false), new RelTile3i(1, 0, 0), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('G', IoPortType.Output, shape, false), new RelTile3i(1, 0, 0), Direction90.PlusY),
//            };
//            return temp;
//        }
//        public IoPortTemplate[] shapeTemp5(IoPortShapeProto shape)
//        {
//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {
//            new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 2), Direction90.MinusX),
//            new IoPortTemplate(new PortSpec('B', IoPortType.Input, shape, false), new RelTile3i(0, 0, 3), Direction90.MinusX),

//            new IoPortTemplate(new PortSpec('C', IoPortType. Output, shape, false), new RelTile3i(0, 0, 4), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('D', IoPortType.Output, shape, false), new RelTile3i(0, 0, 4), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('E', IoPortType.Output, shape, false), new RelTile3i(0, 0, 4), Direction90.PlusY),

//            new IoPortTemplate(new PortSpec('F', IoPortType.Output, shape, false), new RelTile3i(0, 0, 5), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('G', IoPortType.Output, shape, false), new RelTile3i(0, 0, 5), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('H', IoPortType.Output, shape, false), new RelTile3i(0, 0, 5), Direction90.PlusY),

//            new IoPortTemplate(new PortSpec('I', IoPortType.Output, shape, false), new RelTile3i(0, 0, 6), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('J', IoPortType.Output, shape, false), new RelTile3i(0, 0, 6), Direction90.PlusY),

//            new IoPortTemplate(new PortSpec('L', IoPortType.Output, shape, false), new RelTile3i(0, 0, 7), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('M', IoPortType.Output, shape, false), new RelTile3i(0, 0, 7), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('N', IoPortType.Output, shape, false), new RelTile3i(0, 0, 7), Direction90.PlusY),

//            new IoPortTemplate(new PortSpec('O', IoPortType.Output, shape, false), new RelTile3i(0, 0, 8), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('P', IoPortType.Output, shape, false), new RelTile3i(0, 0, 8), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('Q', IoPortType.Output, shape, false), new RelTile3i(0, 0, 8), Direction90.PlusY),

//            };
//            return temp;
//        }
//        public IoPortTemplate[] shapeTemp6(IoPortShapeProto shape)
//        {
//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {

//            new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.MinusX),
//            new IoPortTemplate(new PortSpec('B', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('C', IoPortType.Input, shape, false), new RelTile3i(0, 0, 6), Direction90.PlusY),
//            new IoPortTemplate(new PortSpec('D', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
//            new IoPortTemplate(new PortSpec('E', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('F', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

//            new IoPortTemplate(new PortSpec('G', IoPortType.Output, shape, false), new RelTile3i(49, 0, 6), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('H', IoPortType.Output, shape, false), new RelTile3i(49, 0, 6), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('I', IoPortType.Output, shape, false), new RelTile3i(49, 0, 6), Direction90.PlusY),
//            new IoPortTemplate(new PortSpec('J', IoPortType.Output, shape, false), new RelTile3i(49, 0, 0), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('K', IoPortType.Output, shape, false), new RelTile3i(49, 0, 0), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('L', IoPortType.Output, shape, false), new RelTile3i(49, 0, 0), Direction90.PlusY),
//            };
//            return temp;
//        }
//        public IoPortTemplate[] sbalancer(IoPortShapeProto shape, int height)
//        {

//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {
//                new IoPortTemplate(new PortSpec('A', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
//                new IoPortTemplate(new PortSpec('B', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('C', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),
//                new IoPortTemplate(new PortSpec('D', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusX),
//                new IoPortTemplate(new PortSpec('E', IoPortType.Any, shape, false), new RelTile3i(0, 0, height), Direction90.PlusX),
//                new IoPortTemplate(new PortSpec('F', IoPortType.Any, shape, false), new RelTile3i(0, 0, height), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('G', IoPortType.Any, shape, false), new RelTile3i(0, 0, height), Direction90.PlusY),
//                new IoPortTemplate(new PortSpec('H', IoPortType.Any, shape, false), new RelTile3i(0, 0, height), Direction90.MinusX),
//            };
//            return temp;
//        }
//        public IoPortTemplate[] shapeLoader1(IoPortShapeProto shape)
//        {
//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {
//            new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
//            new IoPortTemplate(new PortSpec('B', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('C', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

//            new IoPortTemplate(new PortSpec('D', IoPortType.Output, shape, false), new RelTile3i(2, 0, 0), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('F', IoPortType.Output, shape, false), new RelTile3i(2, 0, 0), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('G', IoPortType.Output, shape, false), new RelTile3i(2, 0, 0), Direction90.PlusY),
//            new IoPortTemplate(new PortSpec('H', IoPortType.Output, shape, false), new RelTile3i(4, 0, 0), Direction90.PlusX),
//            new IoPortTemplate(new PortSpec('I', IoPortType.Output, shape, false), new RelTile3i(4, 0, 0), Direction90.MinusY),
//            new IoPortTemplate(new PortSpec('J', IoPortType.Output, shape, false), new RelTile3i(4, 0, 0), Direction90.PlusY),
//            };
//            return temp;
//        }

//        public IoPortTemplate[] shapeTransBar2m(IoPortShapeProto shape)
//        {
//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {
//                new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
//                new IoPortTemplate(new PortSpec('B', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('C', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

//                new IoPortTemplate(new PortSpec('D', IoPortType.Output, shape, false), new RelTile3i(1, 0, 0), Direction90.PlusX),
//                new IoPortTemplate(new PortSpec('F', IoPortType.Output, shape, false), new RelTile3i(1, 0, 0), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('G', IoPortType.Output, shape, false), new RelTile3i(1, 0, 0), Direction90.PlusY),

//            };
//            return temp;
//        }
//        public IoPortTemplate[] shapeTransBar4m(IoPortShapeProto shape)
//        {
//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {
//                new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
//                new IoPortTemplate(new PortSpec('B', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('C', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

//                new IoPortTemplate(new PortSpec('D', IoPortType.Output, shape, false), new RelTile3i(3, 0, 0), Direction90.PlusX),
//                new IoPortTemplate(new PortSpec('F', IoPortType.Output, shape, false), new RelTile3i(3, 0, 0), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('G', IoPortType.Output, shape, false), new RelTile3i(3, 0, 0), Direction90.PlusY),

//            };
//            return temp;
//        }

//        public IoPortTemplate[] shapeTransBar10m(IoPortShapeProto shape)
//        {
//            IoPortTemplate[] temp = new IoPortTemplate[]
//            {
//                new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
//                new IoPortTemplate(new PortSpec('B', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('C', IoPortType.Input, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

//                new IoPortTemplate(new PortSpec('D', IoPortType.Output, shape, false), new RelTile3i(9, 0, 0), Direction90.PlusX),
//                new IoPortTemplate(new PortSpec('F', IoPortType.Output, shape, false), new RelTile3i(9, 0, 0), Direction90.MinusY),
//                new IoPortTemplate(new PortSpec('G', IoPortType.Output, shape, false), new RelTile3i(9, 0, 0), Direction90.PlusY),

//            };
//            return temp;
//        }


//        public override bool CanBePaused => true;
//        private TransPEntityProto _proto;
//        private SimLoopEvents _simLoopEvents;
//        public Dict<ProductProto, Quantity> productCount = new Dict<ProductProto, Quantity>();
//        private ImmutableArray<IoPortData> _connectedInputPortsCache;
//        [DoNotSave(0, null)]
//        private ImmutableArray<IoPortData> _connectedOutputPortsCache;
//        public readonly ProductQuantity[] _inputBuffer;
//        public readonly Queueue<ZipBuffProduct> _outputBuffer;
//        public int OutputPortsConnected => _connectedOutputPortsCache.Length;
//        public int InputPortsConnected => _connectedInputPortsCache.Length;
//        private Quantity _quantityInInputBuffer;
//        private Quantity _quantityInOutputBuffer;
//        private Quantity _maxBufferSize;
//        private int _lastUsedInputPortIndex;
//        private int _lastUsedOutputPortIndex;
//        private Duration m_delay;
//        private static readonly Action<object, BlobWriter> s_serializeDataDelayedAction;
//        private static readonly Action<object, BlobReader> s_deserializeDataDelayedAction;
//        public ProtosDb _protosDb;
//        public ImmutableArray<Mafi.Core.Entities.Animations.AnimationParams> AnimationParams
//        {
//            get => this.Prototype.AnimationParams;
//        }


//        //public Quantity MaxBufferSize
//        //{
//        //    get => _maxBufferSize + _connectedInputPortsCache.Length.Quantity();
//        //}
//        public Quantity MaxBufferSize;

//        private Queueue<ZipBuffProduct> productBuffer = new Queueue<ZipBuffProduct>();
////        private bool m_powerLow;
//        public Upoints GetQuickRemoveCost(out bool canAfford)
//        {
//            canAfford = false;
//            Quantity quantity = Quantity.Zero;
//            //foreach (TransportedProductMutable transportedProductMutable in this.m_products)
//            //{
//            //    quantity += transportedProductMutable.Quantity;
//            //}
//            quantity += _quantityInInputBuffer; quantity += _quantityInOutputBuffer;
//            Upoints upoints = QuickDeliverCostHelper.QuantityToUnityCost(quantity.Value, base.Context.UpointsManager.QuickActionCostMultiplier) ?? Upoints.Zero;
//            canAfford = base.Context.UpointsManager.CanConsume(upoints);
//            return upoints;
//        }

//        public TransPEntity(EntityId id, TransPEntityProto proto, TileTransform transform, EntityContext context, SimLoopEvents simLoopEvents, ProtosDb protosDb, ProductColorManager pcm
//                            )
//            : base(id, proto, transform, context)
//        {
//            _proto = proto;
//            _protosDb = protosDb;
//            PColors = pcm;
//            PColors.Init();
//            _simLoopEvents = simLoopEvents;
//            _inputBuffer = new ProductQuantity[this.Ports.Length];
//            _outputBuffer = new Queueue<ZipBuffProduct>();

//            for (int index = 0; index < _inputBuffer.Length; ++index)
//                _inputBuffer[index] = ProductQuantity.None;
//            this.recomputePortInfo();

//        }
//        public void GetAllBufferedProducts(Lyst<ProductQuantity> aggregated)
//        {
//            foreach (var productQuantity in this._inputBuffer)
//            {
//                if (productQuantity.IsNotEmpty)
//                {
//                    AggregateProductQuantity(productQuantity, aggregated);
//                }
//            }

//            foreach (var zipBuffProduct in this._outputBuffer)
//            {
//                AggregateProductQuantity(zipBuffProduct.ProductQuantity, aggregated);
//            }
//        }

//        private void AggregateProductQuantity(ProductQuantity productQuantity, Lyst<ProductQuantity> aggregated)
//        {
//            aggregated.Add(productQuantity);
//        }

//        public class TransPEntityProto : LayoutEntityProto, IProto, IProtoWithAnimation
//        {
//            public TransPEntityProto(TransPEntityProto.ID id, Str strings, EntityLayout layout, EntityCosts costs, Gfx graphics, ImmutableArray<AnimationParams> animationParams)
//                 : base(id, strings, layout, costs, graphics)
//            {
//                this.AnimationParams = animationParams;
//            }
//            public ImmutableArray<AnimationParams> AnimationParams { get; }
//            public enum TransportType
//            {
//                Unkown,
//                Flat,
//                Loose,
//                Fluid,
//                Molten,
//                Shaft
//            }
//            public override Type EntityType => typeof(TransPEntity);

//            public readonly Quantity MaxQuantityPerTransportedProduct;
//            public TransportType transportType;
//            public PartialQuantity ThroughputPerTick;
//            public RelTile1f SpeedPerTick;
//        }

//        public new TransPEntityProto Prototype
//        {
//            get
//            {
//                return _proto;
//            }
//            protected set
//            {
//                _proto = value;
//                base.Prototype = value;
//            }
//        }
//        [InitAfterLoad(InitPriority.Normal)]
//        private void initialize()
//        {
//            this.recomputePortInfo();
//            PColors.Init();
//        }
//        public new void OnPortConnectionChanged(IoPort ourPort, IoPort otherPort)
//        {
//            this.recomputePortInfo();
//            if (!ourPort.IsNotConnected)
//                return;
//            int portIndex = (int)ourPort.PortIndex;
//            if (_inputBuffer[portIndex].IsNotEmpty)
//                return;
//            this.moveInputToOutBuffer(portIndex);
//        }

//        void IEntityWithSimUpdate.SimUpdate()
//        {

//            if (IsNotEnabled || _connectedOutputPortsCache.IsNotValid)
//            {
//                return;
//            }
//            if (_quantityInOutputBuffer < this.MaxBufferSize)
//            {

//                int num = 0;
//                for (int length = _connectedInputPortsCache.Length; num < length; ++num)
//                {
//                    int index = (_lastUsedInputPortIndex + 1) % length;
//                    _lastUsedInputPortIndex = index;
//                    IoPortData ioPortData = _connectedInputPortsCache[index];
//                    if (!_inputBuffer[(int)ioPortData.PortIndex].IsEmpty)
//                    {
//                        moveInputToOutBuffer((int)ioPortData.PortIndex);
//                        if (_quantityInOutputBuffer >= this.MaxBufferSize)
//                            break;
//                    }
//                }
//            }
//            if (_quantityInOutputBuffer.IsNotPositive)
//            {
//                return;
//            }
//            this.tryReleaseFirstProduct();

//        }
//        protected override IoPortType? PortTypeOverride => null;

//        public bool IsFullyConnected { get; private set; }
//        public bool IsProductsRemovalInProgress { get; private set; }
//        public bool IsMoving { get; private set; }

//        public enum Status
//        {
//            Idle,
//            NotConnected,
//            Moving,
//            Paused,
//            PowerLow,
//            ProductRemoval,
//        }


//        protected override void OnAddedToWorld(EntityAddReason reason)
//        {
//            base.OnAddedToWorld(reason);
//            string tit = DefaultTitle.Value;
//            IoPortTemplate[] newTemplate = null;
//            IoPort chkPort = null;
//            IoPort ourPort = null;
//            bool portfound = false;
//            foreach (IoPort pt in Ports)
//            {
//                chkPort = null;

//                int di = pt.Direction.DirectionIndex;

//                if (di == 0)
//                {
//                    Context.IoPortsManager.TryGetPortAt(pt.Position.AddX(1), new Direction903d(3), out chkPort);
//                }
//                if (di == 1)
//                {
//                    Context.IoPortsManager.TryGetPortAt(pt.Position.AddY(1), new Direction903d(4), out chkPort);
//                }
//                if (di == 3)
//                {
//                    Context.IoPortsManager.TryGetPortAt(pt.Position.AddX(-1), new Direction903d(0), out chkPort);
//                }
//                if (di == 4)
//                {
//                    Context.IoPortsManager.TryGetPortAt(pt.Position.AddY(-1), new Direction903d(1), out chkPort);
//                }



//                if (chkPort != null)
//                {
//                    if (tit == "Loader A")
//                    {
//                        newTemplate = shapeLoader1(chkPort.ShapePrototype);
//                        portfound = true;
//                        ourPort = pt;
//                        break;
//                    }
//                    if (tit == "Trans Bar 2m")
//                    {
//                        newTemplate = shapeTransBar2m(chkPort.ShapePrototype);
//                        portfound = true;
//                        ourPort = pt;
//                        break;
//                    }
//                    if (tit == "Trans Bar 4m")
//                    {
//                        newTemplate = shapeTransBar4m(chkPort.ShapePrototype);
//                        portfound = true;
//                        ourPort = pt;
//                        break;
//                    }
//                    if (tit == "Trans Bar 20m")
//                    {
//                        newTemplate = shapeTransBar10m(chkPort.ShapePrototype);
//                        portfound = true;
//                        ourPort = pt;
//                        break;
//                    }
//                    if (tit.Contains("Balancer") == true)
//                    {

//                        Int32.TryParse(tit.Substring(9, 1), out int h);
//                        newTemplate = sbalancer(chkPort.ShapePrototype, h);
//                        portfound = true;
//                        ourPort = pt;
//                        break;
//                    }
//                    if (tit == "IN" || tit == "INtxt")
//                    {
//                        portfound = true;
//                        newTemplate = shapeTemp1(chkPort.ShapePrototype);
//                        ourPort = pt;
//                        break;
//                    }
//                    if (tit == "OUT")
//                    {
//                        newTemplate = shapeTemp4(chkPort.ShapePrototype);
//                        portfound = true;
//                        ourPort = pt;
//                    }
//                    if (tit == "Straight 20m")
//                    {
//                        newTemplate = shapeTemp2(chkPort.ShapePrototype);
//                        portfound = true;
//                        ourPort = pt;
//                        break;
//                    }
//                    if (tit == "Straight 40m")
//                    {
//                        newTemplate = shapeTemp3(chkPort.ShapePrototype);
//                        portfound = true;
//                        ourPort = pt;
//                        break;
//                    }
//                    if (tit == "Straight 100m")
//                    {
//                        newTemplate = shapeTemp6(chkPort.ShapePrototype);
//                        portfound = true;
//                        ourPort = pt;
//                        break;
//                    }
//                    if (tit == "Height Fix")
//                    {
//                        newTemplate = shapeTemp5(chkPort.ShapePrototype);
//                        portfound = true;
//                        ourPort = pt;
//                        break;
//                    }
//                }
//                else
//                {
//                    Log.Debug("No port found!!!");
//                }


//            }

//            if (portfound == true)
//            {
//                //foreach (IoPort port in this.Ports)
//                //{
//                //    this.Context.IoPortsManager.DisconnectAndRemove(port);

//                //}
//                //foreach (IoPortTemplate temp in base.Prototype.Layout.LayoutTiles)


//                //new IoPortTemplate(new PortSpec('A', IoPortType.Input, shape, false), new RelTile3i(0, 0, 2), Direction90.MinusX),
//                Upgrade(newTemplate);
//                OnPortConnectionChanged(chkPort, ourPort);
//                base.MakeFullyConstructed();
//                this.tryReleaseFirstProduct();

//            }
//            if (this.ConstructionState != ConstructionState.NotInitialized)
//                return;
//            foreach (IoPort port in this.Ports)
//            {
//                if (port.ConnectedPort.HasValue && port.ConnectedPort.Value.OwnerEntity.IsConstructed)
//                {
//                    this.StartConstructionIfNotStarted();
//                    break;
//                }
//            }
//        }
//        private void createPorts(IoPortTemplate[] newTemp)
//        {
//            IEntityWithPorts thisWithPorts = this as IEntityWithPorts;
//            if (thisWithPorts != null)
//            {
//                this.Ports = base.Prototype.Ports.Map<IoPort>((IoPortTemplate x, int i) => IoPort.CreateFor<IEntityWithPorts>(this.Context.PortIdFactory.GetNextId(), thisWithPorts, this.Prototype.Layout, this.Transform, newTemp[i], i, this.PortTypeOverride));
//                return;
//            }
//            this.Ports = ImmutableArray<IoPort>.Empty;
//            Assert.That<bool>(this.Ports.IsEmpty).IsTrue(string.Format("{0} ({1}) has '{2}' ports ", base.Prototype, base.GetType().Name, this.Ports.Length) + "but does not implement 'IEntityWithPorts' interface");
//        }
//        public void Upgrade(IoPortTemplate[] newTemp)
//        {
//            foreach (IoPort port in this.Ports)
//                this.Context.IoPortsManager.DisconnectAndRemove(port);
//            this.createPorts(newTemp);
//            foreach (IoPort port in this.Ports)
//                this.Context.IoPortsManager.AddPortAndTryConnect(port);
//        }

//        public Quantity sendToOuputPort(ProductQuantity quantity)
//        {
//            if (ConnectedOutputPorts.Length > 0)
//            {
//                IoPortData ioPortData = ConnectedOutputPorts[0];
//                return ioPortData.SendAsMuchAs(quantity);
//            }
//            else { return quantity.Quantity; }
//        }
//        private void recomputePortInfo()
//        {
//            ImmutableArray<IoPort> immutableArray = this.Ports;
//            immutableArray = immutableArray.Filter((Predicate<IoPort>)(x => x.IsConnectedAsInput));
//            _connectedInputPortsCache = immutableArray.Map<IoPortData>((Func<IoPort, IoPortData>)(x => new IoPortData(x)));
//            immutableArray = this.Ports;
//            immutableArray = immutableArray.Filter((Predicate<IoPort>)(x => x.IsConnectedAsOutput));
//            _connectedOutputPortsCache = immutableArray.Map<IoPortData>((Func<IoPort, IoPortData>)(x => new IoPortData(x)));
//        }
//        Quantity IEntityWithPorts.ReceiveAsMuchAsFromPort(ProductQuantity pq, IoPortToken sourcePort)
//        {
//            if (this.IsNotEnabled)
//            {
//                if (this.ConstructionState == ConstructionState.NotInitialized)
//                {
//                    Log.Warning("Mini-zipper was not constructed when it received products.");
//                    this.StartConstructionIfNotStarted();
//                    Assert.That<ConstructionState>(this.ConstructionState).IsNotEqualTo<ConstructionState>(ConstructionState.NotInitialized);
//                }
//                return pq.Quantity;
//            }
//            if (_inputBuffer[(int)sourcePort.PortIndex].IsNotEmpty)
//                return pq.Quantity;
//            _inputBuffer[(int)sourcePort.PortIndex] = pq;
//            _quantityInInputBuffer += pq.Quantity;
//            return Quantity.Zero;

//        }
//        private void moveInputToOutBuffer(int index)
//        {
//            ProductQuantity productQuantity = _inputBuffer[index];
//            _quantityInInputBuffer -= productQuantity.Quantity;
//            _quantityInOutputBuffer += productQuantity.Quantity;
//            _inputBuffer[index] = ProductQuantity.None;
//            if (_outputBuffer.IsNotEmpty)
//            {
//                ZipBuffProduct last = _outputBuffer.Last;
//                if (last.EnqueuedAtStep == _simLoopEvents.CurrentStep && (Proto)last.ProductQuantity.Product == (Proto)productQuantity.Product)
//                {
//                    _outputBuffer.PopLast();
//                    productQuantity = productQuantity.WithNewQuantity(last.ProductQuantity.Quantity + productQuantity.Quantity);
//                }
//            }
//            else
//            {
//                //myColor = Color.grey;
//            }
//            _outputBuffer.Enqueue(new ZipBuffProduct(productQuantity, _simLoopEvents.CurrentStep));
//        }
//        private void tryReleaseFirstProduct()
//        {
//            if (PColors == null)
//            {
//                PColors = new ProductColorManager(_protosDb);
//                PColors.Init();

//            }
//            if (_outputBuffer.IsEmpty)
//            {
//                Log.Error(string.Format("Invalid state, m_outputBuffer is empty but quantityInOutputBuffer is {0}", (object)_quantityInOutputBuffer));
//                _quantityInOutputBuffer = Quantity.Zero;
//            }
//            else
//            {
//                ZipBuffProduct zipBuffProduct = _outputBuffer.Peek();
//                if (_simLoopEvents.CurrentStep - zipBuffProduct.EnqueuedAtStep < m_delay)
//                    return;
//                ImmutableArray<IoPortData> outputPortsCache = _connectedOutputPortsCache;
//                ProductQuantity productQuantity = zipBuffProduct.ProductQuantity;
//                currentProduct = productQuantity.Product;

//                //                if (PColors != null)
//                myColor = PColors.GetColor(productQuantity.Product.Id, true);



//                int num = 0;
//                for (int length = outputPortsCache.Length; num < length; ++num)
//                {
//                    int index = (_lastUsedOutputPortIndex + 1) % length;
//                    _lastUsedOutputPortIndex = index;
//                    outputPortsCache[index].SendAsMuchAs(ref productQuantity);
//                    if (productQuantity.IsEmpty)
//                    {
//                        _quantityInOutputBuffer -= zipBuffProduct.ProductQuantity.Quantity;
//                        _outputBuffer.Dequeue();
//                        return;
//                    }
//                }
//                Assert.That<Quantity>(productQuantity.Quantity).IsLessOrEqual(zipBuffProduct.ProductQuantity.Quantity);
//                if (!(productQuantity.Quantity < zipBuffProduct.ProductQuantity.Quantity))
//                {
//                    //                    if (PColors != null)
//                    myColor = PColors.GetColor(productQuantity.Product.Id, false);
//                    return;
//                }

//                this._outputBuffer.GetRefFirst() = new ZipBuffProduct(productQuantity, zipBuffProduct.EnqueuedAtStep);
//                _quantityInOutputBuffer -= zipBuffProduct.ProductQuantity.Quantity - productQuantity.Quantity;
//            }
//        }

//        private void recomputeBufferSizeAndThresholds()
//        {
//            PartialQuantity zero1 = PartialQuantity.Zero;
//            PartialQuantity zero2 = PartialQuantity.Zero;
//            foreach (IoPort port in this.Ports)
//            {
//                if (port.IsConnected)
//                {
//                    PartialQuantity throughputPerTick = port.GetMaxThroughputPerTick();
//                    if (port.IsConnectedAsInput)
//                        zero1 += throughputPerTick;
//                    else if (port.IsConnectedAsOutput)
//                        zero2 += throughputPerTick;
//                    else
//                        Log.Error("Port connected but is not input or output.");
//                }
//            }
//            PartialQuantity partialQuantity = zero1.Min(zero2);
//            m_delay = !(partialQuantity.Value <= Fix32.One) ? (!(partialQuantity.Value <= Fix32.Three) ? 2.Ticks() : 5.Ticks()) : 10.Ticks();
//            _maxBufferSize = (3 * m_delay.Ticks / 2 * partialQuantity).ToQuantityCeiled();
//        }
//        protected override void OnDestroy()
//        {
//            IAssetTransactionManager transactionManager = this.Context.AssetTransactionManager;
//            for (int index = 0; index < _inputBuffer.Length; ++index)
//            {
//                transactionManager.StoreClearedProduct(_inputBuffer[index]);
//                _inputBuffer[index] = ProductQuantity.None;
//            }
//            foreach (ZipBuffProduct zipBuffProduct in _outputBuffer)
//            {
//                if (zipBuffProduct.ProductQuantity.IsNotEmpty)
//                    transactionManager.StoreClearedProduct(zipBuffProduct.ProductQuantity);
//            }
//            _outputBuffer.Clear();
//            base.OnDestroy();
//        }
//        public static void Serialize(TransPEntity value, BlobWriter writer)
//        {
//            if (!writer.TryStartClassSerialization<TransPEntity>(value))
//                return;
//            writer.EnqueueDataSerialization((object)value, TransPEntity.s_serializeDataDelayedAction);
//        }
//        protected override void SerializeData(BlobWriter writer)
//        {
//            base.SerializeData(writer);
//            //            ProductColorManager.Serialize(PColors, writer);
//            //            writer.WriteGeneric<ProductColorManager>(this.PColors);
//            Duration.Serialize(this.m_delay, writer);
//            ColorRgba.Serialize(new ColorRgba(myColor.r, myColor.g, myColor.b, myColor.a), writer);
//            writer.WriteArray<ProductQuantity>(_inputBuffer);
//            writer.WriteInt(_lastUsedInputPortIndex);
//            writer.WriteInt(_lastUsedOutputPortIndex);
//            Quantity.Serialize(_maxBufferSize, writer);
//            Queueue<ZipBuffProduct>.Serialize(_outputBuffer, writer);
//            Quantity.Serialize(_quantityInInputBuffer, writer);
//            Quantity.Serialize(_quantityInOutputBuffer, writer);
//            writer.WriteGeneric<ISimLoopEvents>(_simLoopEvents);
//            ImmutableArray<IoPort>.Serialize(this.Ports, writer);
//            writer.WriteGeneric<TransPEntityProto>(this.Prototype);


//        }
//        public static TransPEntity Deserialize(BlobReader reader)
//        {
//            TransPEntity miniZipper;
//            if (reader.TryStartClassDeserialization<TransPEntity>(out miniZipper))
//                reader.EnqueueDataDeserialization((object)miniZipper, TransPEntity.s_deserializeDataDelayedAction);
//            return miniZipper;
//        }
//        protected override void DeserializeData(BlobReader reader)
//        {
//            base.DeserializeData(reader);
//            //            ProductColorManager.Deserialize(reader);
//            //            reader.SetField<TransPEntity>(this, "PColors" ,(object)reader.ReadGenericAs<ProductColorManager>());
//            this.m_delay = Duration.Deserialize(reader);
//            ColorRgba mcolor = ColorRgba.Deserialize(reader);
//            this.myColor = mcolor.ToColor32();
//            reader.SetField<TransPEntity>(this, "_inputBuffer", (object)reader.ReadArray<ProductQuantity>());
//            _lastUsedInputPortIndex = reader.ReadInt();
//            _lastUsedOutputPortIndex = reader.ReadInt();
//            _maxBufferSize = Quantity.Deserialize(reader);
//            reader.SetField<TransPEntity>(this, "_outputBuffer", (object)Queueue<ZipBuffProduct>.Deserialize(reader));
//            _quantityInInputBuffer = Quantity.Deserialize(reader);
//            _quantityInOutputBuffer = Quantity.Deserialize(reader);
//            reader.SetField<TransPEntity>(this, "_simLoopEvents", (object)reader.ReadGenericAs<ISimLoopEvents>());
//            this.Ports = ImmutableArray<IoPort>.Deserialize(reader);
//            reader.SetField<TransPEntity>(this, "_proto", (object)reader.ReadGenericAs<TransPEntityProto>());
//        }

//        static TransPEntity()
//        {
//            TransPEntity.s_serializeDataDelayedAction = delegate (object obj, BlobWriter writer)
//            {
//                ((TransPEntity)obj).SerializeData(writer);
//            };
//            TransPEntity.s_deserializeDataDelayedAction = delegate (object obj, BlobReader reader)
//            {
//                ((TransPEntity)obj).DeserializeData(reader);
//            };
//        }

//    }
//}