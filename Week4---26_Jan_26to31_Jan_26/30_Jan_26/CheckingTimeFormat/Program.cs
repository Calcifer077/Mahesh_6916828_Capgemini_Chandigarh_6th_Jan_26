using System.Text.RegularExpressions;

namespace CheckingTimeFormat
{
    internal class Program
    {
        public static bool IsValidTime(string time)
        {
            return Regex.IsMatch(time, @"^(0[1-9]|1[0-2]):[0-5][0-9](am|pm)$", RegexOptions.IgnoreCase);
        }   

        static void Main(string[] args)
        {
            Console.WriteLine(IsValidTime("10:342PM"));
        }
    }
}