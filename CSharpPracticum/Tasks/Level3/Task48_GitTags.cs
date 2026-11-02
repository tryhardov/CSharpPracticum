namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(48, "git tag -a, git push origin <tag>, git show <tag>")]
public sealed class Task48_GitTags : ITask
{
    public string Title => "Git: теги (v1.0.0)";

    public string Description => "Поставить аннотированный тег на стабильный коммит main и запушить его.";

    public string[] Requirements =>
    [
        "git tag -a v1.0.0 -m \"Release v1.0.0\" на main",
        "git push origin v1.0.0",
        "git tag и git show v1.0.0 — в git-notes.md",
    ];

    public void Run()
    {
        GitHelper.PrintGuide(
            [
                "git switch main (после merge level-3, dotnet build и dotnet test зелёные)",
                "git tag -a v1.0.0 -m \"Release v1.0.0\"",
                "git push origin v1.0.0",
                "git tag; git show v1.0.0 → вывод в git-notes.md (Task 48)",
            ],
            "tag",
            "log --oneline --decorate -n 5");
    }
}
