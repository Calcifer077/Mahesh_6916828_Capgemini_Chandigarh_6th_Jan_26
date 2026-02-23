namespace CountVowels
{
    internal class Program{
        public static bool isVowel(char a)
        {
            return a == 'a' || a == 'e' || a == 'i' || a == 'o' || a == 'u';
        }

        static void Main(string[] args)
        {
            string input = "this is the input";
            int output = 0;

            for(int i = 0; i < input.Length; i++)
            {
                if(isVowel(input[i])) output++;
            }

            Console.WriteLine("Input is: " + input);
            Console.WriteLine("Output is: " + output);
        }
    }
}