using System;

class CreditCard
{
    public string CardNumber { get; private set; }
    public string CardHolderName { get; private set; }
    public double Balance { get; private set; }

    public CreditCard(string cardNumber, string cardHolderName, double initialBalance)
    {
        CardNumber = cardNumber;
        CardHolderName = cardHolderName;
        Balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposited {amount} to the card. New balance: {Balance}");
    }

    public void Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawn {amount} from the card. New balance: {Balance}");
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }

    public void Transfer(double amount, CreditCard recipient)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            recipient.Deposit(amount);
            Console.WriteLine($"Transferred {amount} to {recipient.CardHolderName}. New balance: {Balance}");
        }
        else
        {
            Console.WriteLine("Insufficient funds for transfer.");
        }
    }


    public static CreditCard operator +(CreditCard card, double amount)
    {
        card.Deposit(amount);
        return card;
    }
    public static CreditCard operator -(CreditCard card, double amount)
    {
        card.Withdraw(amount);
        return card;
    }
    public static bool operator ==(CreditCard card1, CreditCard card2)
    {
        if (ReferenceEquals(card1, card2))
            return true;
        if (card1 is null || card2 is null)
            return false;
        return card1.CardNumber == card2.CardNumber;
    }
    public static bool operator !=(CreditCard card1, CreditCard card2)
    {
        return !(card1 == card2);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        CreditCard other = (CreditCard)obj;
        return this.CardNumber == other.CardNumber;
    }

    public override int GetHashCode()
    {
        return CardNumber.GetHashCode();
    }
}

class Program
{
    static void Main(string[] args)
    {
        CreditCard card1 = new CreditCard("1234 5678 9012 3456", "John Doe", 1000);
        CreditCard card2 = new CreditCard("9876 5432 1098 7654", "Jane Smith", 500);

        // Deposit
        card1 += 200;
        Console.WriteLine();

        // Withdraw
        card1 -= 100;
        Console.WriteLine();

        // Transfer
        card1.Transfer(300, card2);
        Console.WriteLine();

        // Check equality
        if (card1 == card2)
        {
            Console.WriteLine("The cards have the same number.");
        }
        else
        {
            Console.WriteLine("The cards have different numbers.");
        }
    }
}
