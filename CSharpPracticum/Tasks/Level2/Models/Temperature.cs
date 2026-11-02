namespace CSharpPracticum.Tasks.Level2;

public sealed class Temperature
{
    public const double AbsoluteZeroCelsius = -273.15;

    private double _celsius;

    public Temperature(double celsius = 0)
    {
        Celsius = celsius;
    }

    public double Celsius
    {
        get => _celsius;
        set
        {
            if (double.IsNaN(value) || value < AbsoluteZeroCelsius)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value), value, $"Температура не может быть ниже {AbsoluteZeroCelsius} °C.");
            }

            _celsius = value;
        }
    }

    public double Fahrenheit => (_celsius * 9 / 5) + 32;
}
