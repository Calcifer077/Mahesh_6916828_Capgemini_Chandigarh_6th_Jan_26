using System;

namespace Country_Code_Validation
{
    class InvalidCodeException : Exception
    {
        public InvalidCodeException(string message) : base(message) { }
    }

    class Repository
    {
        public static string GetCountryName(string CountryCode)
        {
            return RepositoryImplementation.GetCountryName(CountryCode);
        }
    }

    public class RepositoryImplementation
    {
        public static string GetCountryName(string CountryCode)
        {
            int code = Convert.ToInt32(CountryCode);

            if (code >= 70 && code <= 99)
            {
                return "India";
            }
            else if (code == 908)
            {
                return "USA";
            }
            else if (code == 011)
            {
                return "Dial somewhere outside of USA";
            }
            else
            {
                throw new InvalidCodeException("Error: Invalid Code Entered");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Country Code:");
            string input = Console.ReadLine();

            try
            {
                string result = Repository.GetCountryName(input);
                Console.WriteLine("Result: " + result);
            }
            catch (InvalidCodeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter numeric country code only.");
            }
        }
    }
}