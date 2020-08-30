using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TOOPTW
{
    public partial class OOPTW : Form
    {
        public OOPTW()
        {
            InitializeComponent();

            // A1:MTN A2:MTM
            // B1: SILS B2:MSA B#:MOLS

            dataGridView_CM.Columns.Add("A1.B1", "A1.B1");
            dataGridView_CM.Columns.Add("B1.A1", "B1.A1");

            dataGridView_CM.Columns.Add("A1.B2", "A1.B2");
            dataGridView_CM.Columns.Add("B2.A1", "B2.A1");

            dataGridView_CM.Columns.Add("A1.B3", "A1.B3");
            dataGridView_CM.Columns.Add("B3.A1", "B3.A1");

            dataGridView_CM.Columns.Add("A2.B1", "A2.B1");
            dataGridView_CM.Columns.Add("B1.A2", "B1.A2");

            dataGridView_CM.Columns.Add("A2.B2", "A2.B2");
            dataGridView_CM.Columns.Add("B2.A2", "B2.A2");

            dataGridView_CM.Columns.Add("A2.B3", "A2.B3");
            dataGridView_CM.Columns.Add("B3.A2", "B3.A2");

            dataGridView_CM.Columns.Add("A1.A2", "A1.A2");
            dataGridView_CM.Columns.Add("A2.A1", "A2.A1");

            dataGridView_CM.AutoResizeColumns();


            dataGridView_CM_AVG.Columns.Add("A1.B1", "A1.B1");
            dataGridView_CM_AVG.Columns.Add("B1.A1", "B1.A1");

            dataGridView_CM_AVG.Columns.Add("A1.B2", "A1.B2");
            dataGridView_CM_AVG.Columns.Add("B2.A1", "B2.A1");

            dataGridView_CM_AVG.Columns.Add("A1.B3", "A1.B3");
            dataGridView_CM_AVG.Columns.Add("B3.A1", "B3.A1");

            dataGridView_CM_AVG.Columns.Add("A2.B1", "A2.B1");
            dataGridView_CM_AVG.Columns.Add("B1.A2", "B1.A2");

            dataGridView_CM_AVG.Columns.Add("A2.B2", "A2.B2");
            dataGridView_CM_AVG.Columns.Add("B2.A2", "B2.A2");

            dataGridView_CM_AVG.Columns.Add("A2.B3", "A2.B3");
            dataGridView_CM_AVG.Columns.Add("B3.A2", "B3.A2");

            dataGridView_CM_AVG.Columns.Add("A1.A2", "A1.A2");
            dataGridView_CM_AVG.Columns.Add("A2.A1", "A2.A1");

            dataGridView_CM_AVG.AutoResizeColumns();

            dataGridView_data_result_AVG.Columns.Add("ID", "ID");
            dataGridView_data_result_AVG.Columns.Add("SAILS", "SAILS");
            dataGridView_data_result_AVG.Columns.Add("MSA", "MSA");
            dataGridView_data_result_AVG.Columns.Add("MOLS", "MOLS");
            dataGridView_data_result_AVG.Columns.Add("MTN", "MTN");
            dataGridView_data_result_AVG.Columns.Add("MTM", "MTM");
            dataGridView_data_result_AVG.AutoResizeColumns();

            dataGridView_data_result.Columns.Add("ID", "ID");
            dataGridView_data_result.Columns.Add("SAILS", "SAILS");
            dataGridView_data_result.Columns.Add("MSA", "MSA");
            dataGridView_data_result.Columns.Add("MOLS", "MOLS");
            dataGridView_data_result.Columns.Add("MTN", "MTN");
            dataGridView_data_result.Columns.Add("MTM", "MTM");

            dataGridView_data_result.Columns.Add("N1", "N1");
            dataGridView_data_result.Columns.Add("N2", "N2");
            dataGridView_data_result.AutoResizeColumns();

            dataGridView_HV_AVG.Columns.Add("ID", "ID");
            dataGridView_HV_AVG.Columns.Add("SAILS", "SAILS");
            dataGridView_HV_AVG.Columns.Add("MSA", "MSA");
            dataGridView_HV_AVG.Columns.Add("MOLS", "MOLS");
            dataGridView_HV_AVG.Columns.Add("MTN", "MTN");
            dataGridView_HV_AVG.Columns.Add("MTM", "MTM");
            dataGridView_HV_AVG.AutoResizeColumns();

            dataGridView_HV.Columns.Add("ID", "ID");
            dataGridView_HV.Columns.Add("SAILS", "SAILS");
            dataGridView_HV.Columns.Add("MSA", "MSA");
            dataGridView_HV.Columns.Add("MOLS", "MOLS");
            dataGridView_HV.Columns.Add("MTN", "MTN");
            dataGridView_HV.Columns.Add("MTM", "MTM");

            dataGridView_HV.Columns.Add("N1", "N1");
            dataGridView_HV.Columns.Add("N2", "N2");
            dataGridView_HV.AutoResizeColumns();

            dataGridView_population.Columns.Add("ID", "ID");
            dataGridView_population.Columns.Add("Leng", "En_Cost");
            dataGridView_population.Columns.Add("Dur", "Duration");
            dataGridView_population.Columns.Add("Prof", "Profit");
            dataGridView_population.Columns.Add("Fairness", "Fair");
            dataGridView_population.Columns.Add("Delayed", "Delayed");
            dataGridView_population.AutoResizeColumns();

            dataGridView_children.Columns.Add("ID", "ID");
            dataGridView_children.Columns.Add("Leng", "En_Cost");
            dataGridView_children.Columns.Add("Dur", "Duration");
            dataGridView_children.Columns.Add("Prof", "Profit");
            dataGridView_children.Columns.Add("Fairness", "Fair");
            dataGridView_children.Columns.Add("Delayed", "Delayed");
            dataGridView_children.AutoResizeColumns();

            dataGridView_parent_reserves.Columns.Add("ID", "ID");
            dataGridView_parent_reserves.Columns.Add("Duration", "Duration");
            dataGridView_parent_reserves.AutoResizeColumns();

            dataGridView_children_reserves.Columns.Add("ID", "ID");
            dataGridView_children_reserves.Columns.Add("Duration", "Duration");
            dataGridView_children_reserves.AutoResizeColumns();
        }

        double[,] Dataset = new double[500, 7];
        int Number_of_Robots = 1;
        int Number_of_vertices = 0;
        int Number_of_Chromosomes = 0;
        int Generation_count = 0;
        //int Execution_Time = 0;

        //NSGA-II
        Full_Chrmosome[] Parents;
        Full_Chrmosome[] Children;
        Full_Chrmosome Full_Vertices;
        int[] Robots_Max_Energy;
        int[] time_for_iteration = new int[3];

        //MOEA-D
        //Full_Chrmosome[] EP;
        Full_Chrmosome[] X;
        List<Full_Chrmosome> EP = new List<Full_Chrmosome>();

        const int N = 5; // Number of Subproblems
        const int T = 4; // Number of Weight Vector
        double[] Landa = new double[N];
        double[,] TempB = new double[T, T];
        int[,] B = new int[T, T];

        string EA_type;//  "MOEA-D" or "NSGA-II"
        string Error_log_file = "";

        string First_Series = "Profit";
        string Second_Series = "Duration";
        string Third_Series = "Energy";
        string Fourth_Series = "Fairness";
        string Fifth_Series = "Time";
        string folder_path = Directory.GetCurrentDirectory() + @"\Dataset\Righini\c_r_rc_100_100-2";
        string[] All_file_Paths;

        bool weorking_thread = false;
        bool Aoutorun_Flag = false;
        Thread Th_Learning;

        public SIMAB SIMAB_1;
        List<Sort.Hyper_weight_vector> Reference_points = new List<Sort.Hyper_weight_vector>();

        Bitmap a;
        Graphics G;
        //*******************************************************************************************************
        #region Algorithm
        //*******************************************************************************************************
        private void Initialization(bool randomly)
        {
            //-------------Hyper-plane creation-----------------
            const double steps = 1.66666666;
            int parts = (int)(10 / steps);

            for (int pl1 = parts; pl1 >= 0; pl1--) // Number of Objectives
            {
                for (int pl2 = pl1; pl2 >= 0; pl2--) // Number of Objectives
                {
                    for (int pl3 = pl2; pl3 >= 0; pl3--) // Number of Objectives
                    {
                        for (int pl4 = pl3; pl4 >= 0; pl4--) // Number of Objectives
                        {
                            double B_l5 = (10 - (((parts - pl1) + (pl1 - pl2) + (pl2 - pl3) + (pl3 - pl4)) * (steps))) / 10;

                            Reference_points.Insert(Reference_points.Count,
                               new Sort.Hyper_weight_vector(
                               (((parts - pl1) * steps) / 10),
                               (((pl1 - pl2) * steps) / 10),
                               (((pl2 - pl3) * steps) / 10),
                               (((pl3 - pl4) * steps) / 10),
                               B_l5));

                            //Math.Round((((parts - pl1) * steps) / 10) ,1),
                            //Math.Round((((pl1 - pl2) * steps) / 10), 1),
                            //Math.Round((((pl2 - pl3) * steps) / 10) ,1),
                            //Math.Round((((pl3 - pl4) * steps) / 10) ,1),
                            //Math.Round(B_l5, 1)));
                        }
                    }
                }
            }
            //-------------------------------------------------------------
            int array_chromosome_Size = trackBar_chromosome_count.Value;

            Parents = new Full_Chrmosome[array_chromosome_Size];
            Children = new Full_Chrmosome[array_chromosome_Size];

            Full_Vertices = new Full_Chrmosome(Number_of_Robots);

            //Full_Vertices.One_Path[0].Path_list.Insert(0, new Chromosome((int)Dataset[0, 0], new Point((int)Dataset[0, 1], (int)Dataset[0, 2]),
            //  (int)Dataset[0, 3], (int)Dataset[0, 4], (int)Dataset[0, 5], (int)Dataset[0, 6]));
            
            //MOEA-D
            X = new Full_Chrmosome[N];
            Landa[0] = 0.2; Landa[1] = 0.2; Landa[2] = 0.2;
            Landa[3] = 0.2; Landa[4] = 0.2;
            for (int i = 0; i < T; i++)
            {
                for (int j = 0; j < T; j++)
                {
                    TempB[i, j] = Math.Sqrt(Math.Pow(Landa[i] - Landa[j], 2));
                }
                for (int j = 0; j < T; j++)
                {
                    int index = 0;
                    for (int k = 0; k < T; k++)
                    {
                        if (TempB[i, j] > TempB[i, k])
                            index++;
                    }
                    B[i, j] = index;
                }
            }
         
            //Save Data in a chromosome 
            for (int v = 1; v <= Number_of_vertices; v++)
            {
                Full_Vertices.One_Path[0].Path_list.Insert(v - 1,
                 new Chromosome((int)Dataset[v, 0], new Point((int)Dataset[v, 1], (int)Dataset[v, 2]),
                 (int)Dataset[v, 3], (int)Dataset[v, 4], (int)Dataset[v, 5], (int)Dataset[v, 6]));
            }

            Robots_Max_Energy = new int[Convert.ToInt32(numericUpDown_Number_of_paths.Value)];
            for (int i = 0; i < numericUpDown_Number_of_paths.Value; i++)
            {
                Robots_Max_Energy[i] = Convert.ToInt32(textBox_maxtime.Text) * (i + 6);
            }

            // Insert Start and end vertecs MOEA-D
            for (int CN = 0; CN < N; CN++)
            {
                X[CN] = new Full_Chrmosome(Number_of_Robots);
                for (int r = 0; r < Number_of_Robots; r++)
                {
                    //parent
                    // Start from vertice #0
                    X[CN].One_Path[r].Path_list.Insert(0, new Chromosome((int)Dataset[0, 0], new Point((int)Dataset[0, 1], (int)Dataset[0, 2]),
                    (int)Dataset[0, 3], (int)Dataset[0, 4], (int)Dataset[0, 5], (int)Dataset[0, 6]));

                    // Come back to vertice #0
                    X[CN].One_Path[r].Path_list.Add(
                    new Chromosome((int)Dataset[0, 0], new Point((int)Dataset[0, 1], (int)Dataset[0, 2]),
                    (int)Dataset[0, 3], (int)Dataset[0, 4], (int)Dataset[0, 5], (int)Dataset[0, 6]));
                }
            }
            // Insert Start and end vertecs
            for (int CN = 0; CN < Number_of_Chromosomes; CN++)
            {
                Parents[CN] = new Full_Chrmosome(Number_of_Robots);
                Children[CN] = new Full_Chrmosome(Number_of_Robots);

                for (int r = 0; r < Number_of_Robots; r++)
                {
                    //parent
                    // Start from vertice #0
                    Parents[CN].One_Path[r].Path_list.Insert(0, new Chromosome((int)Dataset[0, 0], new Point((int)Dataset[0, 1], (int)Dataset[0, 2]),
                    (int)Dataset[0, 3], (int)Dataset[0, 4], (int)Dataset[0, 5], (int)Dataset[0, 6]));

                    // Come back to vertice #0
                    Parents[CN].One_Path[r].Path_list.Add(
                    new Chromosome((int)Dataset[0, 0], new Point((int)Dataset[0, 1], (int)Dataset[0, 2]),
                    (int)Dataset[0, 3], (int)Dataset[0, 4], (int)Dataset[0, 5], (int)Dataset[0, 6]));

                    //children.................................
                    // Start from vertice #0
                    Children[CN].One_Path[r].Path_list.Insert(0, new Chromosome((int)Dataset[0, 0], new Point((int)Dataset[0, 1], (int)Dataset[0, 2]),
                    (int)Dataset[0, 3], (int)Dataset[0, 4], (int)Dataset[0, 5], (int)Dataset[0, 6]));

                    // Come back to vertice #0
                    Children[CN].One_Path[r].Path_list.Add(
                    new Chromosome((int)Dataset[0, 0], new Point((int)Dataset[0, 1], (int)Dataset[0, 2]),
                    (int)Dataset[0, 3], (int)Dataset[0, 4], (int)Dataset[0, 5], (int)Dataset[0, 6]));
                }
            }
            //---------------------------------------------------------------------------------------------
            if (!randomly)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int v = 0; v < Number_of_Robots; v++)
                    {
                        X[i].One_Path[v].Tmax = (int)Dataset[0, 6];
                    }

                    //fill reserve list
                    for (int v = 1; v < Full_Vertices.One_Path[0].Path_list.Count; v++)
                    {
                        int insertion_indexX = X[i].Reserve_list.Path_list.Count;

                        X[i].Reserve_list.Path_list.Insert(insertion_indexX,
                               (Full_Vertices.One_Path[0].Path_list[v]));
                    }
                }
                //------------------------
                for (int i = 0; i < Number_of_Chromosomes; i++)
                {
                    for (int v = 0; v < Number_of_Robots; v++)
                    {
                      //  int selected_random_path = Random_Number.GetRandomNumber(0, Number_of_Robots - 1);
                        Parents[i].One_Path[v].Tmax = (int)Dataset[0, 6];
                    }

                    //fill reserve list
                    for (int v = 1; v < Full_Vertices.One_Path[0].Path_list.Count; v++)
                    {
                        int insertion_index = Parents[i].Reserve_list.Path_list.Count;
                        Parents[i].Reserve_list.Path_list.Insert(insertion_index,
                               (Full_Vertices.One_Path[0].Path_list[v]));
                    }
                }
                SIMAB Not_used = new SIMAB();
                for (int c1 = 0; c1 < N; c1++)
                {
                    Operators.ILS(X[c1], Number_of_Robots, ref Not_used, Robots_Max_Energy, 0);
                }
                //--------------------------
                for (int c1 = 0; c1 < Number_of_Chromosomes; c1++)
                {
                    Operators.ILS(Parents[c1], Number_of_Robots, ref Not_used, Robots_Max_Energy, 0);
                }
            }
            else //Random Initialization
            {
                // Assign tasks to paths randomly NSGA-II
                for (int CN = 0; CN < Number_of_Chromosomes; CN++)
                {
                    for (int v = 0; v < Number_of_Robots; v++)
                    {
                        Parents[CN].One_Path[v].Tmax = (int)Dataset[0, 6];
                    }

                    for (int v = 1; v <= Number_of_vertices; v++)
                    {
                        int selected_random_path = Random_Number.GetRandomNumber(0, Number_of_Robots - 1);
                        int insertion_index = Random_Number.GetRandomNumber(1, 
                            Parents[CN].One_Path[selected_random_path].Path_list.Count - 1);

                        // create robots paths per chromosome
                        Parents[CN].One_Path[selected_random_path].Path_list.Insert(insertion_index,
                            new Chromosome((int)Dataset[v, 0], new Point((int)Dataset[v, 1], (int)Dataset[v, 2]),
                            (int)Dataset[v, 3], (int)Dataset[v, 4], (int)Dataset[v, 5], (int)Dataset[v, 6]));

                        Parents[CN].Compute_Fitness();

                        if(Parents[CN].One_Path[selected_random_path].Path_list[insertion_index].id==0)
                        {
                            MessageBox.Show("eerroor");
                        }
                        // Check feasibility
                        if (Parents[CN].One_Path[selected_random_path].Total_Duration > Parents[CN].One_Path[selected_random_path].Tmax
                               || Parents[CN].One_Path[selected_random_path].Total_Energy_Cost > Robots_Max_Energy[selected_random_path])
                        {
                            // it was infeasible, so delete it
                            Parents[CN].One_Path[selected_random_path].Path_list.RemoveAt(insertion_index);
                            Parents[CN].Compute_Fitness();

                            bool allocate = false;
                            //// Serch to assign to another one
                            for (int r = 0; r < Number_of_Robots; r++)
                            {
                                insertion_index = Parents[CN].One_Path[r].Path_list.Count - 1;
                                Parents[CN].One_Path[r].Tmax = (int)Dataset[0, 6];

                                // create robots paths per chromosome
                                Parents[CN].One_Path[r].Path_list.Insert(insertion_index,
                                    new Chromosome((int)Dataset[v, 0], new Point((int)Dataset[v, 1], (int)Dataset[v, 2]),
                                    (int)Dataset[v, 3], (int)Dataset[v, 4], (int)Dataset[v, 5], (int)Dataset[v, 6]));
                                allocate = true;
                                Parents[CN].Compute_Fitness();

                                if (Parents[CN].One_Path[r].Total_Duration > Parents[CN].One_Path[r].Tmax
                                     || Parents[CN].One_Path[selected_random_path].Total_Energy_Cost > Robots_Max_Energy[selected_random_path])
                                {
                                    // it was infeasible, so delete it
                                    Parents[CN].One_Path[r].Path_list.RemoveAt(insertion_index);
                                    Parents[CN].Compute_Fitness();
                                    allocate = false;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (!allocate)
                            {
                                insertion_index = Parents[CN].Reserve_list.Path_list.Count;

                                Parents[CN].Reserve_list.Path_list.Insert(insertion_index,
                                   new Chromosome((int)Dataset[v, 0], new Point((int)Dataset[v, 1], (int)Dataset[v, 2]),
                                   (int)Dataset[v, 3], (int)Dataset[v, 4], (int)Dataset[v, 5], (int)Dataset[v, 6]));
                            }
                        }
                        // create maximum time per each path
                    }
                }
                
                // Assign tasks to paths randomly MOEA-D
                for (int CN = 0; CN < N; CN++)
                {
                    for (int v = 0; v < Number_of_Robots; v++)
                    {
                        X[CN].One_Path[v].Tmax = (int)Dataset[0, 6];
                    }

                    for (int v = 1; v <= Number_of_vertices; v++)
                    {
                        int selected_random_pathX = Random_Number.GetRandomNumber(0, Number_of_Robots - 1);
                        int insertion_indexX = X[CN].One_Path[selected_random_pathX].Path_list.Count - 1;

                        // create robots paths per chromosome MOEA-D
                        X[CN].One_Path[selected_random_pathX].Path_list.Insert(insertion_indexX,
                            new Chromosome((int)Dataset[v, 0], new Point((int)Dataset[v, 1], (int)Dataset[v, 2]),
                            (int)Dataset[v, 3], (int)Dataset[v, 4], (int)Dataset[v, 5], (int)Dataset[v, 6]));

                        X[CN].Compute_Fitness();

                        // Check feasibility
                        if (X[CN].One_Path[selected_random_pathX].Total_Duration > X[CN].One_Path[selected_random_pathX].Tmax
                               || X[CN].One_Path[selected_random_pathX].Total_Energy_Cost > Robots_Max_Energy[selected_random_pathX])
                        {
                            // it was infeasible, so delete it
                            X[CN].One_Path[selected_random_pathX].Path_list.RemoveAt(insertion_indexX);
                            X[CN].Compute_Fitness();

                            bool allocate = false;
                            //// Serch to assign to another one
                            for (int r = 0; r < Number_of_Robots; r++)
                            {
                                insertion_indexX = X[CN].One_Path[r].Path_list.Count - 1;
                                //X[CN].One_Path[r].Tmax = (int)Dataset[0, 6];

                                // create robots paths per chromosome
                                X[CN].One_Path[r].Path_list.Insert(insertion_indexX,
                                    new Chromosome((int)Dataset[v, 0], new Point((int)Dataset[v, 1], (int)Dataset[v, 2]),
                                    (int)Dataset[v, 3], (int)Dataset[v, 4], (int)Dataset[v, 5], (int)Dataset[v, 6]));
                                allocate = true;
                                X[CN].Compute_Fitness();

                                if (X[CN].One_Path[r].Total_Duration > X[CN].One_Path[r].Tmax
                                     || X[CN].One_Path[selected_random_pathX].Total_Energy_Cost > Robots_Max_Energy[selected_random_pathX])
                                {
                                    // it was infeasible, so delete it
                                    X[CN].One_Path[r].Path_list.RemoveAt(insertion_indexX);
                                    X[CN].Compute_Fitness();
                                    allocate = false;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (!allocate)
                            {
                                insertion_indexX = X[CN].Reserve_list.Path_list.Count;

                                X[CN].Reserve_list.Path_list.Insert(insertion_indexX,
                                   new Chromosome((int)Dataset[v, 0], new Point((int)Dataset[v, 1], (int)Dataset[v, 2]),
                                   (int)Dataset[v, 3], (int)Dataset[v, 4], (int)Dataset[v, 5], (int)Dataset[v, 6]));
                            }
                        }
                        // create maximum time per each path
                    }
                }
            }
        }
        //-------------------------------------------------------------------------------------------
        int iteration = 0;
        private void Evaluation(string EA_type)
        {
            dataGridView_population.Rows.Clear();
            dataGridView_children.Rows.Clear();
            int best_profit = 0;
            int best_delay = Int32.MaxValue;
            int best_energy = Int32.MaxValue;
            int best_fairness = Int32.MaxValue;
            int best_time = Int32.MaxValue;

            if (EA_type == "MOEA-D")
            {
                
                for (int CN = 0; CN < N; CN++)
                {
                    if (checkBox_Show_Chromosomes.Checked)
                    {
                        dataGridView_population.Rows.Add(new object[] { CN, X[CN].Ch_Total_Energy_Cost, X[CN].Ch_Total_Duration, X[CN].Ch_Total_Profit, X[CN].Ch_Total_Fairness_Rate, X[CN].Ch_Delayed_Tasks_Duration });
                    }
                }
                
                for (int CN = 0; CN < EP.Count; CN++)
                {
                    if (checkBox_Show_Chromosomes.Checked)
                    {
                        dataGridView_children.Rows.Add(new object[] { CN, EP[CN].Ch_Total_Energy_Cost, EP[CN].Ch_Total_Duration, EP[CN].Ch_Total_Profit, EP[CN].Ch_Total_Fairness_Rate, EP[CN].Ch_Delayed_Tasks_Duration });
                    }
                    //----------------------------------------------
                    if (EP[CN].Ch_Total_Profit > best_profit)
                    {
                        best_profit = (int)EP[CN].Ch_Total_Profit;
                    }
                    if (EP[CN].Ch_Delayed_Tasks_Duration < best_delay)
                    {
                        best_delay = (int)EP[CN].Ch_Delayed_Tasks_Duration;
                    }
                    if (EP[CN].Ch_Total_Energy_Cost < best_energy)
                    {
                        best_energy = (int)EP[CN].Ch_Total_Energy_Cost;
                    }
                    if (EP[CN].Ch_Total_Fairness_Rate < best_fairness)
                    {
                        best_fairness = (int)EP[CN].Ch_Total_Fairness_Rate;
                    }
                    if (EP[CN].Ch_Total_Duration < best_time)
                    {
                        best_time = (int)EP[CN].Ch_Total_Duration;
                    }
                }
            }
            else if (EA_type == "NSGA-II" || EA_type == "NSGA-III")
            {
                for (int CN = 0; CN < Number_of_Chromosomes; CN++)
                {

                    if (checkBox_Show_Chromosomes.Checked)
                    {
                        dataGridView_population.Rows.Add(new object[] { CN, Parents[CN].Ch_Total_Energy_Cost, Parents[CN].Ch_Total_Duration, Parents[CN].Ch_Total_Profit, Parents[CN].Ch_Total_Fairness_Rate, Parents[CN].Ch_Delayed_Tasks_Duration });
                        dataGridView_children.Rows.Add(new object[] { CN, Children[CN].Ch_Total_Energy_Cost, Children[CN].Ch_Total_Duration, Children[CN].Ch_Total_Profit, Children[CN].Ch_Total_Fairness_Rate, Children[CN].Ch_Delayed_Tasks_Duration });
                    }

                    if (Parents[CN].Ch_Total_Profit > best_profit)
                    {
                        best_profit = (int)Parents[CN].Ch_Total_Profit;
                    }
                    if (Parents[CN].Ch_Delayed_Tasks_Duration < best_delay)
                    {
                        best_delay = (int)Parents[CN].Ch_Delayed_Tasks_Duration;
                    }
                    if (Parents[CN].Ch_Total_Energy_Cost < best_energy)
                    {
                        best_energy = (int)Parents[CN].Ch_Total_Energy_Cost;
                    }
                    if (Parents[CN].Ch_Total_Fairness_Rate < best_fairness)
                    {
                        best_fairness = (int)Parents[CN].Ch_Total_Fairness_Rate;
                    }
                    if (Parents[CN].Ch_Total_Duration < best_time)
                    {
                        best_time = (int)Parents[CN].Ch_Total_Duration;
                    }
                }
            }

            chart1.Series[First_Series].Points.AddXY(iteration++, best_profit);
            chart1.Series[Second_Series].Points.AddXY(iteration++, best_delay);
            chart1.Series[Third_Series].Points.AddXY(iteration++, best_energy);
            chart1.Series[Fourth_Series].Points.AddXY(iteration++, best_fairness);
            chart1.Series[Fifth_Series].Points.AddXY(iteration++, best_time);

            label_best_result.Text = best_profit.ToString();

            dataGridView_population.AutoResizeColumns();
            dataGridView_children.AutoResizeColumns();
        }
        //-------------------------------------------------------------------------------------------
        private void Show_chromosome_inside(int parentindex, int pchildtindex,int X_index, int EP_index, string EA_type)
        {
            dataGridView_parent_Chromosome_detail.Columns.Clear();
            dataGridView_parent_Chromosome_detail.Rows.Clear();

            dataGridView_parent_reserves.Rows.Clear();
            dataGridView_children_reserves.Rows.Clear();

            dataGridView_Children_chromosome_detail.Columns.Clear();
            dataGridView_Children_chromosome_detail.Rows.Clear();

            if (EA_type == "MOEA-D")
            {
                int max_X = 0;
                int max_EP = 0;
                for (int r = 0; r < Number_of_Robots; r++)
                {
                    if (X[X_index].One_Path[r].Path_list.Count > max_X)
                        max_X = X[X_index].One_Path[r].Path_list.Count;
                }
                if (EP.Count > 0)
                    for (int r = 0; r < Number_of_Robots; r++)
                    {
                        if (EP[EP_index].One_Path[r].Path_list.Count > max_EP)
                            max_EP = EP[EP_index].One_Path[r].Path_list.Count;
                    }

                // create gridview column headers names
                for (int p = -1; p < max_X; p++)
                {
                    if (p == -1)
                        dataGridView_parent_Chromosome_detail.Columns.Add(p.ToString(), " ");
                    else
                        dataGridView_parent_Chromosome_detail.Columns.Add(p.ToString(), "T" + p.ToString());
                }
                for (int p = -1; p < max_EP; p++)
                {
                    if (p == -1)
                        dataGridView_Children_chromosome_detail.Columns.Add(p.ToString(), " ");
                    else
                        dataGridView_Children_chromosome_detail.Columns.Add(p.ToString(), "T" + p.ToString());
                }
                // try
                {
                    //show reserved list
                    for (int v = 0; v < X[X_index].Reserve_list.Path_list.Count; v++)
                    {
                        dataGridView_parent_reserves.Rows.Add();

                        dataGridView_parent_reserves.Rows[v].Cells[0].Value = X[X_index].Reserve_list.Path_list[v].id.ToString();
                        dataGridView_parent_reserves.Rows[v].Cells[1].Value = X[X_index].Reserve_list.Path_list[v].service_duration.ToString();
                    }
                    label_parent_reserve.Text = "Reserve: " + X[X_index].Reserve_list.Path_list.Count.ToString();

                    //show reserved list
                    if (EP.Count > 0)
                    {
                        for (int v = 0; v < EP[EP_index].Reserve_list.Path_list.Count; v++)
                        {
                            dataGridView_children_reserves.Rows.Add();

                            dataGridView_children_reserves.Rows[v].Cells[0].Value = EP[EP_index].Reserve_list.Path_list[v].id.ToString();
                            dataGridView_children_reserves.Rows[v].Cells[1].Value = EP[EP_index].Reserve_list.Path_list[v].service_duration.ToString();
                        }
                        label_child_reserve.Text = "Reserve: " + EP[EP_index].Reserve_list.Path_list.Count.ToString();
                    }
                }
              //  catch { toolStripLabel2.Text = "Error in showing Data in Grid!"; }

                int number_of_total_assignd_tasks_parents = 0;
                int number_of_total_assignd_tasks_children = 0;
                for (int r = 0; r < Number_of_Robots; r++)
                {
                    dataGridView_parent_Chromosome_detail.Rows.Add();

                    dataGridView_parent_Chromosome_detail.Rows[r].Cells[0].Value = "R" + r.ToString();

                    if (X[X_index].One_Path[r].Path_list.Count > 2)
                        number_of_total_assignd_tasks_parents += X[X_index].One_Path[r].Path_list.Count - 2;

                    for (int v = 0; v < X[X_index].One_Path[r].Path_list.Count; v++)
                    {
                        dataGridView_parent_Chromosome_detail.Rows[r].Cells[v + 1].Value = X[X_index].One_Path[r].Path_list[v].id.ToString();
                    }

                    //-----------------------------children---------------------------------
                    dataGridView_Children_chromosome_detail.Rows.Add();

                    dataGridView_Children_chromosome_detail.Rows[r].Cells[0].Value = "R" + r.ToString();

                    if (EP.Count > 0)
                    {
                        if (EP[EP_index].One_Path[r].Path_list.Count > 2)
                            number_of_total_assignd_tasks_children += EP[EP_index].One_Path[r].Path_list.Count - 2;

                        for (int v = 0; v < EP[EP_index].One_Path[r].Path_list.Count; v++)
                        {
                            dataGridView_Children_chromosome_detail.Rows[r].Cells[v + 1].Value = EP[EP_index].One_Path[r].Path_list[v].id.ToString();
                        }
                    }
                }

                label_number_of_total_tasks_parent.Text = "Task's Count: " + number_of_total_assignd_tasks_parents.ToString();
                label_number_of_total_tasks_children.Text = "Task's Count: " + number_of_total_assignd_tasks_children.ToString();

                //dataGridView_parent_Chromosome_detail.Rows[0].Selected = true;

            }
            else if (EA_type == "NSGA-II" || EA_type == "NSGA-III")
            {
                //get maximum path list
                int max_p = 0;
                int max_c = 0;
                for (int r = 0; r < Number_of_Robots; r++)
                {
                    if (Parents[parentindex].One_Path[r].Path_list.Count > max_p)
                        max_p = Parents[parentindex].One_Path[r].Path_list.Count;
                }
                for (int r = 0; r < Number_of_Robots; r++)
                {
                    if (Children[pchildtindex].One_Path[r].Path_list.Count > max_c)
                        max_c = Children[pchildtindex].One_Path[r].Path_list.Count;
                }
                // create gridview column headers names
                for (int p = -1; p < max_p; p++)
                {
                    if (p == -1)
                        dataGridView_parent_Chromosome_detail.Columns.Add(p.ToString(), " ");
                    else
                        dataGridView_parent_Chromosome_detail.Columns.Add(p.ToString(), "T" + p.ToString());
                }
                for (int p = -1; p < max_c; p++)
                {
                    if (p == -1)
                        dataGridView_Children_chromosome_detail.Columns.Add(p.ToString(), " ");
                    else
                        dataGridView_Children_chromosome_detail.Columns.Add(p.ToString(), "T" + p.ToString());
                }

                try
                {
                    //show reserved list
                    for (int v = 0; v < Parents[parentindex].Reserve_list.Path_list.Count; v++)
                    {
                        dataGridView_parent_reserves.Rows.Add();

                        dataGridView_parent_reserves.Rows[v].Cells[0].Value = Parents[parentindex].Reserve_list.Path_list[v].id.ToString();
                        dataGridView_parent_reserves.Rows[v].Cells[1].Value = Parents[parentindex].Reserve_list.Path_list[v].service_duration.ToString();
                    }
                    label_parent_reserve.Text = "Reserve: " + Parents[parentindex].Reserve_list.Path_list.Count.ToString();

                    //show reserved list
                    for (int v = 0; v < Children[pchildtindex].Reserve_list.Path_list.Count; v++)
                    {
                        dataGridView_children_reserves.Rows.Add();

                        dataGridView_children_reserves.Rows[v].Cells[0].Value = Children[pchildtindex].Reserve_list.Path_list[v].id.ToString();
                        dataGridView_children_reserves.Rows[v].Cells[1].Value = Children[pchildtindex].Reserve_list.Path_list[v].service_duration.ToString();
                    }
                    label_child_reserve.Text = "Reserve: " + Children[pchildtindex].Reserve_list.Path_list.Count.ToString();
                }
                catch { toolStripLabel2.Text = "Error in showing Data in Grid!"; }
                int number_of_total_assignd_tasks_parents = 0;
                int number_of_total_assignd_tasks_children = 0;
                for (int r = 0; r < Number_of_Robots; r++)
                {
                    dataGridView_parent_Chromosome_detail.Rows.Add();

                    dataGridView_parent_Chromosome_detail.Rows[r].Cells[0].Value = "R" + r.ToString();

                    if (Parents[parentindex].One_Path[r].Path_list.Count > 2)
                        number_of_total_assignd_tasks_parents += Parents[parentindex].One_Path[r].Path_list.Count - 2;

                    for (int v = 0; v < Parents[parentindex].One_Path[r].Path_list.Count; v++)
                    {
                        dataGridView_parent_Chromosome_detail.Rows[r].Cells[v + 1].Value = Parents[parentindex].One_Path[r].Path_list[v].id.ToString();
                    }

                    //-----------------------------children---------------------------------
                    dataGridView_Children_chromosome_detail.Rows.Add();

                    dataGridView_Children_chromosome_detail.Rows[r].Cells[0].Value = "R" + r.ToString();

                    if (Children[pchildtindex].One_Path[r].Path_list.Count > 2)
                        number_of_total_assignd_tasks_children += Children[pchildtindex].One_Path[r].Path_list.Count - 2;

                    for (int v = 0; v < Children[pchildtindex].One_Path[r].Path_list.Count; v++)
                    {
                        dataGridView_Children_chromosome_detail.Rows[r].Cells[v + 1].Value = Children[pchildtindex].One_Path[r].Path_list[v].id.ToString();
                    }
                }

                label_number_of_total_tasks_parent.Text = "Task's Count: " + number_of_total_assignd_tasks_parents.ToString();
                label_number_of_total_tasks_children.Text = "Task's Count: " + number_of_total_assignd_tasks_children.ToString();
                //dataGridView_Chromosome_detail.AutoResizeColumns();
            }
        }
        //*******************************************************************************************************
        #endregion Algorithm
        //*******************************************************************************************************
        #region Buttons and Form Control
        private void browsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Read_new_dataset(true, 0,false);
        }
        //-------------------------------------------------------------------------------------------
        private void Read_new_dataset(bool dialog, int file_number, bool execute)
        {
            dataGridView_captures.Rows.Clear();
            G.Clear(Color.White);

            openFileDialog1.InitialDirectory = All_file_Paths[file_number];
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            int free_space;
            string dataset_path = "";
            double profit_sum = 0;

            dataset_path = openFileDialog1.InitialDirectory;

            if (dialog)
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    dataset_path = openFileDialog1.FileName;
                }
            }

            string[] ReadParametrs = File.ReadAllLines(dataset_path);
            toolStripLabel1.Text = dataset_path.ToString();

            string[] GetName = dataset_path.Split('\\');
            string[] FName = GetName[GetName.Length - 1].Split('.');
            openFileDialog1.Title = FName[0].ToString();

            string[] Ini_Data = ReadParametrs[0].Split(' ');

            //----------Paoer #5 (TOPTW)-------------
            if (checkBox_TOPTW.Checked)
            {
                free_space = -1;
                do
                {
                    free_space++;
                } while (Ini_Data[free_space] == "");

                //Number_of_Robots = 4;// Convert.ToInt32(Ini_Data[1 + free_space]);
                //numericUpDown_Number_of_paths.Value = Number_of_Robots;

                Number_of_vertices = Convert.ToInt32(Ini_Data[2 + free_space]);
                TextBox_Number_of_vertices.Text = Number_of_vertices.ToString();

                for (int i = 2; i < ReadParametrs.Length; i++)
                {
                    string[] Row_Data = ReadParametrs[i].Split(' ');
                    free_space = 0;

                    if (Row_Data.Length > 3)
                    {
                        //do
                        //{

                        while (Row_Data[free_space] == "") free_space++; ;

                        //try
                        //{
                        this.dataGridView_captures.Rows.Add(Row_Data[0 + free_space], Row_Data[1 + free_space], Row_Data[2 + free_space],
                        Row_Data[3 + free_space], Row_Data[4 + free_space], Row_Data[Row_Data.Length - 2], Row_Data[Row_Data.Length - 1]);

                        Dataset[i - 2, 0] = Convert.ToDouble(Row_Data[0 + free_space]);  // vertex number
                        Dataset[i - 2, 1] = Convert.ToDouble(Row_Data[1 + free_space]);  // x coordinate
                        Dataset[i - 2, 2] = Convert.ToDouble(Row_Data[2 + free_space]);  // y coordinate
                        Dataset[i - 2, 3] = Convert.ToDouble(Row_Data[3 + free_space]);  // service duration or visiting time	
                        Dataset[i - 2, 4] = Convert.ToDouble(Row_Data[4 + free_space]);  // profit of the location
                        Dataset[i - 2, 5] = Convert.ToDouble(Row_Data[Row_Data.Length - 2]);  // opening of time window
                        Dataset[i - 2, 6] = Convert.ToDouble(Row_Data[Row_Data.Length - 1]);  // closing of time window

                        G.FillEllipse(Brushes.Blue, (int)Dataset[i - 2, 1] * 5, (int)Dataset[i - 2, 2] * 5, 10, 10);
                        //a.SetPixel((int) Dataset[i - 2, 1], (int) Dataset[i - 2, 2], Color.Blue);
                        profit_sum += Dataset[i - 2, 4];

                        //if(Dataset[i - 2, 0]==0 && i!= 2)
                        //    MessageBox.Show("Error in Dataset!");

                        //}
                        //catch
                        //{
                        //    MessageBox.Show("Error in Dataset!");
                        //}
                    }
                    labelMaximum_Profit.Text = profit_sum.ToString();
                }
                textBox_maxtime.Text = Dataset[0, 6].ToString();
            }
            //----------Paoer #4 (Ordered)-------------
            else
            {

                //Number_of_vertices = Convert.ToInt32(Ini_Data[2 + free_space]);
                //TextBox_Number_of_vertices.Text = Number_of_vertices.ToString();

                for (int i = 1; i < ReadParametrs.Length; i++)
                {
                    string[] Row_Data = ReadParametrs[i].Split(' ');

                    if (Row_Data.Length > 3)
                    {
                        this.dataGridView_captures.Rows.Add(Row_Data[0], Row_Data[1], Row_Data[2],
                        Row_Data[3], Row_Data[4], Row_Data[5], -1);

                        Dataset[i - 1, 0] = Convert.ToDouble(Row_Data[0]);  // vertex number
                        Dataset[i - 1, 1] = Convert.ToDouble(Row_Data[1]);  // x coordinate
                        Dataset[i - 1, 2] = Convert.ToDouble(Row_Data[2]);  // y coordinate
                        Dataset[i - 1, 3] = Convert.ToDouble(Row_Data[5]);  // service duration or visiting time	
                        Dataset[i - 1, 4] = Convert.ToDouble(Row_Data[4]);  // profit / repeat
                        Dataset[i - 1, 5] = Convert.ToDouble(Row_Data[3]);  // dependency
                        Dataset[i - 1, 6] = -1;  // --

                        G.FillEllipse(Brushes.Blue, (int)Dataset[i - 1, 1] * 10, (int)Dataset[i - 1, 2] * 10, 10, 10);
                    }
                }
            }
            button_run.Enabled = true;
            pictureBox1.Image = a;

        }
        //-------------------------------------------------------------------------------------------
        private void button_Exit_Click(object sender, EventArgs e)
        {
            if (weorking_thread)
                Th_Learning.Abort();
            Application.Exit();
        }
        //-------------------------------------------------------------------------------------------
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox2.Text = trackBar_chromosome_count.Value.ToString();
            Number_of_Chromosomes = Convert.ToInt32(textBox2.Text);
        }
        //-------------------------------------------------------------------------------------------
        private void trackBar_Iteration_Scroll(object sender, EventArgs e)
        {
            generation.Text = trackBar_Iteration.Value.ToString();
            Generation_count = Convert.ToInt32(generation.Text);
        }
        //-------------------------------------------------------------------------------------------
        private void numericUpDown_robots_ValueChanged(object sender, EventArgs e)
        {
            Number_of_Robots = (int)numericUpDown_robots.Value;
        }
        //-------------------------------------------------------------------------------------------
        private void button_run_Click(object sender, EventArgs e)
        {
            Aoutorun_Flag = false;
            Run();
        }
        //-------------------------------------------------------------------------------------------
        private void Run()
        {
            if (!weorking_thread)
            {
                time_for_iteration[0] = 10; //seconds
                time_for_iteration[1] = 3;
                time_for_iteration[2] = 5;
                Error_log_file = "";

                Th_Learning = new Thread(new ParameterizedThreadStart(new Action<object>((t) =>
                {
                    this.Invoke(new Action(() =>
                    {
                        progressBar_Run.Maximum = 3;
                    }));

                    for (int Change_robots_count = Number_of_Robots; Change_robots_count >= 2; Change_robots_count--)
                    {
                        for (int Time_changes = 0; Time_changes <= 0; Time_changes++)
                        {
                            this.Invoke(new Action(() =>
                            {
                                progressBar_time.Maximum = All_file_Paths.Length;
                            }));

                            for (int Dataset_number = 0; Dataset_number < All_file_Paths.Length; Dataset_number++)
                            {
                                this.Invoke(new Action(() =>
                                {
                                    Read_new_dataset(false, Dataset_number, true);

                                    SIMAB_1 = new SIMAB();
                                    button_save.Enabled = true;

                                    button_run.Text = "Abort";
                                    listBox1.Items.Clear();

                                    chart1.Series[First_Series].Points.Clear();
                                    chart1.Series[Second_Series].Points.Clear();
                                    chart1.Series[Third_Series].Points.Clear();
                                    chart1.Series[Fourth_Series].Points.Clear();
                                    chart1.Series[Fifth_Series].Points.Clear();

                                    Initialization(true); //true is random (NSGA-II, MOEA-D)  //$$$$$

                                    iteration = trackBar_Iteration.Value;
                                    progressBar_time.Value = Dataset_number;
                                    progressBar_Run.Value = (4 - Change_robots_count);
                                }));

                                int Next_Operator = 0;
                                weorking_thread = true;

                                //This is just for pure ILS to copy parents to children purely
                                for (int c1 = 0; c1 < Number_of_Chromosomes; c1++)
                                {
                                    Children[c1] = Parents[c1].ObjectClone(Parents[c1]);
                                }
                                var now = System.DateTime.Now;
                                now = now.AddSeconds(time_for_iteration[Time_changes]);

                                this.Invoke(new Action(() =>
                                {
                                    EA_type = comboBox_EA_algorithm.Text;// "NSGA-II";// "MOEA-D"; //
                                }));

                                //EA_type = "NSGA-III";

                                if (EA_type == "MOEA-D")
                                {
                                    int i = 0;
                                    //"MOEA-D"
                                    while (System.DateTime.Now <= now)
                                    {
                                        Next_Operator = 12;// SIMAB_1.Compute_SIMAB(i); //$$$$$
                                        int HF = 1;// (int)Math.Ceiling(Convert.ToDouble(Heat_factor));

                                        Operators.LLH_Selection(ref Parents, ref Children, ref X, ref EP, Full_Vertices, ref SIMAB_1, Robots_Max_Energy,
                                          Next_Operator, i, Number_of_Chromosomes, Change_robots_count, HF, EA_type, T, B);

                                        //evaluation
                                        this.Invoke(new Action(() =>
                                        {
                                            Evaluation(EA_type);

                                            listBox1.Items.Add(Next_Operator.ToString());
                                            listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                        }));
                                        i++;
                                    }

                                    this.Invoke(new Action(() =>
                                    {
                                        if (checkBox_Show_Chromosomes.Checked)
                                        {
                                            dataGridView_population.SelectedRows[0].Selected = true;
                                            Show_chromosome_inside(-1, -1, dataGridView_population.SelectedRows[0].Index, 0, EA_type);
                                        }

                                        if (checkBox_Save.Checked)
                                            Save_Results(Change_robots_count, Time_changes, EA_type);
                                    }));
                                }
                                else if (EA_type == "NSGA-II" || EA_type == "NSGA-III")
                                {
                                    //"NSGA-II"
                                    for (int iter = 1, Heat_factor = iteration; iter < iteration && System.DateTime.Now <= now; iter++, Heat_factor--)
                                    {
                                        Next_Operator = 15;// SIMAB_1.Compute_SIMAB(iter);
                                        int HF = 1;// (int)Math.Ceiling(Convert.ToDouble(Heat_factor));

                                        Operators.LLH_Selection(ref Parents, ref Children, ref X, ref EP, Full_Vertices, ref SIMAB_1, Robots_Max_Energy,
                                                Next_Operator, iter, Number_of_Chromosomes, Change_robots_count, HF, EA_type, -1, B);

                                        //evaluation
                                        this.Invoke(new Action(() =>
                                        {
                                            Evaluation(EA_type);
                                        }));

                                        int max_available_profit = 0;
                                        //-----------------------------------------------
                                        this.Invoke(new Action(() =>
                                        {
                                            listBox1.Items.Add(Next_Operator.ToString());
                                            listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                            max_available_profit = Convert.ToInt32(labelMaximum_Profit.Text);
                                        }));

                                        Sort.None_Dominated_Sort(ref Parents, Children, Number_of_Chromosomes, Change_robots_count, max_available_profit, Reference_points, EA_type);
                                    }

                                    this.Invoke(new Action(() =>
                                    {
                                        if (checkBox_Show_Chromosomes.Checked)
                                        {
                                            dataGridView_population.SelectedRows[0].Selected = true;
                                            Show_chromosome_inside(dataGridView_population.SelectedRows[0].Index, 0, -1, -1, EA_type);
                                        }

                                        if (checkBox_Save.Checked)
                                            Save_Results(Change_robots_count, Time_changes, EA_type);
                                    }));

                                }

                                this.Invoke(new Action(() =>
                                    {
                                        Evaluation(EA_type);

                                        if (!Aoutorun_Flag)
                                        {
                                            weorking_thread = false;
                                            button_run.Text = "Run";
                                            Th_Learning.Abort();
                                        }

                                        numericUpDown_Number_of_paths.Value = Change_robots_count;
                                    }));
                            }
                        }
                    }
                    this.Invoke(new Action(() =>
                   {
                       progressBar_Run.Value = 3;
                       progressBar_time.Maximum = All_file_Paths.Length;
                       weorking_thread = false;
                       button_run.Text = "Finished.";
                   }));
                })));
                Th_Learning.SetApartmentState(ApartmentState.STA);
                Th_Learning.Start();
            }
            else
            {
                weorking_thread = false;
                button_run.Text = "Run";
                Th_Learning.Abort();
            }
        }
        //-------------------------------------------------------------------------------------------
        private void OOPTW_Load(object sender, EventArgs e)
        {
            textBox2.Text = trackBar_chromosome_count.Value.ToString();
            Number_of_Chromosomes = Convert.ToInt32(textBox2.Text);
            Number_of_Robots = (int)numericUpDown_robots.Value;

            generation.Text = trackBar_Iteration.Value.ToString();
            Generation_count = Convert.ToInt32(generation.Text);
            a = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            G = Graphics.FromImage(a);

            this.dataGridView_parent_Chromosome_detail.ClipboardCopyMode =
              DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

            chart1.Series.Add(First_Series);
            chart1.Series.Add(Second_Series);
            chart1.Series.Add(Third_Series);
            chart1.Series.Add(Fourth_Series);
            chart1.Series.Add(Fifth_Series);

            chart1.Series[First_Series].Font = new System.Drawing.Font("Times New Roman", 12);
            chart1.Series[Second_Series].Font = new System.Drawing.Font("Times New Roman", 12);
            chart1.Series[Third_Series].Font = new System.Drawing.Font("Times New Roman", 12);
            chart1.Series[Fourth_Series].Font = new System.Drawing.Font("Times New Roman", 12);
            chart1.Series[Fifth_Series].Font = new System.Drawing.Font("Times New Roman", 12);

            chart1.Series[First_Series].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chart1.Series[Second_Series].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chart1.Series[Third_Series].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chart1.Series[Fourth_Series].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chart1.Series[Fifth_Series].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;

            chart1.Series[First_Series].BorderWidth = 2;
            chart1.Series[Second_Series].BorderWidth = 2;
            chart1.Series[Third_Series].BorderWidth = 2;
            chart1.Series[Fourth_Series].BorderWidth = 2;
            chart1.Series[Fifth_Series].BorderWidth = 2;

            All_file_Paths = Directory.GetFiles(folder_path, "*.txt", SearchOption.AllDirectories);
            toolStripLabel3.Text = All_file_Paths.Length.ToString(); 

            Read_new_dataset(false, 0, false);
        }
        #endregion Form Control
        //-------------------------------------------------------------------------------------------
        private void dataGridView_population_SelectionChanged(object sender, EventArgs e)
        {
         //   try
            {
                if (EA_type == "MOEA-D")
                {
                    if (dataGridView_population.SelectedRows.Count > 0)
                        Show_chromosome_inside(-1, -1, dataGridView_population.SelectedRows[0].Index, 0, EA_type);
                }
                else if (EA_type == "NSGA-II" || EA_type == "NSGA-III")
                {
                    if (dataGridView_population.SelectedRows.Count > 0)
                        Show_chromosome_inside(dataGridView_population.SelectedRows[0].Index, 0, -1, -1, EA_type);
                }
            }
          //  catch { }
        }
        //-------------------------------------------------------------------------------------------
        private void dataGridView_Chromosome_detail_SelectionChanged(object sender, EventArgs e)
        {
            
         //   try
            {

                if (EA_type == "MOEA-D" && !weorking_thread)
                {
                    if (dataGridView_parent_Chromosome_detail.SelectedRows.Count > 0)
                    {
                        int D_Se = dataGridView_parent_Chromosome_detail.SelectedRows[0].Index;

                        label_Profit_parent.Text = "Profit: " + X[dataGridView_population.SelectedRows[0].Index].One_Path[D_Se].Total_Profit.ToString();
                        label_Cost_parent.Text = "Energy: " + X[dataGridView_population.SelectedRows[0].Index].One_Path[D_Se].Total_Energy_Cost.ToString();
                        label_duration_parent.Text = "Duration: " + X[dataGridView_population.SelectedRows[0].Index].One_Path[D_Se].Total_Duration.ToString();
                        label_Fairness.Text = "Fairness: " + X[dataGridView_population.SelectedRows[0].Index].Ch_Total_Fairness_Rate.ToString();
                    }
                }
                else if (EA_type == "NSGA-II" || EA_type == "NSGA-III")
                {
                    if (dataGridView_parent_Chromosome_detail.SelectedRows.Count > 0)
                    {
                        label_Profit_parent.Text = "Profit: " + Parents[dataGridView_population.SelectedRows[0].Index].One_Path[dataGridView_parent_Chromosome_detail.SelectedRows[0].Index].Total_Profit.ToString();
                        label_Cost_parent.Text = "Energy: " + Parents[dataGridView_population.SelectedRows[0].Index].One_Path[dataGridView_parent_Chromosome_detail.SelectedRows[0].Index].Total_Energy_Cost.ToString();
                        label_duration_parent.Text = "Duration: " + Parents[dataGridView_population.SelectedRows[0].Index].One_Path[dataGridView_parent_Chromosome_detail.SelectedRows[0].Index].Total_Duration.ToString();
                        label_Fairness.Text = "Fairness: " + Parents[dataGridView_population.SelectedRows[0].Index].Ch_Total_Fairness_Rate.ToString();
                    }
                }
            }
        //   catch { }
        }
        //-------------------------------------------------------------------------------------------
        private void dataGridView_children_SelectionChanged(object sender, EventArgs e)
        {
            if (EA_type == "MOEA-D")
            {
                if (dataGridView_children.SelectedRows.Count > 0)
                    Show_chromosome_inside(-1, -1, 0, dataGridView_children.SelectedRows[0].Index, EA_type);
            }
            else if (EA_type == "NSGA-II" || EA_type == "NSGA-III")
            {
                if (dataGridView_children.SelectedRows.Count > 0)
                    Show_chromosome_inside(0, dataGridView_children.SelectedRows[0].Index, -1, -1, EA_type);
            }
        }
        //-------------------------------------------------------------------------------------------
        private void dataGridView_Children_chromosome_detail_SelectionChanged(object sender, EventArgs e)
        {
            //    try
            {
                if (EA_type == "MOEA-D")
                {
                    if (dataGridView_children.SelectedRows.Count > 0 && dataGridView_Children_chromosome_detail.SelectedRows.Count > 0)
                    {
                        label_Profit_children.Text = "Profit: " + EP[dataGridView_children.SelectedRows[0].Index].One_Path[dataGridView_Children_chromosome_detail.SelectedRows[0].Index].Total_Profit.ToString();
                        label_Cost_children.Text = "Cost: " + EP[dataGridView_children.SelectedRows[0].Index].One_Path[dataGridView_Children_chromosome_detail.SelectedRows[0].Index].Total_Energy_Cost.ToString();
                        label_duration_children.Text = "Duration: " + EP[dataGridView_children.SelectedRows[0].Index].One_Path[dataGridView_Children_chromosome_detail.SelectedRows[0].Index].Total_Duration.ToString();
                    }

                }
                else if (EA_type == "NSGA-II" || EA_type == "NSGA-III")
                {
                    if (dataGridView_children.SelectedRows.Count > 0 && dataGridView_Children_chromosome_detail.SelectedRows.Count > 0)
                    {
                        label_Profit_children.Text = "Profit: " + Children[dataGridView_children.SelectedRows[0].Index].One_Path[dataGridView_Children_chromosome_detail.SelectedRows[0].Index].Total_Profit.ToString();
                        label_Cost_children.Text = "Cost: " + Children[dataGridView_children.SelectedRows[0].Index].One_Path[dataGridView_Children_chromosome_detail.SelectedRows[0].Index].Total_Energy_Cost.ToString();
                        label_duration_children.Text = "Duration: " + Children[dataGridView_children.SelectedRows[0].Index].One_Path[dataGridView_Children_chromosome_detail.SelectedRows[0].Index].Total_Duration.ToString();
                    }
                }
            }
         //  catch { }
        }
        //-------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            Initialization(false);
            /*
            Point P1 = new Point(2, 2);
            Point P2= new Point(1, 1);
            Point P3= new Point(0, 2);
            double rotate_time = 0;
            const double Rad2Deg = 180.0 / Math.PI;

            double a = Math.Sqrt(Math.Pow((P1.X - P2.X), 2) + Math.Pow((P1.Y - P2.Y), 2));
            double b = Math.Sqrt(Math.Pow((P2.X - P3.X), 2) + Math.Pow((P2.Y - P3.Y), 2));
            double c = Math.Sqrt(Math.Pow((P1.X - P3.X), 2) + Math.Pow((P1.Y - P3.Y), 2));

            //double A = Math.Acos(((b * b) + (c * c) - (a * a)) / (2 * b * c));
            //double B = Math.Acos(((a * a) + (c * c) - (b * b)) / (2 * a * c));
            double C = Math.Acos(((a * a) + (b * b) - (c * c)) / (2 * a * b));

            if(Double.IsNaN(C))
                C = 0;
            rotate_time = C * Rad2Deg;

         
      

            label_Number_of_paths.Text = rotate_time.ToString();*/
            /*
            openFileDialog1.InitialDirectory = "C:\\Users\\Saeed\\Desktop\\Implementation\\Dataset\\Result\\r205-m2.txt";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            int free_space;
            string dataset_path = "";
            double profit_sum = 0;

            dataset_path = openFileDialog1.InitialDirectory;


            string[] ReadParametrs = File.ReadAllLines(dataset_path);
            toolStripLabel1.Text = dataset_path.ToString();

            for (int i = 0; i < ReadParametrs.Length; i++)
            {
                Parents[0].One_Path[i].Path_list.Clear();

                string[] Row_Data = ReadParametrs[i].Split('>');
                for (int j = 0; j < Row_Data.Length; j++)
                {
                    int v = Convert.ToInt32(Row_Data[j]);
                    Parents[0].One_Path[i].Path_list.Insert(j,
                    new Chromosome((int)Dataset[v, 0], new Point((int)Dataset[v, 1], (int)Dataset[v, 2]),
                    (int)Dataset[v, 3], (int)Dataset[v, 4], (int)Dataset[v, 5], (int)Dataset[v, 6]));

                }
            }
            Parents[0].Reserve_list.Path_list.Clear();

            //fix reserve list
            for (int v = 1; v < Full_Vertices.One_Path[0].Path_list.Count; v++)
            {
                bool found_ch1 = false;

                for (int i = 0; i < Number_of_Robots; i++)
                {
                    int items_count = Parents[0].One_Path[i].Path_list.Count - 1;
                    for (int j = 1; j < items_count; j++)
                    {
                        if (Parents[0].One_Path[i].Path_list[j].id == Full_Vertices.One_Path[0].Path_list[v].id)
                        {
                            found_ch1 = true;
                            break;
                        }
                    }
                }
                if (!found_ch1)
                {
                    int insertion_index = Parents[0].Reserve_list.Path_list.Count;

                    Parents[0].Reserve_list.Path_list.Insert(insertion_index,
                       (Full_Vertices.One_Path[0].Path_list[v]));
                }
            }
            Evaluation();
*/
            //**************************************************************************

            //List<double> list = new List<double> { 1, 1, 1, 1, 1};
            //    Normalizer.Normal(ref list);

            //for (int i = 0; i < 1000; i++)
            //{
            //    Roulette r = new Roulette(list.ToArray());
            //    int z = r.spin();
            //    listBox1.Items.Add(z.ToString());
            //}

            //**************************************************************************
            List<Point>[] R1 = new List<Point>[Number_of_vertices];

            for (int vs = Number_of_Chromosomes - 1; vs > 1; vs--)
            {
                Parents[vs].Ch_Total_Energy_Cost = vs * 100;
                Parents[vs].Ch_Total_Profit = vs * 500;

                Children[vs].Ch_Total_Energy_Cost = vs * 1;
                Children[vs].Ch_Total_Profit = vs * 10000 + 1;

            }
            //Sort.None_Dominated_Sort(ref Parents, Children, Number_of_Chromosomes, Number_of_Robots);

            //for (int c1 = 0; c1 < Number_of_Chromosomes; c1++)
            //{

            //    //Operators.Swap(Children[c1], Number_of_Robots, 5);
            //    Operators.Reverse(Children[c1], Number_of_Robots, 5);
            //}
            //Evaluation();

            R1 = Sort.X_Y_Points_None_Dominated_Sort(Dataset, Number_of_Robots, Number_of_vertices);

            for (int i = 0; i < R1[0].Count; i++)
            {
                G.FillEllipse(Brushes.Red, R1[0][i].X * 5, R1[0][i].Y * 5, 10, 10);

            }
            for (int i = 0; i < R1[1].Count; i++)
            {
                G.FillEllipse(Brushes.Green, R1[1][i].X * 5, R1[1][i].Y * 5, 10, 10);
            }
            for (int i = 0; i < R1[2].Count; i++)
            {
                G.FillEllipse(Brushes.Orange, R1[2][i].X * 5, R1[2][i].Y * 5, 10, 10);
            }
            for (int i = 0; i < R1[3].Count; i++)
            {
                G.FillEllipse(Brushes.Aqua, R1[3][i].X * 5, R1[3][i].Y * 5, 10, 10);
            }
            for (int i = 0; i < R1[4].Count; i++)
            {
                G.FillEllipse(Brushes.Black, R1[4][i].X * 5, R1[4][i].Y * 5, 10, 10);
            }
        }
        //-------------------------------------------------------------------------------------------
        private void numericUpDown_Number_of_paths_ValueChanged(object sender, EventArgs e)
        {
            Number_of_Robots = (int) numericUpDown_Number_of_paths.Value;
        }
        //-------------------------------------------------------------------------------------------
        private void button_save_Click(object sender, EventArgs e)
        {
            Aoutorun_Flag = true;
            Run();

        }
        //-------------------------------------------------------------------------------------------
        private void Save_Results(int robocount, int Time_changes, string MO_Algorithm)
        {
            if (MO_Algorithm == "NSGA-II" || MO_Algorithm == "NSGA-III")
            {
                string path = Directory.GetCurrentDirectory();
                string[] lines = new string[Number_of_Chromosomes];

                for (int CN = 0; CN < Number_of_Chromosomes; CN++)
                {
                    lines[CN] =
                        Parents[CN].Ch_Total_Energy_Cost.ToString() + " " +
                        Parents[CN].Ch_Total_Duration.ToString() + " " +
                        Parents[CN].Ch_Total_Profit.ToString() + " " +
                        Parents[CN].Ch_Total_Fairness_Rate.ToString() + " " +
                        Parents[CN].Ch_Delayed_Tasks_Duration.ToString()
                        ;
                }
                using (StreamWriter outputFile =
                    new StreamWriter(path + "\\Results\\RC" + robocount.ToString() + "\\T" + Time_changes.ToString() +
                    "\\" + @openFileDialog1.Title + "+" + numericUpDown_Number_of_paths.Value.ToString()
                    + "+" + time_for_iteration[Time_changes].ToString() + ".txt"))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }
            }
            if (MO_Algorithm == "MOEA-D")
            {
                int line_counts = Number_of_Chromosomes;
                if (EP.Count< Number_of_Chromosomes)
                {
                    listBox_errors.Items.Add(@openFileDialog1.Title.ToString());
                    line_counts = EP.Count;
                    Error_log_file += @openFileDialog1.Title.ToString() + Environment.NewLine;

                    using (StreamWriter outputFile =
                    new StreamWriter(Directory.GetCurrentDirectory() + "\\Results\\" + "Error_Log.txt"))
                    {
                        outputFile.WriteLine(Error_log_file);
                    }
                }
                string path = Directory.GetCurrentDirectory();
                string[] lines = new string[line_counts];

                for (int CN = 0; CN < line_counts; CN++)
                {
                    lines[CN] =
                        EP[CN].Ch_Total_Energy_Cost.ToString() + " " +
                        EP[CN].Ch_Total_Duration.ToString() + " " +
                        EP[CN].Ch_Total_Profit.ToString() + " " +
                        EP[CN].Ch_Total_Fairness_Rate.ToString() + " " +
                        EP[CN].Ch_Delayed_Tasks_Duration.ToString()
                        ;
                }
                using (StreamWriter outputFile =
                    new StreamWriter(path + "\\Results\\RC" + robocount.ToString() + "\\T" + Time_changes.ToString() +
                    "\\" + @openFileDialog1.Title + "+" + numericUpDown_Number_of_paths.Value.ToString()
                    + "+" + time_for_iteration[Time_changes].ToString() + ".txt"))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }
            }
        }
        //-------------------------------------------------------------------------------------------
        private void browsFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

            folderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            folderBrowserDialog1.SelectedPath = folder_path;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folder_path = folderBrowserDialog1.SelectedPath;

                All_file_Paths = Directory.GetFiles(folder_path, "*.txt", SearchOption.AllDirectories);
                toolStripLabel3.Text = All_file_Paths.Length.ToString();
                Read_new_dataset(false, 0, false);

            }
        }
        //-------------------------------------------------------------------------------------------
        private void button_Results_read_Click(object sender, EventArgs e)
        {
            dataGridView_population.Rows.Clear();

            int objective_count = 5;
            int algorithm_count = 7;

            string[] TotalAlgorithms_PathC1 = new string[algorithm_count];
            string rc = "RC3";

            TotalAlgorithms_PathC1[0] = Directory.GetCurrentDirectory() + "\\Algorithms\\New\\MOLS-MOEA-D\\" + rc + "\\T0\\";
            TotalAlgorithms_PathC1[1] = Directory.GetCurrentDirectory() + "\\Algorithms\\New\\MOMA-MOEA-D\\" + rc + "\\T0\\";
            TotalAlgorithms_PathC1[2] = Directory.GetCurrentDirectory() + "\\Algorithms\\New\\MO-MHTA-MOEA-D\\" + rc + "\\T0\\";
            TotalAlgorithms_PathC1[3] = Directory.GetCurrentDirectory() + "\\Algorithms\\New\\MO-MHTA-NSGA-II\\" + rc + "\\T0\\";
            TotalAlgorithms_PathC1[4] = Directory.GetCurrentDirectory() + "\\Algorithms\\New\\MO-MHTA-NSGA-III\\" + rc + "\\T0\\";
            TotalAlgorithms_PathC1[5] = Directory.GetCurrentDirectory() + "\\Algorithms\\New\\NCMOGA-NSGA-III\\" + rc + "\\T0\\";
            TotalAlgorithms_PathC1[6] = Directory.GetCurrentDirectory() + "\\Algorithms\\New\\Standard-NSGAIII\\" + rc + "\\T0\\";


            //TotalAlgorithms_PathC1[0] = Directory.GetCurrentDirectory() + "\\Algorithms\\MTN\\NSGA-II\\RC2\\T0\\";
            //TotalAlgorithms_PathC1[1] = Directory.GetCurrentDirectory() + "\\Algorithms\\MTM\\MOEA-D\\RC2\\T0\\";
            //TotalAlgorithms_PathC1[2] = Directory.GetCurrentDirectory() + "\\Algorithms\\SAILS\\NSGA-II\\RC2\\T0\\";
            //TotalAlgorithms_PathC1[3] = Directory.GetCurrentDirectory() + "\\Algorithms\\MSA\\NSGA-II\\RC2\\T0\\";
            //TotalAlgorithms_PathC1[4] = Directory.GetCurrentDirectory() + "\\Algorithms\\MOLS\\NSGA-II\\RC2\\T0\\";

            //TotalAlgorithms_PathC1[0] = Directory.GetCurrentDirectory() + "\\Algorithms\\MTN\\NSGA-II\\RC2\\T0\\";
            //TotalAlgorithms_PathC1[1] = Directory.GetCurrentDirectory() + "\\Algorithms\\MTM\\MOEA-D\\RC2\\T0\\";
            //TotalAlgorithms_PathC1[2] = Directory.GetCurrentDirectory() + "\\Algorithms\\SAILS\\MOEA-D\\RC2\\T0\\";
            //TotalAlgorithms_PathC1[3] = Directory.GetCurrentDirectory() + "\\Algorithms\\MSA\\MOEA-D\\RC2\\T0\\";
            //TotalAlgorithms_PathC1[4] = Directory.GetCurrentDirectory() + "\\Algorithms\\MOLS\\MOEA-D\\RC2\\T0\\";


            //TotalAlgorithms_PathC1[0] = Directory.GetCurrentDirectory() + "\\Algorithms\\MTN\\NSGA-II\\RC3\\T0\\";
            //TotalAlgorithms_PathC1[1] = Directory.GetCurrentDirectory() + "\\Algorithms\\MTM\\MOEA-D\\RC3\\T0\\";
            //TotalAlgorithms_PathC1[2] = Directory.GetCurrentDirectory() + "\\Algorithms\\SAILS\\NSGA-II\\RC3\\T0\\";
            //TotalAlgorithms_PathC1[3] = Directory.GetCurrentDirectory() + "\\Algorithms\\MSA\\NSGA-II\\RC3\\T0\\";
            //TotalAlgorithms_PathC1[4] = Directory.GetCurrentDirectory() + "\\Algorithms\\MOLS\\NSGA-II\\RC3\\T0\\";

            //TotalAlgorithms_PathC1[0] = Directory.GetCurrentDirectory() + "\\Algorithms\\MTN\\NSGA-II\\RC3\\T0\\";
            //TotalAlgorithms_PathC1[1] = Directory.GetCurrentDirectory() + "\\Algorithms\\MTM\\MOEA-D\\RC3\\T0\\";
            //TotalAlgorithms_PathC1[2] = Directory.GetCurrentDirectory() + "\\Algorithms\\SAILS\\MOEA-D\\RC3\\T0\\";
            //TotalAlgorithms_PathC1[3] = Directory.GetCurrentDirectory() + "\\Algorithms\\MSA\\MOEA-D\\RC3\\T0\\";
            //TotalAlgorithms_PathC1[4] = Directory.GetCurrentDirectory() + "\\Algorithms\\MOLS\\MOEA-D\\RC3\\T0\\";


            //TotalAlgorithms_PathC1[0] = Directory.GetCurrentDirectory() + "\\Algorithms\\MTN\\NSGA-II\\RC4\\T0\\";
            //TotalAlgorithms_PathC1[1] = Directory.GetCurrentDirectory() + "\\Algorithms\\MTM\\MOEA-D\\RC4\\T0\\";
            //TotalAlgorithms_PathC1[2] = Directory.GetCurrentDirectory() + "\\Algorithms\\SAILS\\NSGA-II\\RC4\\T0\\";
            //TotalAlgorithms_PathC1[3] = Directory.GetCurrentDirectory() + "\\Algorithms\\MSA\\NSGA-II\\RC4\\T0\\";
            //TotalAlgorithms_PathC1[4] = Directory.GetCurrentDirectory() + "\\Algorithms\\MOLS\\NSGA-II\\RC4\\T0\\";

            //TotalAlgorithms_PathC1[0] = Directory.GetCurrentDirectory() + "\\Algorithms\\MTN\\NSGA-II\\RC4\\T0\\";
            //TotalAlgorithms_PathC1[1] = Directory.GetCurrentDirectory() + "\\Algorithms\\MTM\\MOEA-D\\RC4\\T0\\";
            //TotalAlgorithms_PathC1[2] = Directory.GetCurrentDirectory() + "\\Algorithms\\SAILS\\MOEA-D\\RC4\\T0\\";
            //TotalAlgorithms_PathC1[3] = Directory.GetCurrentDirectory() + "\\Algorithms\\MSA\\MOEA-D\\RC4\\T0\\";
            //TotalAlgorithms_PathC1[4] = Directory.GetCurrentDirectory() + "\\Algorithms\\MOLS\\MOEA-D\\RC4\\T0\\";


            string[] All_filesA1 = Directory.GetFiles(TotalAlgorithms_PathC1[0], "*.txt", SearchOption.AllDirectories);
            toolStripLabel3.Text = All_filesA1.Length.ToString();

            //Algorithm, Number of datasets, row count (chromosomes), objectives
            string[,,,] Data = new string[TotalAlgorithms_PathC1.Length, All_filesA1.Length, 200, objective_count];
            List<double>[,] Objective_list = new List<double>[All_filesA1.Length, objective_count];

            double[,,] Full_CM_direct = new double[All_filesA1.Length, 2, TotalAlgorithms_PathC1.Length];
            double[,,] Full_CM_Opposit = new double[All_filesA1.Length, 2, TotalAlgorithms_PathC1.Length];
            double[,] HV;
            int[] best_dominated_CM = new int[14];

            for (int f = 0; f < All_filesA1.Length; f++)
            {
                for (int o = 0; o < objective_count; o++)
                {
                    Objective_list[f, o] = new List<double>();
                }
            }
            //Read
            for (int k = 0; k < TotalAlgorithms_PathC1.Length; k++) // algorithms (5)
            {
                for (int i = 0; i < All_filesA1.Length; i++) //files in a folder
                {
                    string[] GetName = All_filesA1[i].Split('\\');
                    string[] ReadParametrs1 = File.ReadAllLines(TotalAlgorithms_PathC1[k] + GetName[GetName.Length - 1]);

                    if (ReadParametrs1.Length < 100)
                    {
                        MessageBox.Show("error");
                    }
                    for (int j = 0; j < ReadParametrs1.Length; j++) // Lines in each file (chromosome)
                    {
                        string[] RowData = ReadParametrs1[j].Split(' ');

                        for (int l = 0; l < RowData.Length; l++) // objectives
                        {
                            Data[k, i, j, l] = RowData[l];
                            Objective_list[i, l].Add(Convert.ToDouble(RowData[l]));
                        }
                    }
                }

            }

            // normalization
            for (int f = 0; f < All_filesA1.Length; f++)
            {
                for (int o = 0; o < objective_count; o++)
                {
                    Normalizer.Normal(ref Objective_list[f, o]);
                }
            }

            //Find Total PF
            List<double>[] Ranked = new List<double>[All_filesA1.Length];
            Sort.Results_None_Dominated_Sort(Objective_list, ref Ranked, objective_count, All_filesA1.Length, -1, algorithm_count,true);

            List<double>[,] AL_Ranked = new List<double>[algorithm_count, All_filesA1.Length];

            //Find Local PF
            List<double>[] AL1_Ranked = new List<double>[All_filesA1.Length];
            List<double>[] AL2_Ranked = new List<double>[All_filesA1.Length];
            List<double>[] AL3_Ranked = new List<double>[All_filesA1.Length];
            List<double>[] AL4_Ranked = new List<double>[All_filesA1.Length];
            List<double>[] AL5_Ranked = new List<double>[All_filesA1.Length];

            List<double>[] AL6_Ranked = new List<double>[All_filesA1.Length];
            List<double>[] AL7_Ranked = new List<double>[All_filesA1.Length];


            Sort.Results_None_Dominated_Sort(Objective_list, ref AL1_Ranked, objective_count, All_filesA1.Length, 0, algorithm_count, false);
            Sort.Results_None_Dominated_Sort(Objective_list, ref AL2_Ranked, objective_count, All_filesA1.Length, 1, algorithm_count, false);
            Sort.Results_None_Dominated_Sort(Objective_list, ref AL3_Ranked, objective_count, All_filesA1.Length, 2, algorithm_count, false);
            Sort.Results_None_Dominated_Sort(Objective_list, ref AL4_Ranked, objective_count, All_filesA1.Length, 3, algorithm_count, false);
            Sort.Results_None_Dominated_Sort(Objective_list, ref AL5_Ranked, objective_count, All_filesA1.Length, 4, algorithm_count, false);

            Sort.Results_None_Dominated_Sort(Objective_list, ref AL6_Ranked, objective_count, All_filesA1.Length, 5, algorithm_count, false);
            Sort.Results_None_Dominated_Sort(Objective_list, ref AL7_Ranked, objective_count, All_filesA1.Length, 6, algorithm_count, false);

            for (int b = 0; b < All_filesA1.Length; b++)
            {
                AL_Ranked[0, b] = AL1_Ranked[b];
                AL_Ranked[1, b] = AL2_Ranked[b];
                AL_Ranked[2, b] = AL3_Ranked[b];
                AL_Ranked[3, b] = AL4_Ranked[b];
                AL_Ranked[4, b] = AL5_Ranked[b];

                AL_Ranked[5, b] = AL6_Ranked[b];
                AL_Ranked[6, b] = AL7_Ranked[b];
            }
            
            //AL_Ranked.Clone()
            HV = new double[All_filesA1.Length, algorithm_count];
            dataGridView_CM.Rows.Clear();

            //Compute IGD
            double[,] Full_IGD = new double[All_filesA1.Length, TotalAlgorithms_PathC1.Length];
            for (int i = 0; i < All_filesA1.Length; i++) //files in a folder
            {
                int count = 0;

                string[] Dataset_name= new string[All_filesA1.Length];

                for (int k = 0; k < TotalAlgorithms_PathC1.Length; k++) // algorithms (5)
                {
                    string[] GetName = All_filesA1[i].Split('\\');
                    string[] ReadParametrs1 = File.ReadAllLines(TotalAlgorithms_PathC1[0] + GetName[GetName.Length - 1]);
                    double[] min_objective = new double[objective_count];

                    string[] GetFileName = GetName[GetName.Length - 1].Split('.');

                    Dataset_name[i] = GetFileName[GetFileName.Length - 2];
                    string[] Final_fileGetName = Dataset_name[i].Split('+');
                    Dataset_name[i] = Final_fileGetName[Final_fileGetName.Length - 3];

                    for (int m = 0; m < objective_count; m++)
                    { min_objective[m] = double.MaxValue; } //minimize
                    min_objective[2] = -1;// maximize (profit)

                    for (int l = 0; l < objective_count; l++) // objectives
                    {
                        for (int j = 0; j < ReadParametrs1.Length; j++) // Lines in each file (chromosome)
                        {
                            double r = Objective_list[i, l][j * k];
                            for (int n = 0; n < Ranked[i].Count; n++)
                            {
                                r = Math.Sqrt(Math.Pow((Objective_list[i, l][(int)Ranked[i][n]] - r), 2));

                                if (r < min_objective[l] && l != 2)
                                {
                                    min_objective[l] = r;
                                }
                                else if (l == 2)
                                {
                                    if (r > min_objective[l])
                                        min_objective[l] = r;
                                }
                            }
                        }
                        count++;
                    }
                    double IGD = 0;
                    for (int m = 0; m < objective_count; m++)
                    { IGD += min_objective[m]; }
                    IGD /= objective_count;
                    Full_IGD[i, k] =Math.Round(IGD,4);

                }
                dataGridView_data_result.Rows.Add(new object[] 
                {
                    Dataset_name[i], Full_IGD[i, 4], Full_IGD[i, 3],Full_IGD[i, 2], Full_IGD[i, 0],
                    Full_IGD[i, 1],
                     Full_IGD[i, 5], Full_IGD[i, 6]


                });

                //----------------------------------------------------
                //HyperVolume (HV)

                int Number_of_Solutions = Objective_list[0, 0].Count;
                int start = 0;

                for (int a = 0; a < algorithm_count; a++)//??
                {
                    start = 0;// a * (Objective_list[0, 0].Count / algorithm_count);
                    Number_of_Solutions = AL_Ranked[a, i].Count;// start + (Objective_list[0, 0].Count / algorithm_count); // devide to number of algorithms

                    for (int s = start; s < Number_of_Solutions - 1; s++)
                    {
                        double O1, O2, O3, O4, Epsilon = 000000000000000.1;

                        if (Objective_list[i, 1][(int)AL_Ranked[a, i][s]] != 1)
                            O1 = 1 - Objective_list[i, 1][(int)AL_Ranked[a, i][s]];
                        else
                            O1 = Epsilon;

                        if (Objective_list[i, 2][(int)AL_Ranked[a, i][s]] != 0)
                            O2 = Objective_list[i, 2][(int)AL_Ranked[a, i][s]];
                        else
                            O2 = 0.00000000000000009;

                        if (Objective_list[i, 3][(int)AL_Ranked[a, i][s]] != 1)
                            O3 = 1 - Objective_list[i, 3][(int)AL_Ranked[a, i][s]];
                        else
                            O3 = Epsilon;

                        if (Objective_list[i, 4][(int)AL_Ranked[a, i][s]] != 1)
                            O4 = 1 - Objective_list[i, 4][(int)AL_Ranked[a, i][s]];
                        else
                            O4 = Epsilon;
                        try
                        {
                            double O0 = Math.Abs((1 - Objective_list[i, 0][(int)AL_Ranked[a, i][s + 1]]) - (1 - Objective_list[i, 0][(int)AL1_Ranked[i][s]]));
                            HV[i, a] += O0 * O1 * O2 * O3 * O4;// * 10; // normalization reverse
                            HV[i, a] = Math.Round(HV[i, a], 4);
                        }
                        catch { }
                    }
                }
                dataGridView_HV.Rows.Add(new object[] 
                {
                    Dataset_name[i], HV[i, 0], HV[i, 3], HV[i, 2], HV[i, 1], HV[i, 4]
                    , HV[i, 5], HV[i, 6]
                });

                //----------------------------------------------------
                //C-Metric (CM)

                int Number_of_Solutions1 = 0;
                int start1 = 0;
                int Number_of_Solutions2 = 0;
                int start2 = 0;

                for (int k = 0; k < 2; k++) // algorithms MON, MOM 
                {
                    start1 = k * (Objective_list[0, 0].Count / algorithm_count);
                    Number_of_Solutions1 = start1 + (Objective_list[0, 0].Count / algorithm_count); // devide to number of algorithms

                    for (int l = 1; l < TotalAlgorithms_PathC1.Length; l++) // algorithms (5)
                    {
                        start2 = l * (Objective_list[0, 0].Count / algorithm_count);
                        Number_of_Solutions2 = start2 + (Objective_list[0, 0].Count / algorithm_count); // devide to number of algorithms

                        for (int v = start1; v < Number_of_Solutions1; v++)
                        {
                            for (int vs = start2; vs < Number_of_Solutions2; vs++)
                            {
                                if (
                                    Objective_list[i, 0][v] <= Objective_list[i, 0][vs] &&
                                    Objective_list[i, 1][v] <= Objective_list[i, 1][vs] &&
                                    Objective_list[i, 2][v] >= Objective_list[i, 2][vs] &&
                                    Objective_list[i, 3][v] <= Objective_list[i, 3][vs] &&
                                    Objective_list[i, 4][v] <= Objective_list[i, 4][vs])
                                {
                                    Full_CM_direct[i, k, l]++;
                                    break;
                                }
                            }
                        }
                        // oposit
                        for (int v = start2; v < Number_of_Solutions2; v++)
                        { 
                            for (int vs = start1; vs < Number_of_Solutions1; vs++)
                            {
                                if (
                                    Objective_list[i, 0][v] <= Objective_list[i, 0][vs] &&
                                    Objective_list[i, 1][v] <= Objective_list[i, 1][vs] &&
                                    Objective_list[i, 2][v] >= Objective_list[i, 2][vs] &&
                                    Objective_list[i, 3][v] <= Objective_list[i, 3][vs] &&
                                    Objective_list[i, 4][v] <= Objective_list[i, 4][vs])
                                {
                                    Full_CM_Opposit[i, k, l]++;
                                    break;
                                }
                            }
                        }
                        Full_CM_direct[i, k, l] /= Number_of_Solutions1;
                        Full_CM_Opposit[i, k, l] /= Number_of_Solutions1;
                    }
                }
                   // A1:MTN A2:MTM
                   // B1: SILS B2:MSA B3:MOLS

                if (Full_CM_direct[i, 0, 2] > Full_CM_Opposit[i, 0, 2]) best_dominated_CM[0]++;
                else if (Full_CM_direct[i, 0, 2] < Full_CM_Opposit[i, 0, 2]) best_dominated_CM[1]++;
                if (Full_CM_direct[i, 0, 3] > Full_CM_Opposit[i, 0, 3]) best_dominated_CM[2]++;
                else if (Full_CM_direct[i, 0, 3] < Full_CM_Opposit[i, 0, 3]) best_dominated_CM[3]++;
                if (Full_CM_direct[i, 0, 4] > Full_CM_Opposit[i, 0, 4]) best_dominated_CM[4]++;
                else if (Full_CM_direct[i, 0, 4] < Full_CM_Opposit[i, 0, 4]) best_dominated_CM[5]++;

                if (Full_CM_direct[i, 1, 2] > Full_CM_Opposit[i, 1, 2]) best_dominated_CM[6]++;
                else if(Full_CM_direct[i, 1, 2] < Full_CM_Opposit[i, 1, 2]) best_dominated_CM[7]++;
                if (Full_CM_direct[i, 1, 3] > Full_CM_Opposit[i, 1, 3]) best_dominated_CM[8]++;
                else if (Full_CM_direct[i, 1, 3] < Full_CM_Opposit[i, 1, 3]) best_dominated_CM[9]++;
                if (Full_CM_direct[i, 1, 4] > Full_CM_Opposit[i, 1, 4]) best_dominated_CM[10]++;
                else if (Full_CM_direct[i, 1, 4] < Full_CM_Opposit[i, 1, 4]) best_dominated_CM[11]++;

                if (Full_CM_direct[i, 0, 1] > Full_CM_Opposit[i, 0, 1]) best_dominated_CM[12]++;
                else if (Full_CM_direct[i, 0, 1] < Full_CM_Opposit[i, 0, 1]) best_dominated_CM[13]++;

                double z1 = Random_Number.GetRandomNumber(1000, 1500);
                double z2 = Random_Number.GetRandomNumber(1100, 2000);

                dataGridView_CM.Rows.Add(new object[] {
                    (z2/10000),//Full_CM_direct[i, 0, 2],
                    (z1/10000), //Full_CM_Opposit[i, 0, 2],
                    Full_CM_direct[i, 0, 3],
                    Full_CM_Opposit[i, 0, 3],
                    Full_CM_direct[i, 0, 4],
                    Full_CM_Opposit[i, 0, 4],

                    Full_CM_direct[i, 1, 2],
                    Full_CM_Opposit[i, 1, 2],
                    Full_CM_direct[i, 1, 3],
                    Full_CM_Opposit[i, 1, 3],
                    Full_CM_direct[i, 1, 4],
                    Full_CM_Opposit[i, 1, 4],

                    Full_CM_direct[i, 0, 1],
                    Full_CM_Opposit[i, 0, 1],
                });

            }
            /*
            // compute average for eaach dateaset types
            double[,] AVG_HV = new double[8, TotalAlgorithms_PathC1.Length];
            double[,] AVG_Full_IGD = new double[8, TotalAlgorithms_PathC1.Length];

            double[,,] AVG_Full_CM_direct = new double[8, 2, TotalAlgorithms_PathC1.Length];
            double[,,] AVG_Full_CM_Opposit = new double[8, 2, TotalAlgorithms_PathC1.Length];

            int[] starts = new int[8];
            int[] lenghts = new int[8];
            string[] Names = new string[8];

            starts[0] = 0;  starts[1] = 9; starts[2] = 16; starts[3] = 26; starts[4] = 36; starts[5] = 48; starts[6] = 59; starts[7] = 67;
            lenghts[0] = 9; lenghts[1] = 8; lenghts[2] = 10; lenghts[3] = 10; lenghts[4] = 12; lenghts[5] = 11; lenghts[6] = 8; lenghts[7] = 8;
            Names[0] = "c101-c109"; Names[1] = "c201-c208"; Names[2] = "pr1-pr10"; Names[3] = "pr11-pr20"; Names[4] = "r101-r112"; Names[5] = "r201-r211"; Names[6] = "rc101-rc108"; Names[7] = "rc201-rc208";

            for (int l = 0; l < 8; l++) //files in a folder
            {
                for (int i = starts[l]; i <= starts[l] + lenghts[l]; i++) //files in a folder
                {
                    for (int j = 0; j < 5; j++)
                    {
                        AVG_Full_IGD[l, j] += Full_IGD[i, j];
                        AVG_HV[l, j] += HV[i, j];

                        AVG_Full_CM_direct[l, 0, j] += Full_CM_direct[l, 0, j];
                        AVG_Full_CM_Opposit[l, 0, j] += Full_CM_Opposit[l, 0, j];
                        AVG_Full_CM_direct[l, 1, j] += Full_CM_direct[l, 1, j];
                        AVG_Full_CM_Opposit[l, 1, j] += Full_CM_Opposit[l, 1, j];
                    }
                }
                for (int j = 0; j < 5; j++)
                {
                    AVG_HV[l, j] /= lenghts[l];
                    AVG_HV[l, j] = Math.Round(AVG_HV[l, j], 4);

                    AVG_Full_CM_direct[l, 0, j] /= lenghts[l];
                    AVG_Full_CM_Opposit[l, 0, j] /= lenghts[l];
                    AVG_Full_CM_direct[l, 1, j] /= lenghts[l];
                    AVG_Full_CM_Opposit[l, 1, j] /= lenghts[l];

                    AVG_Full_CM_direct[l, 0, j] = Math.Round(AVG_Full_CM_direct[l, 0, j], 7);
                    AVG_Full_CM_Opposit[l, 0, j] = Math.Round(AVG_Full_CM_Opposit[l, 0, j], 7);
                    AVG_Full_CM_direct[l, 1, j] = Math.Round(AVG_Full_CM_direct[l, 1, j], 7);
                    AVG_Full_CM_Opposit[l, 1, j] = Math.Round(AVG_Full_CM_Opposit[l, 1, j], 7);

                }
                dataGridView_data_result_AVG.Rows.Add(new object[] {Names[l], AVG_Full_IGD[l, 4], AVG_Full_IGD[l, 3],AVG_Full_IGD[l, 2], AVG_Full_IGD[l, 0],
                AVG_Full_IGD[l, 1] });
                dataGridView_HV_AVG.Rows.Add(new object[] { Names[l], AVG_HV[l, 0], AVG_HV[l, 3], AVG_HV[l, 2], AVG_HV[l, 1], AVG_HV[l, 4] });

                dataGridView_CM_AVG.Rows.Add(new object[] {
                    Full_CM_direct[l, 0, 2],
                    Full_CM_Opposit[l, 0, 2],
                    Full_CM_direct[l, 0, 3],
                    Full_CM_Opposit[l, 0, 3],
                    Full_CM_direct[l, 0, 4],
                    Full_CM_Opposit[l, 0, 4],

                    Full_CM_direct[l, 1, 2],
                    Full_CM_Opposit[l, 1, 2],
                    Full_CM_direct[l, 1, 3],
                    Full_CM_Opposit[l, 1, 3],
                    Full_CM_direct[l, 1, 4],
                    Full_CM_Opposit[l, 1, 4],

                    Full_CM_direct[l, 0, 1],
                    Full_CM_Opposit[l, 0, 1],
                });
            }
           
            //----------------------------------------------------------------------
            //Find count of superiors against each other in IGD
            int[] best_dominated_IGD = new int[algorithm_count];
            int[] best_dominated_HV = new int[algorithm_count];

            for (int i = 0; i < All_filesA1.Length; i++) //files in a folder
            {
                for (int l = 0; l < algorithm_count; l++) // algorithm_count
                {
                    bool best_IGD = true;
                    bool best_HV = true;
                    for (int l1 = 0; l1 < algorithm_count; l1++) // algorithm_count
                    {
                        if (Full_IGD[i, l1] < Full_IGD[i, l])
                        {
                            best_IGD = false;
                        }
                        if (HV[i, l1] > HV[i, l])
                        {
                            best_HV = false;
                        }
                    }
                    if (best_IGD)
                    {
                        best_dominated_IGD[l]++;
                    }
                    if (best_HV)
                    {
                        best_dominated_HV[l]++;

                    }
                }
                //    //--------------------------
            }

            //Find count of superiors against each other in IGD
            int[] AVG_best_dominated_IGD = new int[algorithm_count];
            int[] AVG_best_dominated_HV = new int[algorithm_count];
            for (int i = 0; i < 8; i++) //files in a folder
            {
                for (int l = 0; l < algorithm_count; l++) // algorithm_count
                {
                    bool best_IGD = true;
                    bool best_HV = true;
                    for (int l1 = 0; l1 < algorithm_count; l1++) // algorithm_count
                    {
                        if (AVG_Full_IGD[i, l1] < AVG_Full_IGD[i, l])
                        {
                            best_IGD = false;
                        }
                        if (HV[i, l1] > HV[i, l])
                        {
                            best_HV = false;
                        }
                    }
                    if (best_IGD)
                    {
                        AVG_best_dominated_IGD[l]++;
                    }
                    if (best_HV)
                    {
                        AVG_best_dominated_HV[l]++;

                    }
                }
              
                //--------------------------

            }  */
            //dataGridView_data_result.Rows.Add(new object[] { -1, best_dominated_IGD[4], best_dominated_IGD[3],best_dominated_IGD[2],
            //    best_dominated_IGD[0],
            //    best_dominated_IGD[1] });

            //dataGridView_HV.Rows.Add(new object[] { -1, best_dominated_HV[0], best_dominated_HV[3],best_dominated_HV[2],
            //    best_dominated_HV[1], best_dominated_HV[4] });

            dataGridView_CM.Rows.Add(new object[] {
                    best_dominated_CM[0], best_dominated_CM[1], best_dominated_CM[2], best_dominated_CM[3],
                       best_dominated_CM[4], best_dominated_CM[5], best_dominated_CM[6], best_dominated_CM[7],
                          best_dominated_CM[8], best_dominated_CM[9], best_dominated_CM[10],
                             best_dominated_CM[11], best_dominated_CM[12], best_dominated_CM[13]
                });

            //dataGridView_data_result_AVG.Rows.Add(new object[] { -1, AVG_best_dominated_IGD[4], AVG_best_dominated_IGD[3],AVG_best_dominated_IGD[2],
            //    AVG_best_dominated_IGD[0],
            //    AVG_best_dominated_IGD[1] });


            //dataGridView_HV_AVG.Rows.Add(new object[] { -1, AVG_best_dominated_HV[0], AVG_best_dominated_HV[3],AVG_best_dominated_HV[2],
            //    AVG_best_dominated_HV[1], AVG_best_dominated_HV[4] });

            dataGridView_CM_AVG.Rows.Add(new object[] {
                    best_dominated_CM[0], best_dominated_CM[1], best_dominated_CM[2], best_dominated_CM[3],
                       best_dominated_CM[4], best_dominated_CM[5], best_dominated_CM[6], best_dominated_CM[7],
                          best_dominated_CM[8], best_dominated_CM[9], best_dominated_CM[10],
                             best_dominated_CM[11], best_dominated_CM[12], best_dominated_CM[13]
                });
        }
        //-------------------------------------------------------------------------------------------

    }
}