namespace FirstNonRepatingCharacter
{
    internal class Program{

        static void Main(string[] args)
        {
            string input = "abcdeedcbaef";
            
            int[] arr = new int[26];

            char output = '$';

            for(int i = 0; i < input.Length; i++)
            {
                arr[input[i] - 'a']++;
            }

            for(int i = 0; i < input.Length; i++)
            {
                if(arr[input[i] - 'a'] == 1)
                {
                    output = input[i];
                    break;
                }
            }

            Console.WriteLine("Input is: " + input);
            Console.WriteLine("Output is: " + output);

        }
    }
}