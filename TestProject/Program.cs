using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioCircleManagementSystem.ViewModels;
using BioCircleManagementSystem.Views.Customers;
using BioCircleManagementSystem.Model;

namespace TestProject
{
    class Program
    {
        static Program  program;
        static void Main(string[] args)
        {
            program = new Program();
            program.Run();
        }

        public void Run()
        {
            int weekNumber = (DateTime.Now.DayOfYear / 7)+1;
            int a = 6;
            int b = 7;
            Console.WriteLine(weekNumber);
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(DateTime.Now.DayOfYear);
            Console.WriteLine(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
        }
    }
}
