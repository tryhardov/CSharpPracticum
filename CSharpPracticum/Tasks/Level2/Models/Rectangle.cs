namespace CSharpPracticum.Tasks.Level2;

public sealed class Rectangle : IShape
{
    private readonly double _width;
    private readonly double _height;

    public Rectangle(double width, double height)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(width);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(height);
        _width = width;
        _height = height;
    }

    public double Area() => _width * _height;

    public double Perimeter() => 2 * (_width + _height);

    public override string ToString() => $"Прямоугольник({_width}×{_height})";
}
