namespace ConvertRomanToDecimal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = {"abc", "Apple", "Mango"};
            char input2 = 'a';

            int output = 0;

            bool flag = false;

            for(int i = 0; i < input1.Length; i++)
            {
                if(input1[i][0].ToString().ToLower() == input2.ToString().ToLower()) output ++;
                foreach (var item in input1[i])
                {
                    if(!Char.IsLetter(item)) flag = true;
                }
            }

            if(output == 0)
            {
                output = -1;
            }else if(flag)
            {
                output = -2;
            }
            Console.WriteLine("Input is: [" + string.Join(',', input1) + "]");
            Console.WriteLine("Output is: " + output);
        }
    }
}