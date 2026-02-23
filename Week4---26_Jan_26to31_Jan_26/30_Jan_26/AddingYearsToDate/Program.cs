namespace AddingYeardsToDate
{
    internal class Program
    {
        public static int AddYearsToDate(string dateStr, int years)
        {
            if (years < 0) return -2;

            DateTime date;
            if (!DateTime.TryParseExact(
                dateStr,
                "dd/MM/yyyy",
                null,
                System.Globalization.DateTimeStyles.None,
                out date))
                return -1;

            DateTime newDate = date.AddYears(years);
            Console.WriteLine(newDate);
            return 1;
        }

        static void Main(string[] args)
        {
            AddYearsToDate("25/01/2024", 1);
        }
    }
}