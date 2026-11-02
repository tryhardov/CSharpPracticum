namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(49, "git reset --hard HEAD~1, git reflog, git reset --hard <hash>")]
public sealed class Task49_GitReflog : ITask
{
    public string Title => "Git: восстановление через reflog";

    public string Description => "Удалить коммит через reset --hard и вернуть его по хешу из reflog.";

    public string[] Requirements =>
    [
        "Сделать коммит, затем git reset --hard HEAD~1",
        "Найти хеш в git reflog, git reset --hard <hash>",
        "git reflog и git log --oneline — в git-notes.md",
    ];

    public void Run()
    {
        GitHelper.PrintGuide(
            [
                "Работайте на временной ветке: git switch -c demo/reflog (в main так не делайте!)",
                "Создать файл, git commit; git log --oneline",
                "git reset --hard HEAD~1 — коммит «пропал»",
                "git reflog → найти хеш пропавшего коммита",
                "git reset --hard <hash> → git log --oneline; вывод — в git-notes.md (Task 49)",
            ],
            "reflog -n 8");
    }
}
