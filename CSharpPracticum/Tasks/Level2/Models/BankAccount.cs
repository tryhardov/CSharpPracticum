namespace CSharpPracticum.Tasks.Level2;

public sealed class BankAccount
{
    private decimal _balance;

    public BankAccount(decimal initialBalance = 0)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(initialBalance);
        _balance = initialBalance;
    }

    public decimal Balance => _balance;

    public void Deposit(decimal amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        _balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        if (amount > _balance)
        {
            throw new InsufficientFundsException(_balance, amount);
        }

        _balance -= amount;
    }
}
