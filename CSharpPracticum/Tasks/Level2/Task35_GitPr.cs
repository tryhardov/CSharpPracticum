namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(35, "git add/commit/push, GitHub Pull Request, git rebase -i HEAD~3, Conventional Commits")]
public sealed class Task35_GitPr : ITask
{
    public string Title => "Git: PR, Conventional Commits, rebase";

    public string Description => "Пройти продвинутый git-сценарий с Pull Request и squash через rebase -i.";

    public string[] Requirements =>
    [
        ".gitignore и .editorconfig отдельным коммитом",
        "Ветка feature/task-35, 2–3 коммита Conventional Commits, push",
        "Pull Request в main и merge (можно squash)",
        "Ветка feature/rebase-demo, 3 коммита, rebase -i HEAD~3",
        "git log --oneline после rebase — в git-notes.md",
    ];

    public void Run()
    {
        GitHelper.PrintGuide(
            [
                "Коммит «chore: add gitignore and editorconfig» в main",
                "git switch -c feature/task-35 → 2–3 коммита feat/fix/docs",
                "git push -u origin feature/task-35",
                "На GitHub: Compare & pull request → описание (что сделано, что проверял) → Squash and merge",
                "git switch main && git pull; git switch -c feature/rebase-demo → 3 мелких коммита",
                "git rebase -i HEAD~3 (pick + два squash) → git log --oneline в git-notes.md",
            ],
            "branch -vv",
            "log --oneline -n 10");
    }
}
