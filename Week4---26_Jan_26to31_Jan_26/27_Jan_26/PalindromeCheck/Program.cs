namespace PalindromeCheck
{
    internal class Program{

        static void Main(string[] args)
        {
            string input = "abcdeedcba";
            
            bool output = true;

            for(int i = 0; i < input.Length / 2; i++)
            {
                if(input[i] != input[input.Length - i - 1])
                {
                    output = false;
                }
            }

            Console.WriteLine("Input is: " + input);
            Console.WriteLine("Output is: " + output);
        }
    }
}