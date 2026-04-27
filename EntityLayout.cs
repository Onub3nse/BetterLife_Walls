using Mafi;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core.Roads;
using Mafi.Curves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterLife_RoadsAndSigns
{
    public partial class btLayouts
    {
        public partial class Layouts
        {

        }
        public partial class RoadLanes
        {
            public static CubicBezierCurve2f CreateCurve((double, double) start, (double, double) c1, (double, double) c2, (double, double) end)
            {
                return new CubicBezierCurve2f(ImmutableArray.Create(new Vector2f(start.Item1.ToFix32(), start.Item2.ToFix32()), new Vector2f(c1.Item1.ToFix32(), c1.Item2.ToFix32()), new Vector2f(c2.Item1.ToFix32(), c2.Item2.ToFix32()), new Vector2f(end.Item1.ToFix32(), end.Item2.ToFix32())));
            }

        }
    }
}
 