using System.Data;

namespace EmployeeDesignation
{
    internal class Program
    {

        public static void solve(string[] input1, string input2)
        {
            int count = 0;
            List<string> list = new List<string>();

            for(int i = 1; i < input1.Length; i += 2)
            {
                foreach(var item in input1[i])
                {
                    if (!char.IsLetterOrDigit(item))
                    {
                        count = -1;
                        break;
                    }
                    
                    
                    
                }

                if(count== -1) break;
                if(input1[i].ToLower().Equals(input2.ToLower()))
                {
                    list.Add(input1[i - 1]);
                }
            }

            if(count == -1)
            {
                Console.WriteLine("Invalid Input");
            }else if(list.Count == 0)
            {
                Console.WriteLine("No employee found for " + input2 + " designation");
            }
            else
            {
                foreach(var item in list)
                {
                    Console.Write(item + " ");
                }
            }
        }

        static void Main(string[] args)
        {
            // int n = Convert.ToInt32(Console.ReadLine());
            // string[] input1 = new string[n];

            // for(int i = 0; i < n; i++)
            // {
            //     input1[i] = Console.ReadLine();
            // }
            // string input2 = Console.ReadLine();

            int n = 6;
            string[] input1 = {"Ram", "Manger", "Ganesh", "Developer", "Srijith", "Developer"};
            string input2 = "Developer";


            solve(input1, input2);
        }
    }
}