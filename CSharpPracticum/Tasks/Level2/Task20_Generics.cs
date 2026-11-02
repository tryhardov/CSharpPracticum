namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(20, "generic-методы, ref, ограничение where T : IComparable<T>")]
public sealed class Task20_Generics : ITask
{
    public string Title => "Обобщения: Swap<T>, Max<T>";

    public string Description => "Написать Swap<T> без ограничений и Max<T> с IComparable<T>.";

    public string[] Requirements =>
    [
        "Swap<T>(ref T a, ref T b)",
        "Max<T>(T a, T b) where T : IComparable<T>",
        "Показать на int, string, double",
    ];

    public void Run()
    {
        int i1 = 1, i2 = 2;
        GenericUtils.Swap(ref i1, ref i2);
        Console.WriteLine($"int:    Swap → {i1}, {i2}; Max(3, 7) = {GenericUtils.Max(3, 7)}");

        string s1 = "яблоко", s2 = "арбуз";
        GenericUtils.Swap(ref s1, ref s2);
        Console.WriteLine($"string: Swap → {s1}, {s2}; Max(\"abc\", \"abd\") = {GenericUtils.Max("abc", "abd")}");

        double d1 = 1.5, d2 = -2.5;
        GenericUtils.Swap(ref d1, ref d2);
        Console.WriteLine($"double: Swap → {d1}, {d2}; Max(1.5, -2.5) = {GenericUtils.Max(1.5, -2.5)}");
    }
}
