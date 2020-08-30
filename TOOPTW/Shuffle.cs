using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOPTW
{
    class Shuffle
    {
        static public void Suffle_array(ref Chromosome[] array)
        {
            for (int i = 0; i < array.Length * 10; i++)
            {
                int p1 = Random_Number.GetRandomNumber(0, array.Length - 1);
                int p2 = Random_Number.GetRandomNumber(0, array.Length - 1);

                Chromosome temp = array[p1];
                array[p1] = array[p2];
                array[p2] = temp;
            }
        }

        static public void Suffle_array(ref Chromosome[,] array)
        {
            int a = (int)array.GetLongLength(0);
            int b = (int)array.GetLongLength(1);

            for (int CN = 0; CN < array.GetLongLength(0); CN++)
            {
                for (int i = 0; i < array.GetLongLength(1) * 10; i++)
                {
                    int p1 = Random_Number.GetRandomNumber(0, (int)array.GetLongLength(1) - 1);
                    int p2 = Random_Number.GetRandomNumber(0, (int)array.GetLongLength(1) - 1);

                    Chromosome temp = array[CN, p1];
                    array[CN, p1] = array[CN, p2];
                    array[CN, p2] = temp;
                }
            }
        }
    }
}
