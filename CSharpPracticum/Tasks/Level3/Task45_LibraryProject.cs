namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(45, "классы Book/Reader/Library, свои исключения, xUnit (проект CSharpPracticum.Tests)")]
public sealed class Task45_LibraryProject : ITask
{
    public string Title => "Мини-проект «Библиотека» + тесты";

    public string Description => "Выдача и возврат книг с лимитом 3 книги на читателя; тесты — в CSharpPracticum.Tests.";

    public string[] Requirements =>
    [
        "Book, Reader, Library",
        "Лимит 3 книги, повторная выдача — исключения",
        "5+ юнит-тестов xUnit, все зелёные (dotnet test)",
    ];

    public void Run()
    {
        var library = new Library();
        var reader = new Reader("Анна");
        var books = new[]
        {
            new Book("Мастер и Маргарита", "Булгаков"), new Book("Идиот", "Достоевский"),
            new Book("Война и мир", "Толстой"), new Book("Евгений Онегин", "Пушкин"),
        };

        foreach (Book book in books)
        {
            try
            {
                library.Borrow(reader, book);
                Console.WriteLine($"Выдано: {book}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Отказ: {ex.Message}");
            }
        }

        try
        {
            library.Borrow(new Reader("Борис"), books[0]);
        }
        catch (BookNotAvailableException ex)
        {
            Console.WriteLine($"Отказ: {ex.Message}");
        }

        library.Return(reader, books[0]);
        Console.WriteLine($"Возвращено: {books[0]}; доступна: {books[0].IsAvailable}");
        Console.WriteLine("Тесты запускаются командой: dotnet test");
    }
}
