namespace CSharpPracticum.Tasks.Level2;

public sealed class Triangle : IShape
{
    private readonly double _a;
    private readonly double _b;
    private readonly double _c;

    public Triangle(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0 || a + b <= c || a + c <= b || b + c <= a)
        {
            throw new ArgumentException("Треугольник с такими сторонами не существует.");
        }

        _a = a;
        _b = b;
        _c = c;
    }

    public double Area()
    {
        double p = Perimeter() / 2;
        return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
    }

    public double Perimeter() => _a + _b + _c;

    public override string ToString() => $"Треугольник({_a}, {_b}, {_c})";
}
