public class BankOperations : IBankAccountOperation
{
    decimal bal = 0;

    public void Deposit(decimal d)
    {
        bal += d;
    }

    public void Withdraw(decimal d)
    {
        if (bal >= d)
            bal -= d;
    }

    public decimal ProcessOperation(string message)
    {
        message = message.ToLower();

        decimal amount = 0;

        string[] words = message.Split(" ");

        foreach (var item in words)
        {
            bool flag = true;

            for (int i = 0; i < item.Length; i++)
            {
                if (item[i] < '0' || item[i] > '9')
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                amount = Convert.ToDecimal(item);
                break;
            }
        }

        if (message.Contains("deposit") ||
            message.Contains("put") ||
            message.Contains("invest") ||
            message.Contains("transfer"))
        {
            Deposit(amount);
        }
        else if (message.Contains("withdraw") ||
                 message.Contains("pull"))
        {
            Withdraw(amount);
        }

        return bal;
    }
}