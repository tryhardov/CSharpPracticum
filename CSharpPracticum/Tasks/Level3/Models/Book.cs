namespace CSharpPracticum.Tasks.Level3;

public sealed class Book
{
    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public string Title { get; }

    public string Author { get; }

    public bool IsAvailable { get; internal set; } = true;

    public override string ToString() => $"«{Title}» — {Author}";
}
