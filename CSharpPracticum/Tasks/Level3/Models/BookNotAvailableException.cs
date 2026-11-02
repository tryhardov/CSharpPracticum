namespace CSharpPracticum.Tasks.Level3;

public sealed class BookNotAvailableException : InvalidOperationException
{
    public BookNotAvailableException(Book book)
        : base($"Книга {book} уже выдана.")
    {
    }
}
