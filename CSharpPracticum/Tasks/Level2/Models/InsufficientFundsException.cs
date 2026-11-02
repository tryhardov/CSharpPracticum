namespace CSharpPracticum.Tasks.Level2;

public sealed class InsufficientFundsException : Exception
{
    public InsufficientFundsException(decimal balance, decimal requested)
        : base($"Недостаточно средств: баланс {balance}, запрошено {requested}.")
    {
        Balance = balance;
        Requested = requested;
    }

    public decimal Balance { get; }

    public decimal Requested { get; }
}
