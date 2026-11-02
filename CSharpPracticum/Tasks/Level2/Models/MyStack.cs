namespace CSharpPracticum.Tasks.Level2;

public sealed class MyStack<T>
{
    private T[] _items = new T[4];

    public int Count { get; private set; }

    public bool IsEmpty => Count == 0;

    public void Push(T item)
    {
        if (Count == _items.Length)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }

        _items[Count++] = item;
    }

    public T Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Стек пуст.");
        }

        T item = _items[--Count];
        _items[Count] = default!;
        return item;
    }

    public T Peek() => IsEmpty ? throw new InvalidOperationException("Стек пуст.") : _items[Count - 1];
}
