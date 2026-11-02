namespace CSharpPracticum.Tasks.Level2;

public sealed class Point : IEquatable<Point>
{
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }

    public int Y { get; }

    public bool Equals(Point? other) => other is not null && X == other.X && Y == other.Y;

    public override bool Equals(object? obj) => Equals(obj as Point);

    public override int GetHashCode() => HashCode.Combine(X, Y);

    public override string ToString() => $"({X}; {Y})";
}
