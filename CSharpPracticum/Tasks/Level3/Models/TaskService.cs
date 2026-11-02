namespace CSharpPracticum.Tasks.Level3;

public sealed class TaskService
{
    private readonly TaskRepository _repository;

    public TaskService(TaskRepository repository)
    {
        _repository = repository;
    }

    public TaskItem Add(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Название задачи не может быть пустым.", nameof(title));
        }

        return _repository.Add(title.Trim());
    }

    public IReadOnlyList<TaskItem> GetAll() => _repository.GetAll();

    public bool MarkDone(int id)
    {
        TaskItem? item = _repository.Get(id);
        if (item is null)
        {
            return false;
        }

        item.IsDone = true;
        _repository.Save();
        return true;
    }

    public bool Delete(int id) => _repository.Remove(id);
}
