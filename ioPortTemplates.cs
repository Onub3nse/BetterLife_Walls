using Mafi;
using Mafi.Core.Ports.Io;
using System;
namespace BetterLife_Walls

{
    public static class portTemplates
    {
        public static class balancersShapes
        {
            public static IoPortTemplate[] shapeBalancer(IoPortShapeProto shape, int height)
            {
                if (height > 0)
                {
                    IoPortTemplate[] temp = new IoPortTemplate[]
                    {
                            new IoPortTemplate(new PortSpec('A', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                            new IoPortTemplate(new PortSpec('B', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('C', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),
                            new IoPortTemplate(new PortSpec('D', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusX),
                            new IoPortTemplate(new PortSpec('E', IoPortType.Any, shape, false), new RelTile3i(0, 0, height), Direction90.PlusX),
                            new IoPortTemplate(new PortSpec('F', IoPortType.Any, shape, false), new RelTile3i(0, 0, height), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('G', IoPortType.Any, shape, false), new RelTile3i(0, 0, height), Direction90.PlusY),
                            new IoPortTemplate(new PortSpec('H', IoPortType.Any, shape, false), new RelTile3i(0, 0, height), Direction90.MinusX),
                    };
                    return temp;
                }
                else
                {
                    IoPortTemplate[] temp = new IoPortTemplate[]
                    {
                            new IoPortTemplate(new PortSpec('A', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                            new IoPortTemplate(new PortSpec('B', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('C', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),
                            new IoPortTemplate(new PortSpec('D', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusX),
                    };
                    return temp;
                }
            }
        }
        public static class transPORTshapes
        {
            public static IoPortTemplate[] shapeAuto(string tit, IoPortShapeProto shape)
            {
                if (tit == "Loader A")
                {
                    IoPortTemplate[] temp = new IoPortTemplate[]
                    {
                        new IoPortTemplate(new PortSpec('A', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                        new IoPortTemplate(new PortSpec('B', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('C', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

                        new IoPortTemplate(new PortSpec('D', IoPortType.Any, shape, false), new RelTile3i(2, 0, 0), Direction90.PlusX),
                        new IoPortTemplate(new PortSpec('E', IoPortType.Any, shape, false), new RelTile3i(2, 0, 0), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('F', IoPortType.Any, shape, false), new RelTile3i(2, 0, 0), Direction90.PlusY),
                        new IoPortTemplate(new PortSpec('G', IoPortType.Any, shape, false), new RelTile3i(4, 0, 0), Direction90.PlusX),
                        new IoPortTemplate(new PortSpec('H', IoPortType.Any, shape, false), new RelTile3i(4, 0, 0), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('I', IoPortType.Any, shape, false), new RelTile3i(4, 0, 0), Direction90.PlusY),
                    };
                    return temp;
                }
                if (tit == "Trans Bar 2m")
                {
                    IoPortTemplate[] temp = new IoPortTemplate[]
                    {
                            new IoPortTemplate(new PortSpec('A', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                            new IoPortTemplate(new PortSpec('B', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('C', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

                            new IoPortTemplate(new PortSpec('D', IoPortType.Any, shape, false), new RelTile3i(1, 0, 0), Direction90.PlusX),
                            new IoPortTemplate(new PortSpec('E', IoPortType.Any, shape, false), new RelTile3i(1, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('F', IoPortType.Any, shape, false), new RelTile3i(1, 0, 0), Direction90.PlusY),

                    };
                    return temp;
                }
                if (tit == "Trans Bar 4m")
                {
                    IoPortTemplate[] temp = new IoPortTemplate[]
                    {
                            new IoPortTemplate(new PortSpec('A', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                            new IoPortTemplate(new PortSpec('B', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('C', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

                            new IoPortTemplate(new PortSpec('D', IoPortType.Any, shape, false), new RelTile3i(3, 0, 0), Direction90.PlusX),
                            new IoPortTemplate(new PortSpec('E', IoPortType.Any, shape, false), new RelTile3i(3, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('F', IoPortType.Any, shape, false), new RelTile3i(3, 0, 0), Direction90.PlusY),

                    };
                    return temp;
                }
                if (tit == "Trans Bar 20m")
                {
                    IoPortTemplate[] temp = new IoPortTemplate[]
                        {
                            new IoPortTemplate(new PortSpec('A', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                            new IoPortTemplate(new PortSpec('B', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('C', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

                            new IoPortTemplate(new PortSpec('D', IoPortType.Any, shape, false), new RelTile3i(9, 0, 0), Direction90.PlusX),
                            new IoPortTemplate(new PortSpec('E', IoPortType.Any, shape, false), new RelTile3i(9, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('F', IoPortType.Any, shape, false), new RelTile3i(9, 0, 0), Direction90.PlusY),

                        };
                    return temp;
                }
                if (tit.Contains("Balancer") == true)
                {

                    Int32.TryParse(tit.Substring(9, 1), out int h);
                    IoPortTemplate[] temp = new IoPortTemplate[]
                    {
                            new IoPortTemplate(new PortSpec('A', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                            new IoPortTemplate(new PortSpec('B', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('C', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),
                            new IoPortTemplate(new PortSpec('D', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusX),
                            new IoPortTemplate(new PortSpec('E', IoPortType.Any, shape, false), new RelTile3i(0, 0, h), Direction90.PlusX),
                            new IoPortTemplate(new PortSpec('F', IoPortType.Any, shape, false), new RelTile3i(0, 0, h), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('G', IoPortType.Any, shape, false), new RelTile3i(0, 0, h), Direction90.PlusY),
                            new IoPortTemplate(new PortSpec('H', IoPortType.Any, shape, false), new RelTile3i(0, 0, h), Direction90.MinusX),
                    };
                    return temp;
                }
                if (tit == "Straight 20m")
                {
                    IoPortTemplate[] temp = new IoPortTemplate[]
                    {
                        new IoPortTemplate(new PortSpec('A', IoPortType.Any, shape, false), new RelTile3i(0, 0, 5), Direction90.MinusX),
                        new IoPortTemplate(new PortSpec('B', IoPortType.Any, shape, false), new RelTile3i(0, 0, 5), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('C', IoPortType.Any, shape, false), new RelTile3i(0, 0, 5), Direction90.PlusY),
                        new IoPortTemplate(new PortSpec('D', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                        new IoPortTemplate(new PortSpec('E', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('F', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

                        new IoPortTemplate(new PortSpec('G', IoPortType.Any, shape, false), new RelTile3i(9, 0, 5), Direction90.PlusX),
                        new IoPortTemplate(new PortSpec('H', IoPortType.Any, shape, false), new RelTile3i(9, 0, 5), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('I', IoPortType.Any, shape, false), new RelTile3i(9, 0, 5), Direction90.PlusY),
                        new IoPortTemplate(new PortSpec('J', IoPortType.Any, shape, false), new RelTile3i(9, 0, 0), Direction90.PlusX),
                        new IoPortTemplate(new PortSpec('K', IoPortType.Any, shape, false), new RelTile3i(9, 0, 0), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('L', IoPortType.Any, shape, false), new RelTile3i(9, 0, 0), Direction90.PlusY),
                    };
                    return temp;
                }
                if (tit == "Straight 40m")
                {
                    IoPortTemplate[] temp = new IoPortTemplate[]
                    {
                        new IoPortTemplate(new PortSpec('A', IoPortType.Any, shape, false), new RelTile3i(0, 0, 5), Direction90.MinusX),
                        new IoPortTemplate(new PortSpec('B', IoPortType.Any, shape, false), new RelTile3i(0, 0, 5), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('C', IoPortType.Any, shape, false), new RelTile3i(0, 0, 5), Direction90.PlusY),
                        new IoPortTemplate(new PortSpec('D', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                        new IoPortTemplate(new PortSpec('E', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('F', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

                        new IoPortTemplate(new PortSpec('G', IoPortType.Any, shape, false), new RelTile3i(19, 0, 5), Direction90.PlusX),
                        new IoPortTemplate(new PortSpec('H', IoPortType.Any, shape, false), new RelTile3i(19, 0, 5), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('I', IoPortType.Any, shape, false), new RelTile3i(19, 0, 5), Direction90.PlusY),
                        new IoPortTemplate(new PortSpec('J', IoPortType.Any, shape, false), new RelTile3i(19, 0, 0), Direction90.PlusX),
                        new IoPortTemplate(new PortSpec('K', IoPortType.Any, shape, false), new RelTile3i(19, 0, 0), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('L', IoPortType.Any, shape, false), new RelTile3i(19, 0, 0), Direction90.PlusY),
                    };
                    return temp;
                }
                if (tit == "Straight 100m")
                {
                    IoPortTemplate[] temp = new IoPortTemplate[]
                    {

                        new IoPortTemplate(new PortSpec('A', IoPortType.Any, shape, false), new RelTile3i(0, 0, 5), Direction90.MinusX),
                        new IoPortTemplate(new PortSpec('B', IoPortType.Any, shape, false), new RelTile3i(0, 0, 5), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('C', IoPortType.Any, shape, false), new RelTile3i(0, 0, 5), Direction90.PlusY),
                        new IoPortTemplate(new PortSpec('D', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                        new IoPortTemplate(new PortSpec('E', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('F', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

                        new IoPortTemplate(new PortSpec('G', IoPortType.Any, shape, false), new RelTile3i(49, 0, 5), Direction90.PlusX),
                        new IoPortTemplate(new PortSpec('H', IoPortType.Any, shape, false), new RelTile3i(49, 0, 5), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('I', IoPortType.Any, shape, false), new RelTile3i(49, 0, 5), Direction90.PlusY),
                        new IoPortTemplate(new PortSpec('J', IoPortType.Any, shape, false), new RelTile3i(49, 0, 0), Direction90.PlusX),
                        new IoPortTemplate(new PortSpec('K', IoPortType.Any, shape, false), new RelTile3i(49, 0, 0), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('L', IoPortType.Any, shape, false), new RelTile3i(49, 0, 0), Direction90.PlusY),
                    };
                    return temp;
                }
                return null;
            }



            public static IoPortTemplate[] shapeTrans10(IoPortShapeProto shape)
            {
                IoPortTemplate[] temp = new IoPortTemplate[]
                {
                        new IoPortTemplate(new PortSpec('A', IoPortType.Any, shape, false), new RelTile3i(0, 0, 5), Direction90.MinusX),
                        new IoPortTemplate(new PortSpec('B', IoPortType.Any, shape, false), new RelTile3i(0, 0, 5), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('C', IoPortType.Any, shape, false), new RelTile3i(0, 0, 5), Direction90.PlusY),
                        new IoPortTemplate(new PortSpec('D', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                        new IoPortTemplate(new PortSpec('E', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('F', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

                        new IoPortTemplate(new PortSpec('G', IoPortType.Any, shape, false), new RelTile3i(9, 0, 5), Direction90.PlusX),
                        new IoPortTemplate(new PortSpec('H', IoPortType.Any, shape, false), new RelTile3i(9, 0, 5), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('I', IoPortType.Any, shape, false), new RelTile3i(9, 0, 5), Direction90.PlusY),
                        new IoPortTemplate(new PortSpec('J', IoPortType.Any, shape, false), new RelTile3i(9, 0, 0), Direction90.PlusX),
                        new IoPortTemplate(new PortSpec('K', IoPortType.Any, shape, false), new RelTile3i(9, 0, 0), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('L', IoPortType.Any, shape, false), new RelTile3i(9, 0, 0), Direction90.PlusY),
                };
                return temp;
            }
            public static IoPortTemplate[] shapeTrans20(IoPortShapeProto shape)
            {
                IoPortTemplate[] temp = new IoPortTemplate[]
                {
                        new IoPortTemplate(new PortSpec('A', IoPortType.Any, shape, false), new RelTile3i(0, 0, 5), Direction90.MinusX),
                        new IoPortTemplate(new PortSpec('B', IoPortType.Any, shape, false), new RelTile3i(0, 0, 5), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('C', IoPortType.Any, shape, false), new RelTile3i(0, 0, 5), Direction90.PlusY),
                        new IoPortTemplate(new PortSpec('D', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                        new IoPortTemplate(new PortSpec('E', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('F', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

                        new IoPortTemplate(new PortSpec('G', IoPortType.Any, shape, false), new RelTile3i(19, 0, 5), Direction90.PlusX),
                        new IoPortTemplate(new PortSpec('H', IoPortType.Any, shape, false), new RelTile3i(19, 0, 5), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('I', IoPortType.Any, shape, false), new RelTile3i(19, 0, 5), Direction90.PlusY),
                        new IoPortTemplate(new PortSpec('J', IoPortType.Any, shape, false), new RelTile3i(19, 0, 0), Direction90.PlusX),
                        new IoPortTemplate(new PortSpec('K', IoPortType.Any, shape, false), new RelTile3i(19, 0, 0), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('L', IoPortType.Any, shape, false), new RelTile3i(19, 0, 0), Direction90.PlusY),
                };
                return temp;
            }
            public static IoPortTemplate[] shapeTrans100(IoPortShapeProto shape)
            {
                IoPortTemplate[] temp = new IoPortTemplate[]
                {

                        new IoPortTemplate(new PortSpec('A', IoPortType.Any, shape, false), new RelTile3i(0, 0, 5), Direction90.MinusX),
                        new IoPortTemplate(new PortSpec('B', IoPortType.Any, shape, false), new RelTile3i(0, 0, 5), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('C', IoPortType.Any, shape, false), new RelTile3i(0, 0, 5), Direction90.PlusY),
                        new IoPortTemplate(new PortSpec('D', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                        new IoPortTemplate(new PortSpec('E', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('F', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

                        new IoPortTemplate(new PortSpec('G', IoPortType.Any, shape, false), new RelTile3i(49, 0, 5), Direction90.PlusX),
                        new IoPortTemplate(new PortSpec('H', IoPortType.Any, shape, false), new RelTile3i(49, 0, 5), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('I', IoPortType.Any, shape, false), new RelTile3i(49, 0, 5), Direction90.PlusY),
                        new IoPortTemplate(new PortSpec('J', IoPortType.Any, shape, false), new RelTile3i(49, 0, 0), Direction90.PlusX),
                        new IoPortTemplate(new PortSpec('K', IoPortType.Any, shape, false), new RelTile3i(49, 0, 0), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('L', IoPortType.Any, shape, false), new RelTile3i(49, 0, 0), Direction90.PlusY),
                };
                return temp;
            }
            public static IoPortTemplate[] shapeLoader1(IoPortShapeProto shape)
            {
                IoPortTemplate[] temp = new IoPortTemplate[]
                {
                        new IoPortTemplate(new PortSpec('A', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                        new IoPortTemplate(new PortSpec('B', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('C', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

                        new IoPortTemplate(new PortSpec('D', IoPortType.Any, shape, false), new RelTile3i(2, 0, 0), Direction90.PlusX),
                        new IoPortTemplate(new PortSpec('E', IoPortType.Any, shape, false), new RelTile3i(2, 0, 0), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('F', IoPortType.Any, shape, false), new RelTile3i(2, 0, 0), Direction90.PlusY),
                        new IoPortTemplate(new PortSpec('G', IoPortType.Any, shape, false), new RelTile3i(4, 0, 0), Direction90.PlusX),
                        new IoPortTemplate(new PortSpec('H', IoPortType.Any, shape, false), new RelTile3i(4, 0, 0), Direction90.MinusY),
                        new IoPortTemplate(new PortSpec('I', IoPortType.Any, shape, false), new RelTile3i(4, 0, 0), Direction90.PlusY),
                };
                return temp;
            }

            public static IoPortTemplate[] shapeTransBar2m(IoPortShapeProto shape)
            {
                IoPortTemplate[] temp = new IoPortTemplate[]
                {
                            new IoPortTemplate(new PortSpec('A', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                            new IoPortTemplate(new PortSpec('B', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('C', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

                            new IoPortTemplate(new PortSpec('D', IoPortType.Any, shape, false), new RelTile3i(1, 0, 0), Direction90.PlusX),
                            new IoPortTemplate(new PortSpec('E', IoPortType.Any, shape, false), new RelTile3i(1, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('F', IoPortType.Any, shape, false), new RelTile3i(1, 0, 0), Direction90.PlusY),

                };
                return temp;
            }
            public static IoPortTemplate[] shapeTransBar4m(IoPortShapeProto shape)
            {
                IoPortTemplate[] temp = new IoPortTemplate[]
                {
                            new IoPortTemplate(new PortSpec('A', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                            new IoPortTemplate(new PortSpec('B', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('C', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

                            new IoPortTemplate(new PortSpec('D', IoPortType.Any, shape, false), new RelTile3i(3, 0, 0), Direction90.PlusX),
                            new IoPortTemplate(new PortSpec('E', IoPortType.Any, shape, false), new RelTile3i(3, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('F', IoPortType.Any, shape, false), new RelTile3i(3, 0, 0), Direction90.PlusY),

                };
                return temp;
            }
            public static IoPortTemplate[] shapeTransBar10m(IoPortShapeProto shape)
            {
                IoPortTemplate[] temp = new IoPortTemplate[]
                {
                            new IoPortTemplate(new PortSpec('A', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusX),
                            new IoPortTemplate(new PortSpec('B', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('C', IoPortType.Any, shape, false), new RelTile3i(0, 0, 0), Direction90.PlusY),

                            new IoPortTemplate(new PortSpec('D', IoPortType.Any, shape, false), new RelTile3i(9, 0, 0), Direction90.PlusX),
                            new IoPortTemplate(new PortSpec('E', IoPortType.Any, shape, false), new RelTile3i(9, 0, 0), Direction90.MinusY),
                            new IoPortTemplate(new PortSpec('F', IoPortType.Any, shape, false), new RelTile3i(9, 0, 0), Direction90.PlusY),

                };
                return temp;
            }
        }

    }
}
