namespace AnagramCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s1 = "geeks";
            string s2 ="kseeg";

            int[] arr1 = new int[26];
            int[] arr2 = new int[26];

            for(int i = 0; i < s1.Length; i++)
            {
                arr1[s1[i] - 'a']++;
            }
            for(int i = 0; i < s2.Length; i++)
            {
                arr2[s2[i] - 'a']++;
            }

            bool output  = true;

            for(int i = 0; i < 26; i++)
            {
                if(arr1[i] != arr2[i])
                {
                    output = false;
                    break;
                }
            }

            Console.WriteLine("Input is: " + s1 + " " + s2);
            Console.WriteLine("Output is: "+output);
        }
    }
}