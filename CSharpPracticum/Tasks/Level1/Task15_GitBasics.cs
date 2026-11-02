namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(15, "git init / add / commit / branch / switch / merge, ручное разрешение конфликта в README.md")]
public sealed class Task15_GitBasics : ITask
{
    public string Title => "Git: репозиторий, ветка, merge, конфликт";

    public string Description => "Пройти базовый git-сценарий и сохранить историю в git-notes.md.";

    public string[] Requirements =>
    [
        "git init, 2–3 коммита",
        "Ветка feature/git-basics, изменение, коммит, merge в main",
        "Смоделировать и вручную разрешить конфликт в README.md",
        "Сохранить git log --graph --oneline --all в git-notes.md",
    ];

    public void Run()
    {
        GitHelper.PrintGuide(
            [
                "git init (или используйте уже созданный репозиторий) и 2–3 осмысленных коммита",
                "git switch -c feature/git-basics → правка → commit",
                "git switch main → git merge feature/git-basics",
                "Правка одной и той же строки README.md в двух ветках → merge → убрать маркеры <<<<<<<",
                "git log --graph --oneline --all → вставить вывод в git-notes.md (раздел Task 15)",
            ],
            "status -sb",
            "log --graph --oneline --all -n 15");
    }
}
