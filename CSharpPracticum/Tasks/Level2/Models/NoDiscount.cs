namespace CSharpPracticum.Tasks.Level2;

public sealed class NoDiscount : IDiscountStrategy
{
    public decimal Apply(decimal price) => price;
}
