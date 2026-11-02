using System.Globalization;

namespace CSharpPracticum.Common;

public static class ConsoleHelper
{
    public static string ReadLine(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? throw new EndOfStreamException("Ввод закрыт.");
    }
    public static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
    {
        while (true)
        {
            string input = ReadLine(prompt).Trim();
            if (int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value)
                && value >= min && value <= max)
            {
                return value;
            }

            Console.WriteLine("Некорректный ввод, попробуйте ещё раз.");
        }
    }
    public static double ReadDouble(string prompt)
    {
        while (true)
        {
            string input = ReadLine(prompt).Trim().Replace(',', '.');
            if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double value)
                && double.IsFinite(value))
            {
                return value;
            }

            Console.WriteLine("Некорректный ввод, попробуйте ещё раз.");
        }
    }
}
