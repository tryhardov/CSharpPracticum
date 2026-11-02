namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(50, "git bisect start/bad/good/reset, scripts/bisect-demo.sh создаёт демонстрационный репозиторий")]
public sealed class Task50_GitBisect : ITask
{
    public string Title => "Git: bisect (поиск плохого коммита)";

    public string Description => "Найти коммит, сломавший функцию, бинарным поиском по истории.";

    public string[] Requirements =>
    [
        "Репозиторий с 10+ коммитами, один из средних ломает функцию",
        "git bisect start / bad / good <hash>, шаги good/bad",
        "Найти плохой коммит, git bisect reset",
        "Вывод — в git-notes.md",
    ];

    public void Run()
    {
        GitHelper.PrintGuide(
            [
                "bash scripts/bisect-demo.sh — создаст отдельный репозиторий /tmp/bisect-demo (12 коммитов, 7-й плохой)",
                "cd /tmp/bisect-demo && git bisect start",
                "git bisect bad; git bisect good <хеш первого коммита> (git log --oneline)",
                "На каждом шаге: bash check.sh; echo $? → git bisect good (0) или git bisect bad (1)",
                "Git назовёт первый плохой коммит → git bisect log → git bisect reset",
                "Вывод — в git-notes.md (Task 50). Бонус: git bisect run bash check.sh",
            ]);
    }
}
