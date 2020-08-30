using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOPTW
{
    class Roulette
    {
        double[] c;
        double total;
        //Random random;

        public Roulette(double[] n)
        {
            total = 0;
            c = new double[n.Length + 1];
            c[0] = 0;
            // Create cumulative values for later:
            for (int i = 0; i < n.Length; i++)
            {
                c[i + 1] = c[i] + n[i];
                total += n[i];
            }
        }

        public int spin()
        {
            // Create a random number between 0 and 1 and times by the total we calculated earlier.
            double random_number = (double)Random_Number.GetRandomNumber(0, 1000000) / 1000000;
            double r = random_number * total;

            // Binary search for efficiency. Objective is to find index of the number just above r:
            int index = 0;
            int b = c.Length - 1;
            while (b - index > 1)
            {
                int mid = (index + b) / 2;
                if (c[mid] > r) b = mid;
                else index = mid;
            }
            return index;
        }
    }


}
