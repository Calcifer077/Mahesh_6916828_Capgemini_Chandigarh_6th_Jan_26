namespace ConsoleApp1CU
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             // Basic input output with conditional
                
                int x, y;
                Console.Write("Enter x value: ");
                x = int.Parse(Console.ReadLine());

                Console.Write("Enter y value: ");
                y = int.Parse(Console.ReadLine());

                if (x > y)
                {
                    Console.WriteLine("X is greateer than y");
                }
                else if (x < y)
                {
                    Console.WriteLine();
                }

             */

            /*
                // For each loop
                
                int[] arr = { 1, 2, 3, 4, 5 };

                foreach (var item in arr)
                {
                    Console.WriteLine(item);
                }
             */
            Footballer obj = new Footballer();
            obj.DisplayFootballeData();


        }
    }
}
