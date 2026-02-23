
// A very simple example to show exception handling
/*
internal class Program
{
    private static void Main(string[] args)
    {
        // Try will containt the code that can have any kind of exception
        try
        {
            int[] num = {1, 2,3};
            Console.WriteLine(num[3]);
        
        // If there is any kind of exception, catch will handle it and print the message.
        // We get 'Exception' object as parameter in catch block, which contains details of error.
        }catch(Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine(ex.Message);
        }
        // Below piece of code will run whether there is an exception or not. It is used to release any resources that we have used in try block.
        finally
        {
            Console.WriteLine("This will always execute");
        }
    }
}
*/

// Throw keyword is used to throw an exception explicitly. We can create our own custom exception and throw it when some specific condition is met.
/*
internal class Program
{
    public static void Main(string[] args)
    {
        int age = 12;
        try
        {
            if (age < 18)
            {
                throw new ArithmeticException("Access denied - You must be at least 18 years old.");
            }
            else
            {
                Console.WriteLine("Access granted - You are old enough!");
            }
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
*/

// Custom Exception
// Custom exceptions are user-defined exception classes created by inheriting from the base System.Exception class. They allow developers to
// Provide meaningful exception names.
// Add custom messages.
// Include additional properties for error details.

// A simple example of a custom exception to validate age input. If the age is less than 18, we will throw an InvalidAgeException with a custom message.
/*
class InvalidAgeException : Exception
{
    // Calling parent class constructor to initialize the message property of the exception
    public InvalidAgeException(string message) : base(message)
    {
    }
}
class Program
{
    static void Main()
    {
        int age = 15;

        try
        {
            if (age < 18)
            {
                throw new InvalidAgeException("Age must be 18 or above.");
            }
            Console.WriteLine("Access granted.");
        }
        catch (InvalidAgeException ex)
        {
            Console.WriteLine("Custom Exception Caught: " + ex.Message);
        }
    }
}
*/

// Example with additional property
/*
class AccountBalanceException : Exception
{
    public double CurrentBalance { get; }

    public AccountBalanceException(string message, double balance) 
        : base(message)
    {
        CurrentBalance = balance;
    }
}

class Program
{
    static void Main()
    {
        double balance = 500;

        try
        {
            double withdraw = 700;

            if (withdraw > balance)
            {
                throw new AccountBalanceException("Insufficient balance.", balance);
            }

            balance -= withdraw;
            Console.WriteLine("Withdrawal successful. Balance: " + balance);
        }
        catch (AccountBalanceException ex)
        {
            Console.WriteLine($"{ex.Message} Current Balance: {ex.CurrentBalance}");
        }
    }
}
*/