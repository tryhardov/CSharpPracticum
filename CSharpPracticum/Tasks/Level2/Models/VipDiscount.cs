namespace CSharpPracticum.Tasks.Level2;

public sealed class VipDiscount : IDiscountStrategy
{
    public decimal Apply(decimal price) => price * 0.90m;
}
