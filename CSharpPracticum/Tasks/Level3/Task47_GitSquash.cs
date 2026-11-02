namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(47, "git rebase -i HEAD~4, pick/squash, git log --oneline")]
public sealed class Task47_GitSquash : ITask
{
    public string Title => "Git: rebase -i (сквош коммитов)";

    public string Description => "Объединить 4 маленьких коммита в один.";

    public string[] Requirements =>
    [
        "Ветка feature/squash-demo, 4 коммита",
        "git rebase -i HEAD~4 → squash",
        "git log --oneline до и после — в git-notes.md",
    ];

    public void Run()
    {
        GitHelper.PrintGuide(
            [
                "git switch -c feature/squash-demo",
                "4 маленьких коммита; git log --oneline → сохранить «ДО»",
                "git rebase -i HEAD~4: первый pick, остальные squash (или s) → сохранить редактор",
                "В редакторе сообщений оставить одно сообщение",
                "git log --oneline → сохранить «ПОСЛЕ» в git-notes.md (Task 47)",
            ],
            "branch --show-current",
            "log --oneline -n 8");
    }
}
