namespace CSharpPracticum.Tasks.Level2;

public sealed class Circle : IShape
{
    private readonly double _radius;

    public Circle(double radius)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(radius);
        _radius = radius;
    }

    public double Area() => Math.PI * _radius * _radius;

    public double Perimeter() => 2 * Math.PI * _radius;

    public override string ToString() => $"Круг(r={_radius})";
}
