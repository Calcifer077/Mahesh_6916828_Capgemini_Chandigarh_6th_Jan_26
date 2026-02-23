namespace MaxDiffInArray
{
    internal class MaxDiffInArray
    {
        static void Main(string[] args)
        {
            int[] input = {2, 3, 10, 6, 4, 8, 1 };

            int output = 0;

            bool hasNeg = false;

            foreach (var item in input)
            {
                if(item  < 0)
                {
                    hasNeg = true;
                    break;
                }
            }

            if (hasNeg)
            {
                output = -1;
            }
            else
            {
                HashSet<int> set = new HashSet<int>();
                foreach (var item in input)
                {
                    if (set.Contains(item))
                    {
                        output = -3;
                    }

                    set.Add(item);
                }

                if(output == 0)
                {
                    if(input.Length == 1 || input.Length > 10)
                    {
                        output = -2;
                    }
                    else
                    {
                        for(int i = 0; i < input.Length; i++)
                        {
                            for(int j = i + 1; j < input.Length; j++)
                            {
                                if(input[j] > input[i])
                                {   
                                    output = Math.Max(output, input[j] - input[i]);
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Input is: [" + string.Join(',', input) + "]");
            Console.WriteLine("Output is: " + output);
        }
    }
}