using System.Data;

namespace ReplaceString
{
    internal class Program
    {

        public static void solve(int n, string[] input1, char input2)
        {
            if(n <= 0)
            {
                Console.WriteLine("Number not positive");
                return;
            }else if (char.IsLetterOrDigit(input2))
            {
                Console.WriteLine("Character not a special character"); return;
            }

            List<string> list = new List<string>();

            for(int i = 0; i < n; i++)
            {
                foreach(var item in input1[i])
                {
                    if (!char.IsLetterOrDigit(item))
                    {
                        Console.WriteLine("Invalid String");
                        return;
                    }
                }
            }

            
            
            for(int i =0 ; i < input1.Length-1; i++)
            {
                Console.Write(input1[i] + " ");
            }
            
            for(int i = 0; i < input1[n - 1].Length; i++)
            {
                Console.Write(input2);
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

            int n = 5;
            string[] input1 = {"Hi", "are", "you", "fine", "ram"};
            char input2 = '*';

            solve(n, input1, input2);
        }
    }
}