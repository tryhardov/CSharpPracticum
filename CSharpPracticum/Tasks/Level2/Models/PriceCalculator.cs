namespace CSharpPracticum.Tasks.Level2;

public sealed class PriceCalculator
{
    private readonly IDiscountStrategy _strategy;

    public PriceCalculator(IDiscountStrategy strategy)
    {
        _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
    }

    public decimal Calculate(decimal price)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(price);
        return _strategy.Apply(price);
    }
}
