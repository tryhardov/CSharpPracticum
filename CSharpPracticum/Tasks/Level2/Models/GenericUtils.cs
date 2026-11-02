namespace CSharpPracticum.Tasks.Level2;

public static class GenericUtils
{
    public static void Swap<T>(ref T a, ref T b) => (a, b) = (b, a);
    public static T Max<T>(T a, T b) where T : IComparable<T> => a.CompareTo(b) >= 0 ? a : b;
}
