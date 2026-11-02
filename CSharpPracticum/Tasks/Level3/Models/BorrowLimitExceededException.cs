namespace CSharpPracticum.Tasks.Level3;

public sealed class BorrowLimitExceededException : InvalidOperationException
{
    public BorrowLimitExceededException(Reader reader, int limit)
        : base($"{reader.Name} уже взял максимум книг ({limit}).")
    {
    }
}
