namespace StringCompression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "aaabbc";
            string output = "";

            int count = 1;
            for(int i = 1; i < input.Length; i++)
            {
                if(input[i] == input[i - 1])
                {
                    count++;
                }
                else
                {
                    output += input[i - 1];
                    output += (char) (count + '0');
                    count = 1;
                }
            }

            output += input[input.Length - 1];
            output += (char) (count + '0');

            Console.WriteLine("Input is: " + input);
            Console.WriteLine("Output is: " + output);
        }
    }
}