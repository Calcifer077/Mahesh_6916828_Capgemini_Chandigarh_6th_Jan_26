namespace DigitSumInStringArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] str = new string[n];

            for(int i = 0; i < n; i++) str[i] = Console.ReadLine();

            int output = 0;

            for(int i = 0; i < n; i++)
            {
                foreach (var item in str[i])
                {
                    if(!char.IsLetterOrDigit(item))
                    {
                        output = -1;
                        break;
                    }
                    else
                    {
                        if (char.IsDigit(item))
                        {
                            output += item - '0';
                        }
                    }
                }

                if(output == -1) break;
            }

            Console.WriteLine("Input is: [" + string.Join(',', str) + "]");
            Console.WriteLine("Output is: " + output);
        }
    }
}