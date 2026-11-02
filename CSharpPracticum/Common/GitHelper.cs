using System.ComponentModel;
using System.Diagnostics;

namespace CSharpPracticum.Common;
public static class GitHelper
{
    public static void PrintGuide(string[] steps, params string[] stateCommands)
    {
        Console.WriteLine("Это git-задание: команды выполняются в терминале VS Code.");
        Console.WriteLine("Порядок действий:");
        for (int i = 0; i < steps.Length; i++)
        {
            Console.WriteLine($"  {i + 1}. {steps[i]}");
        }

        Console.WriteLine();
        Console.WriteLine("Подробности и команды для копирования — в GIT_GUIDE.md.");
        Console.WriteLine("Вывод ключевых команд сохраните в git-notes.md.");

        if (stateCommands.Length == 0)
        {
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Текущее состояние репозитория:");
        foreach (string command in stateCommands)
        {
            Show(command);
        }
    }
    public static void Show(string arguments)
    {
        Console.WriteLine($"$ git {arguments}");
        try
        {
            var info = new ProcessStartInfo("git", arguments)
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
            };

            using Process? process = Process.Start(info);
            if (process is null)
            {
                Console.WriteLine("(не удалось запустить git)");
                return;
            }

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            Console.Write(output);
            if (!string.IsNullOrWhiteSpace(error))
            {
                Console.Write(error);
            }
        }
        catch (Exception ex) when (ex is Win32Exception or InvalidOperationException)
        {
            Console.WriteLine($"(git недоступен: {ex.Message})");
        }
    }
}
