using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOPTW
{
    public class SIMAB
    {
        public const int operator_count = 24;

        //public double[] q_t1;
        public double[] q_t2;

        //public double[] n_t1;
        public double[] n_t2;

        public double[] arg_max;

        // SIMAB Learning paprametrs
        public SIMAB()
        {
            //q_t1 = new double[operator_count];
            q_t2 = new double[operator_count];

            //n_t1 = new double[operator_count];
            n_t2 = new double[operator_count];
            arg_max = new double[operator_count];
        }
        /*
        public double
            InSwap_Count,
            ExSwap_Count,
            Insert_Count,
            Replace_Count,
            Crossover2P_Count,
            PMX_Count,
            Reverse_Count,
            ILS_Count,
            Shake_Count,
            MaxShift_ILS_Count
            ;
        public double
            InSwap_Last_Used_Iteration,
            ExSwap_Last_Used_Iteration,
            Insert_Last_Used_Iteration,
            Replace_Last_Used_Iteration,
            Crossover2P_Last_Used_Iteration,
            PMX_Last_Used_Iteration,
            Reverse_Last_Used_Iteration,
            ILS_Last_Used_Iteration,
            Shake_Last_Used_Iteration,
            MaxShift_Last_Used_Iteration
        ;
        public double
            InSwap_Current_Reward,
            ExSwap_Current_Reward,
            Insert_Current_Reward,
            Replace_Current_Reward,
            Crossover2P_Current_Reward,
            PMX_Current_Reward,
            Reverse_Current_Reward,
            ILS_Current_Reward,
            Shake_Current_Reward,
            MaxShift_Current_Reward
            ;
        public double
           InSwap_Maximum_Reward,
           ExSwap_Maximum_Reward,
           Insert_Maximum_Reward,
           Replace_Maximum_Reward,
           Crossover2P_Maximum_Reward,
           PMX_Maximum_Reward,
           Reverse_Maximum_Reward,
           ILS_Maximum_Reward,
           Shake_Maximum_Reward,
           MaxShift_Maximum_Reward
           ;
   */

        public double[] LLH_Counter = new double[operator_count];
        public double[] LLH_Wait_Counter = new double[operator_count];
        public double[] LLH_Last_Used_Iteration = new double[operator_count];
        public double[] LLH_Max_Reward = new double[operator_count];
        public double[] LLH_Current_Reward = new double[operator_count];
        public double[] LLH_Total_Reward = new double[operator_count];

        public double[] LLH_Max_Fitness = new double[operator_count];
        public double[] LLH_No_Improve_Iteration_count = new double[operator_count];

        public int Compute_SIMAB(int iter)
        {
            for (int LLH_ID = 0; LLH_ID < LLH_Wait_Counter.Length; LLH_ID++)
            {
                n_t2[LLH_ID] =
             LLH_Wait_Counter[LLH_ID] * ((LLH_Max_Reward[LLH_ID] / (LLH_Max_Reward[LLH_ID] + (iter )))//- LLH_Last_Used_Iteration[LLH_ID]
             + (1 / (LLH_Wait_Counter[LLH_ID] + 1)));
                q_t2[LLH_ID] =
                     LLH_Wait_Counter[LLH_ID] * (LLH_Max_Reward[LLH_ID] / (LLH_Max_Reward[LLH_ID] + (iter )))//- LLH_Last_Used_Iteration[LLH_ID]
                    + LLH_Total_Reward[LLH_ID] * (1 / (LLH_Wait_Counter[LLH_ID] + 1));
            }
            double C = 5; //Scaling Factor => Exploration (increase) and Explotation (decrease)

            double Total_execution_operators_count=0;
            for (int LLH_ID = 0; LLH_ID < operator_count; LLH_ID++)
            {
                Total_execution_operators_count += LLH_Wait_Counter[LLH_ID];
            }

            for (int i = 0; i < operator_count; i++)
            {
                arg_max[i] = (q_t2[i] + C * Math.Sqrt(2 * Math.Log(Total_execution_operators_count) / LLH_Counter[i]));
            }

            // Positioning max
            double m = arg_max.Max();
            int p = Array.IndexOf(arg_max, m);

            return (p);
        }
    }
}
