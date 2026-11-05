# SQL notes

> Учебная БД: `PracticeDB`. Скрипт создания: [`init.sql`](./init.sql).
> Выполнять запросы в SSMS или Azure Data Studio после запуска `init.sql`.

## Task 01 — Создание базы и таблиц

### Запрос

```sql
SELECT s.name AS SchemaName, t.name AS TableName
FROM sys.tables AS t
JOIN sys.schemas AS s ON s.schema_id = t.schema_id
WHERE s.name = N'dbo'
ORDER BY t.name;

SELECT
    OBJECT_NAME(fkc.parent_object_id) AS TableName,
    COL_NAME(fkc.parent_object_id, fkc.parent_column_id) AS ColumnName,
    OBJECT_NAME(fkc.referenced_object_id) AS ReferencedTable,
    COL_NAME(fkc.referenced_object_id, fkc.referenced_column_id) AS ReferencedColumn
FROM sys.foreign_key_columns AS fkc
ORDER BY TableName, ColumnName;
```

### Результат

Созданы `Departments`, `Employees`, `Projects`, `EmployeeProjects`. Внешние ключи связывают сотрудников с отделами и руководителями, а назначения — с сотрудниками и проектами.

## Task 02 — INSERT: заполнение данными

### Запрос

```sql
SELECT N'Departments' AS TableName, COUNT(*) AS RowCount FROM dbo.Departments
UNION ALL SELECT N'Employees', COUNT(*) FROM dbo.Employees
UNION ALL SELECT N'Projects', COUNT(*) FROM dbo.Projects
UNION ALL SELECT N'EmployeeProjects', COUNT(*) FROM dbo.EmployeeProjects;
```

### Результат

`Departments` — 4 строки, `Employees` — 10, `Projects` — 5, `EmployeeProjects` — 14.

## Task 03 — SELECT + WHERE

### Запрос

```sql
SELECT EmployeeId, EmployeeName, Salary
FROM dbo.Employees
WHERE Salary > 50000
ORDER BY Salary DESC;

SELECT EmployeeId, EmployeeName, HireDate
FROM dbo.Employees
WHERE YEAR(HireDate) = 2023
ORDER BY HireDate;

SELECT EmployeeId, EmployeeName
FROM dbo.Employees
WHERE EmployeeName LIKE N'А%';

SELECT EmployeeId, EmployeeName, Salary
FROM dbo.Employees
WHERE DepartmentId = 2
ORDER BY EmployeeId;

SELECT EmployeeId, EmployeeName, Salary
FROM dbo.Employees
WHERE Salary BETWEEN 40000 AND 60000
ORDER BY Salary;
```

### Результат

Пять выборок непустые. Условия возвращают соответственно сотрудников с зарплатой выше 50 000, нанятых в 2023 году, имена на «А», отдел № 2 и зарплаты в диапазоне 40 000–60 000 включительно.

## Task 04 — ORDER BY + TOP

### Запрос

```sql
SELECT TOP (3) EmployeeName, Salary
FROM dbo.Employees
ORDER BY Salary DESC, EmployeeId;

SELECT TOP (5) EmployeeName, HireDate
FROM dbo.Employees
ORDER BY HireDate, EmployeeId;

SELECT EmployeeName, DepartmentId, Salary
FROM dbo.Employees
ORDER BY DepartmentId, Salary DESC, EmployeeId;
```

### Результат

В топ-3 зарплат входят Алексей Лебедев (90 000), Пётр Сидоров (72 000) и Анна Иванова (65 000). Топ-5 по стажу начинается с Алексея Лебедева (25.05.2018) и Петра Сидорова (01.07.2019).

## Task 05 — Агрегаты

### Запрос

```sql
SELECT
    COUNT(*) AS EmployeeCount,
    SUM(Salary) AS SalaryTotal,
    ROUND(AVG(Salary), 2) AS SalaryAverage,
    MIN(Salary) AS SalaryMinimum,
    MAX(Salary) AS SalaryMaximum,
    SUM(CASE WHEN Salary > 50000 THEN 1 ELSE 0 END) AS Over50000Count
FROM dbo.Employees;
```

### Результат

Сотрудников — 10; сумма зарплат — 589 000,00; средняя — 58 900,00; минимум — 43 000,00; максимум — 90 000,00; зарплату выше 50 000 получают 7 сотрудников.

## Task 06 — GROUP BY: статистика по отделам

### Запрос

```sql
SELECT
    DepartmentId,
    COUNT(*) AS EmployeeCount,
    ROUND(AVG(Salary), 2) AS AverageSalary,
    SUM(Salary) AS TotalSalary
FROM dbo.Employees
GROUP BY DepartmentId
ORDER BY AverageSalary DESC;
```

### Результат

| DepartmentId | EmployeeCount | AverageSalary | TotalSalary |
|---:|---:|---:|---:|
| 4 | 1 | 90000.00 | 90000.00 |
| 1 | 4 | 60000.00 | 240000.00 |
| 2 | 3 | 57000.00 | 171000.00 |
| 3 | 2 | 44000.00 | 88000.00 |

## Task 07 — GROUP BY + HAVING

### Запрос

```sql
SELECT DepartmentId, COUNT(*) AS EmployeeCount
FROM dbo.Employees
GROUP BY DepartmentId
HAVING COUNT(*) > 2;

SELECT DepartmentId, AVG(Salary) AS AverageSalary
FROM dbo.Employees
GROUP BY DepartmentId
HAVING AVG(Salary) > 55000;

SELECT DepartmentId, SUM(Salary) AS TotalSalary
FROM dbo.Employees
GROUP BY DepartmentId
HAVING SUM(Salary) > 150000;
```

### Результат

Более двух сотрудников — в отделах 1 и 2. Средняя зарплата выше 55 000 — в отделах 1, 2 и 4. Суммарная зарплата выше 150 000 — в отделах 1 и 2.

## Task 08 — INNER JOIN: сотрудники и отделы

### Запрос

```sql
SELECT e.EmployeeName, d.DepartmentName, e.Salary
FROM dbo.Employees AS e
INNER JOIN dbo.Departments AS d ON d.DepartmentId = e.DepartmentId
ORDER BY d.DepartmentName, e.Salary DESC, e.EmployeeId;
```

### Результат

Возвращаются все 10 сотрудников с названием их отдела; строки без соответствующего отдела не попадают в результат.

## Task 09 — LEFT JOIN: сотрудники без проектов

### Запрос

```sql
SELECT e.EmployeeId, e.EmployeeName
FROM dbo.Employees AS e
LEFT JOIN dbo.EmployeeProjects AS ep ON ep.EmployeeId = e.EmployeeId
WHERE ep.EmployeeId IS NULL;
```

### Результат

Одна строка: `9 — Наталья Соколова`.

## Task 10 — Множественный JOIN

### Запрос

```sql
SELECT e.EmployeeName, d.DepartmentName, p.ProjectName, ep.Hours
FROM dbo.Employees AS e
INNER JOIN dbo.Departments AS d ON d.DepartmentId = e.DepartmentId
INNER JOIN dbo.EmployeeProjects AS ep ON ep.EmployeeId = e.EmployeeId
INNER JOIN dbo.Projects AS p ON p.ProjectId = ep.ProjectId
ORDER BY d.DepartmentName, e.EmployeeName, p.ProjectName;
```

### Результат

Получено 14 строк — по одной на каждое назначение сотрудника на проект; в строках присутствуют сотрудник, отдел, проект и часы.

## Task 11 — Self-join: сотрудники и руководители

### Запрос

```sql
SELECT e.EmployeeName, m.EmployeeName AS ManagerName
FROM dbo.Employees AS e
LEFT JOIN dbo.Employees AS m ON m.EmployeeId = e.ManagerId
ORDER BY e.EmployeeId;
```

### Результат

Для сотрудников 3, 4, 6 и 9 указаны руководители; для остальных значение `ManagerName` равно `NULL`.

## Task 12 — Подзапрос: зарплата выше средней

### Запрос

```sql
SELECT EmployeeName, Salary
FROM dbo.Employees
WHERE Salary > (SELECT AVG(Salary) FROM dbo.Employees)
ORDER BY Salary DESC;
```

### Результат

Четыре сотрудника: Алексей Лебедев (90 000), Пётр Сидоров (72 000), Анна Иванова (65 000), Ольга Смирнова (61 000). Средняя зарплата — 58 900.

## Task 13 — EXISTS: сотрудники с назначениями

### Запрос

```sql
SELECT e.EmployeeId, e.EmployeeName
FROM dbo.Employees AS e
WHERE EXISTS
(
    SELECT 1
    FROM dbo.EmployeeProjects AS ep
    WHERE ep.EmployeeId = e.EmployeeId
)
ORDER BY e.EmployeeId;
```

### Результат

Возвращается 9 сотрудников; сотрудник № 9 не назначен ни на один проект.

## Task 14 — NOT EXISTS: сотрудники без назначений

### Запрос

```sql
SELECT e.EmployeeId, e.EmployeeName
FROM dbo.Employees AS e
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.EmployeeProjects AS ep
    WHERE ep.EmployeeId = e.EmployeeId
)
ORDER BY e.EmployeeId;
```

### Результат

Одна строка: `9 — Наталья Соколова`.

## Task 15 — UNION

### Запрос

```sql
SELECT EmployeeId, EmployeeName
FROM dbo.Employees
WHERE DepartmentId = 1
UNION
SELECT EmployeeId, EmployeeName
FROM dbo.Employees
WHERE Salary > 70000
ORDER BY EmployeeId;
```

### Результат

Пять сотрудников с ID 1, 2, 3, 4 и 10. Повторяющийся сотрудник № 2 выводится только один раз.

## Task 16 — UPDATE с проверкой до и после

### Запрос

```sql
SELECT EmployeeId, EmployeeName, Salary
FROM dbo.Employees
WHERE DepartmentId = 2
ORDER BY EmployeeId;

BEGIN TRANSACTION;

UPDATE dbo.Employees
SET Salary = ROUND(Salary * 1.10, 2)
WHERE DepartmentId = 2;

SELECT EmployeeId, EmployeeName, Salary
FROM dbo.Employees
WHERE DepartmentId = 2
ORDER BY EmployeeId;

ROLLBACK TRANSACTION;

SELECT EmployeeId, EmployeeName, Salary
FROM dbo.Employees
WHERE DepartmentId = 2
ORDER BY EmployeeId;
```

### Результат

До изменения: 61 000, 58 000 и 52 000. Внутри транзакции: 67 100, 63 800 и 57 200. После `ROLLBACK` снова отображаются исходные зарплаты.

## Task 17 — DELETE с проверкой до и после

### Запрос

```sql
SELECT EmployeeId, EmployeeName
FROM dbo.Employees
WHERE EmployeeId = 9;

BEGIN TRANSACTION;

DELETE FROM dbo.Employees
WHERE EmployeeId = 9;

SELECT COUNT(*) AS RemainingEmployees
FROM dbo.Employees;

ROLLBACK TRANSACTION;

SELECT COUNT(*) AS EmployeesAfterRollback
FROM dbo.Employees;

SELECT EmployeeId, EmployeeName
FROM dbo.Employees
WHERE EmployeeId = 9;
```

### Результат

До удаления существует сотрудник № 9. В транзакции остаётся 9 сотрудников; после отката снова 10, сотрудник № 9 снова присутствует.

## Task 18 — Транзакция и откат при ошибке

### Запрос

```sql
SELECT EmployeeId, Salary
FROM dbo.Employees
WHERE EmployeeId = 1;

BEGIN TRY
    BEGIN TRANSACTION;

    UPDATE dbo.Employees
    SET Salary = Salary + 5000
    WHERE EmployeeId = 1;

    SELECT EmployeeId, Salary
    FROM dbo.Employees
    WHERE EmployeeId = 1;

    THROW 50001, N'Демонстрационная ошибка: требуется откат.', 1;
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;

    SELECT ERROR_MESSAGE() AS ErrorMessage;
END CATCH;

SELECT EmployeeId, Salary
FROM dbo.Employees
WHERE EmployeeId = 1;
```

### Результат

Внутри транзакции зарплата сотрудника № 1 временно равна 70 000; после демонстрационной ошибки выполнен откат, итоговая зарплата — 65 000.

## Task 19 — Представление: сводка по отделам

### Запрос

```sql
CREATE OR ALTER VIEW dbo.vDepartmentSalarySummary
AS
SELECT
    d.DepartmentId,
    d.DepartmentName,
    COUNT(e.EmployeeId) AS EmployeeCount,
    COALESCE(ROUND(AVG(e.Salary), 2), 0) AS AverageSalary,
    COALESCE(SUM(e.Salary), 0) AS TotalSalary
FROM dbo.Departments AS d
LEFT JOIN dbo.Employees AS e ON e.DepartmentId = d.DepartmentId
GROUP BY d.DepartmentId, d.DepartmentName;
GO

SELECT DepartmentName, EmployeeCount, AverageSalary, TotalSalary
FROM dbo.vDepartmentSalarySummary
ORDER BY DepartmentId;
```

### Результат

Представление возвращает 4 отдела. В текущих тестовых данных количество сотрудников по отделам — 4, 3, 2 и 1; средние зарплаты — 60 000, 57 000, 44 000 и 90 000.

## Task 20 — Индекс

### Запрос

```sql
IF NOT EXISTS
(
    SELECT 1
    FROM sys.indexes
    WHERE object_id = OBJECT_ID(N'dbo.Employees')
      AND name = N'IX_Employees_DepartmentId_Salary'
)
BEGIN
    CREATE NONCLUSTERED INDEX IX_Employees_DepartmentId_Salary
        ON dbo.Employees (DepartmentId, Salary DESC)
        INCLUDE (EmployeeName, HireDate);
END;

SELECT name, type_desc
FROM sys.indexes
WHERE object_id = OBJECT_ID(N'dbo.Employees')
  AND name = N'IX_Employees_DepartmentId_Salary';

SELECT EmployeeName, Salary
FROM dbo.Employees
WHERE DepartmentId = 2
ORDER BY Salary DESC;
```

### Результат

Создаётся некластерный индекс с ключами отдела и зарплаты и включёнными полями для этой выборки. Проверка метаданных возвращает одну строку индекса.

## Task 21 — Хранимая процедура

### Запрос

```sql
CREATE OR ALTER PROCEDURE dbo.GetEmployeesByDepartment
    @DepartmentId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT EmployeeId, EmployeeName, Salary, HireDate
    FROM dbo.Employees
    WHERE DepartmentId = @DepartmentId
    ORDER BY Salary DESC, EmployeeId;
END;
GO

EXEC dbo.GetEmployeesByDepartment @DepartmentId = 2;
```

### Результат

Вызов для отдела № 2 возвращает Ольгу Смирнову, Дмитрия Орлова и Елену Волкову, отсортированных по зарплате по убыванию.

## Task 22 — Табличная функция и диапазон дат

### Запрос

```sql
CREATE OR ALTER FUNCTION dbo.GetEmployeesHiredBetween
(
    @StartDate DATE,
    @EndDate DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT EmployeeId, EmployeeName, HireDate, DepartmentId
    FROM dbo.Employees
    WHERE HireDate >= @StartDate
      AND HireDate < DATEADD(DAY, 1, @EndDate)
);
GO

SELECT EmployeeId, EmployeeName, HireDate
FROM dbo.GetEmployeesHiredBetween('20230101', '20231231')
ORDER BY HireDate, EmployeeId;
```

### Результат

Два сотрудника, нанятых в 2023 году: Иван Петров (10.02.2023) и Елена Волкова (01.06.2023).

## Task 23 — Оконные функции

### Запрос

```sql
SELECT
    DepartmentId,
    EmployeeName,
    Salary,
    ROW_NUMBER() OVER
        (PARTITION BY DepartmentId ORDER BY Salary DESC, EmployeeId) AS RowInDepartment,
    DENSE_RANK() OVER
        (PARTITION BY DepartmentId ORDER BY Salary DESC) AS SalaryRank
FROM dbo.Employees
ORDER BY DepartmentId, Salary DESC, EmployeeId;
```

### Результат

Возвращаются все 10 сотрудников. Для каждого отдела нумерация начинается с 1; наиболее высокооплачиваемые сотрудники отделов — Пётр Сидоров, Ольга Смирнова, Сергей Морозов и Алексей Лебедев.

## Task 24 — Рекурсивный CTE: иерархия сотрудников

### Запрос

```sql
WITH EmployeeHierarchy AS
(
    SELECT EmployeeId, EmployeeName, ManagerId, 0 AS HierarchyLevel
    FROM dbo.Employees
    WHERE ManagerId IS NULL

    UNION ALL

    SELECT e.EmployeeId, e.EmployeeName, e.ManagerId, h.HierarchyLevel + 1
    FROM dbo.Employees AS e
    INNER JOIN EmployeeHierarchy AS h ON e.ManagerId = h.EmployeeId
)
SELECT EmployeeId, EmployeeName, ManagerId, HierarchyLevel
FROM EmployeeHierarchy
ORDER BY HierarchyLevel, EmployeeId
OPTION (MAXRECURSION 100);
```

### Результат

Иерархия содержит все 10 сотрудников: 6 сотрудников без руководителя на уровне 0 и 4 подчинённых на уровне 1.

## Task 25 — CASE: категории зарплат

### Запрос

```sql
SELECT
    CASE
        WHEN Salary >= 70000 THEN N'Высокая'
        WHEN Salary >= 55000 THEN N'Средняя'
        ELSE N'Начальная'
    END AS SalaryCategory,
    COUNT(*) AS EmployeeCount
FROM dbo.Employees
GROUP BY
    CASE
        WHEN Salary >= 70000 THEN N'Высокая'
        WHEN Salary >= 55000 THEN N'Средняя'
        ELSE N'Начальная'
    END
ORDER BY SalaryCategory;
```

### Результат

Высокая — 2 сотрудника; средняя — 4; начальная — 4.

## Task 26 — Фильтрация по датам

### Запрос

```sql
DECLARE @YearStart DATE = '20230101';
DECLARE @NextYearStart DATE = '20240101';

SELECT EmployeeId, EmployeeName, HireDate
FROM dbo.Employees
WHERE HireDate >= @YearStart
  AND HireDate < @NextYearStart
ORDER BY HireDate, EmployeeId;
```

### Результат

Два сотрудника: Иван Петров (10.02.2023) и Елена Волкова (01.06.2023).

## Task 27 — Итоговый отчёт по проектам

### Запрос

```sql
WITH ProjectTotals AS
(
    SELECT
        p.ProjectId,
        p.ProjectName,
        p.StartDate,
        COUNT(ep.EmployeeId) AS EmployeeCount,
        COALESCE(SUM(ep.Hours), 0) AS TotalHours
    FROM dbo.Projects AS p
    LEFT JOIN dbo.EmployeeProjects AS ep ON ep.ProjectId = p.ProjectId
    GROUP BY p.ProjectId, p.ProjectName, p.StartDate
)
SELECT ProjectName, StartDate, EmployeeCount, TotalHours
FROM ProjectTotals
ORDER BY TotalHours DESC, ProjectId;
```

### Результат

| Проект | Участников | Часов |
|---|---:|---:|
| AI Assistant | 3 | 310 |
| CRM System | 3 | 300 |
| Mobile App | 3 | 285 |
| Data Warehouse | 3 | 260 |
| Legacy Refactor | 2 | 170 |
