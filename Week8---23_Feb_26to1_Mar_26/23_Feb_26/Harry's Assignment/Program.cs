namespace Harry_s_Assignment
{
    class StringPlay
    {
        public int Convert {  get; set; }
        public int Max {  get; set; }
    }

    class StringMethods
    {
        public int ConvertToInt(StringPlay sp, string str)
        {
            sp.Convert = Convert.ToInt32(str);

            return sp.Convert;
        }

        public int GetMax(StringPlay sp, string str, char ch)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (var item in str)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict.Add(item, 1);
                }
            }

            if (dict.ContainsKey(ch))
            {
                sp.Max = dict[ch];
            }   

            return sp.Max;
        }

    }

class Program
    {
        static void Main(string[] args)
        {
            StringPlay sp = new StringPlay();
            StringMethods sm = new StringMethods();

            // 🔹 Test 1: Convert String to Integer
            Console.WriteLine("Enter a number (string format): ");
            string inputNumber = Console.ReadLine();

            int result = sm.ConvertToInt(sp, inputNumber);
            Console.WriteLine("Converted Integer: " + result);

            Console.WriteLine();

            // 🔹 Test 2: Count Character Occurrence
            Console.WriteLine("Enter a string: ");
            string inputString = Console.ReadLine();

            Console.WriteLine("Enter a character to count: ");
            char ch = Convert.ToChar(Console.ReadLine());

            int count = sm.GetMax(sp, inputString, ch);
            Console.WriteLine($"Character '{ch}' occurred {count} times.");

            Console.WriteLine();

            // 🔹 Display values stored inside object
            Console.WriteLine("Stored in StringPlay Object:");
            Console.WriteLine("Convert Property: " + sp.Convert);
            Console.WriteLine("Max Property: " + sp.Max);
        }
    }
}
