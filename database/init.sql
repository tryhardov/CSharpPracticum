IF DB_ID(N'PracticeDB') IS NOT NULL
BEGIN
    ALTER DATABASE PracticeDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE PracticeDB;
END;
GO

CREATE DATABASE PracticeDB;
GO

USE PracticeDB;
GO

CREATE TABLE dbo.Departments
(
    DepartmentId   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Departments PRIMARY KEY,
    DepartmentName NVARCHAR(100) NOT NULL
);

CREATE TABLE dbo.Employees
(
    EmployeeId   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Employees PRIMARY KEY,
    EmployeeName NVARCHAR(100) NOT NULL,
    Salary       DECIMAL(10,2) NOT NULL,
    HireDate     DATE NOT NULL,
    DepartmentId INT NOT NULL,
    ManagerId    INT NULL,
    CONSTRAINT FK_Employees_Departments
        FOREIGN KEY (DepartmentId) REFERENCES dbo.Departments(DepartmentId),
    CONSTRAINT FK_Employees_Manager
        FOREIGN KEY (ManagerId) REFERENCES dbo.Employees(EmployeeId)
);

CREATE TABLE dbo.Projects
(
    ProjectId   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Projects PRIMARY KEY,
    ProjectName NVARCHAR(100) NOT NULL,
    StartDate   DATE NOT NULL
);

CREATE TABLE dbo.EmployeeProjects
(
    EmployeeId INT NOT NULL,
    ProjectId  INT NOT NULL,
    Hours      INT NOT NULL CONSTRAINT DF_EmployeeProjects_Hours DEFAULT (0),
    CONSTRAINT PK_EmployeeProjects PRIMARY KEY (EmployeeId, ProjectId),
    CONSTRAINT FK_EmployeeProjects_Employees
        FOREIGN KEY (EmployeeId) REFERENCES dbo.Employees(EmployeeId),
    CONSTRAINT FK_EmployeeProjects_Projects
        FOREIGN KEY (ProjectId) REFERENCES dbo.Projects(ProjectId)
);
GO

INSERT INTO dbo.Departments (DepartmentName)
VALUES
    (N'Разработка'),
    (N'Аналитика'),
    (N'Тестирование'),
    (N'Менеджмент');
GO

INSERT INTO dbo.Employees (EmployeeName, Salary, HireDate, DepartmentId, ManagerId)
VALUES
    (N'Анна Иванова',     65000.00, '20200315', 1, NULL),
    (N'Пётр Сидоров',     72000.00, '20190701', 1, NULL),
    (N'Мария Кузнецова',  55000.00, '20211120', 1, 2),
    (N'Иван Петров',      48000.00, '20230210', 1, 1),
    (N'Ольга Смирнова',   61000.00, '20200905', 2, NULL),
    (N'Дмитрий Орлов',    58000.00, '20220418', 2, 5),
    (N'Елена Волкова',    52000.00, '20230601', 2, NULL),
    (N'Сергей Морозов',   45000.00, '20211212', 3, NULL),
    (N'Наталья Соколова', 43000.00, '20240115', 3, 10),
    (N'Алексей Лебедев',  90000.00, '20180525', 4, NULL);
GO

INSERT INTO dbo.Projects (ProjectName, StartDate)
VALUES
    (N'CRM System',      '20230110'),
    (N'Mobile App',      '20230501'),
    (N'Data Warehouse',  '20221120'),
    (N'AI Assistant',    '20240201'),
    (N'Legacy Refactor', '20210615');
GO

INSERT INTO dbo.EmployeeProjects (EmployeeId, ProjectId, Hours)
VALUES
    (1, 1, 120), (1, 3, 80),
    (2, 1, 150), (2, 4, 60),
    (3, 2, 100), (4, 2, 90),
    (4, 5, 40),  (5, 3, 110),
    (6, 3, 70),  (6, 4, 50),
    (7, 2, 95),  (8, 5, 130),
    (10, 4, 200), (10, 1, 30);
GO

SELECT N'Departments' AS TableName, COUNT(*) AS RowCount FROM dbo.Departments
UNION ALL
SELECT N'Employees', COUNT(*) FROM dbo.Employees
UNION ALL
SELECT N'Projects', COUNT(*) FROM dbo.Projects
UNION ALL
SELECT N'EmployeeProjects', COUNT(*) FROM dbo.EmployeeProjects;
GO
