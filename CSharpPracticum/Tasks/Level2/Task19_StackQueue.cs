namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(19, "обобщённые классы MyStack<T>, MyQueue<T>; Array.Resize; InvalidOperationException")]
public sealed class Task19_StackQueue : ITask
{
    public string Title => "Свой стек и очередь на массиве";

    public string Description => "Реализовать MyStack<T> и MyQueue<T> с расширением массива.";

    public string[] Requirements =>
    [
        "Стек: Push, Pop, Peek, Count, IsEmpty",
        "Очередь: Enqueue, Dequeue, Peek, Count, IsEmpty",
        "Удвоение массива при переполнении",
        "Пустая коллекция — InvalidOperationException",
    ];

    public void Run()
    {
        var stack = new MyStack<int>();
        for (int i = 1; i <= 6; i++)
        {
            stack.Push(i * 10);
        }

        Console.WriteLine($"Стек: Count={stack.Count}, Peek={stack.Peek()}");
        Console.WriteLine($"Pop: {stack.Pop()}, {stack.Pop()}; Count={stack.Count}");

        var queue = new MyQueue<string>();
        foreach (string s in new[] { "a", "b", "c", "d", "e" })
        {
            queue.Enqueue(s);
        }

        Console.WriteLine($"Очередь: Count={queue.Count}, Peek={queue.Peek()}");
        Console.WriteLine($"Dequeue: {queue.Dequeue()}, {queue.Dequeue()}; Count={queue.Count}");

        var empty = new MyStack<int>();
        try
        {
            empty.Pop();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Pop из пустого стека → {ex.Message}");
        }

        try
        {
            new MyQueue<int>().Dequeue();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Dequeue из пустой очереди → {ex.Message}");
        }
    }
}
