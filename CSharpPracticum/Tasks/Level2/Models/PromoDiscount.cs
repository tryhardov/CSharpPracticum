namespace CSharpPracticum.Tasks.Level2;

public sealed class PromoDiscount : IDiscountStrategy
{
    public decimal Apply(decimal price) => price * 0.80m;
}
