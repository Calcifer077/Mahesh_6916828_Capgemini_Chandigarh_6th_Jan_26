using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1CU
{
    internal class BasicClassExampleWithEncapsulation
    {
        public int EId, EAge;
        public string EName, EAddress;

        public void GetEmpData()
        {
            Console.WriteLine("Enter the employee detail");
            this.EId = Convert.ToInt32(Console.ReadLine());
            this.EName = Console.ReadLine();
            this.EAddress = Console.ReadLine();
            this.EAge = Convert.ToInt32(Console.ReadLine());    
        }

        public void DisplayEmpDta()
        {
            Console.WriteLine("Employee id is: " + this.EId);
            Console.WriteLine("Employee name is: " + this.EName);
            Console.WriteLine("Employee address is: " + this.EAddress);
            Console.WriteLine("Employee age is: " + this.EAge);
        }

        static void Maint(String[] args)
        {
            BasicClassExampleWithEncapsulation obj = new BasicClassExampleWithEncapsulation();
            obj.GetEmpData();
            obj.DisplayEmpDta();
        }
    }

    
}
