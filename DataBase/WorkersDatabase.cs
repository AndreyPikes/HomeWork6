using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workers.Data;

namespace Workers
{
    public class WorkersDatabase
    {
        public List<Department> ListDepartment { get; set; }
        public List<Worker> ListWorkers {get; set;}

        public WorkersDatabase()
        {
            ListWorkers = new List<Worker>();
            ListDepartment = new List<Department>();
            CreateDepartments(5);
            CreateWorkers(20);
        }

        private void CreateDepartments(int count)
        {
            ListDepartment.Add(new Department($"без департамента"));

            for (int i = 1; i <= count; i++)
            {
                ListDepartment.Add(new Department($"Департамент номер {i}"));
            }            
        }

        private void CreateWorkers(int count)
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
