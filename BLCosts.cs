using Mafi.Base;
using Mafi.Core.Prototypes;
using System;

namespace BetterLife_Walls
{
    public static class BLCosts
    {
        public static EntityCostsTpl.Builder Build
        {
            get
            {
                return new EntityCostsTpl.Builder();
            }
        }
        //private static readonly (int CP, int Iron)[] blCosts =
        //{
        //    (8, 25),
        //    (10, 45),
        //    (12, 75),
        //    (14, 85),
        //    (16, 105),
        //    (19, 125)
        //};

        public static EntityCostsTpl BalancerCosts(int level)
        {
            if (level is < 0 or > 5) throw new ArgumentOutOfRangeException(nameof(level));
            //var (cp, iron) = blCosts[level];
            return BLCosts.Build.MaintenanceT1(0).Priority(8).CP2(8 + (level * 2));
        }

        public static EntityCostsTpl TransBarCosts(int level)
        {
            if (level is < 0 or > 7) throw new ArgumentOutOfRangeException(nameof(level));
            //var (cp, iron) = blCosts[level];
            return BLCosts.Build.MaintenanceT1(0).Priority(8).CP2(8 + (level * 2));
        }


        public static class Machines
        {
            public static EntityCostsTpl BetterAssemblerT1
            {
                get
                {
                    return BLCosts.Build.CP(10).Product(5, Ids.Products.Iron);
                }
            }
            public static EntityCostsTpl BetterAssemblerT2
            {
                get
                {
                    return BLCosts.Build.CP(20).Product(10, Ids.Products.Iron);
                }
            }
        }

        public static class Buildings
        {
            public static EntityCostsTpl McDonalds
            {
                get
                {
                    return BLCosts.Build.CP2(40).Product(10, Ids.Products.Potato);
                }
            }
            public static EntityCostsTpl KFC
            {
                get
                {
                    return BLCosts.Build.CP2(40).Product(10, Ids.Products.Potato);
                }
            }

        }

        public static class Walls
        {
            public static EntityCostsTpl Wall1
            {
                get
                {
                    return BLCosts.Build.MaintenanceT1(0).Priority(8).Workers(0).Product(5, Ids.Products.Cement);
                }
            }
        }
        public static class Roads
        {
            public static EntityCostsTpl Industrial
            {
                get
                {
                    return BLCosts.Build.MaintenanceT1(0).Priority(8).Workers(2).CP(10);
                }
            }
            public static EntityCostsTpl IndustrialLarge
            {
                get
                {
                    return BLCosts.Build.MaintenanceT1(0).Priority(8).Workers(5).CP(30);
                }
            }
            public static EntityCostsTpl Tier1
            {
                get
                {
                    return BLCosts.Build.MaintenanceT1(0).Priority(8).Workers(5).CP(30);
                }
            }
            public static EntityCostsTpl Tier1Large
            {
                get
                {
                    return BLCosts.Build.MaintenanceT1(0).Priority(8).Workers(10).CP(60);
                }
            }

        }

        //            EntityCostsTpl roadCosts2 = Build.Priority(8).CP3(20).Product(10, Ids.Products.Iron);
        //            EntityCostsTpl roadCosts3 = Build.Priority(8).CP3(40).Product(20, Ids.Products.Iron);
        //            EntityCostsTpl balancerCosts = Build.Priority(8).CP(5).Product(5, Ids.Products.Iron).Product(5, Ids.Products.MechanicalParts);

        public static class transPORTs
        {
            public static class transBarCosts
            {
                public static EntityCostsTpl Loader1
                {
                    get
                    {
                        return BLCosts.Build.MaintenanceT1(0).Priority(8).CP(50).Product(75, Ids.Products.Iron);
                    }
                }
                public static EntityCostsTpl bar2m
                {
                    get
                    {
                        return BLCosts.Build.MaintenanceT1(0).Priority(8).CP(20).Product(40, Ids.Products.Iron);
                    }
                }
                public static EntityCostsTpl bar4m
                {
                    get
                    {
                        return BLCosts.Build.MaintenanceT1(0).Priority(8).CP(40).Product(80, Ids.Products.Iron);
                    }
                }
                public static EntityCostsTpl bar10m
                {
                    get
                    {
                        return BLCosts.Build.MaintenanceT1(0).Priority(8).CP(00).Product(120, Ids.Products.Iron);
                    }
                }

            }

            public static class transPortCosts
            {
                public static EntityCostsTpl transp10m
                {
                    get
                    {
                        return BLCosts.Build.MaintenanceT1(0).Priority(8).CP(10).Product(25, Ids.Products.Iron);
                    }
                }
                public static EntityCostsTpl transp20m
                {
                    get
                    {
                        return BLCosts.Build.MaintenanceT1(0).Priority(8).CP(20).Product(50, Ids.Products.Iron);
                    }
                }
                public static EntityCostsTpl transp100m
                {
                    get
                    {
                        return BLCosts.Build.MaintenanceT1(0).Priority(8).CP(100).Product(150, Ids.Products.Iron);
                    }
                }

            }
        }



    }
}
