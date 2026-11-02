namespace CSharpPracticum.Tasks.Level3;

public sealed class Library
{
    public const int MaxBooksPerReader = 3;

    public void Borrow(Reader reader, Book book)
    {
        ArgumentNullException.ThrowIfNull(reader);
        ArgumentNullException.ThrowIfNull(book);

        if (!book.IsAvailable)
        {
            throw new BookNotAvailableException(book);
        }

        if (reader.BorrowedBooks.Count >= MaxBooksPerReader)
        {
            throw new BorrowLimitExceededException(reader, MaxBooksPerReader);
        }

        book.IsAvailable = false;
        reader.AddBook(book);
    }
    public void Return(Reader reader, Book book)
    {
        ArgumentNullException.ThrowIfNull(reader);
        ArgumentNullException.ThrowIfNull(book);

        if (!reader.RemoveBook(book))
        {
            throw new InvalidOperationException($"Книга {book} не числится за читателем {reader.Name}.");
        }

        book.IsAvailable = true;
    }
}
