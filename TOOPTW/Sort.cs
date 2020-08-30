using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TOOPTW
{
    static class Sort
    {
        /*  static public void None_Dominated_Sort1(ref Full_Chrmosome[] Parents_POP, Full_Chrmosome[] Children_POP, int Number_of_Chromosomes, int Number_of_Robots)
          {
              bool[] Parents_Status = new bool[Number_of_Chromosomes];
              bool[] Children_Status = new bool[Number_of_Chromosomes];

              Full_Chrmosome[] Ranked = new Full_Chrmosome[Number_of_Chromosomes * 2];

              int vr = 0;
              do
              {
                  for (int v = 0; v < Number_of_Chromosomes; v++)
                  {
                      bool dominated_by_parent = false;
                      bool dominated_by_child = false;
                      bool Diferences_in_parents = false;

                      for (int vs = 0; vs < Number_of_Chromosomes; vs++)
                      {
                          //search in parents
                          if (v != vs && !Parents_Status[vs] &&
                              //Parents_POP[vs].Ch_Total_Cost < Parents_POP[v].Ch_Total_Cost &&
                              // Parents_POP[vs].Ch_Total_Duration > Parents_POP[v].Ch_Total_Duration &&
                              Parents_POP[vs].Ch_Total_Profit > Parents_POP[v].Ch_Total_Profit)
                          {
                              dominated_by_parent = true;
                              break;
                          }

                          //search in childrens
                          if (!Children_Status[vs] &&
                              //Children_POP[vs].Ch_Total_Cost < Parents_POP[v].Ch_Total_Cost &&
                              //   Children_POP[vs].Ch_Total_Duration > Parents_POP[v].Ch_Total_Duration &&
                              Children_POP[vs].Ch_Total_Profit > Parents_POP[v].Ch_Total_Profit)

                          {
                              dominated_by_child = true;
                              break;
                          }
                      }
                      //adding to the new list
                      if (!Parents_Status[v])
                      {
                          for (int ch = 0; ch < vr && !Diferences_in_parents; ch++)
                          {
                              if (
                               //Parents_POP[vs].Ch_Total_Cost == Parents_POP[v].Ch_Total_Cost &&
                               // Parents_POP[vs].Ch_Total_Duration == Parents_POP[v].Ch_Total_Duration &&
                               Parents_POP[v].Ch_Total_Profit == Ranked[ch].Ch_Total_Profit)
                              {
                                  for (int j = 0; j < Number_of_Robots; j++)
                                  {
                                      int RC1 = Parents_POP[v].One_Path[j].Path_list.Count;
                                      int RC2 = Ranked[ch].One_Path[j].Path_list.Count;
                                      if (RC1 != RC2)
                                      {
                                          Diferences_in_parents = true;
                                          break;
                                      }
                                      else
                                      {
                                          for (int i = 0; i < RC1; i++)
                                          {
                                              if (Parents_POP[v].One_Path[j].Path_list[i].id != Ranked[ch].One_Path[j].Path_list[i].id)
                                              {
                                                  Diferences_in_parents = true;
                                                  break;
                                              }
                                          }
                                      }
                                  }
                              }
                              else
                              { Diferences_in_parents = true; break; }
                              Parents_Status[v] = true;
                          }
                          if ((!dominated_by_parent && !dominated_by_child && Diferences_in_parents) 
                              || (!dominated_by_parent && !dominated_by_child && vr == 0))
                          {
                              Parents_Status[v] = true;
                              Ranked[vr] = Parents_POP[v].ObjectClone(Parents_POP[v]);
                              vr++;
                          }
                      }
                  }
                  //----------------------------------------------------------
                  for (int v = 0; v < Number_of_Chromosomes; v++)
                  {
                      bool dominated_by_parent = false;
                      bool dominated_by_child = false;
                      bool Diferences_in_parents = false;

                      for (int vs = 0; vs < Number_of_Chromosomes; vs++)
                      {
                          //search in parents
                          if (!Parents_Status[vs] &&
                              //  Parents_POP[vs].Ch_Total_Cost < Children_POP[v].Ch_Total_Cost &&
                              //   Parents_POP[vs].Ch_Total_Duration > Children_POP[v].Ch_Total_Duration &&
                              Parents_POP[vs].Ch_Total_Profit > Children_POP[v].Ch_Total_Profit)
                          {
                              dominated_by_parent = true;
                              break;
                          }
                          //search in childrens
                          if (v != vs && !Children_Status[vs] &&
                              //   Children_POP[vs].Ch_Total_Cost < Children_POP[v].Ch_Total_Cost &&
                              //     Children_POP[vs].Ch_Total_Duration > Children_POP[v].Ch_Total_Duration &&
                              Children_POP[vs].Ch_Total_Profit > Children_POP[v].Ch_Total_Profit)
                          //    &&
                          //    !(//Children_POP[vs].Ch_Total_Cost == Children_POP[v].Ch_Total_Cost &&
                          ////    Children_POP[vs].Ch_Total_Duration == Children_POP[v].Ch_Total_Duration &&
                          //    Children_POP[vs].Ch_Total_Profit == Children_POP[v].Ch_Total_Profit))
                          {
                              dominated_by_child = true;
                              break;
                          }
                      }
                      if (!Children_Status[v])
                      {
                          for (int ch = 0; ch < vr && !Diferences_in_parents; ch++)
                          {
                          if (
                               //Children_POP[vs].Ch_Total_Cost == Parents_POP[v].Ch_Total_Cost &&
                               // Children_POP[vs].Ch_Total_Duration == Parents_POP[v].Ch_Total_Duration &&
                               Children_POP[v].Ch_Total_Profit == Ranked[ch].Ch_Total_Profit)
                                  {
                                  for (int j = 0; j < Number_of_Robots; j++)
                                  {
                                      int RC1 = Children_POP[v].One_Path[j].Path_list.Count;
                                      int RC2 = Ranked[ch].One_Path[j].Path_list.Count;
                                      if (RC1 != RC2)
                                      {
                                          // Parents_Status[v] = true;
                                          Diferences_in_parents = true;
                                          break;
                                      }
                                      else
                                      {
                                          for (int i = 0; i < RC1; i++)
                                          {
                                              if (Children_POP[v].One_Path[j].Path_list[i].id != Ranked[ch].One_Path[j].Path_list[i].id)
                                              {
                                                  //Parents_Status[v] = true;
                                                  Diferences_in_parents = true;
                                                  break;
                                              }
                                          }
                                      }
                                  }
                              }
                              else
                              { Diferences_in_parents = true; break; }
                              Parents_Status[v] = true;
                          }
                          if ((!dominated_by_parent && !dominated_by_child && Diferences_in_parents)
                              || (!dominated_by_parent && !dominated_by_child && vr == 0))
                          {
                              Children_Status[v] = true;
                              Ranked[vr] = Children_POP[v].ObjectClone(Children_POP[v]);
                              vr++;
                          }
                      }
                  }
              } while (vr < Number_of_Chromosomes);

              for (int vs = 0; vs < Number_of_Chromosomes; vs++)
              {
                  Parents_POP[vs] = Ranked[vs].ObjectClone(Ranked[vs]);
              }
          }*/
        //________________________________________________________________________________________________________________
        static public void None_Dominated_Sort(ref Full_Chrmosome[] Parents_POP, Full_Chrmosome[] Children_POP, int Number_of_Chromosomes, int Number_of_Robots, int max_available_profit, List<Hyper_weight_vector> Reference_points, string Algorithm)
        {
            int[] Parents_Status = new int[Number_of_Chromosomes];
            int[] Children_Status = new int[Number_of_Chromosomes];
            List<Full_Chrmosome>[] Ranked = new List<Full_Chrmosome>[Number_of_Chromosomes * 2];

            for (int vs = 0; vs < Number_of_Chromosomes; vs++)
            {
                Parents_Status[vs] = -1;
                Children_Status[vs] = -1;
                Ranked[vs] = new List<Full_Chrmosome>();
                Ranked[vs + Number_of_Chromosomes] = new List<Full_Chrmosome>();
            }

          //  int rank_count = 0;
            for (int rank_count = 0; rank_count < Number_of_Chromosomes * 2; rank_count++) // if all rtanked it can breack
            {
                //search in parents
                for (int v = 0; v < Number_of_Chromosomes; v++)
                {
                    bool dominated_by_parent = false;
                    bool dominated_by_child = false;

                    for (int vs = 0; vs < Number_of_Chromosomes && Parents_Status[v] == -1; vs++)
                    {
                        //search in parents
                        if (v != vs && (Parents_Status[vs] == -1 || Parents_Status[vs] == rank_count) &&
                            Dominates(Parents_POP[vs], Parents_POP[v]))
                        {
                            dominated_by_parent = true;
                            break;
                        }

                        //search in childrens
                        if ((Children_Status[vs] == -1 || Children_Status[vs] == rank_count) &&
                            Dominates(Children_POP[vs], Parents_POP[v]))

                        {
                            dominated_by_child = true;
                            break;
                        }
                    }
                    //adding to the new list
                    if (Parents_Status[v] == -1 && !dominated_by_parent && !dominated_by_child)
                    {
                        Parents_Status[v] = rank_count;
                        Ranked[rank_count].Insert(Ranked[rank_count].Count, Parents_POP[v].ObjectClone(Parents_POP[v]));
                     //   rank_count++;
                    }
                }
                //----------------------------------------------------------
                //search in children
                for (int v = 0; v < Number_of_Chromosomes; v++)
                {
                    bool dominated_by_parent = false;
                    bool dominated_by_child = false;

                    for (int vs = 0; vs < Number_of_Chromosomes && Children_Status[v] == -1; vs++)
                    {
                        //search in parents
                        if ((Parents_Status[vs] == -1 || Parents_Status[vs] == rank_count) &&
                            Dominates(Parents_POP[vs], Children_POP[v]))
                        {
                            dominated_by_parent = true;
                            break;
                        }
                        //search in childrens
                        if (v != vs && (Children_Status[vs] == -1 || Children_Status[vs] == rank_count) &&
                            Dominates(Children_POP[vs], Children_POP[v]))
                        {
                            dominated_by_child = true;
                            break;
                        }
                    }
                    if (Children_Status[v] == -1)
                    {
                        if (!dominated_by_parent && !dominated_by_child)
                        {
                            Children_Status[v] = rank_count;
                            Ranked[rank_count].Insert(Ranked[rank_count].Count, Children_POP[v].ObjectClone(Children_POP[v]));
                          //  rank_count++;
                        }
                    }
                }
            } //while (rank_count < Number_of_Chromosomes * 2);

            //string Algorithm = "NSGA-III";

     
                int l = 0;
                int insertion_level_solutions_count = 0;
                while (insertion_level_solutions_count + Ranked[l].Count < Number_of_Chromosomes)
                {
                    insertion_level_solutions_count += Ranked[l].Count;
                    l++; // the latest level for selecting by CD
                }
                // copy safe best levels to the next generations
                int direct_copied_count = 0;
                for (int Level = 0; Level < l; Level++)
                {
                    for (int i = 0; i < Ranked[Level].Count; i++)
                    {
                        Parents_POP[direct_copied_count] = Ranked[Level][i].ObjectClone(Ranked[Level][i]);
                        direct_copied_count++;
                    }
                }

            //--------------------------------------CD---------------------------------------------------
            if (Algorithm == "NSGA-II")
            {
                var sortedList_Profit = Ranked[l].OrderBy(si => si.Ch_Total_Profit).ToList();
                var sortedList_Fairness_Rate = Ranked[l].OrderBy(si => si.Ch_Total_Fairness_Rate).ToList();
                var sortedList_Energy_Cost = Ranked[l].OrderBy(si => si.Ch_Total_Energy_Cost).ToList();
                var sortedList_Duration = Ranked[l].OrderBy(si => si.Ch_Total_Duration).ToList();
                var sortedList_Delayed_Tasks_Duration = Ranked[l].OrderBy(si => si.Ch_Delayed_Tasks_Duration).ToList();

                //clear all CD values in candidate solutions to select in l-th level 
                for (int i = 0; i < sortedList_Profit.Count; i++)
                    sortedList_Profit[i].Ch_CD = 0;

                // Compute CD for each objective
                for (int i = 0; i < sortedList_Profit.Count - 1; i++)
                    sortedList_Profit[i].Ch_CD +=
                        (double)Math.Abs(sortedList_Profit[i].Ch_Total_Profit - sortedList_Profit[i + 1].Ch_Total_Profit) /
                       (sortedList_Profit[sortedList_Profit.Count - 1].Ch_Total_Profit - sortedList_Profit[0].Ch_Total_Profit);
                for (int i = 0; i < sortedList_Fairness_Rate.Count - 1; i++)
                    sortedList_Fairness_Rate[i].Ch_CD +=
                        (double)Math.Abs(sortedList_Fairness_Rate[i].Ch_Total_Fairness_Rate - sortedList_Fairness_Rate[i + 1].Ch_Total_Fairness_Rate) /
                       (sortedList_Fairness_Rate[sortedList_Fairness_Rate.Count - 1].Ch_Total_Fairness_Rate - sortedList_Fairness_Rate[0].Ch_Total_Fairness_Rate);
                for (int i = 0; i < sortedList_Energy_Cost.Count - 1; i++)
                    sortedList_Energy_Cost[i].Ch_CD +=
                        (double)Math.Abs(sortedList_Energy_Cost[i].Ch_Total_Energy_Cost - sortedList_Energy_Cost[i + 1].Ch_Total_Energy_Cost) /
                       (sortedList_Energy_Cost[sortedList_Energy_Cost.Count - 1].Ch_Total_Energy_Cost - sortedList_Energy_Cost[0].Ch_Total_Energy_Cost);
                for (int i = 0; i < sortedList_Duration.Count - 1; i++)
                    sortedList_Duration[i].Ch_CD +=
                        (double)Math.Abs(sortedList_Duration[i].Ch_Total_Duration - sortedList_Duration[i + 1].Ch_Total_Duration) /
                       (sortedList_Duration[sortedList_Duration.Count - 1].Ch_Total_Duration - sortedList_Duration[0].Ch_Total_Duration);
                for (int i = 0; i < sortedList_Delayed_Tasks_Duration.Count - 1; i++)
                    sortedList_Delayed_Tasks_Duration[i].Ch_CD +=
                        (double)Math.Abs(sortedList_Delayed_Tasks_Duration[i].Ch_Delayed_Tasks_Duration - sortedList_Delayed_Tasks_Duration[i + 1].Ch_Delayed_Tasks_Duration) /
                       (sortedList_Delayed_Tasks_Duration[sortedList_Delayed_Tasks_Duration.Count - 1].Ch_Delayed_Tasks_Duration - sortedList_Delayed_Tasks_Duration[0].Ch_Delayed_Tasks_Duration);

                //copy chromosomes with Beter (higher CD or located in a minor crowded region).
                var Final_Sorted = sortedList_Profit.OrderBy(si => si.Ch_CD).ToList();
                int counter_copy = Final_Sorted.Count - 1;

                while (direct_copied_count < Number_of_Chromosomes)
                {
                    Parents_POP[direct_copied_count] = Final_Sorted[counter_copy].ObjectClone(Final_Sorted[counter_copy]);
                    direct_copied_count++;
                    counter_copy--;
                }
            }
            //.................................NSGA-III............................................
            else if (Algorithm == "NSGA-III")
            {
                int M = 5, p = 3;
                int H = 210;
                int[] Z = new int[] { 0, 0, max_available_profit, 0, 0 }; // reference point

                var sortedList_Profit = Ranked[l].OrderBy(si => si.Ch_Total_Profit).ToList();

                for (int i = 0; i < sortedList_Profit.Count; i++) // maxi maximization as minimization for profit
                    sortedList_Profit[i].Ch_Total_Profit = max_available_profit - sortedList_Profit[i].Ch_Total_Profit;

                double min_profit = sortedList_Profit.Min(item => item.Ch_Total_Profit);

                for (int i = 0; i < sortedList_Profit.Count; i++) // maxi maximization as minimization for profit
                    sortedList_Profit[i].Ch_Total_Profit -= min_profit;

                //-------------Hyper-plane creation-----------------
                /*
                const double steps = 1.66666666;
                int parts = (int)(10 / steps);
                List <Hyper_weight_vector> Reference_points = new List<Hyper_weight_vector>();

                for (int pl1 = parts; pl1 >= 0; pl1--) // Number of Objectives
                {
                    for (int pl2 = pl1; pl2 >= 0; pl2--) // Number of Objectives
                    {
                        for (int pl3 = pl2; pl3 >= 0; pl3--) // Number of Objectives
                        {
                            for (int pl4 = pl3; pl4 >= 0; pl4--) // Number of Objectives
                            {
                                double B_l5 = (10 -(((parts - pl1) + (pl1 - pl2) + (pl2 - pl3) + (pl3 - pl4)) * (steps))) / 10;

                                Reference_points.Insert(Reference_points.Count,
                                    new Hyper_weight_vector(((parts - pl1) * steps) / 10, ((pl1 - pl2) * steps) / 10, 
                                    ((pl2 - pl3) * steps) / 10, ((pl3 - pl4) * steps) / 10,
                                    (B_l5)));
                            }
                        }
                    }
                }*/

                // Compute distances between points to hyper-plane, rank them and select best
                List<int>[] Classified_Reference_points = new List<int>[Reference_points.Count];
                List<double>[] Classified_Reference_points_distances = new List<double>[Reference_points.Count];
                for (int i = 0; i < Reference_points.Count; i++)
                {
                    Classified_Reference_points[i] = new List<int>();
                    Classified_Reference_points_distances[i] = new List<double>();
                }
                //Normalization
                var maxFairness = sortedList_Profit.Max(r => r.Ch_Total_Fairness_Rate);
                var minFairness = sortedList_Profit.Min(r => r.Ch_Total_Fairness_Rate);

                var maxEnergy = sortedList_Profit.Max(r => r.Ch_Total_Energy_Cost);
                var minEnergy = sortedList_Profit.Min(r => r.Ch_Total_Energy_Cost);

                var maxProfit = sortedList_Profit.Max(r => r.Ch_Total_Profit);
                var minProfit = sortedList_Profit.Min(r => r.Ch_Total_Profit);

                var maxDuration = sortedList_Profit.Max(r => r.Ch_Total_Duration);
                var minDuration = sortedList_Profit.Min(r => r.Ch_Total_Duration);

                var maxDelayed = sortedList_Profit.Max(r => r.Ch_Delayed_Tasks_Duration);
                var minDelayed = sortedList_Profit.Min(r => r.Ch_Delayed_Tasks_Duration);

                for (int i = 0; i < sortedList_Profit.Count; i++)
                {
                    sortedList_Profit[i].Ch_Total_Fairness_Rate = (sortedList_Profit[i].Ch_Total_Fairness_Rate - minFairness) / (maxFairness - minFairness);
                    sortedList_Profit[i].Ch_Total_Energy_Cost = (sortedList_Profit[i].Ch_Total_Energy_Cost - minEnergy) / (maxEnergy - minEnergy);
                    sortedList_Profit[i].Ch_Total_Profit = (sortedList_Profit[i].Ch_Total_Profit - minProfit) / (maxProfit - minProfit);
                    sortedList_Profit[i].Ch_Total_Duration = (sortedList_Profit[i].Ch_Total_Duration - minDuration) / (maxDuration - minDuration);
                    sortedList_Profit[i].Ch_Delayed_Tasks_Duration = (sortedList_Profit[i].Ch_Delayed_Tasks_Duration - minDelayed) / (maxDelayed - minDelayed);
                }

                //Compute distance in n-diminsional line and point
                for (int i = 0; i < sortedList_Profit.Count; i++)
                {
                    double min_vector_dis = double.MaxValue;
                    int vector_id = -1;
                    for (int j = 0; j < Reference_points.Count; j++)
                    {
                        double dist = DistanceFromPointToLine(
                            new Hyper_weight_vector(
                            sortedList_Profit[i].Ch_Total_Fairness_Rate,
                            sortedList_Profit[i].Ch_Total_Energy_Cost,
                            sortedList_Profit[i].Ch_Total_Profit,
                            sortedList_Profit[i].Ch_Total_Duration,
                            sortedList_Profit[i].Ch_Delayed_Tasks_Duration
                            ),
                            Reference_points[j]);
                        if (dist < min_vector_dis)
                        {
                            min_vector_dis = dist;
                            vector_id = j;
                        }
                    }
                    int index = 0;
                    while (index < Classified_Reference_points[vector_id].Count)
                    {
                        if (Classified_Reference_points_distances[vector_id][index] < min_vector_dis)
                            break;
                        index++;
                    }
                    Classified_Reference_points[vector_id].Insert(index, i);
                    Classified_Reference_points_distances[vector_id].Insert(index, min_vector_dis);
                }
                //Select 

                //copy chromosomes with Beter (higher CD or located in a minor crowded region).
                var Final_Sorted = sortedList_Profit.OrderBy(si => si.Ch_CD).ToList();
                int counter_copy = Final_Sorted.Count - 1;

                while (direct_copied_count < Number_of_Chromosomes)
                {
                    for (int i = 0; i < Reference_points.Count && direct_copied_count < Number_of_Chromosomes; i++)
                    {
                        if (Classified_Reference_points[i].Count > 0)
                        {
                            Parents_POP[direct_copied_count] = sortedList_Profit[Classified_Reference_points[i][Classified_Reference_points[i].Count - 1]].ObjectClone(sortedList_Profit[Classified_Reference_points[i][Classified_Reference_points[i].Count - 1]]);
                            Classified_Reference_points[i].RemoveAt(Classified_Reference_points[i].Count - 1);
                            Parents_POP[direct_copied_count].Compute_Fitness();

                            direct_copied_count++;
                            counter_copy--;
                        }
                    }
                }
                double distF = DistanceFromPointToLine(new Hyper_weight_vector(1, 1, 1, 1, 1),
                            new Hyper_weight_vector(5, 5, 5, 5, 5));

            }
            /*
            // Copy to parent and search if it is not repeatitive
            int items = 0;
            for (int vs = 0; vs < Number_of_Chromosomes; vs++)
            {
                for (int i = 0; i < Ranked[vs].Count; i++)
                {
                    bool Final_equality = false;

                    for (int ch = 0; ch < vs; ch++)
                    {
                        bool Diferences_in_parents = false;

                        if (
                             Children_POP[vs].Ch_Total_Energy_Cost == Ranked[vs][i].Ch_Total_Energy_Cost &&
                             Children_POP[vs].Ch_Delayed_Tasks_Duration == Ranked[vs][i].Ch_Delayed_Tasks_Duration &&
                             Children_POP[vs].Ch_Total_Fairness_Rate == Ranked[vs][i].Ch_Total_Fairness_Rate &&
                             Children_POP[vs].Ch_Total_Duration == Ranked[vs][i].Ch_Total_Duration &&
                             Parents_POP[ch].Ch_Total_Profit == Ranked[vs][i].Ch_Total_Profit)
                        {

                            for (int j = 0; j < Number_of_Robots; j++)
                            {
                                int RC1 = Parents_POP[ch].One_Path[j].Path_list.Count;
                                int RC2 = Ranked[vs][i].One_Path[j].Path_list.Count;
                                if (RC1 != RC2)
                                {
                                    Diferences_in_parents = true;
                                    break;
                                }
                                else
                                {
                                    for (int k = 0; k < RC1; k++)
                                    {
                                        if (Parents_POP[ch].One_Path[j].Path_list[k].id != Ranked[vs][i].One_Path[j].Path_list[k].id)
                                        {
                                            Diferences_in_parents = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Diferences_in_parents = true;
                        }
                        if (!Diferences_in_parents)
                        {
                            Final_equality = true;
                            return;
                        }
                    }
                    if (!Final_equality)
                    {
                        Parents_POP[items] = Ranked[vs][i].ObjectClone(Ranked[vs][i]);
                        items++;
                    }
                }
            }*/
        }
        //________________________________________________________________________________________________________________
        static public bool Dominates(Full_Chrmosome A, Full_Chrmosome B)
        {
            //A dominates B
            if (
                A.Ch_Total_Energy_Cost < B.Ch_Total_Energy_Cost &&
                A.Ch_Delayed_Tasks_Duration < B.Ch_Delayed_Tasks_Duration &&
                A.Ch_Total_Fairness_Rate < B.Ch_Total_Fairness_Rate &&
                A.Ch_Total_Duration < B.Ch_Total_Duration &&
                A.Ch_Total_Profit > B.Ch_Total_Profit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //________________________________________________________________________________________________________________
        public struct Hyper_weight_vector
        {
            public double B1; // Total_Fairness_Rate;
            public double B2; // Total_Energy_Cost;
            public double B3; // Total_Profit;
            public double B4; // Total_Duration;
            public double B5; // Delayed_Tasks_Duration;

            public Hyper_weight_vector(double F1, double F2, double F3, double F4, double F5)
            {
                B1 = F1;
                B2 = F2;
                B3 = F3;
                B4 = F4;
                B5 = F5;
            }
        }
        //________________________________________________________________________________________________________________
        public static double DistanceFromPointToLine(Hyper_weight_vector point, Hyper_weight_vector lineE)
        {
            // given a line based on two points, and a point away from the line,
            // find the perpendicular distance from the point to the line.
            // see http://mathworld.wolfram.com/Point-LineDistance2-Dimensional.html
            // for explanation and defination.
            // Point l1 = line.InitialPoint;
            // Point l2 = line.TerminalPoint;

            // return Math.Abs((l2.X - l1.X) * (l1.Y - point.Y) - (l1.X - point.X) * (l2.Y - l1.Y)) /
            // Math.Sqrt(Math.Pow(l2.X - l1.X, 2) + Math.Pow(l2.Y - l1.Y, 2));

            double LineS1 = 0, LineS2 = 0, LineS3 = 0, LineS4 = 0, LineS5 = 0;
            double LineE1 = lineE.B1, LineE2 = lineE.B2, LineE3 = lineE.B3, LineE4 = lineE.B4, LineE5 = lineE.B5;
            double Point1 = point.B1, Point2 = point.B2, Point3 = point.B3, Point4 = point.B4, Point5 = point.B5;

            double distance = Math.Abs((LineE1 - LineS1) * (LineS1 - Point1) *
                            (LineE2 - LineS2) * (LineS2 - Point2) *
                            (LineE3 - LineS3) * (LineS3 - Point3) *
                            (LineE4 - LineS4) * (LineS4 - Point4) *
                            (LineE5 - LineS5) * (LineS5 - Point5) 
                -(LineE2 - LineS2) * (LineS2 - Point2) * (LineS3 - Point3)* (LineS4 - Point4) * (LineS5 - Point5)) /
                    Math.Sqrt(Math.Pow(LineE1 - LineS1, 2) + Math.Pow(LineE2 - LineS2, 2) + Math.Pow(LineE3 - LineS3, 2) + Math.Pow(LineE4 - LineS4, 2) + Math.Pow(LineE5 - LineS5, 2));

            return Math.Sqrt(Math.Pow(LineE1 - Point1, 2) + Math.Pow(LineE2 - Point2, 2) + Math.Pow(LineE3 - Point3, 2)
                + Math.Pow(LineE4 - Point4, 2) + Math.Pow(LineE5 - Point5, 2));

            

            // return Math.Abs((lineE.X - lineS.X) * (lineS.Y - point.Y) - (lineS.X - point.X) * (lineE.Y - lineS.Y)) /
            //    Math.Sqrt(Math.Pow(lineE.X - lineS.X, 2) + Math.Pow(lineE.Y - lineS.Y, 2));
        }

        static public void Results_None_Dominated_Sort(List<double>[,] Objective_list, ref List<double>[] Ranked, int objective_count, int FilesLenght, int algorithm_no,int algorithm_count, bool full)
        {
            int Number_of_Solutions = Objective_list[0, 0].Count;
            int start = 0;

            if (!full)
            {
                start = algorithm_no * (Objective_list[0, 0].Count / algorithm_count);
                Number_of_Solutions = start + (Objective_list[0, 0].Count / algorithm_count); // devide to number of algorithms
            }

            int[,] Solution_Status = new int[FilesLenght, Number_of_Solutions];
            //List<Full_Chrmosome>[] Ranked = new List<Full_Chrmosome>[Number_of_Solutions];
            Ranked = new List<double>[FilesLenght];

            for (int f = 0; f < FilesLenght; f++)
            {
                for (int s = start; s < Number_of_Solutions; s++)
                {
                    Solution_Status[f, s] = -1;
                }
                Ranked[f] = new List<double>();
            }

            //int rank_count = 0;
            for (int f = 0; f < FilesLenght; f++)
            {
                int rank_count = 0;

                //    do
                //    {
                //search in parents
                for (int v = start; v < Number_of_Solutions; v++)
                {
                    bool dominated = false;

                    for (int vs = start; vs < Number_of_Solutions && Solution_Status[f, v] == -1; vs++)
                    {
                        //search in parents
                        if (v != vs && (Solution_Status[f, vs] == -1) &&
                            Objective_list[f, 0][vs] < Objective_list[f, 0][v] &&
                            Objective_list[f, 1][vs] < Objective_list[f, 1][v] &&
                            Objective_list[f, 2][vs] > Objective_list[f, 2][v] &&
                            Objective_list[f, 3][vs] < Objective_list[f, 3][v] &&
                            Objective_list[f, 4][vs] < Objective_list[f, 4][v])
                        {
                            dominated = true;
                            break;
                        }
                    }
                    //adding to the new list
                    if (Solution_Status[f, v] == -1 && !dominated)
                    {
                        bool added = false;
                        if (rank_count > 0)
                            for (int g = 0; g < rank_count; g++)
                            {
                                if (Objective_list[f, 0][v] >= Objective_list[f, 0][(int)Ranked[f][g]])
                                {
                                    Ranked[f].Insert(g, v);
                                    added = true;
                                    break;
                                }
                            }
                        else
                            Ranked[f].Insert(0, v);
                        
                        if(added==false)
                            Ranked[f].Insert(rank_count, v);

                        Solution_Status[f, v] = 1;
                        rank_count++;
                    }
                }
               // } while (rank_count < Number_of_Solutions);

            }
        }
        //________________________________________________________________________________________________________________
        static public List<Point>[] X_Y_Points_None_Dominated_Sort(double[,] Dataset, int Number_of_Robots, int Number_of_vertices)
        {
            Point[] Positions = new Point[Number_of_vertices];
            int[] Positions_Status = new int[Number_of_vertices];

            List<Point>[] Rank = new List<Point>[Number_of_vertices];

            for (int v = 1; v < Number_of_vertices; v++)
            {
                Rank[v - 1] = new List<Point>();
                Positions[v - 1] = new Point((int)Dataset[v, 1], (int)Dataset[v, 2]);
                Positions_Status[v] = -1;
            }

            for (int rank_count = 0; rank_count < Number_of_vertices; rank_count++)
            {
                for (int vr = 0; vr < Number_of_vertices; vr++)
                {
                    bool dominated = false;

                    for (int v = 0; v < Number_of_vertices && Positions_Status[vr] == -1; v++)
                    {
                        if (Positions[vr].X > Positions[v].X && Positions[vr].Y > Positions[v].Y
                            && (Positions_Status[v] == -1 || Positions_Status[v] == rank_count))
                        {
                            dominated = true;
                            break;
                        }
                    }
                    if (!dominated && Positions_Status[vr] == -1)
                    {
                        Positions_Status[vr] = rank_count;
                        Rank[rank_count].Add(new Point(Positions[vr].X, Positions[vr].Y));
                    }
                }
            }
            return (Rank);
        }
    }
    //________________________________________________________________________________________________________________

    public static class MultiDimensionalArrayExtensions
    {
        /// <summary>
        ///   Orders the two dimensional array by the provided key in the key selector.
        /// </summary>
        /// <typeparam name="T">The type of the source two-dimensional array.</typeparam>
        /// <param name="source">The source two-dimensional array.</param>
        /// <param name="keySelector">The selector to retrieve the column to sort on.</param>
        /// <returns>A new two dimensional array sorted on the key.</returns>
        public static T[,] OrderBy<T>(this T[,] source, Func<T[], T> keySelector)
        {
            return source.ConvertToSingleDimension().OrderBy(keySelector).ConvertToMultiDimensional();
        }
        /// <summary>
        ///   Orders the two dimensional array by the provided key in the key selector in descending order.
        /// </summary>
        /// <typeparam name="T">The type of the source two-dimensional array.</typeparam>
        /// <param name="source">The source two-dimensional array.</param>
        /// <param name="keySelector">The selector to retrieve the column to sort on.</param>
        /// <returns>A new two dimensional array sorted on the key.</returns>
        public static T[,] OrderByDescending<T>(this T[,] source, Func<T[], T> keySelector)
        {
            return source.ConvertToSingleDimension().
                OrderByDescending(keySelector).ConvertToMultiDimensional();
        }
        /// <summary>
        ///   Converts a two dimensional array to single dimensional array.
        /// </summary>
        /// <typeparam name="T">The type of the two dimensional array.</typeparam>
        /// <param name="source">The source two dimensional array.</param>
        /// <returns>The repackaged two dimensional array as a single dimension based on rows.</returns>
        private static IEnumerable<T[]> ConvertToSingleDimension<T>(this T[,] source)
        {
            T[] arRow;

            for (int row = 0; row < source.GetLength(0); ++row)
            {
                arRow = new T[source.GetLength(1)];

                for (int col = 0; col < source.GetLength(1); ++col)
                    arRow[col] = source[row, col];

                yield return arRow;
            }
        }
        /// <summary>
        ///   Converts a collection of rows from a two dimensional array back into a two dimensional array.
        /// </summary>
        /// <typeparam name="T">The type of the two dimensional array.</typeparam>
        /// <param name="source">The source collection of rows to convert.</param>
        /// <returns>The two dimensional array.</returns>
        private static T[,] ConvertToMultiDimensional<T>(this IEnumerable<T[]> source)
        {
            T[,] twoDimensional;
            T[][] arrayOfArray;
            int numberofColumns;

            arrayOfArray = source.ToArray();
            numberofColumns = (arrayOfArray.Length > 0) ? arrayOfArray[0].Length : 0;
            twoDimensional = new T[arrayOfArray.Length, numberofColumns];

            for (int row = 0; row < arrayOfArray.GetLength(0); ++row)
                for (int col = 0; col < numberofColumns; ++col)
                    twoDimensional[row, col] = arrayOfArray[row][col];

            return twoDimensional;
        }
    }
}
