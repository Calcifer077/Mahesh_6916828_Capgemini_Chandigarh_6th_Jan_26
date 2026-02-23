using System;
using System.Text;

namespace Is_IsNot
{
    internal class Program{
        static void Main(string[] args){
            string input = "This is just a misconception";
            string output = "";

        StringBuilder sb = new StringBuilder();
        int length = input.Length;

        for (int i = 0; i < length; i++)
        {
            // Check if we found "is"
            if (i <= length - 2 && input[i] == 'i' && input[i + 1] == 's')
            {
                bool prefixIsLetter = false;
                bool suffixIsLetter = false;

                // Check character before 'i'
                if (i > 0 && char.IsLetter(input[i - 1]))
                {
                    prefixIsLetter = true;
                }

                // Check character after 's'
                if (i + 2 < length && char.IsLetter(input[i + 2]))
                {
                    suffixIsLetter = true;
                }

                // If it's a standalone word "is", replace it
                if (!prefixIsLetter && !suffixIsLetter)
                {
                    sb.Append("is not");
                    i++; // Skip the 's' since we handled it
                    continue;
                }
            }
            
            // Otherwise, just append the current character
            sb.Append(input[i]);
        }

        output = sb.ToString();

            Console.WriteLine("Input is: " + input);
            Console.WriteLine("Output is: " + output);
        }
    }
}