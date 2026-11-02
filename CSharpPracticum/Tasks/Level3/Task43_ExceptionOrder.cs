namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(43, "несколько catch (от частного к общему), finally, свой Exception")]
public sealed class Task43_ExceptionOrder : ITask
{
    public string Title => "Порядок catch и finally";

    public string Description => "Три вида исключений ловятся своими блоками, finally выполняется всегда.";

    public string[] Requirements =>
    [
        "FormatException, DivideByZeroException, CustomException",
        "catch от частного к общему",
        "finally с выводом «завершено»",
        "Комментарий, почему порядок важен",
    ];

    public static void Throwing(int scenario)
    {
        switch (scenario)
        {
            case 1:
                _ = int.Parse("не число");
                break;
            case 2:
                int zero = 0;
                _ = 10 / zero;
                break;
            case 3:
                throw new CustomException("Своё исключение");
            default:
                Console.WriteLine("Исключения не будет.");
                break;
        }
    }


    public void Run()
    {
        for (int scenario = 1; scenario <= 4; scenario++)
        {
            Console.WriteLine($"Сценарий {scenario}:");
            try
            {
                Throwing(scenario);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"  FormatException: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"  DivideByZeroException: {ex.Message}");
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"  CustomException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  Прочее: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("  завершено");
            }
        }
    }
}
