namespace CSharpPracticum.Tasks.Level3;

public sealed class CustomException : Exception
{
    public CustomException(string message) : base(message)
    {
    }
}
