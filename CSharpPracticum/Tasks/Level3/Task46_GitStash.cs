namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(46, "git stash, git stash list, git switch, git stash pop")]
public sealed class Task46_GitStash : ITask
{
    public string Title => "Git: stash / stash pop";

    public string Description => "Спрятать незакоммиченные изменения и вернуть их.";

    public string[] Requirements =>
    [
        "Незакоммиченные изменения → git stash",
        "git stash list — до и после",
        "Переключиться на другую ветку и обратно, git stash pop",
        "Вывод сохранить в git-notes.md",
    ];

    public void Run()
    {
        GitHelper.PrintGuide(
            [
                "Внести правку в файл (например, README.md), не коммитить",
                "git stash list (пусто) → git stash → git stash list (запись stash@{0})",
                "git switch другая-ветка → git switch level-3",
                "git stash pop → git stash list (пусто)",
                "Оба вывода git stash list — в git-notes.md (Task 46)",
            ],
            "stash list",
            "status -sb");
    }
}
