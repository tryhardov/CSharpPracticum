using System.Globalization;
using System.Data;
using Microsoft.Data.SqlClient;

internal static class Program
{
    private static int Main()
    {
        string? connectionString = Environment.GetEnvironmentVariable("PRACTICE_DB_CONNECTION");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            Console.Error.WriteLine("Задайте строку подключения в PRACTICE_DB_CONNECTION.");
            return 1;
        }

        Console.WriteLine("Задания по интеграции с PracticeDB");
        Console.WriteLine("28. Поиск сотрудников отдела");
        Console.WriteLine("29. Назначение сотрудника на проект");
        Console.WriteLine("30. Отчёт по отделам");
        Console.Write("Выберите задание (28–30): ");

        if (!int.TryParse(Console.ReadLine(), out int taskNumber) || taskNumber is < 28 or > 30)
        {
            Console.Error.WriteLine("Введите номер задания 28, 29 или 30.");
            return 1;
        }

        try
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            bool succeeded = taskNumber switch
            {
                28 => FindEmployeesByDepartment(connection),
                29 => AssignEmployeeToProject(connection),
                30 => PrintDepartmentReport(connection),
                _ => false
            };

            return succeeded ? 0 : 1;
        }
        catch (SqlException exception)
        {
            Console.Error.WriteLine(
                $"Ошибка SQL Server (код {exception.Number}): {exception.Message}");
            return 1;
        }
    }

    private static bool FindEmployeesByDepartment(SqlConnection connection)
    {
        if (!TryReadInt("ID отдела: ", 1, out int departmentId))
        {
            return false;
        }

        const string sql = """
            SELECT EmployeeId, EmployeeName, Salary, HireDate
            FROM dbo.Employees
            WHERE DepartmentId = @DepartmentId
            ORDER BY Salary DESC, EmployeeId;
            """;

        using var command = new SqlCommand(sql, connection);
        command.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = departmentId;

        using SqlDataReader reader = command.ExecuteReader();
        bool hasRows = false;
        while (reader.Read())
        {
            hasRows = true;
            Console.WriteLine(
                $"{reader.GetInt32(0)} | {reader.GetString(1)} | " +
                $"{reader.GetDecimal(2).ToString("N2", CultureInfo.CurrentCulture)} | " +
                $"{reader.GetDateTime(3):yyyy-MM-dd}");
        }

        if (!hasRows)
        {
            Console.WriteLine("В выбранном отделе сотрудники не найдены.");
        }

        return true;
    }

    private static bool AssignEmployeeToProject(SqlConnection connection)
    {
        if (!TryReadInt("ID сотрудника: ", 1, out int employeeId) ||
            !TryReadInt("ID проекта: ", 1, out int projectId) ||
            !TryReadInt("Количество часов (0 или больше): ", 0, out int hours))
        {
            return false;
        }

        const string sql = """
            INSERT INTO dbo.EmployeeProjects (EmployeeId, ProjectId, Hours)
            VALUES (@EmployeeId, @ProjectId, @Hours);
            """;

        using var command = new SqlCommand(sql, connection);
        command.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
        command.Parameters.Add("@ProjectId", SqlDbType.Int).Value = projectId;
        command.Parameters.Add("@Hours", SqlDbType.Int).Value = hours;

        int affectedRows = command.ExecuteNonQuery();
        Console.WriteLine($"Добавлено назначений: {affectedRows}.");
        return true;
    }

    private static bool PrintDepartmentReport(SqlConnection connection)
    {
        const string sql = """
            SELECT
                d.DepartmentName,
                COUNT(e.EmployeeId) AS EmployeeCount,
                COALESCE(ROUND(AVG(e.Salary), 2), 0) AS AverageSalary,
                COALESCE(SUM(e.Salary), 0) AS TotalSalary
            FROM dbo.Departments AS d
            LEFT JOIN dbo.Employees AS e ON e.DepartmentId = d.DepartmentId
            GROUP BY d.DepartmentId, d.DepartmentName
            ORDER BY d.DepartmentId;
            """;

        using var command = new SqlCommand(sql, connection);
        using SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader.GetString(0)} | сотрудников: {reader.GetInt32(1)} | " +
                $"средняя зарплата: {reader.GetDecimal(2).ToString("N2", CultureInfo.CurrentCulture)} | " +
                $"сумма: {reader.GetDecimal(3).ToString("N2", CultureInfo.CurrentCulture)}");
        }

        return true;
    }

    private static bool TryReadInt(string prompt, int minimum, out int value)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out value) && value >= minimum)
        {
            return true;
        }

        Console.Error.WriteLine($"Введите целое число не меньше {minimum}.");
        return false;
    }
}
