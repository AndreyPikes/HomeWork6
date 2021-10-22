using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workers.Data;

namespace Workers
{
    public static class WorkersDatabase
    {
        public static ObservableCollection<Department> ListDepartment { get; set; }
        public static ObservableCollection<Worker> ListWorkers {get; set;}

        static WorkersDatabase()
        {
            ListWorkers = new ObservableCollection<Worker>();
            ListDepartment = new ObservableCollection<Department>();
            CreateDepartments(5);
            CreateWorkers(80);
        }

        private static void CreateDepartments(int count)
        {
            ListDepartment.Add(new Department($"без департамента"));

            for (int i = 1; i <= count; i++)
            {
                ListDepartment.Add(new Department($"Департамент номер {i}"));
            }            
        }

        private static void CreateWorkers(int count)
        {
            Random random = new Random();

            string[] names = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "Names.txt");
            string[] positions = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "Positions.txt");

            for (int i = 0; i < count; i++)
            {
                ListWorkers.Add(new Worker(names[random.Next(0, names.Length - 1)],
                                            random.Next(18, 70),
                                            positions[random.Next(0, positions.Length - 1)],
                                            "Комментарий отстутствует",
                                            random.Next(1, 3) > 1 ? false : true,
                                            ListDepartment[random.Next(1, ListDepartment.Count)]));
            }
        }
    }
}
