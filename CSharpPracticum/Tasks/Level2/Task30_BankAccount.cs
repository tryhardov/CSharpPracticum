namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(30, "class : Exception, throw, try/catch, decimal")]
public sealed class Task30_BankAccount : ITask
{
    public string Title => "BankAccount + своё исключение";

    public string Description => "Счёт с приватным балансом и InsufficientFundsException.";

    public string[] Requirements =>
    [
        "Приватный баланс, Deposit, Withdraw",
        "InsufficientFundsException : Exception",
        "Показать успешное снятие и превышение баланса",
    ];

    public void Run()
    {
        var account = new BankAccount(100m);
        account.Deposit(50m);
        Console.WriteLine($"После пополнения: {account.Balance}");

        account.Withdraw(120m);
        Console.WriteLine($"После снятия 120: {account.Balance}");

        try
        {
            account.Withdraw(500m);
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.WriteLine($"Баланс не изменился: {account.Balance}");
    }
}
