namespace CSharpPracticum.Tasks.Level3;

public sealed class Reader
{
    private readonly List<Book> _borrowed = [];

    public Reader(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public IReadOnlyList<Book> BorrowedBooks => _borrowed;

    internal void AddBook(Book book) => _borrowed.Add(book);

    internal bool RemoveBook(Book book) => _borrowed.Remove(book);
}
