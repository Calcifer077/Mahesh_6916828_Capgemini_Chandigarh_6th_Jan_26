using System.Text.RegularExpressions;

namespace ValidateHex
{
    internal class Program
    {
        public static bool IsValidHexColor(string color)
        {
            return Regex.IsMatch(color, @"^#[0-9A-Fa-f]{6}$");
        }

        static void Main(string[] args)
        {
            Console.WriteLine(IsValidHexColor("#FF5731"));
        }
    }
}
