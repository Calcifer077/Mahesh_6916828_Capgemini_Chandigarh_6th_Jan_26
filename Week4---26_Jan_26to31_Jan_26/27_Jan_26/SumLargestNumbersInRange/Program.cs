namespace SumLargestNumbersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = {7 ,13 ,18 ,26 ,34, 58, 65, 54 };

            int output = 0;

            bool isNegative= false;
            bool isOutOfBounds = false;

            foreach (var item in input)
            {
                if(item < 0) isNegative = true;
                if(item < 0 || item > 100) isOutOfBounds = true;
            }

            if(isNegative && isOutOfBounds)
            {
                output = -3;
            }else if (isNegative)
            {
                output = -1;
            }else if (isOutOfBounds)
            {
                output = -2;
            }
            else
            {
                int max1 = 0, max2 = 0, max3 = 0, max4 = 0, max5 = 0, max6 = 0, max7 = 0, max8 = 0, max9 = 0, max10 = 0;

                foreach (var item in input)
                {
                    if(item <= 10)
                    {
                        max1 = Math.Max(max1, item);
                    }else if(item <= 20)
                    {
                        max2 = Math.Max(max2, item);
                    }else if(item <= 30)
                    {
                        max3 = Math.Max(max3, item);
                    }else if(item <= 40)
                    {
                        max4 = Math.Max(max4, item);
                    }else if(item <= 50)
                    {
                        max5 = Math.Max(max5, item);
                    }else if(item <= 60)
                    {
                        max6 = Math.Max(max6, item);
                    }else if(item <= 70)
                    {
                        max7 = Math.Max(max7, item);
                    }else if(item <= 80)
                    {
                        max8 = Math.Max(max8, item);
                    }else if(item <= 90)
                    {
                        max9 = Math.Max(max9, item);
                    }else if(item <= 100)
                    {
                        max10 = Math.Max(max10, item);
                    }
                }

                output = max1 + max2 + max3 + max4 + max5 + max6 + max7 + max8 + max9 + max10;
            }

            Console.WriteLine("Input is: [" + string.Join(',', input) + " ]");
            Console.WriteLine("Output is: " + output);
        }
    }
}
