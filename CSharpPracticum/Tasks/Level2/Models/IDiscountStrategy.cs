namespace CSharpPracticum.Tasks.Level2;

public interface IDiscountStrategy
{
    decimal Apply(decimal price);
}
