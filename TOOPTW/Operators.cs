using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOPTW
{
    static class Operators
    {
        static public void InSwap_ExSwap(Full_Chrmosome Target_Chromosome, int Number_of_Robots, ref SIMAB SIMB_F, int[] Robots_Max_Energy, bool INSWAP_Flag, bool EXSWAP_Flag, int iteration, int rate)
        {
            //Two-level particle swarm optimization for the multi-modal teamorienteering problem with time windows 2017
            //Swap two random task inside two random path from given chromosome
            if (INSWAP_Flag)
            {
                   for (int i = 0; i < rate; i++)
                {
                    int RN_P1;
                    int RN_P2;

                    int Gene_P1;
                    int Gene_P2;

                    int try_count = 0;
                    do
                    {
                        try_count++;

                        RN_P1 = Random_Number.GetRandomNumber(0, Number_of_Robots - 1);
                        RN_P2 = Random_Number.GetRandomNumber(0, Number_of_Robots - 1);
                        Gene_P1 = 0;
                        Gene_P2 = 0;
                        if (Target_Chromosome.One_Path[RN_P1].Path_list.Count > 2 && Target_Chromosome.One_Path[RN_P2].Path_list.Count > 2)
                        {
                            Gene_P1 = Random_Number.GetRandomNumber(1, Target_Chromosome.One_Path[RN_P1].Path_list.Count - 2);
                            Gene_P2 = Random_Number.GetRandomNumber(1, Target_Chromosome.One_Path[RN_P2].Path_list.Count - 2);
                        }
                    } while (try_count < Number_of_Robots && Gene_P1 == 0 &&
                    (Target_Chromosome.One_Path[RN_P1].Tmax <
                    Target_Chromosome.One_Path[RN_P1].Total_Duration - Target_Chromosome.One_Path[RN_P1].Path_list[Gene_P1].service_duration + Target_Chromosome.One_Path[RN_P2].Path_list[Gene_P2].service_duration
                    || Target_Chromosome.One_Path[RN_P2].Tmax <
                    Target_Chromosome.One_Path[RN_P2].Total_Duration - Target_Chromosome.One_Path[RN_P2].Path_list[Gene_P2].service_duration + Target_Chromosome.One_Path[RN_P1].Path_list[Gene_P1].service_duration
                    || Target_Chromosome.One_Path[RN_P1].Path_list.Count < 3
                    || Target_Chromosome.One_Path[RN_P2].Path_list.Count < 3));

                    if (try_count < Number_of_Robots)
                    {
                        var temp = Target_Chromosome.One_Path[RN_P1].Path_list[Gene_P1].ObjectClone(Target_Chromosome.One_Path[RN_P1].Path_list[Gene_P1]);
                        Target_Chromosome.One_Path[RN_P1].Path_list[Gene_P1] = Target_Chromosome.One_Path[RN_P2].Path_list[Gene_P2].ObjectClone(Target_Chromosome.One_Path[RN_P2].Path_list[Gene_P2]);
                        Target_Chromosome.One_Path[RN_P2].Path_list[Gene_P2] = temp.ObjectClone(temp);

                        Target_Chromosome.Compute_Fitness();

                        if (Target_Chromosome.One_Path[RN_P1].Tmax < Target_Chromosome.One_Path[RN_P1].Total_Duration
                            || Target_Chromosome.One_Path[RN_P2].Tmax < Target_Chromosome.One_Path[RN_P2].Total_Duration
                            || Robots_Max_Energy[RN_P1] < Target_Chromosome.One_Path[RN_P1].Total_Energy_Cost
                            || Robots_Max_Energy[RN_P2] < Target_Chromosome.One_Path[RN_P2].Total_Energy_Cost)
                        {
                            temp = Target_Chromosome.One_Path[RN_P1].Path_list[Gene_P1].ObjectClone(Target_Chromosome.One_Path[RN_P1].Path_list[Gene_P1]);
                            Target_Chromosome.One_Path[RN_P1].Path_list[Gene_P1] = Target_Chromosome.One_Path[RN_P2].Path_list[Gene_P2].ObjectClone(Target_Chromosome.One_Path[RN_P2].Path_list[Gene_P2]);
                            Target_Chromosome.One_Path[RN_P2].Path_list[Gene_P2] = temp.ObjectClone(temp);
                        }
                    }
                }
                //...................................................................
                Target_Chromosome.Compute_Fitness();
                }
            if (EXSWAP_Flag)
            {
                 for (int i = 0; i < rate; i++)
                {
                    int RN_P1;
                    int RN_P2;

                    int Gene_P1;
                    int Gene_P2;
                    //swap with reserves
                    if (Target_Chromosome.Reserve_list.Path_list.Count > 0)
                    {
                        int try_count = 0;
                        do
                        {
                            try_count++;
                            RN_P1 = Random_Number.GetRandomNumber(0, Number_of_Robots - 1);
                            Gene_P1 = 0;
                            Gene_P2 = 0;
                            if (Target_Chromosome.One_Path[RN_P1].Path_list.Count > 2)
                            {
                                Gene_P1 = Random_Number.GetRandomNumber(1, Target_Chromosome.One_Path[RN_P1].Path_list.Count - 2);
                                Gene_P2 = Random_Number.GetRandomNumber(0, Target_Chromosome.Reserve_list.Path_list.Count - 1);
                            }
                            else if (try_count >= Number_of_Robots) { break; }
                        } while (try_count < Number_of_Robots && Gene_P1 == 0 &&
                        (Target_Chromosome.One_Path[RN_P1].Tmax <
                        Target_Chromosome.One_Path[RN_P1].Total_Duration - Target_Chromosome.One_Path[RN_P1].Path_list[Gene_P1].service_duration + Target_Chromosome.Reserve_list.Path_list[Gene_P2].service_duration
                               || Target_Chromosome.One_Path[RN_P1].Path_list.Count < 3));
                        if (try_count < Number_of_Robots)
                        {
                            var temp = Target_Chromosome.One_Path[RN_P1].Path_list[Gene_P1].ObjectClone(Target_Chromosome.One_Path[RN_P1].Path_list[Gene_P1]);
                            Target_Chromosome.One_Path[RN_P1].Path_list[Gene_P1] = Target_Chromosome.Reserve_list.Path_list[Gene_P2].ObjectClone(Target_Chromosome.Reserve_list.Path_list[Gene_P2]);
                            Target_Chromosome.Reserve_list.Path_list[Gene_P2] = temp.ObjectClone(temp);

                            Target_Chromosome.Compute_Fitness();

                            if (Target_Chromosome.One_Path[RN_P1].Tmax < Target_Chromosome.One_Path[RN_P1].Total_Duration
                                || Robots_Max_Energy[RN_P1] < Target_Chromosome.One_Path[RN_P1].Total_Energy_Cost)
                            {
                                temp = Target_Chromosome.One_Path[RN_P1].Path_list[Gene_P1].ObjectClone(Target_Chromosome.One_Path[RN_P1].Path_list[Gene_P1]);
                                Target_Chromosome.One_Path[RN_P1].Path_list[Gene_P1] = Target_Chromosome.Reserve_list.Path_list[Gene_P2].ObjectClone(Target_Chromosome.Reserve_list.Path_list[Gene_P2]);
                                Target_Chromosome.Reserve_list.Path_list[Gene_P2] = temp.ObjectClone(temp);
                            }
                        }
                    }
                }
                //...................................................................
                Target_Chromosome.Compute_Fitness();
             }
        }
        //________________________________________________________________________________________________________________
        static public void Insert_Replace(Full_Chrmosome Target_Chromosome, int Number_of_Robots, ref SIMAB SIMB_F, int[] Robots_Max_Energy, bool INSERT_Flag, bool REPLACE_Flag, int iteration, int rate)
        {
            //Two-level particle swarm optimization for the multi-modal teamorienteering problem with time windows 2017
            // remove one task inside one random robot's path and insert to one othe random path from given chromosome
            if (REPLACE_Flag)
            {
                 for (int i = 0; i < rate; i++)
                {
                    int RN_P2 = 0;

                    if (Target_Chromosome.Reserve_list.Path_list.Count > 0)
                    {
                        int reserve_list_selected = 0;
                        int try_count = 0;
                        do
                        {
                            try_count++;
                            reserve_list_selected = Random_Number.GetRandomNumber(0, Target_Chromosome.Reserve_list.Path_list.Count - 1);
                            RN_P2 = Random_Number.GetRandomNumber(0, Number_of_Robots - 1);
                        } while (try_count < Number_of_Robots &&
                        (Target_Chromosome.One_Path[RN_P2].Tmax < Target_Chromosome.One_Path[RN_P2].Total_Duration
                        + Target_Chromosome.Reserve_list.Path_list[reserve_list_selected].service_duration));
                        // check duration restriction is considered with some tries to add

                        //can it found suitable path to add new item?
                        if (try_count < Number_of_Robots)// && Target_Chromosome.One_Path[RN_P2].Path_list.Count > 1)
                        {
                            int Gene_P2 = Random_Number.GetRandomNumber(1, Target_Chromosome.One_Path[RN_P2].Path_list.Count - 1);

                            Target_Chromosome.One_Path[RN_P2].Path_list.Insert(Gene_P2, Target_Chromosome.Reserve_list.Path_list[reserve_list_selected].ObjectClone(Target_Chromosome.Reserve_list.Path_list[reserve_list_selected]));
                            Target_Chromosome.Compute_Fitness();

                            if (Target_Chromosome.One_Path[RN_P2].Tmax < Target_Chromosome.One_Path[RN_P2].Total_Duration
                                || Robots_Max_Energy[RN_P2] < Target_Chromosome.One_Path[RN_P2].Total_Energy_Cost)
                            {
                                Target_Chromosome.One_Path[RN_P2].Path_list.RemoveAt(Gene_P2);
                            }
                            else
                            {
                                Target_Chromosome.Reserve_list.Path_list.RemoveAt(reserve_list_selected);
                            }
                        }
                    }
                }
                //...................................................................
                Target_Chromosome.Compute_Fitness();
            }
            if (INSERT_Flag)
            {
                for (int i = 0; i < rate; i++)
                {
                    int RN_P1 = 0;
                    int RN_P2 = 0;

                    int try_count = 0;
                    do
                    {
                        try_count++;
                        RN_P1 = Random_Number.GetRandomNumber(0, Number_of_Robots - 1);
                    } while (try_count < Number_of_Robots &&
                    Target_Chromosome.One_Path[RN_P1].Path_list.Count <= 2); // check if path is not empty

                    if (try_count < Number_of_Robots)
                    {
                        int Gene_P1 = 0;
                        try_count = 0;
                        do
                        {
                            try_count++;
                            //if (Target_Chromosome.One_Path[RN_P1].Path_list.Count > 1)
                            //{
                            Gene_P1 = Random_Number.GetRandomNumber(1, Target_Chromosome.One_Path[RN_P1].Path_list.Count - 2);
                            RN_P2 = Random_Number.GetRandomNumber(0, Number_of_Robots - 1);
                            //}
                            //else
                            //{
                            //    continue;
                            //}
                        } while (try_count < Number_of_Robots &&
                        (RN_P1 == RN_P2 || (Target_Chromosome.One_Path[RN_P2].Tmax < Target_Chromosome.One_Path[RN_P2].Total_Duration + Target_Chromosome.One_Path[RN_P1].Path_list[Gene_P1].service_duration)));
                        // check duration restriction is considered with some tries to add

                        if (try_count < Number_of_Robots)// && Target_Chromosome.One_Path[RN_P2].Path_list.Count > 1)
                        {
                            int Gene_P2 = Random_Number.GetRandomNumber(1, Target_Chromosome.One_Path[RN_P2].Path_list.Count - 1);

                            Target_Chromosome.One_Path[RN_P2].Path_list.Insert(Gene_P2, Target_Chromosome.One_Path[RN_P1].Path_list[Gene_P1].ObjectClone(Target_Chromosome.One_Path[RN_P1].Path_list[Gene_P1]));
                            Target_Chromosome.Compute_Fitness();

                            if (Target_Chromosome.One_Path[RN_P2].Tmax < Target_Chromosome.One_Path[RN_P2].Total_Duration
                                || Robots_Max_Energy[RN_P2] < Target_Chromosome.One_Path[RN_P2].Total_Energy_Cost)
                            {
                                Target_Chromosome.One_Path[RN_P2].Path_list.RemoveAt(Gene_P2);
                            }
                            else
                            {
                                Target_Chromosome.One_Path[RN_P1].Path_list.RemoveAt(Gene_P1);
                            }
                        }
                    }
                }

                //...................................................................
                Target_Chromosome.Compute_Fitness();
             }
        }
        //________________________________________________________________________________________________________________
        static public void Reverse(Full_Chrmosome Target_Chromosome, int Number_of_Robots, ref SIMAB SIMB_F, int[] Robots_Max_Energy, int iteration, int rate)
        {
            //Swap two random task inside two random path from given chromosome
            // Two-level particle swarm optimization for the multi-modal teamorienteering problem with time windows 2017
            for (int i = 0; i < rate; i++)
            {
                int RN_P1 = 0;
                int Gene_P1 = 0;
                int Gene_P2 = 0;

                int try_count = 0;
                do
                {
                    try_count++;

                    RN_P1 = Random_Number.GetRandomNumber(0, Number_of_Robots - 1);
                    Gene_P1 = 0;
                    Gene_P2 = 0;
                    if (Target_Chromosome.One_Path[RN_P1].Path_list.Count > 5)
                    {
                        Gene_P1 = Random_Number.GetRandomNumber(1, (Target_Chromosome.One_Path[RN_P1].Path_list.Count - 2) / 2);
                        Gene_P2 = Random_Number.GetRandomNumber((Target_Chromosome.One_Path[RN_P1].Path_list.Count - 2) / 2, Target_Chromosome.One_Path[RN_P1].Path_list.Count - 3);
                    }
                } while (try_count < Number_of_Robots && Gene_P1 == 0);

                if (try_count < Number_of_Robots)
                {
                    for (int j = Gene_P1, k = Gene_P2; j <= k; j++, k--)
                    {
                        var temp = Target_Chromosome.One_Path[RN_P1].Path_list[j].ObjectClone(Target_Chromosome.One_Path[RN_P1].Path_list[j]);
                        Target_Chromosome.One_Path[RN_P1].Path_list[j] = Target_Chromosome.One_Path[RN_P1].Path_list[k].ObjectClone(Target_Chromosome.One_Path[RN_P1].Path_list[k]);
                        Target_Chromosome.One_Path[RN_P1].Path_list[k] = temp.ObjectClone(temp);
                    }

                    Target_Chromosome.Compute_Fitness();

                    if (Target_Chromosome.One_Path[RN_P1].Tmax < Target_Chromosome.One_Path[RN_P1].Total_Duration
                        || Robots_Max_Energy[RN_P1] < Target_Chromosome.One_Path[RN_P1].Total_Energy_Cost)
                        for (int j = Gene_P1, k = Gene_P2; j <= k; j++, k--)
                        {
                            var temp = Target_Chromosome.One_Path[RN_P1].Path_list[j].ObjectClone(Target_Chromosome.One_Path[RN_P1].Path_list[j]);//????
                            Target_Chromosome.One_Path[RN_P1].Path_list[j] = Target_Chromosome.One_Path[RN_P1].Path_list[k].ObjectClone(Target_Chromosome.One_Path[RN_P1].Path_list[k]);
                            Target_Chromosome.One_Path[RN_P1].Path_list[k] = temp.ObjectClone(temp);
                        }
                }
                Target_Chromosome.Compute_Fitness();
            }

            //...................................................................
            Target_Chromosome.Compute_Fitness();
        }
        //________________________________________________________________________________________________________________
        //_____________________________________Crossover__________________________________________________________________
        static public void Two_Point_Crossover(Full_Chrmosome Target_Chromosome1, Full_Chrmosome Target_Chromosome2, ref Full_Chrmosome temp_chromosome1, ref Full_Chrmosome temp_chromosome2, int Number_of_Robots, Full_Chrmosome Full_Vertices, int iteration, ref SIMAB SIMB_F, int[] Robots_Max_Energy)
        {
            //A Multi-Objective and Evolutionary Hyper-Heuristic Applied to the Integration and Test Order Problem 2017
            // Two point crossover o two given chroosme

            int Cross_point = Random_Number.GetRandomNumber(1, Number_of_Robots - 1); ;

            temp_chromosome1 = Target_Chromosome1.ObjectClone(Target_Chromosome1);
            temp_chromosome2 = Target_Chromosome2.ObjectClone(Target_Chromosome2);

            temp_chromosome1.Reserve_list.Path_list.Clear();
            temp_chromosome2.Reserve_list.Path_list.Clear();

            // Crossover and recovery Chromosome #1
            for (int i = Cross_point; i < Number_of_Robots; i++)
            {
                int items_count_ch1 = temp_chromosome1.One_Path[i].Path_list.Count - 1;
                for (int del = 1; del < items_count_ch1; del++)
                {
                    temp_chromosome1.One_Path[i].Path_list.RemoveAt(1);
                }
                temp_chromosome1.Compute_Fitness();

                items_count_ch1 = temp_chromosome2.One_Path[i].Path_list.Count - 1;
                for (int j = 1; j < items_count_ch1; j++)
                {
                    bool found = false;
                    for (int k = 0; k < Cross_point && !found; k++)
                    {
                        int items_count_temp = temp_chromosome1.One_Path[k].Path_list.Count - 1;

                        for (int l = 1; l < items_count_temp; l++)
                        {
                            if (temp_chromosome2.One_Path[i].Path_list[j].id == temp_chromosome1.One_Path[k].Path_list[l].id)
                            {
                                found = true;
                                for (int m = 0; m < temp_chromosome1.Reserve_list.Path_list.Count; m++)
                                {
                                    if (temp_chromosome1.One_Path[k].Path_list[l].id == temp_chromosome1.Reserve_list.Path_list[m].id)
                                    {
                                        temp_chromosome1.Reserve_list.Path_list.RemoveAt(m);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    int items_count_temp1 = temp_chromosome1.One_Path[i].Path_list.Count - 1;
                    if (!found)
                    {
                        temp_chromosome1.One_Path[i].Path_list.Insert(items_count_temp1, temp_chromosome2.One_Path[i].Path_list[j].ObjectClone(temp_chromosome2.One_Path[i].Path_list[j]));

                        temp_chromosome1.Compute_Fitness();

                        // Check feasibility
                        if (temp_chromosome1.One_Path[i].Total_Duration > temp_chromosome1.One_Path[i].Tmax
                            || Robots_Max_Energy[i] > temp_chromosome1.One_Path[i].Total_Energy_Cost)
                        {
                            temp_chromosome1.One_Path[i].Path_list.RemoveAt(items_count_temp1);
                        }
                    }
                }
            }

            // Crossover and recovery #!1
            for (int i = 0; i < Cross_point; i++) //Cross_point
            {
                int items_count = temp_chromosome2.One_Path[i].Path_list.Count - 1;
                for (int j = 1; j < items_count; j++)
                {
                    bool found = false;
                    for (int k = 0; k < Number_of_Robots && !found; k++)
                    {
                        int items_count_temp = temp_chromosome1.One_Path[k].Path_list.Count - 1;

                        for (int l = 1; l < items_count_temp; l++)
                        {
                            if (temp_chromosome2.One_Path[i].Path_list[j].id == temp_chromosome1.One_Path[k].Path_list[l].id)
                            {
                                found = true;
                                break;
                            }
                        }
                    }

                    if (!found)
                    {
                        int Insert_point = Random_Number.GetRandomNumber(Cross_point, Number_of_Robots - 1);
                        int items_count_temp1 = temp_chromosome1.One_Path[Insert_point].Path_list.Count - 1;

                        temp_chromosome1.One_Path[Insert_point].Path_list.Insert(items_count_temp1, temp_chromosome2.One_Path[i].Path_list[j].ObjectClone(temp_chromosome2.One_Path[i].Path_list[j]));

                        temp_chromosome1.Compute_Fitness();

                        // Check feasibility
                        if (temp_chromosome1.One_Path[Insert_point].Total_Duration > temp_chromosome1.One_Path[i].Tmax
                            || Robots_Max_Energy[i] > temp_chromosome1.One_Path[i].Total_Energy_Cost)
                        {
                            //// it was infeasible, so delete it
                            temp_chromosome1.One_Path[Insert_point].Path_list.RemoveAt(items_count_temp1);
                        }
                    }
                }
            }

            //.........................................................................
            // Crossover and recovery Chromosome #2
            for (int i = 0; i < Cross_point; i++)
            {
                int items_count_ch2 = temp_chromosome2.One_Path[i].Path_list.Count - 1;
                for (int del = 1; del < items_count_ch2; del++)
                {
                    temp_chromosome2.One_Path[i].Path_list.RemoveAt(1);
                }

                items_count_ch2 = temp_chromosome1.One_Path[i].Path_list.Count - 1;

                for (int j = 1; j < items_count_ch2; j++)
                {
                    bool found = false;
                    for (int k = Cross_point; k < Number_of_Robots && !found; k++)
                    {
                        int items_count_temp = temp_chromosome2.One_Path[k].Path_list.Count - 1;

                        for (int l = 1; l < items_count_temp; l++)
                        {
                            if (temp_chromosome1.One_Path[i].Path_list[j].id == temp_chromosome2.One_Path[k].Path_list[l].id)
                            {
                                found = true;
                                for (int m = 0; m < temp_chromosome2.Reserve_list.Path_list.Count; m++)
                                {
                                    if (temp_chromosome2.One_Path[k].Path_list[l].id == temp_chromosome2.Reserve_list.Path_list[m].id)
                                    {
                                        temp_chromosome2.Reserve_list.Path_list.RemoveAt(m);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    int items_count_temp1 = temp_chromosome2.One_Path[i].Path_list.Count - 1;
                    if (!found)
                    {
                        temp_chromosome2.One_Path[i].Path_list.Insert(items_count_temp1, temp_chromosome1.One_Path[i].Path_list[j].ObjectClone(temp_chromosome1.One_Path[i].Path_list[j]));

                        temp_chromosome2.Compute_Fitness();
                        // Check feasibility
                        if (temp_chromosome2.One_Path[i].Total_Duration > temp_chromosome2.One_Path[i].Tmax
                            || Robots_Max_Energy[i] > temp_chromosome2.One_Path[i].Total_Energy_Cost)
                        {
                            temp_chromosome2.One_Path[i].Path_list.RemoveAt(items_count_temp1);
                        }
                    }
                }
            }

            //  temp_chromosome2.Reserve_list.Path_list.Clear();
            // Crossover and recovery #!2
            for (int i = Cross_point; i < Number_of_Robots; i++)
            {
                int items_count = temp_chromosome1.One_Path[i].Path_list.Count - 1;
                for (int j = 1; j < items_count; j++)
                {
                    bool found = false;
                    for (int k = 0; k < Number_of_Robots && !found; k++)
                    {
                        int items_count_temp = temp_chromosome2.One_Path[k].Path_list.Count - 1;

                        for (int l = 1; l < items_count_temp; l++)
                        {
                            if (temp_chromosome1.One_Path[i].Path_list[j].id == temp_chromosome2.One_Path[k].Path_list[l].id)
                            {
                                found = true;
                                break;
                            }
                        }
                    }
                    int Insert_point = Random_Number.GetRandomNumber(0, Cross_point);

                    int items_count_temp1 = temp_chromosome2.One_Path[Insert_point].Path_list.Count - 1;

                    if (!found)
                    {
                        temp_chromosome2.One_Path[Insert_point].Path_list.Insert(items_count_temp1, temp_chromosome1.One_Path[i].Path_list[j].ObjectClone(temp_chromosome1.One_Path[i].Path_list[j]));

                        temp_chromosome2.Compute_Fitness();
                        // Check feasibility
                        if (temp_chromosome2.One_Path[Insert_point].Total_Duration > temp_chromosome2.One_Path[i].Tmax
                            || Robots_Max_Energy[i] > temp_chromosome2.One_Path[i].Total_Energy_Cost)
                        {
                            temp_chromosome2.One_Path[Insert_point].Path_list.RemoveAt(items_count_temp1);

                        }
                    }
                }
            }

            //fix reserve list
            for (int v = 1; v < Full_Vertices.One_Path[0].Path_list.Count; v++)
            {
                bool found_ch1 = false;
                bool found_ch2 = false;

                for (int i = 0; i < Number_of_Robots; i++)
                {
                    int items_count = temp_chromosome1.One_Path[i].Path_list.Count - 1;
                    for (int j = 1; j < items_count; j++)
                    {
                        if (temp_chromosome1.One_Path[i].Path_list[j].id == Full_Vertices.One_Path[0].Path_list[v].id)
                        {
                            found_ch1 = true;
                            break;
                        }
                    }

                    items_count = temp_chromosome2.One_Path[i].Path_list.Count - 1;
                    for (int j = 1; j < items_count; j++)
                    {
                        if (temp_chromosome2.One_Path[i].Path_list[j].id == Full_Vertices.One_Path[0].Path_list[v].id)
                        {
                            found_ch2 = true;
                            break;
                        }
                    }
                }
                if (!found_ch1)
                {
                    int insertion_index = temp_chromosome1.Reserve_list.Path_list.Count;

                    temp_chromosome1.Reserve_list.Path_list.Insert(insertion_index,
                       Full_Vertices.One_Path[0].Path_list[v].ObjectClone(Full_Vertices.One_Path[0].Path_list[v]));
                }

                if (!found_ch2)
                {
                    int insertion_index = temp_chromosome2.Reserve_list.Path_list.Count;

                    temp_chromosome2.Reserve_list.Path_list.Insert(insertion_index,
                       Full_Vertices.One_Path[0].Path_list[v].ObjectClone(Full_Vertices.One_Path[0].Path_list[v]));
                }
            }

            temp_chromosome1.Compute_Fitness();
            temp_chromosome2.Compute_Fitness();
          }
        //________________________________________________________________________________________________________________
        static public void PMX(Full_Chrmosome Target_Chromosome1, Full_Chrmosome Target_Chromosome2, ref Full_Chrmosome temp_chromosome1, int Number_of_Robots, Full_Chrmosome Full_Vertices, ref SIMAB SIMB_F, int[] Robots_Max_Energy, int iteration)
        {
            //A Multi-Objective and Evolutionary Hyper-Heuristic Applied to the Integration and Test Order Problem 2017

            // Two point crossover o two given chroosme
            int Cross_point1 = Random_Number.GetRandomNumber(1, Number_of_Robots / 2 - 1); ;
            int Cross_point2 = Random_Number.GetRandomNumber(Number_of_Robots / 2, Number_of_Robots - 1); ;

            //copy first chromosome to child and clear edge of chromosome
            temp_chromosome1 = Target_Chromosome1.ObjectClone(Target_Chromosome1);
            Full_Chrmosome temp_chromosome_2_internal = Target_Chromosome2.ObjectClone(Target_Chromosome2);

            temp_chromosome1.Reserve_list.Path_list.Clear();

            for (int i = 0; i < Cross_point1; i++)
            {
                int items_count_ch1 = temp_chromosome1.One_Path[i].Path_list.Count - 1;
                for (int del = 1; del < items_count_ch1; del++)
                {
                    temp_chromosome1.One_Path[i].Path_list.RemoveAt(1);
                }
            }
            for (int i = Cross_point2; i < Number_of_Robots; i++)
            {
                int items_count_ch1 = temp_chromosome1.One_Path[i].Path_list.Count - 1;
                for (int del = 1; del < items_count_ch1; del++)
                {
                    temp_chromosome1.One_Path[i].Path_list.RemoveAt(1);
                }
            }

            for (int i = 0; i < Number_of_Robots; i++)
            {
                if (i < Cross_point1 || i >= Cross_point2)
                {
                    temp_chromosome1.One_Path[i] = temp_chromosome_2_internal.One_Path[i].ObjectClone(temp_chromosome_2_internal.One_Path[i]);

                    int items_count_ch1 = temp_chromosome1.One_Path[i].Path_list.Count - 1;
                    for (int j = 1; j < items_count_ch1; j++)
                    {
                        bool found = false;
                        for (int k = Cross_point1; k < Cross_point2 && !found; k++)
                        {
                            int items_count_ch2 = temp_chromosome1.One_Path[k].Path_list.Count - 1;
                            for (int l = 1; l < items_count_ch2; l++)
                            {
                                if (temp_chromosome1.One_Path[i].Path_list[j].id ==
                                     temp_chromosome1.One_Path[k].Path_list[l].id)
                                {
                                    temp_chromosome1.One_Path[i].Path_list.RemoveAt(j);
                                    found = true;
                                    items_count_ch1--;
                                    j--;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            //fix reserve list
            for (int v = 1; v < Full_Vertices.One_Path[0].Path_list.Count; v++)
            {
                bool found_ch1 = false;

                for (int i = 0; i < Number_of_Robots; i++)
                {
                    int items_count = temp_chromosome1.One_Path[i].Path_list.Count - 1;
                    for (int j = 1; j < items_count; j++)
                    {
                        if (temp_chromosome1.One_Path[i].Path_list[j].id == Full_Vertices.One_Path[0].Path_list[v].id)
                        {
                            found_ch1 = true;
                            break;
                        }
                    }
                }
                if (!found_ch1)
                {
                    int insertion_index = temp_chromosome1.Reserve_list.Path_list.Count;

                    temp_chromosome1.Reserve_list.Path_list.Insert(insertion_index,
                       Full_Vertices.One_Path[0].Path_list[v].ObjectClone(Full_Vertices.One_Path[0].Path_list[v]));
                }
            }

            temp_chromosome1.Compute_Fitness();

            // to return the eliminated ones
            Operators.Insert_Replace(temp_chromosome1, Number_of_Robots, ref SIMB_F, Robots_Max_Energy, false, true, iteration, 10);

            //...................................................................
            temp_chromosome1.Compute_Fitness();
           }
        //________________________________________________________________________________________________________________
        static public void ILS(Full_Chrmosome Target_Chromosome, int Number_of_Robots, ref SIMAB SIMB_F, int[] Robots_Max_Energy, int iteration)
        {
            //Well-tuned algorithms for the Team Orienteering Problem with Time Windows 2017
            int RC = Target_Chromosome.Reserve_list.Path_list.Count;
            for (int i = 0; i < RC; i++)
            {
                List<ILS_Insertion_location> Feasible_Locations = new List<ILS_Insertion_location>();
                List<double> list = new List<double>();
                bool simply_added = false;

                for (int j = 0; j < Number_of_Robots; j++)
                {
                    if (Target_Chromosome.One_Path[j].Tmax > Target_Chromosome.One_Path[j].Total_Duration + Target_Chromosome.Reserve_list.Path_list[i].service_duration)
                    {
                        int Path_items = Target_Chromosome.One_Path[j].Path_list.Count - 1;
                        if (Path_items == 1)
                        {
                            Target_Chromosome.One_Path[j].Path_list.Insert(1, Target_Chromosome.Reserve_list.Path_list[i].ObjectClone(Target_Chromosome.Reserve_list.Path_list[i]));
                            Target_Chromosome.Reserve_list.Path_list.RemoveAt(i);
                            RC--; i--;
                            Target_Chromosome.Compute_Fitness();
                            simply_added = true;
                            break;
                        }
                        else
                        {
                            for (int k = 1; k < Path_items; k++)
                            {
                                Target_Chromosome.Compute_Fitness();
                                double path_current_duration = Target_Chromosome.One_Path[j].Total_Duration;
                                Target_Chromosome.One_Path[j].Path_list.Insert(k, Target_Chromosome.Reserve_list.Path_list[i].ObjectClone(Target_Chromosome.Reserve_list.Path_list[i]));
                                Target_Chromosome.Compute_Fitness();

                                if (Target_Chromosome.One_Path[j].Tmax < Target_Chromosome.One_Path[j].Total_Duration
                                    || Robots_Max_Energy[j] < Target_Chromosome.One_Path[j].Total_Energy_Cost)
                                {
                                    // Was not feasible
                                    Target_Chromosome.One_Path[j].Path_list.RemoveAt(k);
                                }
                                else
                                {
                                    // Was feasible
                                    double time_increasment = (Target_Chromosome.One_Path[j].Total_Duration - path_current_duration);
                                    if (time_increasment != 0)
                                        time_increasment = 1 / time_increasment;
                                    Feasible_Locations.Add(new ILS_Insertion_location(j, k, time_increasment));
                                    list.Add(time_increasment);
                                    Target_Chromosome.One_Path[j].Path_list.RemoveAt(k);
                                }
                            }
                        }
                    }
                }
                if (list.Count > 0 && !simply_added)
                {
                    //assign based on roullet wheel
                    Normalizer.Normal(ref list);
                    Roulette r = new Roulette(list.ToArray());
                    int prob_index = r.spin();

                    Target_Chromosome.One_Path[Feasible_Locations[prob_index].Path_number].Path_list.Insert(Feasible_Locations[prob_index].Index, Target_Chromosome.Reserve_list.Path_list[i].ObjectClone(Target_Chromosome.Reserve_list.Path_list[i]));
                    Target_Chromosome.Reserve_list.Path_list.RemoveAt(i);
                    RC--; i--;
                    Target_Chromosome.Compute_Fitness();
                }
            }

            //...................................................................
            Target_Chromosome.Compute_Fitness();
        }
        public struct ILS_Insertion_location
        {
            public int Path_number, Index;
            public double Probability;
            public ILS_Insertion_location(int PN, int I, double Prob)
            {
                Path_number = PN;
                Index = I;
                Probability = Prob;
            }
        }
        //________________________________________________________________________________________________________________
        static public void Shake_post_cons(Full_Chrmosome Target_Chromosome, int Number_of_Robots, Full_Chrmosome Full_Vertices, ref SIMAB SIMB_F, int[] Robots_Max_Energy, int iteration, int rate)
        {
            //Well-tuned algorithms for the Team Orienteering Problem with Time Windows 2017
            for (int i = 0; i < rate; i++)
            {
                int RN_P1 = Random_Number.GetRandomNumber(0, Number_of_Robots - 1);

                if (Target_Chromosome.One_Path[RN_P1].Path_list.Count > 5)
                {
                    int Post = Random_Number.GetRandomNumber(2, Target_Chromosome.One_Path[RN_P1].Path_list.Count - 3);
                    int Cons = Random_Number.GetRandomNumber(Post, Target_Chromosome.One_Path[RN_P1].Path_list.Count - 2);

                    for (int j = Post; j < Cons; j++)
                    {
                        Target_Chromosome.One_Path[RN_P1].Path_list.RemoveAt(Post);
                    }
                }
            }

            Target_Chromosome.Reserve_list.Path_list.Clear();

            //fix reserve list
            for (int v = 1; v < Full_Vertices.One_Path[0].Path_list.Count; v++)
            {
                bool found_ch1 = false;

                for (int i = 0; i < Number_of_Robots; i++)
                {
                    int items_count = Target_Chromosome.One_Path[i].Path_list.Count - 1;
                    for (int j = 1; j < items_count; j++)
                    {
                        if (Target_Chromosome.One_Path[i].Path_list[j].id == Full_Vertices.One_Path[0].Path_list[v].id)
                        {
                            found_ch1 = true;
                            break;
                        }
                    }
                }
                if (!found_ch1)
                {
                    int insertion_index = Target_Chromosome.Reserve_list.Path_list.Count;

                    Target_Chromosome.Reserve_list.Path_list.Insert(insertion_index,
                       Full_Vertices.One_Path[0].Path_list[v].ObjectClone(Full_Vertices.One_Path[0].Path_list[v]));
                }
            }
            Target_Chromosome.Compute_Fitness();   
        }
        //________________________________________________________________________________________________________________
        static public void MSA(Full_Chrmosome Target_Chromosome, int Number_of_Robots, ref SIMAB SIMB_F, int[] Robots_Max_Energy, int iteration)
        {
            // Iterated localsearch for the team orienteering problem with time windows 2009
            int RC = Target_Chromosome.Reserve_list.Path_list.Count;
            for (int i = 0; i < RC; i++)
            {
                List<ILS_Insertion_location> Feasible_Locations = new List<ILS_Insertion_location>();
                bool simply_added = false;

                for (int j = 0; j < Number_of_Robots; j++)
                {
                    if (Target_Chromosome.One_Path[j].Tmax > Target_Chromosome.One_Path[j].Total_Duration + Target_Chromosome.Reserve_list.Path_list[i].service_duration)
                    {
                        int Path_items = Target_Chromosome.One_Path[j].Path_list.Count - 1;
                        if (Path_items == 1)
                        {
                            Target_Chromosome.One_Path[j].Path_list.Insert(1, Target_Chromosome.Reserve_list.Path_list[i].ObjectClone(Target_Chromosome.Reserve_list.Path_list[i]));
                            Target_Chromosome.Reserve_list.Path_list.RemoveAt(i);
                            RC--; i--;
                            Target_Chromosome.Compute_Fitness();
                            simply_added = true;
                            break;
                        }
                        else
                        {
                            for (int k = 1; k < Path_items; k++)
                            {
                                Target_Chromosome.Compute_Fitness();

                                double path_current_duration = Target_Chromosome.One_Path[j].Total_Duration;
                                Target_Chromosome.One_Path[j].Path_list.Insert(k, Target_Chromosome.Reserve_list.Path_list[i].ObjectClone(Target_Chromosome.Reserve_list.Path_list[i]));
                                Target_Chromosome.Compute_Fitness();

                                if (Target_Chromosome.One_Path[j].Tmax < Target_Chromosome.One_Path[j].Total_Duration
                                      || Robots_Max_Energy[j] < Target_Chromosome.One_Path[j].Total_Energy_Cost)
                                {
                                    // Was not feasible
                                    Target_Chromosome.One_Path[j].Path_list.RemoveAt(k);
                                }
                                else
                                {
                                    // Was feasible
                                    double Shift = Target_Chromosome.One_Path[j].Total_Duration - path_current_duration;

                                    double Ratio = Math.Pow(Target_Chromosome.One_Path[j].Path_list[k].profit, 2) / Shift;
                                    Feasible_Locations.Add(new ILS_Insertion_location(j, k, Ratio));

                                    Target_Chromosome.One_Path[j].Path_list.RemoveAt(k);
                                }
                            }
                        }
                    }
                }
                if (Feasible_Locations.Count > 0 && !simply_added)
                {
                    //Assign to the best by max in equation(Si)^2/Shift
                    double max = -1;
                    int index_found = 0;
                    for (int max_index = 0; max_index < Feasible_Locations.Count; max_index++)
                    {
                        if (Feasible_Locations[max_index].Probability > max)
                        {
                            max = Feasible_Locations[max_index].Probability;
                            index_found = max_index;
                        }
                    }

                    Target_Chromosome.One_Path[Feasible_Locations[index_found].Path_number].Path_list.Insert(Feasible_Locations[index_found].Index, Target_Chromosome.Reserve_list.Path_list[i].ObjectClone(Target_Chromosome.Reserve_list.Path_list[i]));
                    Target_Chromosome.Reserve_list.Path_list.RemoveAt(i);
                    RC--; i--;
                    Target_Chromosome.Compute_Fitness();
                }
            }
            //...................................................................
            Target_Chromosome.Compute_Fitness();
         }
        //________________________________________________________________________________________________________________
        static public void Prposed_LS(ref Full_Chrmosome Target_Chromosome, int Number_of_Robots, ref SIMAB SIMB_F, int[] Robots_Max_Energy, int iteration)
        {
            //Well-tuned algorithms for the Team Orienteering Problem with Time Windows 2017

           // Target_Chromosome = parent.ObjectClone(parent);
            int ReserveCount = Target_Chromosome.Reserve_list.Path_list.Count;

            List<Proposed_LS_Insertion_location>[] Feasible_Locations = new List<Proposed_LS_Insertion_location>[ReserveCount];
            List<double>[] list = new List<double>[ReserveCount];
            int[] prob_index_list = new int[ReserveCount];

            for (int j = 0; j < ReserveCount; j++)
            {
                list[j] = new List<double>();
                Feasible_Locations[j] = new List<Proposed_LS_Insertion_location>();
            }

            for (int i = 0; i < ReserveCount; i++)
            {
                for (int j = 0; j < Number_of_Robots; j++)
                {
                   // if (Target_Chromosome.One_Path[j].Tmax > Target_Chromosome.One_Path[j].Total_Duration)
                    {
                        int Path_items = Target_Chromosome.One_Path[j].Path_list.Count - 1;
                        {
                            for (int k = 1; k < Path_items; k++)
                            {
                                bool ignore = false;

                                //check for insert new
                                if (Target_Chromosome.One_Path[j].Tmax > Target_Chromosome.One_Path[j].Total_Duration + Target_Chromosome.Reserve_list.Path_list[i].service_duration)
                                {
                                    Target_Chromosome.Compute_Fitness();
                                    double path_current_duration = Target_Chromosome.One_Path[j].Total_Duration;
                                    double path_current_profit = Target_Chromosome.One_Path[j].Total_Profit;

                                    Target_Chromosome.One_Path[j].Path_list.Insert(k, Target_Chromosome.Reserve_list.Path_list[i].ObjectClone(Target_Chromosome.Reserve_list.Path_list[i]));

                                    Target_Chromosome.Compute_Fitness();

                                    double time_increasment =
                                        (Target_Chromosome.One_Path[j].Total_Duration - path_current_duration);
                                    if (time_increasment != 0)
                                        time_increasment = 1 / time_increasment;

                                    double profit_increasment =
                                         (Target_Chromosome.One_Path[j].Total_Profit - path_current_profit);

                                    if (Target_Chromosome.One_Path[j].Tmax >= Target_Chromosome.One_Path[j].Total_Duration
                                          || Robots_Max_Energy[j] >= Target_Chromosome.One_Path[j].Total_Energy_Cost)
                                    {
                                        // Was feasible
                                        Feasible_Locations[i].Add(new Proposed_LS_Insertion_location(j, k, -1, i, time_increasment, true, false, false)); //swap is available
                                        list[i].Add((time_increasment + profit_increasment) * 1);
                                        ignore = true;
                                    }

                                    Target_Chromosome.One_Path[j].Path_list.RemoveAt(k);
                                }

                                //Swap with reserve
                                else if (!ignore && Target_Chromosome.One_Path[j].Tmax > Target_Chromosome.One_Path[j].Total_Duration - Target_Chromosome.One_Path[j].Path_list[k].service_duration + Target_Chromosome.Reserve_list.Path_list[i].service_duration)
                                {
                                    Target_Chromosome.Compute_Fitness();
                                    double path_current_duration = Target_Chromosome.One_Path[j].Total_Duration;
                                    double path_current_profit = Target_Chromosome.One_Path[j].Total_Profit;

                                    var temp = Target_Chromosome.One_Path[j].Path_list[k].ObjectClone(Target_Chromosome.One_Path[j].Path_list[k]);
                                    Target_Chromosome.One_Path[j].Path_list[k] = Target_Chromosome.Reserve_list.Path_list[i].ObjectClone(Target_Chromosome.Reserve_list.Path_list[i]);
                                    Target_Chromosome.Reserve_list.Path_list[i] = temp.ObjectClone(temp);

                                    Target_Chromosome.Compute_Fitness();

                                    double time_increasment =
                                        (Target_Chromosome.One_Path[j].Total_Duration - path_current_duration);
                                    if (time_increasment != 0)
                                        time_increasment = 1 / time_increasment;

                                    double profit_increasment =
                                         (Target_Chromosome.One_Path[j].Total_Profit - path_current_profit);

                                    if (Target_Chromosome.One_Path[j].Tmax >= Target_Chromosome.One_Path[j].Total_Duration
                                          || Robots_Max_Energy[j] >= Target_Chromosome.One_Path[j].Total_Energy_Cost)
                                    {
                                        // Was feasible
                                        Feasible_Locations[i].Add(new Proposed_LS_Insertion_location(j, k, -1, i, time_increasment, false, true, false)); //swap is available
                                        list[i].Add(time_increasment + profit_increasment);
                                        ignore = true;
                                    }

                                    temp = Target_Chromosome.One_Path[j].Path_list[k].ObjectClone(Target_Chromosome.One_Path[j].Path_list[k]);
                                    Target_Chromosome.One_Path[j].Path_list[k] = Target_Chromosome.Reserve_list.Path_list[i].ObjectClone(Target_Chromosome.Reserve_list.Path_list[i]);
                                    Target_Chromosome.Reserve_list.Path_list[i] = temp.ObjectClone(temp);
                                }
                                //remove probability
                                else if (!ignore)
                                {
                                    // Remove check
                                    // when was not feasible to swap and insert
                                    Target_Chromosome.Compute_Fitness();
                                    double path_current_duration = Target_Chromosome.One_Path[j].Total_Duration;

                                    var temp = Target_Chromosome.One_Path[j].Path_list[k].ObjectClone(Target_Chromosome.One_Path[j].Path_list[k]);
                                    Target_Chromosome.One_Path[j].Path_list.RemoveAt(k);

                                    Target_Chromosome.Compute_Fitness();
                                    //elimination who has lower effection on time excluding its service time
                                    double time_increasment =
                                    (Target_Chromosome.One_Path[j].Total_Duration - path_current_duration - temp.service_duration);
                                    if (time_increasment != 0)
                                        time_increasment = 1 / time_increasment;

                                    if (Target_Chromosome.One_Path[j].Path_list.Count > 2)
                                    {
                                        // Was feasible to remove (list is not empty)
                                        Feasible_Locations[i].Add(new Proposed_LS_Insertion_location(j, k, -1, i, time_increasment, false, false, true)); //remove is available
                                        list[i].Add(time_increasment);
                                    }
                                    Target_Chromosome.One_Path[j].Path_list.Insert(k, temp);
                                }
                            }
                        }
                    }
                }

                //assign based on roullet wheel
                if (list[i].Count > 0)
                {
                    Normalizer.Normal(ref list[i]);
                    Roulette r = new Roulette(list[i].ToArray());
                    prob_index_list[i] = r.spin();
                }
                else
                {
                    prob_index_list[i] = -1;
                }
            }
            //-------------------------------------------------
            List<int> removed_id = new List<int>();
            for (int j = 0; j < Number_of_Robots; j++)
            {
                int selected_reserve = -1;
                for (int m = 0; m < ReserveCount; m++)
                {
                    if (prob_index_list[m] != -1)
                        if (Feasible_Locations[m][prob_index_list[m]].Path_number1 == j)
                        {
                            selected_reserve = m;
                        }
                }

                if (selected_reserve != -1)
                {
                    int path_number1 = Feasible_Locations[selected_reserve][prob_index_list[selected_reserve]].Path_number1;
                    int path_number2 = Feasible_Locations[selected_reserve][prob_index_list[selected_reserve]].Path_number2;

                    int index1 = Feasible_Locations[selected_reserve][prob_index_list[selected_reserve]].Index1;
                    int index2 = Feasible_Locations[selected_reserve][prob_index_list[selected_reserve]].Index2;

                    if (Feasible_Locations[selected_reserve][prob_index_list[selected_reserve]].Swap == true)
                    {
                        var temp = Target_Chromosome.One_Path[path_number1].Path_list[index1].ObjectClone(Target_Chromosome.One_Path[path_number1].Path_list[index1]);
                        Target_Chromosome.One_Path[path_number1].Path_list[index1] = Target_Chromosome.Reserve_list.Path_list[index2].ObjectClone(Target_Chromosome.Reserve_list.Path_list[index2]);
                        Target_Chromosome.Reserve_list.Path_list[index2] = temp.ObjectClone(temp);
                    }
                    else if (Feasible_Locations[selected_reserve][prob_index_list[selected_reserve]].Insert == true)
                    {
                        Target_Chromosome.One_Path[path_number1].Path_list.Insert(index1,
                             Target_Chromosome.Reserve_list.Path_list[index2].ObjectClone(Target_Chromosome.Reserve_list.Path_list[index2]));
                        removed_id.Add(Target_Chromosome.Reserve_list.Path_list[index2].id);
                    }
                    else if (Feasible_Locations[selected_reserve][prob_index_list[selected_reserve]].Remove == true)
                    {
                        Target_Chromosome.Reserve_list.Path_list.Insert(Target_Chromosome.Reserve_list.Path_list.Count,
                            Target_Chromosome.One_Path[path_number1].Path_list[index1].ObjectClone(Target_Chromosome.One_Path[path_number1].Path_list[index1]));
                       Target_Chromosome.One_Path[path_number1].Path_list.RemoveAt(index1);
                    }
                }
            }
            while (removed_id.Count > 0)
            {
                for (int i = 0; i < Target_Chromosome.Reserve_list.Path_list.Count; i++)
                {
                    if (Target_Chromosome.Reserve_list.Path_list[i].id == removed_id[0])
                    {
                        Target_Chromosome.Reserve_list.Path_list.RemoveAt(i);
                        removed_id.RemoveAt(0);
                        break;
                    }
                }
            }
            //...................................................................
            Target_Chromosome.Compute_Fitness();
           
        }
        public struct Proposed_LS_Insertion_location
        {
            public int Path_number1, Index1;
            public int Path_number2, Index2;
            public bool Insert;
            public bool Swap;
            public bool Remove;
            public double Probability1;
            public Proposed_LS_Insertion_location(int PN1, int Index_1, int PN2, int Index_2, double Prob, bool insert, bool swap, bool remove)
            {
                Path_number1 = PN1;
                Index1 = Index_1;
                Probability1 = Prob;
                Path_number2 = PN2;
                Index2 = Index_2;
                Insert = insert;
                Swap = swap;
                Remove = remove;
            }
        }
        //________________________________________________________________________________________________________________
        static public void Update_EP(ref Full_Chrmosome Temp, ref Full_Chrmosome[] X, ref List<Full_Chrmosome> EP, int[,] B, int c1, int k)
        {
            //Ch_Total_Profit = 0; //f1
            //Ch_Total_Duration = 0; //f2
            //Ch_Total_Energy_Cost = 0; //f3
            //Ch_Total_Fairness_Rate = 0; //f4
            //Ch_Delayed_Tasks_Duration = 0; //f5
            switch (c1)
            {
                case 0:
                    {
                        if (Temp.Ch_Total_Profit > X[B[c1, k]].Ch_Total_Profit)
                        {
                            X[c1] = Temp.ObjectClone(Temp);
                        }
                        for (int i = 0; i < EP.Count; i++)
                        {
                            if (Sort.Dominates(Temp, EP[i]))
                            {
                                EP.RemoveAt(i);
                            }
                        }
                        EP.Insert(0, Temp);

                        break;
                    }
                case 1:
                    {
                        if (Temp.Ch_Total_Duration < X[B[c1, k]].Ch_Total_Duration)
                        {
                            X[c1] = Temp.ObjectClone(Temp);
                        }

                        for (int i = 0; i < EP.Count; i++)
                        {
                            if (Sort.Dominates(Temp, EP[i]))
                            {
                                EP.RemoveAt(i);
                            }
                        }
                        EP.Insert(0, Temp);
                        X[c1] = Temp.ObjectClone(Temp);


                        break;
                    }
                case 2:
                    {
                        if (Temp.Ch_Total_Energy_Cost < X[B[c1, k]].Ch_Total_Energy_Cost)
                        {
                            X[c1] = Temp.ObjectClone(Temp);
                        }

                        for (int i = 0; i < EP.Count; i++)
                        {
                            if (Sort.Dominates(Temp, EP[i]))
                            {
                                EP.RemoveAt(i);
                            }
                        }
                        EP.Insert(0, Temp);

                        break;
                    }
                case 3:
                    {
                        if (Temp.Ch_Total_Fairness_Rate < X[B[c1, k]].Ch_Total_Fairness_Rate)
                        {
                            X[c1] = Temp.ObjectClone(Temp);
                        }
                        for (int i = 0; i < EP.Count; i++)
                        {
                            if (Sort.Dominates(Temp, EP[i]))
                            {
                                EP.RemoveAt(i);
                            }
                        }
                        EP.Insert(0, Temp);

                        break;
                    }
                case 4:
                    {
                        if (Temp.Ch_Delayed_Tasks_Duration < X[B[c1, k]].Ch_Delayed_Tasks_Duration)
                        {
                            X[c1] = Temp.ObjectClone(Temp);
                        }
                        for (int i = 0; i < EP.Count; i++)
                        {
                            if (Sort.Dominates(Temp, EP[i]))
                            {
                                EP.RemoveAt(i);
                            }
                        }
                        EP.Insert(0, Temp);

                        break;
                    }
            }

        }
        //________________________________________________________________________________________________________________
        static public void LLH_Selection(ref Full_Chrmosome[] Parents, ref Full_Chrmosome[] Children, ref Full_Chrmosome[] X, ref List<Full_Chrmosome> EP, Full_Chrmosome Full_Vertices, ref SIMAB SIMAB_1,
            int[] Robots_Max_Energy, int Next_Operator, int iter, int Number_of_Chromosomes, int Number_of_Robots, int HF, string MO_Algorithm, int T, int[,] B)
        {
            double New_Fitness = 0;
            double Total_Reward = 0;
            int Shake_Factor = 1;

            // Both actions for NSGA-III and NSGA-II are same
            if (MO_Algorithm == "NSGA-III")
                MO_Algorithm = "NSGA-II";

            for (int i = 0; i < SIMAB_1.LLH_Counter.Length; i++)
            {
                SIMAB_1.LLH_Wait_Counter[i]++;
            }
            bool Out2chromosome = false;

            Full_Chrmosome Temp = new Full_Chrmosome(Number_of_Robots);
            Full_Chrmosome Temp1 = new Full_Chrmosome(Number_of_Robots);
            Full_Chrmosome Temp2 = new Full_Chrmosome(Number_of_Robots);

            for (int c1 = 0; (c1 < Number_of_Chromosomes && MO_Algorithm == "NSGA-II")
                || (c1 < T && MO_Algorithm == "MOEA-D"); c1++)
            {
                SIMAB_1.LLH_Last_Used_Iteration[Next_Operator] = iter;
                Children[c1].Compute_Fitness();
                SIMAB_1.LLH_Current_Reward[Next_Operator] = Children[c1].Ch_Fitness;

                double Auxiliry_LLH_Current_Reward = 0;

                double Auxiliry_LLH_Next_Reward1 = 0;
                double Auxiliry_LLH_Next_Reward2 = 0;
 
                //-----------------------------

                switch (Next_Operator)
                {
                    case 0:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Children[c1].Ch_Fitness;

                                // if (iter % 2 == 0)
                                Operators.Shake_post_cons(Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.ILS(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);

                                LLH_Avoid_Local_optimum(ref Parents, ref Children, ref SIMAB_1, Number_of_Chromosomes, Next_Operator, 100);
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1); //noty used here

                                Temp = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp.Ch_Fitness;

                                Operators.Shake_post_cons(Temp, Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.ILS(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);

                                Auxiliry_LLH_Next_Reward1 = Temp.Ch_Fitness;

                                Update_EP(ref Temp, ref X, ref EP, B, c1, k);
                            }
                            break;
                        }
                    case 1:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Children[c1].Ch_Fitness;

                                // if (iter % 2 == 0)
                                Operators.Shake_post_cons(Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.ILS(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1); //noty used here

                                Temp = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp.Ch_Fitness;

                                Operators.Shake_post_cons(Temp, Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.ILS(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);

                                Auxiliry_LLH_Next_Reward1 = Temp.Ch_Fitness;

                                Update_EP(ref Temp, ref X, ref EP, B, c1, k);
                            }
                            break;

                        }
                    case 2:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Children[c1].Ch_Fitness;

                                // if (iter % 2 == 0)
                                Operators.Shake_post_cons(Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.ILS(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.InSwap_ExSwap(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, false, true, iter, HF);
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1); //noty used here

                                Temp = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp.Ch_Fitness;

                                Operators.Shake_post_cons(Temp, Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.ILS(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.InSwap_ExSwap(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, false, true, iter, HF);

                                Auxiliry_LLH_Next_Reward1 = Temp.Ch_Fitness;
                                Update_EP(ref Temp, ref X, ref EP, B, c1, k);
                            }
                            break;
                        }
                    case 3:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Children[c1].Ch_Fitness;

                                // if (iter % 2 == 0)
                                Operators.Shake_post_cons(Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.ILS(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.Insert_Replace(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1); //noty used here

                                Temp = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp.Ch_Fitness;

                                Operators.Shake_post_cons(Temp, Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.ILS(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.InSwap_ExSwap(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);

                                Auxiliry_LLH_Next_Reward1 = Temp.Ch_Fitness;
                                Update_EP(ref Temp, ref X, ref EP, B, c1, k);

                            }
                            break;
                        }
                    case 4:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Children[c1].Ch_Fitness;

                                // if (iter % 2 == 0)
                                Operators.Shake_post_cons(Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.ILS(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.Insert_Replace(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1); //noty used here

                                Temp = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp.Ch_Fitness;

                                Operators.Shake_post_cons(Temp, Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.ILS(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.Insert_Replace(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);

                                Auxiliry_LLH_Next_Reward1 = Temp.Ch_Fitness;
                                Update_EP(ref Temp, ref X, ref EP, B, c1, k);

                            }
                            break;
                        }
                    case 5:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Children[c1].Ch_Fitness;

                                // if (iter % 2 == 0)
                                Operators.Shake_post_cons(Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.ILS(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.Reverse(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter, HF);
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1); //noty used here

                                Temp = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp.Ch_Fitness;

                                Operators.Shake_post_cons(Temp, Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.ILS(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.Reverse(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter, HF);

                                Auxiliry_LLH_Next_Reward1 = Temp.Ch_Fitness;
                                Update_EP(ref Temp, ref X, ref EP, B, c1, k);
                            }
                            break;
                        }
                    case 6:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Children[c1].Ch_Fitness;

                                // if (iter % 2 == 0)
                                Operators.Shake_post_cons(Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.MSA(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1); //noty used here

                                Temp = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp.Ch_Fitness;

                                Operators.Shake_post_cons(Temp, Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.MSA(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);

                                Auxiliry_LLH_Next_Reward1 = Temp.Ch_Fitness;
                                Update_EP(ref Temp, ref X, ref EP, B, c1, k);
                            }
                            break;
                        }
                    case 7:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Children[c1].Ch_Fitness;

                                // if (iter % 2 == 0)
                                Operators.Shake_post_cons(Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.MSA(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.InSwap_ExSwap(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1); //noty used here

                                Temp = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp.Ch_Fitness;

                                Operators.Shake_post_cons(Temp, Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.MSA(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.InSwap_ExSwap(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);

                                Auxiliry_LLH_Next_Reward1 = Temp.Ch_Fitness;
                                Update_EP(ref Temp, ref X, ref EP, B, c1, k);
                            }
                            break;
                        }
                    case 8:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Children[c1].Ch_Fitness;

                                // if (iter % 2 == 0)
                                Operators.Shake_post_cons(Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.MSA(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.InSwap_ExSwap(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, false, true, iter, HF);
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1); //noty used here

                                Temp = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp.Ch_Fitness;

                                Operators.Shake_post_cons(Temp, Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.MSA(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.InSwap_ExSwap(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, false, true, iter, HF);

                                Auxiliry_LLH_Next_Reward1 = Temp.Ch_Fitness;
                                Update_EP(ref Temp, ref X, ref EP, B, c1, k);
                            }

                            break;
                        }
                    case 9:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Children[c1].Ch_Fitness;

                                // if (iter % 2 == 0)
                                Operators.Shake_post_cons(Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.MSA(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.Insert_Replace(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1); //noty used here

                                Temp = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp.Ch_Fitness;

                                Operators.Shake_post_cons(Temp, Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.MSA(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.Insert_Replace(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);

                                Auxiliry_LLH_Next_Reward1 = Temp.Ch_Fitness;
                                Update_EP(ref Temp, ref X, ref EP, B, c1, k);
                            }
                            break;
                        }
                    case 10:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Children[c1].Ch_Fitness;

                                // if (iter % 2 == 0)
                                Operators.Shake_post_cons(Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.MSA(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.Insert_Replace(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1); //noty used here

                                Temp = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp.Ch_Fitness;

                                Operators.Shake_post_cons(Temp, Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.MSA(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.Insert_Replace(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);

                                Auxiliry_LLH_Next_Reward1 = Temp.Ch_Fitness;
                                Update_EP(ref Temp, ref X, ref EP, B, c1, k);
                            }

                            break;
                        }
                    case 11:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                // if (iter % 2 == 0)
                                Operators.Shake_post_cons(Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.MSA(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.Reverse(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter, HF);
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1); //noty used here

                                Temp = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp.Ch_Fitness;

                                Operators.Shake_post_cons(Temp, Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter, HF * Shake_Factor);
                                Operators.MSA(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.Reverse(Temp, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter, HF);

                                Auxiliry_LLH_Next_Reward1 = Temp.Ch_Fitness;

                                Update_EP(ref Temp, ref X, ref EP, B, c1, k);
                            }
                            break;
                        }
                    case 12:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                //crossover PMX
                                int Random_CH1 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                int Random_CH2 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Parents[Random_CH1].Ch_Fitness;

                                Operators.PMX(Parents[Random_CH1], Parents[Random_CH2], ref Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter);
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1);

                                Temp1 = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                Temp2 = X[B[c1, l]].ObjectClone(X[B[c1, l]]);

                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp1.Ch_Fitness;

                                Operators.PMX(Temp1, Temp2, ref Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter);

                                Auxiliry_LLH_Next_Reward1 = Temp1.Ch_Fitness;
                                Auxiliry_LLH_Next_Reward2 = Temp2.Ch_Fitness;

                                Update_EP(ref Temp1, ref X, ref EP, B, c1, k);
                                Update_EP(ref Temp2, ref X, ref EP, B, c1, l);
                            }
                            Out2chromosome = true;
                            break;
                        }
                    case 13:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                //crossover PMX
                                int Random_CH1 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                int Random_CH2 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Parents[Random_CH1].Ch_Fitness;

                                Operators.PMX(Parents[Random_CH1], Parents[Random_CH2], ref Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.InSwap_ExSwap(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1);

                                Temp1 = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                Temp2 = X[B[c1, l]].ObjectClone(X[B[c1, l]]);

                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp1.Ch_Fitness;

                                Operators.PMX(Temp1, Temp2, ref Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.InSwap_ExSwap(Temp1, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);
                                Operators.InSwap_ExSwap(Temp2, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);

                                Auxiliry_LLH_Next_Reward1 = Temp1.Ch_Fitness;
                                Auxiliry_LLH_Next_Reward2 = Temp2.Ch_Fitness;

                                Update_EP(ref Temp1, ref X, ref EP, B, c1, k);
                                Update_EP(ref Temp2, ref X, ref EP, B, c1, l);
                            }
                            Out2chromosome = true;
                            break;
                        }
                    case 14:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                //crossover PMX
                                int Random_CH1 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                int Random_CH2 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Parents[Random_CH1].Ch_Fitness;

                                Operators.PMX(Parents[Random_CH1], Parents[Random_CH2], ref Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.InSwap_ExSwap(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, false, true, iter, HF);

                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1);

                                Temp1 = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                Temp2 = X[B[c1, l]].ObjectClone(X[B[c1, l]]);

                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp1.Ch_Fitness;

                                Operators.PMX(Temp1, Temp2, ref Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.InSwap_ExSwap(Temp1, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, false, true, iter, HF);
                                Operators.InSwap_ExSwap(Temp2, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, false, true, iter, HF);

                                Auxiliry_LLH_Next_Reward1 = Temp1.Ch_Fitness;
                                Auxiliry_LLH_Next_Reward2 = Temp2.Ch_Fitness;

                                Update_EP(ref Temp1, ref X, ref EP, B, c1, k);
                                Update_EP(ref Temp2, ref X, ref EP, B, c1, l);
                            }
                            Out2chromosome = true;
                            break;
                        }
                    case 15:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                //crossover PMX
                                int Random_CH1 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                int Random_CH2 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Parents[Random_CH1].Ch_Fitness;

                                Operators.PMX(Parents[Random_CH1], Parents[Random_CH2], ref Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.Insert_Replace(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1);

                                Temp1 = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                Temp2 = X[B[c1, l]].ObjectClone(X[B[c1, l]]);

                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp1.Ch_Fitness;

                                Operators.PMX(Temp1, Temp2, ref Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.Insert_Replace(Temp1, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);
                                Operators.Insert_Replace(Temp2, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);

                                Auxiliry_LLH_Next_Reward1 = Temp1.Ch_Fitness;
                                Auxiliry_LLH_Next_Reward2 = Temp2.Ch_Fitness;

                                Update_EP(ref Temp1, ref X, ref EP, B, c1, k);
                                Update_EP(ref Temp2, ref X, ref EP, B, c1, l);

                            }
                            Out2chromosome = true;
                            break;
                        }
                    case 16:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                //crossover PMX
                                int Random_CH1 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                int Random_CH2 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Parents[Random_CH1].Ch_Fitness;

                                Operators.PMX(Parents[Random_CH1], Parents[Random_CH2], ref Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.Insert_Replace(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1);

                                Temp1 = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                Temp2 = X[B[c1, l]].ObjectClone(X[B[c1, l]]);

                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp1.Ch_Fitness;

                                Operators.PMX(Temp1, Temp2, ref Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.Insert_Replace(Temp1, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);
                                Operators.Insert_Replace(Temp2, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);

                                Auxiliry_LLH_Next_Reward1 = Temp1.Ch_Fitness;
                                Auxiliry_LLH_Next_Reward2 = Temp2.Ch_Fitness;

                                Update_EP(ref Temp1, ref X, ref EP, B, c1, k);
                                Update_EP(ref Temp2, ref X, ref EP, B, c1, l);
                            }
                            Out2chromosome = true;
                            break;
                        }
                    case 17:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                //crossover PMX
                                int Random_CH1 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                int Random_CH2 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Parents[Random_CH1].Ch_Fitness;

                                Operators.PMX(Parents[Random_CH1], Parents[Random_CH2], ref Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.Reverse(Children[c1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter, HF);
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1);

                                Temp1 = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                Temp2 = X[B[c1, l]].ObjectClone(X[B[c1, l]]);

                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp1.Ch_Fitness;

                                Operators.PMX(Temp1, Temp2, ref Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.Reverse(Temp1, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter, HF);
                                Operators.Reverse(Temp2, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter, HF);

                                Auxiliry_LLH_Next_Reward1 = Temp1.Ch_Fitness;
                                Auxiliry_LLH_Next_Reward2 = Temp2.Ch_Fitness;

                                Update_EP(ref Temp1, ref X, ref EP, B, c1, k);
                                Update_EP(ref Temp2, ref X, ref EP, B, c1, l);
                            }
                            Out2chromosome = true;
                            break;
                        }
                    case 18:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                //crossover two point
                                if (c1 < Number_of_Chromosomes / 2 - 1)
                                {
                                    int Random_CH1 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                    int Random_CH2 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                    SIMAB_1.LLH_Current_Reward[Next_Operator] = Parents[Random_CH1].Ch_Fitness;
                                    Auxiliry_LLH_Current_Reward = Parents[Random_CH2].Ch_Fitness;

                                    Operators.Two_Point_Crossover(Parents[Random_CH1], Parents[Random_CH2], ref Children[c1 * 2], ref Children[c1 * 2 + 1], Number_of_Robots, Full_Vertices, iter, ref SIMAB_1, Robots_Max_Energy);

                                }
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1);

                                Temp1 = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                Temp2 = X[B[c1, l]].ObjectClone(X[B[c1, l]]);

                                Full_Chrmosome Child_Temp1 = new Full_Chrmosome(Number_of_Robots);
                                Full_Chrmosome Child_Temp2 = new Full_Chrmosome(Number_of_Robots);

                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp1.Ch_Fitness;
                                Auxiliry_LLH_Current_Reward = Temp1.Ch_Fitness;

                                Operators.PMX(Temp1, Temp2, ref Children[c1], Number_of_Robots, Full_Vertices, ref SIMAB_1, Robots_Max_Energy, iter);
                                Operators.Reverse(Temp1, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter, HF);
                                Operators.Two_Point_Crossover(Temp1, Temp2, ref Child_Temp1, ref Child_Temp2, Number_of_Robots, Full_Vertices, iter, ref SIMAB_1, Robots_Max_Energy);

                                Auxiliry_LLH_Next_Reward1 = Temp1.Ch_Fitness;
                                Auxiliry_LLH_Next_Reward2 = Temp2.Ch_Fitness;

                                Update_EP(ref Child_Temp1, ref X, ref EP, B, c1, k);
                                Update_EP(ref Child_Temp2, ref X, ref EP, B, c1, l);
                            }
                            Out2chromosome = true;
                            break;
                        }
                    case 19:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                //crossover two point
                                if (c1 < Number_of_Chromosomes / 2 - 1)
                                {
                                    int Random_CH1 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                    int Random_CH2 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                    SIMAB_1.LLH_Current_Reward[Next_Operator] = Parents[Random_CH1].Ch_Fitness;
                                    Auxiliry_LLH_Current_Reward = Parents[Random_CH2].Ch_Fitness;
                                    Operators.Two_Point_Crossover(Parents[Random_CH1], Parents[Random_CH2], ref Children[c1 * 2], ref Children[c1 * 2 + 1], Number_of_Robots, Full_Vertices, iter, ref SIMAB_1, Robots_Max_Energy);
                                    Operators.InSwap_ExSwap(Children[c1 * 2], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);
                                    Operators.InSwap_ExSwap(Children[c1 * 2 + 1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);
                                }
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1);

                                Temp1 = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                Temp2 = X[B[c1, l]].ObjectClone(X[B[c1, l]]);

                                Full_Chrmosome Child_Temp1 = new Full_Chrmosome(Number_of_Robots);
                                Full_Chrmosome Child_Temp2 = new Full_Chrmosome(Number_of_Robots);

                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp1.Ch_Fitness;
                                Auxiliry_LLH_Current_Reward = Temp1.Ch_Fitness;

                                Operators.Two_Point_Crossover(Temp1, Temp2, ref Child_Temp1, ref Child_Temp2, Number_of_Robots, Full_Vertices, iter, ref SIMAB_1, Robots_Max_Energy);
                                Operators.InSwap_ExSwap(Child_Temp1, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);
                                Operators.InSwap_ExSwap(Child_Temp2, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);

                                Auxiliry_LLH_Next_Reward1 = Temp1.Ch_Fitness;
                                Auxiliry_LLH_Next_Reward2 = Temp2.Ch_Fitness;

                                Update_EP(ref Child_Temp1, ref X, ref EP, B, c1, k);
                                Update_EP(ref Child_Temp2, ref X, ref EP, B, c1, l);
                            }
                            Out2chromosome = true;
                            break;
                        }
                    case 20:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                //crossover two point
                                if (c1 < Number_of_Chromosomes / 2 - 1)
                                {
                                    int Random_CH1 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                    int Random_CH2 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                    SIMAB_1.LLH_Current_Reward[Next_Operator] = Parents[Random_CH1].Ch_Fitness;
                                    Auxiliry_LLH_Current_Reward = Parents[Random_CH2].Ch_Fitness;
                                    Operators.Two_Point_Crossover(Parents[Random_CH1], Parents[Random_CH2], ref Children[c1 * 2], ref Children[c1 * 2 + 1], Number_of_Robots, Full_Vertices, iter, ref SIMAB_1, Robots_Max_Energy);
                                    Operators.InSwap_ExSwap(Children[c1 * 2], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, false, true, iter, HF);
                                    Operators.InSwap_ExSwap(Children[c1 * 2 + 1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, false, true, iter, HF);

                                }
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1);

                                Temp1 = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                Temp2 = X[B[c1, l]].ObjectClone(X[B[c1, l]]);

                                Full_Chrmosome Child_Temp1 = new Full_Chrmosome(Number_of_Robots);
                                Full_Chrmosome Child_Temp2 = new Full_Chrmosome(Number_of_Robots);

                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp1.Ch_Fitness;
                                Auxiliry_LLH_Current_Reward = Temp1.Ch_Fitness;

                                Operators.Two_Point_Crossover(Temp1, Temp2, ref Child_Temp1, ref Child_Temp2, Number_of_Robots, Full_Vertices, iter, ref SIMAB_1, Robots_Max_Energy);
                                Operators.InSwap_ExSwap(Child_Temp1, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, false, true, iter, HF);
                                Operators.InSwap_ExSwap(Child_Temp2, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, false, true, iter, HF);

                                Auxiliry_LLH_Next_Reward1 = Temp1.Ch_Fitness;
                                Auxiliry_LLH_Next_Reward2 = Temp2.Ch_Fitness;

                                Update_EP(ref Child_Temp1, ref X, ref EP, B, c1, k);
                                Update_EP(ref Child_Temp2, ref X, ref EP, B, c1, l);
                            }
                            Out2chromosome = true;
                            break;
                        }
                    case 21:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                //crossover two point
                                if (c1 < Number_of_Chromosomes / 2 - 1)
                                {
                                    int Random_CH1 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                    int Random_CH2 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                    SIMAB_1.LLH_Current_Reward[Next_Operator] = Parents[Random_CH1].Ch_Fitness;
                                    Auxiliry_LLH_Current_Reward = Parents[Random_CH2].Ch_Fitness;
                                    Operators.Two_Point_Crossover(Parents[Random_CH1], Parents[Random_CH2], ref Children[c1 * 2], ref Children[c1 * 2 + 1], Number_of_Robots, Full_Vertices, iter, ref SIMAB_1, Robots_Max_Energy);
                                    Operators.Insert_Replace(Children[c1 * 2], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);
                                    Operators.Insert_Replace(Children[c1 * 2 + 1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);

                                }
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1);

                                Temp1 = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                Temp2 = X[B[c1, l]].ObjectClone(X[B[c1, l]]);

                                Full_Chrmosome Child_Temp1 = new Full_Chrmosome(Number_of_Robots);
                                Full_Chrmosome Child_Temp2 = new Full_Chrmosome(Number_of_Robots);

                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp1.Ch_Fitness;
                                Auxiliry_LLH_Current_Reward = Temp1.Ch_Fitness;

                                Operators.Two_Point_Crossover(Temp1, Temp2, ref Child_Temp1, ref Child_Temp2, Number_of_Robots, Full_Vertices, iter, ref SIMAB_1, Robots_Max_Energy);
                                Operators.Insert_Replace(Child_Temp1, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);
                                Operators.Insert_Replace(Child_Temp2, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, true, false, iter, HF);

                                Auxiliry_LLH_Next_Reward1 = Temp1.Ch_Fitness;
                                Auxiliry_LLH_Next_Reward2 = Temp2.Ch_Fitness;

                                Update_EP(ref Child_Temp1, ref X, ref EP, B, c1, k);
                                Update_EP(ref Child_Temp2, ref X, ref EP, B, c1, l);
                            }
                            Out2chromosome = true;
                            break;
                        }
                    case 22:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                //crossover two point
                                if (c1 < Number_of_Chromosomes / 2 - 1)
                                {
                                    int Random_CH1 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                    int Random_CH2 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                    SIMAB_1.LLH_Current_Reward[Next_Operator] = Parents[Random_CH1].Ch_Fitness;
                                    Auxiliry_LLH_Current_Reward = Parents[Random_CH2].Ch_Fitness;
                                    Operators.Two_Point_Crossover(Parents[Random_CH1], Parents[Random_CH2], ref Children[c1 * 2], ref Children[c1 * 2 + 1], Number_of_Robots, Full_Vertices, iter, ref SIMAB_1, Robots_Max_Energy);
                                    Operators.Insert_Replace(Children[c1 * 2], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, false, true, iter, HF);
                                    Operators.Insert_Replace(Children[c1 * 2 + 1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, false, true, iter, HF);

                                }
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1);

                                Temp1 = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                Temp2 = X[B[c1, l]].ObjectClone(X[B[c1, l]]);

                                Full_Chrmosome Child_Temp1 = new Full_Chrmosome(Number_of_Robots);
                                Full_Chrmosome Child_Temp2 = new Full_Chrmosome(Number_of_Robots);

                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp1.Ch_Fitness;
                                Auxiliry_LLH_Current_Reward = Temp1.Ch_Fitness;

                                Operators.Two_Point_Crossover(Temp1, Temp2, ref Child_Temp1, ref Child_Temp2, Number_of_Robots, Full_Vertices, iter, ref SIMAB_1, Robots_Max_Energy);
                                Operators.Insert_Replace(Child_Temp1, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, false, true, iter, HF);
                                Operators.Insert_Replace(Child_Temp2, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, false, true, iter, HF);

                                Auxiliry_LLH_Next_Reward1 = Temp1.Ch_Fitness;
                                Auxiliry_LLH_Next_Reward2 = Temp2.Ch_Fitness;

                                Update_EP(ref Child_Temp1, ref X, ref EP, B, c1, k);
                                Update_EP(ref Child_Temp2, ref X, ref EP, B, c1, l);
                            }
                            Out2chromosome = true;
                            break;
                        }
                    case 23:
                        {
                            if (MO_Algorithm == "NSGA-II")
                            {
                                //crossover two point
                                if (c1 < Number_of_Chromosomes / 2 - 1)
                                {
                                    int Random_CH1 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                    int Random_CH2 = Random_Number.GetRandomNumber(1, Number_of_Chromosomes - 1);
                                    SIMAB_1.LLH_Current_Reward[Next_Operator] = Parents[Random_CH1].Ch_Fitness;
                                    Auxiliry_LLH_Current_Reward = Parents[Random_CH2].Ch_Fitness;
                                    Operators.Two_Point_Crossover(Parents[Random_CH1], Parents[Random_CH2], ref Children[c1 * 2], ref Children[c1 * 2 + 1], Number_of_Robots, Full_Vertices, iter, ref SIMAB_1, Robots_Max_Energy);
                                    Operators.Reverse(Children[c1 * 2], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter, HF);
                                    Operators.Reverse(Children[c1 * 2 + 1], Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter, HF);
                                }
                            }
                            else if (MO_Algorithm == "MOEA-D")
                            {
                                int k = Random_Number.GetRandomNumber(0, T - 1);
                                int l = Random_Number.GetRandomNumber(0, T - 1);

                                Temp1 = X[B[c1, k]].ObjectClone(X[B[c1, k]]);
                                Temp2 = X[B[c1, l]].ObjectClone(X[B[c1, l]]);

                                Full_Chrmosome Child_Temp1 = new Full_Chrmosome(Number_of_Robots);
                                Full_Chrmosome Child_Temp2 = new Full_Chrmosome(Number_of_Robots);

                                SIMAB_1.LLH_Current_Reward[Next_Operator] = Temp1.Ch_Fitness;
                                Auxiliry_LLH_Current_Reward = Temp1.Ch_Fitness;

                                Operators.Two_Point_Crossover(Temp1, Temp2, ref Child_Temp1, ref Child_Temp2, Number_of_Robots, Full_Vertices, iter, ref SIMAB_1, Robots_Max_Energy);
                                Operators.Reverse(Child_Temp1, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter, HF);
                                Operators.Reverse(Child_Temp2, Number_of_Robots, ref SIMAB_1, Robots_Max_Energy, iter, HF);

                                Auxiliry_LLH_Next_Reward1 = Temp1.Ch_Fitness;
                                Auxiliry_LLH_Next_Reward2 = Temp2.Ch_Fitness;

                                Update_EP(ref Child_Temp1, ref X, ref EP, B, c1, k);
                                Update_EP(ref Child_Temp2, ref X, ref EP, B, c1, l);
                            }
                            Out2chromosome = true;
                            break;
                        }
                        /*
                    case 24:
                        {
                            SIMAB_1.LLH_Current_Reward[Next_Operator] = Children[c1].Ch_Fitness;

                            Operators.Prposed_LS(ref Children[c1], Number_of_Robots, ref SIMAB_1, iter);

                            LLH_Avoid_Local_optimum(ref Parents, ref Children, ref SIMAB_1, Number_of_Chromosomes, Next_Operator, 200);
                            break;
                        }
                    case 25:
                        {
                            SIMAB_1.LLH_Current_Reward[Next_Operator] = Children[c1].Ch_Fitness;

                            Operators.InSwap_ExSwap(Children[c1], Number_of_Robots, ref SIMAB_1, true, false, iter, HF);
                            Operators.Prposed_LS(ref Children[c1], Number_of_Robots, ref SIMAB_1, iter);

                            LLH_Avoid_Local_optimum(ref Parents, ref Children, ref SIMAB_1, Number_of_Chromosomes, Next_Operator, 200);

                            break;
                        }
                    case 26:
                        {
                            SIMAB_1.LLH_Current_Reward[Next_Operator] = Children[c1].Ch_Fitness;

                            Operators.InSwap_ExSwap(Children[c1], Number_of_Robots, ref SIMAB_1, false, true, iter, HF);
                            Operators.Prposed_LS(ref Children[c1], Number_of_Robots, ref SIMAB_1, iter);

                            LLH_Avoid_Local_optimum(ref Parents, ref Children, ref SIMAB_1, Number_of_Chromosomes, Next_Operator, 200);

                            break;
                        }
                    case 27:
                        {
                            SIMAB_1.LLH_Current_Reward[Next_Operator] = Children[c1].Ch_Fitness;

                            Operators.Insert_Replace(Children[c1], Number_of_Robots, ref SIMAB_1, true, false, iter, HF);
                            Operators.Prposed_LS(ref Children[c1], Number_of_Robots, ref SIMAB_1, iter);

                            break;
                        }
                    case 28:
                        {
                            SIMAB_1.LLH_Current_Reward[Next_Operator] = Children[c1].Ch_Fitness;
                            Operators.Insert_Replace(Children[c1], Number_of_Robots, ref SIMAB_1, true, false, iter, HF);
                            Operators.Prposed_LS(ref Children[c1], Number_of_Robots, ref SIMAB_1, iter);

                            LLH_Avoid_Local_optimum(ref Parents, ref Children, ref SIMAB_1, Number_of_Chromosomes, Next_Operator, 200);

                            break;
                        }
                    case 29:
                        {
                            SIMAB_1.LLH_Current_Reward[Next_Operator] = Children[c1].Ch_Fitness;

                            Operators.Reverse(Children[c1], Number_of_Robots, ref SIMAB_1, iter, HF);
                            Operators.Prposed_LS(ref Children[c1], Number_of_Robots, ref SIMAB_1, iter);

                            break;
                        }
                        */
                }
                //-----------------------------
                if (SIMAB_1.LLH_Current_Reward[Next_Operator] > SIMAB_1.LLH_Max_Fitness[Next_Operator])
                {
                    SIMAB_1.LLH_Max_Fitness[Next_Operator] = SIMAB_1.LLH_Current_Reward[Next_Operator];
                }
                if (Out2chromosome)
                {
                    if (MO_Algorithm == "NSGA-II")
                    {
                        if (c1 < Number_of_Chromosomes / 2 - 1)
                        {
                            Children[c1 * 2].Compute_Fitness();
                            New_Fitness = Children[c1 * 2].Ch_Fitness - SIMAB_1.LLH_Current_Reward[Next_Operator];
                            if (New_Fitness > 0)
                                Total_Reward += 1;
                            else if (New_Fitness < 0)
                                Total_Reward += 0;
                            else
                                Total_Reward += 0.5;

                            Children[c1 * 2 + 1].Compute_Fitness();
                            New_Fitness = Children[c1 * 2 + 1].Ch_Fitness - Auxiliry_LLH_Current_Reward;
                            if (New_Fitness > 0)
                                Total_Reward += 1;
                            else if (New_Fitness < 0)
                                Total_Reward += 0;
                            else
                                Total_Reward += 0.5;
                        }
                    }
                    else if (MO_Algorithm == "MOEA-D")
                    {
                        New_Fitness = Auxiliry_LLH_Next_Reward1 - SIMAB_1.LLH_Current_Reward[Next_Operator];
                        if (New_Fitness > 0)
                            Total_Reward += 1;
                        else if (New_Fitness < 0)
                            Total_Reward += 0;
                        else
                            Total_Reward += 0.5;

                        New_Fitness = Auxiliry_LLH_Next_Reward2 - Auxiliry_LLH_Current_Reward;
                        if (New_Fitness > 0)
                            Total_Reward += 1;
                        else if (New_Fitness < 0)
                            Total_Reward += 0;
                        else
                            Total_Reward += 0.5;
                    }
                }
                else
                {
                    if (MO_Algorithm == "NSGA-II")
                    {
                        Children[c1].Compute_Fitness();
                        New_Fitness = Children[c1].Ch_Fitness - SIMAB_1.LLH_Current_Reward[Next_Operator];

                        if (New_Fitness > 0)
                            Total_Reward += 1;
                        else if (New_Fitness < 0)
                            Total_Reward += 0;
                        else
                            Total_Reward += 0.5;
                    }
                    else if (MO_Algorithm == "MOEA-D")
                    {
                        New_Fitness = Auxiliry_LLH_Next_Reward1 - SIMAB_1.LLH_Current_Reward[Next_Operator];

                        if (New_Fitness > 0)
                            Total_Reward += 1;
                        else if (New_Fitness < 0)
                            Total_Reward += 0;
                        else
                            Total_Reward += 0.5;
                    }
                }
            }
            if (MO_Algorithm == "NSGA-II")
            {
                SIMAB_1.LLH_Total_Reward[Next_Operator] = (1 / ((double)(Number_of_Chromosomes * Number_of_Chromosomes))) * Total_Reward;
                if (SIMAB_1.LLH_Total_Reward[Next_Operator] > SIMAB_1.LLH_Max_Reward[Next_Operator])
                    SIMAB_1.LLH_Max_Reward[Next_Operator] = SIMAB_1.LLH_Total_Reward[Next_Operator]; //saeve max obtained reward
            }
            else if (MO_Algorithm == "MOEA-D")
            {
                SIMAB_1.LLH_Total_Reward[Next_Operator] = (1 / ((double)(T * T))) * Total_Reward;
                if (SIMAB_1.LLH_Total_Reward[Next_Operator] > SIMAB_1.LLH_Max_Reward[Next_Operator])
                    SIMAB_1.LLH_Max_Reward[Next_Operator] = SIMAB_1.LLH_Total_Reward[Next_Operator]; //saeve max obtained reward

            }

            SIMAB_1.LLH_Counter[Next_Operator]++;
            SIMAB_1.LLH_Wait_Counter[Next_Operator] = 0;

        }
        //________________________________________________________________________________________________________________
        static public void LLH_Avoid_Local_optimum(ref Full_Chrmosome[] Parents, ref Full_Chrmosome[] Children, 
            ref SIMAB SIMAB_1,int Number_of_Chromosomes, int Next_Operator, int Threshold)
        {
            if (SIMAB_1.LLH_Current_Reward[Next_Operator] < SIMAB_1.LLH_Max_Fitness[Next_Operator])
            {
                SIMAB_1.LLH_No_Improve_Iteration_count[Next_Operator]++;
            }
            else
            {
                SIMAB_1.LLH_No_Improve_Iteration_count[Next_Operator] = 0;
            }
            if (SIMAB_1.LLH_No_Improve_Iteration_count[Next_Operator] > Threshold)
            {
                for (int cc = 0; cc < Number_of_Chromosomes; cc++)
                {
                    Children[cc] = Parents[cc].ObjectClone(Parents[cc]);
                }
                SIMAB_1.LLH_No_Improve_Iteration_count[Next_Operator] = 0;
            }

        }
    }
}

// Id offsets of operators
//public int InSwap_ID = 0;
//public int ExSwap_ID = 1;
//public int Insert_ID = 2;
//public int Replace_ID = 3;
//public int Crossover2P_ID = 4;
//public int PMX_ID = 5;
//public int Reverse_ID = 6;
//public int ILS_ID = 7;
//public int Shake_ID = 8;
//public int MaxShift_ID = 9;