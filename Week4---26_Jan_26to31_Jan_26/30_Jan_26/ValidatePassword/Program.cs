namespace ValidatePassword
{
    internal class Program
    {
    public static int solve(string pwd)
        {
            if (pwd.Length < 8) return -1;
            if (char.IsDigit(pwd[0]) || !char.IsLetterOrDigit(pwd[0])) return -1;
            if (!char.IsLetterOrDigit(pwd[^1])) return -1;
            if (!pwd.Any(char.IsLetter)) return -1;
            if (!pwd.Any(char.IsDigit)) return -1;
            if (!pwd.Any(c => c == '@' || c == '#' || c == '_')) return -1;
            return 1;
        }

        static void Main(string[] args)
        {
           Console.WriteLine(solve("test12_j")) ;
        }
    }
}