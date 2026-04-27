using Mafi;
using Mafi.Base;
using Mafi.Collections;
using Mafi.Core.Products;
using Mafi.Core.Prototypes;
using Mafi.Serialization;
using Mafi.Unity;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using ProductID = Mafi.Core.Products.ProductProto.ID;

namespace BetterLife
{

    [GenerateSerializer(false, null, 0)]
    [GlobalDependency(RegistrationMode.AsEverything, false, false)]

    public class ProductColorManager
    {
        private static readonly Action<object, BlobReader> s_deserializeDataDelayedAction;
        private static readonly Action<object, BlobWriter> s_serializeDataDelayedAction;
        public static void Serialize(ProductColorManager value, BlobWriter writer)
        {
            if (writer.TryStartClassSerialization<ProductColorManager>(value))
            {
                writer.EnqueueDataSerialization(value, s_serializeDataDelayedAction);
            }
        }
        public static ProductColorManager Deserialize(BlobReader reader)
        {
            if (reader.TryStartClassDeserialization(out ProductColorManager obj, (Func<BlobReader, Type, ProductColorManager>)null))
            {
                reader.EnqueueDataDeserialization(obj, s_deserializeDataDelayedAction);
            }

            return obj;
        }
        public void SerializeData(BlobWriter writer)
        {
            Dict<ProductProto.ID, ColorRgba>.Serialize(m_colorList, writer);
            Dict<ProductProto.ID, ColorRgba>.Serialize(m_defaultColorList, writer);
        }
        private void DeserializeData(BlobReader reader)
        {
            reader.SetField(this, "m_colorList", Dict<ProductProto.ID, ColorRgba>.Deserialize(reader));
            reader.SetField(this, "m_defaultColorList", Dict<ProductProto.ID, ColorRgba>.Deserialize(reader));
        }

        private ProtosDb protosDb;

        public ProductColorManager(ProtosDb protosDb)
        {
            this.protosDb = protosDb;
        }

        public ProductColorManager Init()
        {
            m_colorList = new Dict<ProductID, ColorRgba>(m_defaultColorList);
            return this;
        }
        public Dict<ProductProto.ID, ColorRgba> m_colorList = new Dict<ProductID, ColorRgba>();

        private readonly Dict<ProductProto.ID, ColorRgba> m_defaultColorList = new Dict<ProductProto.ID, ColorRgba>
        {
            {Ids.Products.Acid,                new ColorRgba(255,255,127)},
            {Ids.Products.Ammonia,             new ColorRgba(224, 244, 244)},
            {Ids.Products.Anesthetics,         new ColorRgba(112,138,255)},
            {Ids.Products.AnimalFeed,          new ColorRgba(255,244,33) },
            {Ids.Products.Antibiotics,         new ColorRgba(173,165,255) },
            {Ids.Products.Biomass,             new ColorRgba(99,127,93)},
            {Ids.Products.BlanketFuel,         new ColorRgba(193,133,36)},
            {Ids.Products.BlanketFuelEnriched, new ColorRgba(203,143,46)},
            {Ids.Products.Bread,               new ColorRgba(239,189,103)},
            {Ids.Products.Bricks,              new ColorRgba(239,143,0)},
            {Ids.Products.Brine,               new ColorRgba(9,239,202)},
            {Ids.Products.BrokenGlass,         new ColorRgba(182,239,232)},
            {Ids.Products.Cake,                new ColorRgba(239,157,122)},
            {Ids.Products.Canola,              new ColorRgba(247, 193, 60)},
            {Ids.Products.CarbonDioxide,       new ColorRgba(72, 72, 72)},
            {Ids.Products.Cement,              new ColorRgba(180, 192, 183)},
            {Ids.Products.Chicken,             new ColorRgba(255, 245, 235)},
            {Ids.Products.ChickenCarcass,      new ColorRgba(253, 206, 168)},
            {Ids.Products.ChilledWater,        new ColorRgba(19, 238, 237)},
            {Ids.Products.Chlorine,            new ColorRgba(209, 255, 211)},
            {Ids.Products.Coal,                new ColorRgba(64, 64, 64)},
            {Ids.Products.Compost,             new ColorRgba(51, 33, 22)},
            {Ids.Products.Computing,           new ColorRgba(51, 51, 51)},
            {Ids.Products.ConcreteSlab,        new ColorRgba(221, 214, 209)},
            {Ids.Products.ConstructionParts,   new ColorRgba(221, 221, 221)},
            {Ids.Products.ConstructionParts2,  new ColorRgba(227, 193, 59)},
            {Ids.Products.ConstructionParts3,  new ColorRgba(227, 75, 59)},
            {Ids.Products.ConstructionParts4,  new ColorRgba(138, 101, 215)},
            {Ids.Products.ConsumerElectronics, new ColorRgba(59, 153, 220)},
            {Ids.Products.CookingOil,          new ColorRgba(226, 187, 50)},
            {Ids.Products.Copper,              new ColorRgba(179, 117, 74)},
            {Ids.Products.CopperOre,           new ColorRgba(61, 131, 59)},
            {Ids.Products.CopperScrap,         new ColorRgba(201, 131, 82)},
            {Ids.Products.CopperScrapPressed,  new ColorRgba(201, 131, 82)},
            {Ids.Products.CoreFuel,            new ColorRgba(172, 45, 42)},
            {Ids.Products.CoreFuelDirty,       new ColorRgba(122, 94, 4)},
            {Ids.Products.Corn,                new ColorRgba(130, 185, 83)},
            {Ids.Products.CornMash,            new ColorRgba(182, 171, 62)},
            {Ids.Products.CrudeOil,            new ColorRgba(88, 93, 106)},
            {Ids.Products.Diesel,              new ColorRgba(149, 117, 31)},
            {Ids.Products.Dirt,                new ColorRgba(181, 115, 72)},
            {Ids.Products.Disinfectant,        new ColorRgba(116, 120, 213)},
            {Ids.Products.Eggs,                new ColorRgba(255, 201, 147)},
            {Ids.Products.Electronics,         new ColorRgba(215, 160, 69)},
            {Ids.Products.Electronics2,        new ColorRgba(1, 153, 83)},
            {Ids.Products.Electronics3,        new ColorRgba(120, 30, 13)},
            {Ids.Products.Ethanol,             new ColorRgba(185, 190, 200)},
            {Ids.Products.Exhaust,             new ColorRgba(71, 78, 82)},
            {Ids.Products.FertilizerChemical,  new ColorRgba(227, 210, 168)},
            {Ids.Products.FertilizerChemical2, new ColorRgba(206, 201, 41)},
            {Ids.Products.FertilizerOrganic,   new ColorRgba(120, 155, 97)},
            {Ids.Products.FilterMedia,         new ColorRgba(199, 183, 83)},
            {Ids.Products.FissionProduct,      new ColorRgba(60, 111, 182)},
            {Ids.Products.Flour,               new ColorRgba(114, 164, 226)},
            {Ids.Products.Flowers,             new ColorRgba(99, 160, 59)},
            {Ids.Products.FoodPack,            new ColorRgba(184, 134, 94)},
            {Ids.Products.Fruit,               new ColorRgba(227, 51, 94)},
            {Ids.Products.FuelGas,             new ColorRgba(204, 112, 31)},
            {Ids.Products.Glass,               new ColorRgba(120, 183, 180)},
            {Ids.Products.GlassMix,            new ColorRgba(192, 176, 150)},
            {Ids.Products.Gold,                new ColorRgba(212, 169, 43)},
            {Ids.Products.GoldOre,             new ColorRgba(119, 98, 63)},
            {Ids.Products.GoldOreConcentrate,  new ColorRgba(169, 137, 47)},
            {Ids.Products.GoldOreCrushed,      new ColorRgba(122, 101, 66)},
            {Ids.Products.GoldOrePowder,       new ColorRgba(107, 91, 81)},
            {Ids.Products.GoldScrap,           new ColorRgba(201, 194, 75)},
            {Ids.Products.GoldScrapPressed,    new ColorRgba(200, 192, 74)},
            {Ids.Products.Graphite,            new ColorRgba(104, 101, 101)},
            {Ids.Products.Gravel,              new ColorRgba(159, 144, 137)},
            {Ids.Products.Heat,                new ColorRgba(201, 24, 76)},
            {Ids.Products.HeavyOil,            new ColorRgba(103, 79, 21)},
            {Ids.Products.HouseholdAppliances, new ColorRgba(179, 206, 227)},
            {Ids.Products.HouseholdGoods,      new ColorRgba(138, 182, 89)},
            {Ids.Products.Hydrogen,            new ColorRgba(202, 200, 200)},
            {Ids.Products.HydrogenFluoride,    new ColorRgba(176, 172, 61)},
            {Ids.Products.ImpureCopper,        new ColorRgba(161, 87, 57)},
            {Ids.Products.Iron,                new ColorRgba(128,128,128)},
            {Ids.Products.IronOre,             new ColorRgba(152, 75, 53)},
            {Ids.Products.IronOreCrushed,      new ColorRgba(172, 77, 55)},
            {Ids.Products.IronScrap,           new ColorRgba(102, 102, 102)},
            {Ids.Products.IronScrapPressed,    new ColorRgba(92, 92, 92)},
            {Ids.Products.LabEquipment,        new ColorRgba(227, 227, 227)},
            {Ids.Products.LabEquipment2,       new ColorRgba(221, 189, 59)},
            {Ids.Products.LabEquipment3,       new ColorRgba(227, 75, 59)},
            {Ids.Products.LabEquipment4,       new ColorRgba(125, 92, 194)},
            {Ids.Products.LightOil,            new ColorRgba(127, 140, 67)},
            {Ids.Products.Limestone,           new ColorRgba(186, 186, 141)},
            {Ids.Products.ManufacturedSand,    new ColorRgba(168, 168, 168)},
            {Ids.Products.Meat,                new ColorRgba(204, 88, 97)},
            {Ids.Products.MeatTrimmings,       new ColorRgba(219, 137, 138)},
            {Ids.Products.MechanicalParts,     new ColorRgba(179, 177, 180)},
            {Ids.Products.MechanicalPower,     new ColorRgba(179, 179, 180)},
            {Ids.Products.MedicalEquipment,    new ColorRgba(84, 133, 208)},
            {Ids.Products.MedicalSupplies,     new ColorRgba(227, 227, 227)},
            {Ids.Products.MedicalSupplies2,    new ColorRgba(208, 177, 53)},
            {Ids.Products.MedicalSupplies3,    new ColorRgba(208, 67, 53)},
            {Ids.Products.MediumOil,           new ColorRgba(123, 95, 144)},
            {Ids.Products.Microchips,          new ColorRgba(227, 176, 76)},
            {Ids.Products.MicrochipsStage1A,   new ColorRgba(183, 150, 191)},
            {Ids.Products.MicrochipsStage1B,   new ColorRgba(227, 199, 182)},
            {Ids.Products.MicrochipsStage1C,   new ColorRgba(180, 149, 168)},
            {Ids.Products.MicrochipsStage2A,   new ColorRgba(213, 157, 226)},
            {Ids.Products.MicrochipsStage2B,   new ColorRgba(203, 166, 142)},
            {Ids.Products.MicrochipsStage2C,   new ColorRgba(184, 130, 161)},
            {Ids.Products.MicrochipsStage3A,   new ColorRgba(179, 116, 194)},
            {Ids.Products.MicrochipsStage3B,   new ColorRgba(227, 172, 136)},
            {Ids.Products.MicrochipsStage3C,   new ColorRgba(160, 131, 162)},
            {Ids.Products.MicrochipsStage4A,   new ColorRgba(206, 113, 227)},
            {Ids.Products.MicrochipsStage4B,   new ColorRgba(227, 157, 113)},
            {Ids.Products.MoltenCopper,        new ColorRgba(226, 191, 35)},
            {Ids.Products.MoltenGlass,         new ColorRgba(120, 183, 180)},
            {Ids.Products.MoltenIron,          new ColorRgba(226, 147, 35)},
            {Ids.Products.MoltenSilicon,       new ColorRgba(227, 177, 48)},
            {Ids.Products.MoltenSteel,         new ColorRgba(226, 192, 39)},
            {Ids.Products.Morphine,            new ColorRgba(37, 190, 134)},
            {Ids.Products.MoxRod,              new ColorRgba(144, 144, 81)},
            {Ids.Products.Naphtha,             new ColorRgba(192, 184, 66)},
            {Ids.Products.Nitrogen,            new ColorRgba(103, 137, 193)},
            {Ids.Products.Oxygen,              new ColorRgba(187, 61, 61)},
            {Ids.Products.Paper,               new ColorRgba(219, 219, 220)},
            {Ids.Products.PCB,                 new ColorRgba(8, 150, 82)},
            {Ids.Products.Plastic,             new ColorRgba(45, 151, 175)},
            {Ids.Products.Plutonium,           new ColorRgba(84, 153, 67)},
            {Ids.Products.PollutedAir,         new ColorRgba(38, 38, 38)},
            {Ids.Products.PollutedWater,       new ColorRgba(80, 47, 32)},
            {Ids.Products.PolySilicon,         new ColorRgba(177, 173, 155)},
            {Ids.Products.Poppy,               new ColorRgba(97, 188, 102)},
            {Ids.Products.Potato,              new ColorRgba(102, 60, 18)},
            {Ids.Products.Quartz,              new ColorRgba(198, 206, 217)},
            {Ids.Products.QuartzCrushed,       new ColorRgba(182, 181, 164)},
            {Ids.Products.Recyclables,         new ColorRgba(129, 93, 60)},
            {Ids.Products.RecyclablesPressed,  new ColorRgba(145, 111, 42)},
            {Ids.Products.RetiredWaste,        new ColorRgba(166, 162, 150)},
            {Ids.Products.Rock,                new ColorRgba(181, 164, 155)},
            {Ids.Products.Rubber,              new ColorRgba(89, 96, 106)},
            {Ids.Products.Salt,                new ColorRgba(227, 227, 227)},
            {Ids.Products.Sand,                new ColorRgba(203, 187, 84)},
            {Ids.Products.Sausage,             new ColorRgba(208, 109, 59)},
            {Ids.Products.Seawater,            new ColorRgba(13, 160, 227)},
            {Ids.Products.SiliconWafer,        new ColorRgba(227, 227, 226)},
            {Ids.Products.Slag,                new ColorRgba(132, 130, 128)},
            {Ids.Products.SlagCrushed,         new ColorRgba(173, 172, 168)},
            {Ids.Products.Sludge,              new ColorRgba(85, 63, 43)},
            {Ids.Products.Snack,               new ColorRgba(189, 63, 55)},
            {Ids.Products.SolarCell,           new ColorRgba(40, 135, 205)},
            {Ids.Products.SolarCellMono,       new ColorRgba(10, 72, 107)},
            {Ids.Products.SourWater,           new ColorRgba(97, 227, 138)},
            {Ids.Products.Soybean,             new ColorRgba(149, 193, 120)},
            {Ids.Products.SpentFuel,           new ColorRgba(195, 159, 76)},
            {Ids.Products.SpentMox,            new ColorRgba(189, 111, 64)},
            {Ids.Products.SteamDepleted,       new ColorRgba(128, 180, 222)},
            {Ids.Products.SteamHi,             new ColorRgba(189, 208, 223)},
            {Ids.Products.SteamLo,             new ColorRgba(139, 184, 222)},
            {Ids.Products.SteamSp,             new ColorRgba(188, 140, 154)},
            {Ids.Products.Steel,               new ColorRgba(157, 157, 157)},
            {Ids.Products.Sugar,               new ColorRgba(203, 176, 142)},
            {Ids.Products.SugarCane,           new ColorRgba(215, 185, 78)},
            {Ids.Products.Sulfur,              new ColorRgba(199, 180, 41)},
            {Ids.Products.Tofu,                new ColorRgba(227, 211, 191)},
            {Ids.Products.ToxicSlurry,         new ColorRgba(178, 180, 16)},
            {Ids.Products.TreeSapling,         new ColorRgba(108, 172, 145)},
            {Ids.Products.UraniumDepleted,     new ColorRgba(115, 185, 115)},
            {Ids.Products.UraniumEnriched,     new ColorRgba(158, 255, 158)},
            {Ids.Products.UraniumEnriched20,   new ColorRgba(158, 255, 158)},
            {Ids.Products.UraniumOre,          new ColorRgba(162, 186, 145)},
            {Ids.Products.UraniumOreCrushed,   new ColorRgba(156, 173, 153)},
            {Ids.Products.UraniumReprocessed,  new ColorRgba(87, 96, 85)},
            {Ids.Products.UraniumRod,          new ColorRgba(147, 147, 147)},
            {Ids.Products.Vegetables,          new ColorRgba(162, 170, 89)},
            {Ids.Products.VehicleParts,        new ColorRgba(227, 227, 227)},
            {Ids.Products.VehicleParts2,       new ColorRgba(202, 171, 51)},
            {Ids.Products.VehicleParts3,       new ColorRgba(172, 55, 43)},
            {Ids.Products.Waste,               new ColorRgba(177, 158, 150)},
            {Ids.Products.WastePressed,        new ColorRgba(106, 146, 136)},
            {Ids.Products.WasteWater,          new ColorRgba(183, 112, 17)},
            {Ids.Products.Water,               new ColorRgba(52, 186, 227)},
            {Ids.Products.Wheat,               new ColorRgba(209, 177, 53)},
            {Ids.Products.Wood,                new ColorRgba(160, 102, 38)},
            {Ids.Products.Woodchips,           new ColorRgba(197, 179, 123)},
            {Ids.Products.Yellowcake,          new ColorRgba(161, 165, 67)},

        };

        public bool Save()
        {
            IOrderedEnumerable<ProductProto> sortedProductProtos = protosDb.Filter<ProductProto>(pp => pp.IsAvailable).OrderBy(x => x.Strings.Name.TranslatedString);
            string pColorsFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pColorsFile = pColorsFolder + "\\ProductColors.xml";
            if (File.Exists(pColorsFile))
                File.Delete(pColorsFile);
            XDocument doc = new XDocument();
            XElement el = new XElement("ProductColor");
            byte rv, gv, bv, av;
            foreach (var vl in m_colorList)
            {
                rv = (byte)(vl.Value.R >= 1.0 ? 255 : (vl.Value.R <= 0.0 ? 0 : (Byte)Math.Floor(vl.Value.R * 256.0)));
                gv = (byte)(vl.Value.G >= 1.0 ? 255 : (vl.Value.G <= 0.0 ? 0 : (Byte)Math.Floor(vl.Value.G * 256.0)));
                bv = (byte)(vl.Value.B >= 1.0 ? 255 : (vl.Value.B <= 0.0 ? 0 : (Byte)Math.Floor(vl.Value.B * 256.0)));
                av = (byte)(vl.Value.A >= 1.0 ? 255 : (vl.Value.A <= 0.0 ? 0 : (Byte)Math.Floor(vl.Value.A * 256.0)));

                el.Add(new XElement(vl.Key.ToString(), vl.Value.R.ToString() + "," + vl.Value.G.ToString() + "," + vl.Value.B.ToString() + "," + vl.Value.A.ToString()));
            }

            foreach (ProductProto productProto in sortedProductProtos)
            {
                if (Find(productProto.Id) == false)
                {
                    el.Add(new XElement(productProto.Id.ToString(), "255,0,255,255"));
                }
            }
            doc.Add(el);

            doc.Save(pColorsFile);
            return true;
        }
        public ColorRgba ToColor(string color)
        {
            var arrColorFragments = color?.Split(',').Select(sFragment => { byte.TryParse(sFragment, out byte fragment); return fragment; }).ToArray();
            switch (arrColorFragments?.Length)
            {
                case 3:
                    return new ColorRgba(arrColorFragments[0], arrColorFragments[1], arrColorFragments[2]);
                case 4:
                    return new ColorRgba(arrColorFragments[0], arrColorFragments[1], arrColorFragments[2], arrColorFragments[3]);
                default:
                    return new ColorRgba(255, 0, 255, 255);
            }
        }

        public bool AddProductColor(ProductProto.ID id, ColorRgba color)
        {
            if (!m_colorList.TryGetValue(id, out var c))
            {
                Log.Debug("Color allready exists.");
                return false;
            }

            else
            {
                m_colorList.Add(id, color);
                return true;
            }
        }
        public bool UpdateProductColor(ProductProto.ID iD, ColorRgba color)
        {
            if (!m_colorList.TryGetValue(iD, out var c))
            {
                m_colorList[iD] = color;
                return true;
            }
            return false;

        }
        public bool RemoveProductColor(ProductProto.ID iD)
        {
            if (!m_colorList.TryGetValue(iD, out var c))
            {
                m_colorList.Remove(iD);
                return true;
            }
            return false;
        }
        public bool Find(ProductProto.ID id)
        {
            if (m_colorList.ContainsKey(id))
                return true;
            return false;
        }
        public ColorRgba GetColor(ProductProto.ID iD, bool highlight)
        {

            ColorRgba actualColor;
            ColorRgba colorRgba;

            if (!m_defaultColorList.TryGetValue(iD, out actualColor))
            {
                colorRgba = new ColorRgba(245, 0, 245, 245);

                return colorRgba;
            }
            colorRgba = new ColorRgba((byte)actualColor.R, (byte)actualColor.G, (byte)actualColor.B);
            if (highlight)
            {
                colorRgba = AddToColor(colorRgba, 30);
                actualColor = colorRgba;
            }
            else
            {
                actualColor = colorRgba;
            }

            return actualColor;
        }

        public ColorRgba AddToColor(ColorRgba col, int val)
        {
            return new ColorRgba((int)((float)(int)col.R + val).Min(255f), (int)((float)(int)col.G + val).Min(255f), (int)((float)(int)col.B + val).Min(255f));
        }
        static ProductColorManager()
        {
            s_serializeDataDelayedAction = delegate (object obj, BlobWriter writer)
            {
                ((ProductColorManager)obj).SerializeData(writer);
            };
            s_deserializeDataDelayedAction = delegate (object obj, BlobReader reader)
            {
                ((ProductColorManager)obj).DeserializeData(reader);
            };
        }
    }
}
