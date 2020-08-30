using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TOOPTW
{
    [Serializable]
    class Chromosome
    {
        public int id { get; set; }
        public Point position { get; set; }
        public int service_duration { get; set; }
        public int profit { get; set; }
        public int opening { get; set; }
        public int closing { get; set; }

        public Chromosome()
        {
        }
        public Chromosome(int _id, Point _position, int _service_duration, int _profit, int _opening, int _closing)
        {
            id = _id;
            position = _position;
            service_duration = _service_duration;
            profit = _profit;
            opening = _opening;
            closing = _closing;
        }
        public T ObjectClone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }
    //________________________________________________________________________________________________________________
    [Serializable]
    class Path_attributes
    {
        public int Tmax { get; set; }
        public double Total_Profit { get; set; }
        public double Total_Energy_Cost { get; set; }
        public double Total_Duration { get; set; }
        public double Total_Fairness_Rate { get; set; }

        public List<Chromosome> Path_list = new List<Chromosome>();
        public T ObjectClone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }
    //________________________________________________________________________________________________________________
    [Serializable]
    class Full_Chrmosome
    {
        public Path_attributes[] One_Path;
        public Path_attributes Reserve_list;

        public double Ch_Total_Profit = 0;
        public double Ch_Total_Duration = 0;
        public double Ch_Total_Energy_Cost = 0;
        public double Ch_Delayed_Tasks_Duration = 0;
        public double Ch_Fitness = 0;
        public double Ch_Total_Fairness_Rate = 0;
        public double Ch_CD = 0;

        private int Number_of_Robots;

        public Full_Chrmosome(int N_of_Robots)
        {
            Number_of_Robots = N_of_Robots;
            One_Path = new Path_attributes[Number_of_Robots];
            Reserve_list = new Path_attributes();

            List<Chromosome> list = new List<Chromosome>();
            for (int CN = 0; CN < N_of_Robots; CN++)
            {
                for (int i = 0; i < Number_of_Robots; i++)
                {
                    One_Path[CN] = new Path_attributes();
                }
            }
        }
        //-------------------------------------------------------------------------------
        public void Compute_Fitness()
        {
            Ch_Fitness = 0;
            Ch_Total_Profit = 0; //f1
            Ch_Total_Duration = 0; //f2
            Ch_Total_Energy_Cost = 0; //f3
            Ch_Total_Fairness_Rate = 0; //f4
            Ch_Delayed_Tasks_Duration = 0; //f5

            for (int r = 0; r < Number_of_Robots; r++)
            {
                One_Path[r].Total_Profit = 0; 
                One_Path[r].Total_Duration = 0; 
                One_Path[r].Total_Energy_Cost = 0; 
                One_Path[r].Total_Fairness_Rate = 0; 

                int robot_vertices_count = One_Path[r].Path_list.Count - 1;
                const double Rad2Deg = 180.0 / Math.PI;
                const double Deg2Rad = Math.PI / 180.0;
                double Rtobot_elapsed_time = 0; // second.ms
                int energy_factor_for_robot = 0;
                int Stright_energy_factor_for_robot = 0;
                int Rotation_energy_factor_for_robot = 0;
                double robot_s_angle = 0;

                for (int i = 1; i < robot_vertices_count; i++)
                {
                    //if thask is not opened yet time is shiftin by robot's waiting (Original TOPTW)
                    if (Rtobot_elapsed_time < One_Path[r].Path_list[i].opening)
                    {
                        // Rtobot_elapsed_time += One_Path[r].Path_list[i].opening - Rtobot_elapsed_time;
                    }

                    //if arrived with delay
                    else if (Rtobot_elapsed_time > One_Path[r].Path_list[i].closing)
                    {
                        Ch_Delayed_Tasks_Duration += Rtobot_elapsed_time - One_Path[r].Path_list[i].closing;
                    }

                    //performing the task
                    Rtobot_elapsed_time += One_Path[r].Path_list[i].service_duration;
                    One_Path[r].Total_Profit += One_Path[r].Path_list[i].profit;

                    //Going to next Task
                    double stright_time = 0;
                    double rotate_time = 0;
                    if (One_Path[r].Path_list.Count > 3 && i < robot_vertices_count - 1 && One_Path[r].Path_list[i].position.X != 0 && One_Path[r].Path_list[i].position.Y != 0)
                    {
                        double x = Math.Pow(One_Path[r].Path_list[i].position.X - One_Path[r].Path_list[i + 1].position.X, 2);
                        double y = Math.Pow(One_Path[r].Path_list[i].position.Y - One_Path[r].Path_list[i + 1].position.Y, 2);
                        double path_time_requirement = Math.Sqrt(x + y);
                        stright_time = Math.Abs(path_time_requirement);
                        Rtobot_elapsed_time += stright_time;

                        Point P1 = new Point(One_Path[r].Path_list[i - 1].position.X, One_Path[r].Path_list[i - 1].position.Y);
                        Point P2 = new Point(One_Path[r].Path_list[i].position.X, One_Path[r].Path_list[i].position.Y);
                        Point P3 = new Point(One_Path[r].Path_list[i + 1].position.X, One_Path[r].Path_list[i + 1].position.Y);

                        double a = Math.Sqrt(Math.Pow((P1.X - P2.X), 2) + Math.Pow((P1.Y - P2.Y), 2));
                        double b = Math.Sqrt(Math.Pow((P2.X - P3.X), 2) + Math.Pow((P2.Y - P3.Y), 2));
                        double c = Math.Sqrt(Math.Pow((P1.X - P3.X), 2) + Math.Pow((P1.Y - P3.Y), 2));

                        //double A = Math.Acos(((b * b) + (c * c) - (a * a)) / (2 * b * c));
                        //double B = Math.Acos(((a * a) + (c * c) - (b * b)) / (2 * a * c));
                        double C = Math.Acos(((a * a) + (b * b) - (c * c)) / (2 * a * b));

                        if (Double.IsNaN(C))
                            C = 0;

                        rotate_time += C;
                    }

                    if (r == 0)
                    {
                        Stright_energy_factor_for_robot = 2;
                        Rotation_energy_factor_for_robot = 3;
                        if (One_Path[r].Path_list[i].id < robot_vertices_count / 4)
                        { energy_factor_for_robot = 1; }
                        else if (One_Path[r].Path_list[i].id >= robot_vertices_count/ 4 && One_Path[r].Path_list[i].id < robot_vertices_count/ 2)
                        { energy_factor_for_robot = 3; }
                        else if (One_Path[r].Path_list[i].id >= robot_vertices_count/ 2 && One_Path[r].Path_list[i].id < robot_vertices_count/ 3)
                        { energy_factor_for_robot = 5; }
                        else if (One_Path[r].Path_list[i].id >= robot_vertices_count/ 3)
                        { energy_factor_for_robot = 6; }
                    }
                    else if (r == 1)
                    {
                        Stright_energy_factor_for_robot = 3;
                        Rotation_energy_factor_for_robot = 4;
                        if (One_Path[r].Path_list[i].id < robot_vertices_count/ 4)
                        { energy_factor_for_robot = 1; }
                        else if (One_Path[r].Path_list[i].id >= robot_vertices_count/ 4 && One_Path[r].Path_list[i].id < robot_vertices_count/ 2)
                        { energy_factor_for_robot = 3; }
                        else if (One_Path[r].Path_list[i].id >= robot_vertices_count/ 2 && One_Path[r].Path_list[i].id < robot_vertices_count/ 3)
                        { energy_factor_for_robot = 6; }
                        else if (One_Path[r].Path_list[i].id >= robot_vertices_count/ 3)
                        { energy_factor_for_robot = 7; }
                    }
                    else if (r == 2)
                    {
                        Stright_energy_factor_for_robot = 3;
                        Rotation_energy_factor_for_robot = 4;
                        if (One_Path[r].Path_list[i].id < robot_vertices_count/ 4)
                        { energy_factor_for_robot = 2; }
                        else if (One_Path[r].Path_list[i].id >= robot_vertices_count/ 4 && One_Path[r].Path_list[i].id < robot_vertices_count/ 2)
                        { energy_factor_for_robot = 4; }
                        else if (One_Path[r].Path_list[i].id >= robot_vertices_count/ 2 && One_Path[r].Path_list[i].id < robot_vertices_count/ 3)
                        { energy_factor_for_robot = 6; }
                        else if (One_Path[r].Path_list[i].id >= robot_vertices_count/ 3)
                        { energy_factor_for_robot = 8; }
                    }
                    else if (r == 3)
                    {
                        Stright_energy_factor_for_robot = 2;
                        Rotation_energy_factor_for_robot = 3;
                        if (One_Path[r].Path_list[i].id < robot_vertices_count/ 4)
                        { energy_factor_for_robot = 3; }
                        else if (One_Path[r].Path_list[i].id >= robot_vertices_count/ 4 && One_Path[r].Path_list[i].id < robot_vertices_count/ 2)
                        { energy_factor_for_robot = 5; }
                        else if (One_Path[r].Path_list[i].id >= robot_vertices_count/ 2 && One_Path[r].Path_list[i].id < robot_vertices_count/ 3)
                        { energy_factor_for_robot = 6; }
                        else if (One_Path[r].Path_list[i].id >= robot_vertices_count/ 3)
                        { energy_factor_for_robot = 8; }
                    }
                    One_Path[r].Total_Energy_Cost +=
                        (One_Path[r].Path_list[i].service_duration * energy_factor_for_robot) +
                        (stright_time * Stright_energy_factor_for_robot) +
                        (rotate_time * Rotation_energy_factor_for_robot);
                }

                One_Path[r].Total_Duration = Rtobot_elapsed_time;

                Ch_Total_Profit += One_Path[r].Total_Profit; // sum of total path colleted profit
                Ch_Total_Energy_Cost += One_Path[r].Total_Energy_Cost; // Simply Ecludian

               // if (Rtobot_elapsed_time > Ch_Total_Duration) // for makespan
                {
                    Ch_Total_Duration += Rtobot_elapsed_time; // Sum/max of servise times
                }

                //Wheighted Fitness if needed => Sum of all multiply to desired factor
                Ch_Fitness +=
                    One_Path[r].Total_Profit +
                    (1/One_Path[r].Total_Fairness_Rate) -
                    (1 /One_Path[r].Total_Energy_Cost) -
                    (1/One_Path[r].Total_Duration);
            }
            Ch_Fitness += (1 / Ch_Delayed_Tasks_Duration);

            for (int r = 0; r < Number_of_Robots; r++)
            {
                Ch_Total_Fairness_Rate =
              Math.Pow(One_Path[r].Total_Energy_Cost - (Ch_Total_Energy_Cost / Number_of_Robots), 2); //f4
            }
            Ch_Total_Fairness_Rate /= Number_of_Robots;
            Ch_Total_Fairness_Rate = Math.Sqrt(Ch_Total_Fairness_Rate);
        }
        //-------------------------------------------------------------------------------
        public T ObjectClone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
        //________________________________________________________________________________________________________________
    }
}
