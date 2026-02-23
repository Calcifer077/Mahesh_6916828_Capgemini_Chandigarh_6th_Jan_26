namespace ExtractFileExtension
{
    internal class Program
    {
        public static string GetFileExtension(string s)
        {
            return s.Split('.')[^1];
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetFileExtension("FIle.dat"));
        }
    }
}