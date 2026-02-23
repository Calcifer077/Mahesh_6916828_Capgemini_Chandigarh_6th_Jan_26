namespace BankManagementApp
{
    internal class Program
    {
        class BankAccount {
            public int balance { get; set; }
            public string name { get; set; }

            public BankAccount(int balance, string name)
            {
                this.balance = balance;
                this.name = name;
            }
        }

        class SavingsAccount : BankAccount {
            BankAccount obj;
            public double intRate;
            public SavingsAccount(int balance, string name, double intRate) : base(balance, name) { 
                    obj = new BankAccount(balance, name);
                this.intRate = intRate;
            }

            public void WithdrawMoney(int amount) { 
                if(obj.balance >= amount)
                {
                    obj.balance -= amount;

                    Console.WriteLine("Amount withdrawn. Available balance: " + obj.balance);
                }
                else
                {
                    Console.WriteLine("Insufficient balance.");
                }
            }

            public void DepositMoney(int amount) {
                obj.balance += amount;
                Console.WriteLine("Amount deposited. Available balance: " + obj.balance);
            }

            public void DisplayInformation()
            {
                Console.WriteLine("This account belong to " + obj.name);
                Console.WriteLine("The avalaible balance is " + obj.balance);
                Console.WriteLine("The interest rate on this accout is " + intRate);
            }

            public void InterestCalculation(int years)
            {
                Console.WriteLine($"{years} years interest calculation: ");
                Console.WriteLine((obj.balance * years * intRate) / 100);
            }
        }
        
        class CheckingAccount : BankAccount {
            BankAccount obj;
            public CheckingAccount(int balance, string name) : base(balance, name)
            {
                obj = new BankAccount(balance, name);
            }

            public void WithdrawMoney(int amount)
            {
                if (obj.balance >= amount)
                {
                    obj.balance -= amount;

                    Console.WriteLine("Amount withdrawn. Available balance: " + obj.balance);
                }
                else
                {
                    Console.WriteLine("Insufficient balance.");
                }
            }

            public void DepositMoney(int amount)
            {
                obj.balance += amount;
                Console.WriteLine("Amount deposited. Available balance: " + obj.balance);
            }

            public void DisplayInformation()
            {
                Console.WriteLine("This account belong to " + obj.name);
                Console.WriteLine("The avalaible balance is " + obj.balance);
            }
        }

        static void Main(string[] args)
        {
            SavingsAccount acc1 = new SavingsAccount(1000, "Mahesh", 2.0);
            acc1.DepositMoney(2000);
            //acc1.WithdrawMoney(5000);
            //acc1.DisplayInformation();

            acc1.InterestCalculation(3);

            CheckingAccount acc2 = new CheckingAccount(1000, "Mahe");
            //acc2.DepositMoney(10000);
            //acc2.WithdrawMoney(500);
            //acc2.DisplayInformation();

        }
    }
}