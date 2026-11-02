namespace CSharpPracticum.Tasks.Level2;

public sealed class FileWriter : IDisposable
{
    private readonly StreamWriter _writer;
    private bool _disposed;

    public FileWriter(string path, bool append = false)
    {
        _writer = new StreamWriter(path, append);
    }

    public bool IsDisposed => _disposed;

    public void WriteLine(string line)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        _writer.WriteLine(line);
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _writer.Dispose();
        _disposed = true;
    }
}
