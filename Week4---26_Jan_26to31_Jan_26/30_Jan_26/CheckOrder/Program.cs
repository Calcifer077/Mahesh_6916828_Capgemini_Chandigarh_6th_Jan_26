namespace CheckOrder
{
    internal class Program
    {
        static bool CheckOrder(string input1, string input2, string input3)
        {
            int i2 = input1.IndexOf(input2);
            int i3 = input1.IndexOf(input3);

            return i2 != -1 && i3 != -1 && i3 > i2;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(CheckOrder("todayisc#exam", "is", "exam"));
        }
    }
}