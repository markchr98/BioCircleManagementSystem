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
            CustomerViewModel.Instance.NewCustomer("test", "test", 0000, "test", "test", 0000, "test", 0000);
            CustomerViewModel.Instance.NewContact("mark", 9090, "mark", 90, 7);
        }
    }
}
