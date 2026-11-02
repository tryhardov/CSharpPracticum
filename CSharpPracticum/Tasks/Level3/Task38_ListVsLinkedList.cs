using System.Diagnostics;

namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(38, "List<T>.Insert, LinkedList<T>.AddAfter, LinkedListNode<T>, Stopwatch")]
public sealed class Task38_ListVsLinkedList : ITask
{
    private const int Size = 100_000;
    private const int Inserts = 1000;

    public string Title => "List vs LinkedList (бенчмарк)";

    public string Description => "Сравнить вставку в середину и доступ по индексу.";

    public string[] Requirements =>
    [
        "По 100 000 элементов в List<int> и LinkedList<int>",
        "1000 вставок в середину, замер Stopwatch",
        "Объяснение результата в комментарии",
    ];

    public void Run()
    {
        var list = new List<int>(Enumerable.Range(0, Size));
        var linked = new LinkedList<int>(Enumerable.Range(0, Size));

        var sw = Stopwatch.StartNew();
        for (int i = 0; i < Inserts; i++)
        {
            list.Insert(list.Count / 2, -i);
        }

        TimeSpan listTime = sw.Elapsed;

        sw.Restart();
        LinkedListNode<int> middle = linked.First!;
        for (int i = 0; i < Size / 2; i++)
        {
            middle = middle.Next!;
        }

        for (int i = 0; i < Inserts; i++)
        {
            linked.AddAfter(middle, -i);
        }

        TimeSpan linkedTime = sw.Elapsed;

        Console.WriteLine($"List.Insert:            {listTime.TotalMilliseconds:F3} мс");
        Console.WriteLine($"LinkedList.AddAfter:    {linkedTime.TotalMilliseconds:F3} мс (включая поиск середины)");

        sw.Restart();
        long sumList = 0;
        for (int i = 0; i < 1000; i++)
        {
            sumList += list[i * 50];
        }

        TimeSpan listIndex = sw.Elapsed;

        sw.Restart();
        long sumLinked = 0;
        for (int i = 0; i < 1000; i++)
        {
            sumLinked += linked.ElementAt(i * 50);
        }

        TimeSpan linkedIndex = sw.Elapsed;

        Console.WriteLine($"Доступ по индексу List:       {listIndex.TotalMilliseconds:F3} мс (O(1))");
        Console.WriteLine($"Доступ по индексу LinkedList: {linkedIndex.TotalMilliseconds:F3} мс (O(n), обход с начала)");
        Console.WriteLine($"(контрольные суммы: {sumList}/{sumLinked})");
        Console.WriteLine("Вывод: LinkedList быстрее при вставке по готовому узлу, но медленнее при поиске по индексу.");
    }
}
