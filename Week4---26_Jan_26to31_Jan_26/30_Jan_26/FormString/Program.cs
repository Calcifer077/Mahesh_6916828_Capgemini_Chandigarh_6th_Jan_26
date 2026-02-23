using System.Data;

namespace FormString
{
    internal class Program
    {
        public static string solve(string[] input1, int input2)
        {
            int index = input2 - 1;
            string result = "";
            foreach (string str in input1)
            {

                    foreach (var item in str)
                    {
                        if(!char.IsLetterOrDigit(item))
                    {
                        return "-1";
                    }
                    }

            // Logic to pick the nth character or $
            if (index >= 0 && index < str.Length)
            {
                result += str[index];
            }
            else
            {
                result += "$";
            }
        
            }
        return result;
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] input1 = new string[n];

            for(int i = 0; i < n; i++)
            {
                input1[i] = Console.ReadLine();
            }

            int input2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(solve(input1, input2));
        }
    }
}