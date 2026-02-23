namespace LongestSubstringWithoutRepeatingCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "abcabcbb";
            int output = 0;

            int left = 0, right = 0, n = s.Length;

            Dictionary<char, int> dict = new Dictionary<char, int>();

            while(right < n)
            {
                char r = s[right];

                if (dict.ContainsKey(r))
                {
                    dict[r] = dict[r] + 1;
                }
                else
                {
                    dict.Add(r, 1);
                }

                while(dict.Count < right - left + 1)
                {
                    dict[s[left]]--;
                    if (dict[s[left]] == 0)
                    {
                        dict.Remove(s[left]);
                    }
                    left++;
                }

                output = Math.Max(output, right - left + 1);
                right++;
            }

            Console.WriteLine("Input is: " + s);
            Console.WriteLine("Output is: " + output);

        }
    }
}
