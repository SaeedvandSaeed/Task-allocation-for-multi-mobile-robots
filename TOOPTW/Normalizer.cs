using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOPTW
{
    static class Normalizer
    {

        public static void Normal(ref List<double> list)
        {
            //List<double> list = new List<double> { -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5 };
            double scaleMin = 0; //the normalized minimum desired
            double scaleMax = 1; //the normalized maximum desired

            double valueMax = list.Max();
            double valueMin = list.Min();
            double valueRange = valueMax - valueMin;
            double scaleRange = scaleMax - scaleMin;

            IEnumerable<double> normalized =
                list.Select(i =>
                   ((scaleRange * (i - valueMin))
                       / valueRange)
                   + scaleMin);
            list = normalized.ToList<double>();
        }
    }
}
