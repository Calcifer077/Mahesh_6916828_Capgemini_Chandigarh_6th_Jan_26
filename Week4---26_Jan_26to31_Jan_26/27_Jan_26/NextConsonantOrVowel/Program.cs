namespace NextConsonantOrVowel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "zebRa";

            string output = solve(input);
            Console.WriteLine("Input is: " + input);
            Console.WriteLine("Output is: " + output);
        }

        static string solve(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    return "Invalid input";
                }
                if (char.IsDigit(c))
                {
                    return "Invalid input";
                }
            }

            string vowels = "aeiouAEIOU";
            string consonants = "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ";
            
            Dictionary<char, char> vowelToConsonant = new Dictionary<char, char>
            {
                {'a', 'b'}, {'e', 'f'}, {'i', 'j'}, {'o', 'p'}, {'u', 'v'},
                {'A', 'B'}, {'E', 'F'}, {'I', 'J'}, {'O', 'P'}, {'U', 'V'}
            };

            Dictionary<char, char> consonantToVowel = new Dictionary<char, char>
            {
                
                {'b', 'e'}, {'c', 'e'}, {'d', 'e'}, {'f', 'i'}, {'g', 'i'}, {'h', 'i'}, {'j', 'o'}, {'k', 'o'}, {'l', 'o'}, {'m', 'o'}, {'n', 'o'}, {'p', 'u'}, {'q', 'u'}, {'r', 'u'}, {'s', 'u'}, {'t', 'u'}, {'v', 'a'}, {'w', 'a'}, {'x', 'a'}, {'y', 'a'}, {'z', 'a'},
                {'B', 'E'}, {'C', 'E'}, {'D', 'E'}, {'F', 'I'}, {'G', 'I'}, {'H', 'I'}, {'J', 'O'}, {'K', 'O'}, {'L', 'O'}, {'M', 'O'}, {'N', 'O'}, {'P', 'U'}, {'Q', 'U'}, {'R', 'U'}, {'S', 'U'}, {'T', 'U'}, {'V', 'A'}, {'W', 'A'}, {'X', 'A'}, {'Y', 'A'}, {'Z', 'A'}
            };

            string result = "";
            foreach (char c in input)
            {
                if (vowels.Contains(c))
                {
                    result += vowelToConsonant[c];
                }
                else if (consonants.Contains(c))
                {
                    result += consonantToVowel[c];
                }
            }

            return result;
        }
    }
}
