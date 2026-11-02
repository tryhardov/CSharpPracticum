namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(26, "interface IDiscountStrategy, внедрение зависимости через конструктор, decimal")]
public sealed class Task26_Strategy : ITask
{
    public string Title => "Паттерн «Стратегия» (скидки)";

    public string Description => "Калькулятор цены, не знающий конкретных правил скидок.";

    public string[] Requirements =>
    [
        "IDiscountStrategy.Apply(decimal price)",
        "NoDiscount, VipDiscount (10%), PromoDiscount (20%)",
        "PriceCalculator принимает стратегию в конструкторе",
    ];

    public void Run()
    {
        const decimal price = 1000m;
        var strategies = new (string Name, IDiscountStrategy Strategy)[]
        {
            ("Без скидки", new NoDiscount()),
            ("VIP (10%)", new VipDiscount()),
            ("Промо (20%)", new PromoDiscount()),
        };

        foreach ((string name, IDiscountStrategy strategy) in strategies)
        {
            var calculator = new PriceCalculator(strategy);
            Console.WriteLine($"{name,-12} {price} → {calculator.Calculate(price)}");
        }
    }
}
