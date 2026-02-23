namespace ListTheElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = {1,4,7,3,9,15,24};
            int input2 = 17;

            int output = 0;

            Console.WriteLine("Input is: [" + string.Join(',', input1) + "]");
            Console.WriteLine("Output is: [ ");
            foreach(var item in input1)
            {
                if(item < input2)
                {
                    output = -1;
                    Console.WriteLine(item + " ");
                }
            }

            if(output == 0)
                {
                    Console.Write(" -1]");
                }
        }
    }
}