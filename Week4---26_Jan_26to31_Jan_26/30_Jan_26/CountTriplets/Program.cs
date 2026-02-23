namespace CountTriplets
{
    internal class Program
    {
        static int CountTripleRepeats(string input)
        {
            int count = 0;

            for (int i = 0; i < input.Length - 2; i++)
            {
                if (input[i] == input[i + 1] && input[i] == input[i + 2])
                    count++;
            }
            return count;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(CountTripleRepeats("abcdddefggg"));
        }
    }
}