namespace Donations
{
    internal class Program{
        static void Main(string[] args)
        {
            // int n = Convert.ToInt32(Console.ReadLine());

            // string[] input1 = new string[n];
            // for(int i = 0; i < n; i++)
            // {
            //     input1[i] = Console.ReadLine();
            // }

            // string input2 = Console.ReadLine();

            int n = 4;
            string[] input1 = {"123111241", "124222456", "145111505", "124553567"};
            string input2 = "111";

            HashSet<string> set = new HashSet<string>();

            int output = 0;

            for(int i = 0; i < n; i++)
            {
                if (set.Contains(input1[i]))
                {
                    output = -1;
                    break;
                }

                foreach(char j in input1[i])
                {
                    if (!char.IsLetterOrDigit(j))
                    {
                        output = -2;
                        break;
                    }
                }
            }

            if(output == 0)
            {
                // do the main logic
                foreach (var item in input1)
                {
                    if(item[3] == input2[0] && item[4] == input2[1] && item[5] == input2[2])
                    {
                        output += int.Parse(item[6] + ""+ item[7] +""+item[8]);
                    }
                }
            }

            Console.WriteLine("Input is: [" + string.Join(',', input1) + "]");
            Console.WriteLine("Output is: " + output);
        }
    }
}