namespace ReverseString
{
    internal class Program{
        static void Main(string[] args)
        {
            string input = "hello";

            string output = "";

            for(int i = input.Length - 1; i >= 0; i--)
            {
                output += input[i];
            }

            Console.WriteLine("Input is : " + input);
            Console.WriteLine("Output is: " + output);
        }
    }
}