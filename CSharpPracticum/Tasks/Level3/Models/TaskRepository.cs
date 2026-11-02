using System.Text.Encodings.Web;
using System.Text.Json;

namespace CSharpPracticum.Tasks.Level3;

public sealed class TaskRepository
{
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

    private readonly string _path;
    private readonly List<TaskItem> _items = [];

    public TaskRepository(string path)
    {
        _path = path;
        Load();
    }

    public string? LoadWarning { get; private set; }

    public IReadOnlyList<TaskItem> GetAll() => _items.ToList();

    public TaskItem? Get(int id) => _items.FirstOrDefault(t => t.Id == id);

    public TaskItem Add(string title)
    {
        var item = new TaskItem { Id = _items.Count == 0 ? 1 : _items.Max(t => t.Id) + 1, Title = title };
        _items.Add(item);
        Save();
        return item;
    }

    public void Save()
    {
        File.WriteAllText(_path, JsonSerializer.Serialize(_items, Options));
    }

    public bool Remove(int id)
    {
        int removed = _items.RemoveAll(t => t.Id == id);
        if (removed > 0)
        {
            Save();
        }

        return removed > 0;
    }

    private void Load()
    {
        if (!File.Exists(_path))
        {
            return;
        }

        try
        {
            var loaded = JsonSerializer.Deserialize<List<TaskItem>>(File.ReadAllText(_path));
            if (loaded is not null)
            {
                _items.AddRange(loaded);
            }
        }
        catch (Exception ex) when (ex is JsonException or IOException)
        {
            LoadWarning = $"Не удалось прочитать {_path}: {ex.Message}. Начинаем с пустого списка.";
        }
    }
}
