namespace CSharpPracticum.Tasks.Level2;

public sealed class MyQueue<T>
{
    private T[] _items = new T[4];
    private int _head;

    public int Count { get; private set; }

    public bool IsEmpty => Count == 0;

    public void Enqueue(T item)
    {
        if (Count == _items.Length)
        {
            Grow();
        }

        _items[(_head + Count) % _items.Length] = item;
        Count++;
    }

    public T Dequeue()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Очередь пуста.");
        }

        T item = _items[_head];
        _items[_head] = default!;
        _head = (_head + 1) % _items.Length;
        Count--;
        return item;
    }

    public T Peek() => IsEmpty ? throw new InvalidOperationException("Очередь пуста.") : _items[_head];

    private void Grow()
    {
        var bigger = new T[_items.Length * 2];
        for (int i = 0; i < Count; i++)
        {
            bigger[i] = _items[(_head + i) % _items.Length];
        }

        _items = bigger;
        _head = 0;
    }
}
