namespace ConvertRomanToDecimal
{
    internal class Program
    {
        public static int RomanToDecimal(string roman)
    {
        // Map of Roman symbols to their integer values
        Dictionary<char, int> map = new Dictionary<char, int>
        {
            {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50},
            {'C', 100}, {'D', 500}, {'M', 1000}
        };

        int total = 0;

        for (int i = 0; i < roman.Length; i++)
        {
            // Check for invalid characters
            if (!map.ContainsKey(roman[i]))
            {
                return -1;
            }

            int currentVal = map[roman[i]];

            // Check the next character to decide whether to add or subtract
            if (i + 1 < roman.Length && map.ContainsKey(roman[i + 1]))
            {
                int nextVal = map[roman[i + 1]];

                if (currentVal < nextVal)
                {
                    // Case: IV (4), IX (9), etc.
                    total -= currentVal;
                }
                else
                {
                    total += currentVal;
                }
            }
            else
            {
                // Last character or no valid next character
                total += currentVal;
            }
        }

        return total;
    }
        static void Main(string[] args)
        {
            string input = "XII";

            int output = RomanToDecimal(input);
            

            Console.WriteLine("Input is: " + input);
            Console.WriteLine("Output is: " + output);
        }
    }
}