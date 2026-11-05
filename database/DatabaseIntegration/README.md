# Database integration tasks

Standalone .NET 10 console app for database tasks 28–30. It uses `Microsoft.Data.SqlClient` and the `PracticeDB` schema created by [`../init.sql`](../init.sql).

Set the connection string in the environment; do not put credentials in source files:

```bash
export PRACTICE_DB_CONNECTION='Server=localhost;Database=PracticeDB;Integrated Security=true;TrustServerCertificate=true'
dotnet run --project database/DatabaseIntegration/DatabaseIntegration.csproj
```

Choose task 28 to query employees by department, task 29 to insert an employee/project assignment, or task 30 to print a department salary report. SQL parameters are used for all user-provided values. SQL Server errors, including constraint violations, are printed explicitly.
