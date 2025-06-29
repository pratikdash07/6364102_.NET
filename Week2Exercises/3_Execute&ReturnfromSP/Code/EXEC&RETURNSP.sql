-- Drop stored procedure if exists
IF OBJECT_ID('sp_InsertEmployee', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertEmployee;
GO

-- Drop tables if they exist
IF OBJECT_ID('Employees', 'U') IS NOT NULL
    DROP TABLE Employees;
IF OBJECT_ID('Departments', 'U') IS NOT NULL
    DROP TABLE Departments;
GO

-- Create Departments Table
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

-- Create Employees Table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);

-- Insert sample data into Departments
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');

-- Insert sample data into Employees
INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'),
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
(3, 'Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
(4, 'Emily', 'Davis', 4, 5500.00, '2021-11-05');

SELECT * FROM Employees;
SELECT * FROM Departments;

-- Drop procedure if it exists
IF OBJECT_ID('sp_GetEmployeeCountByDepartment', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetEmployeeCountByDepartment;
GO

-- Create stored procedure
CREATE PROCEDURE sp_GetEmployeeCountByDepartment
    @DepartmentID INT,
    @EmployeeCount INT OUTPUT  -- Output parameter to return the count
AS
BEGIN
    SELECT @EmployeeCount = COUNT(*) 
    FROM Employees 
    WHERE DepartmentID = @DepartmentID;
END;
GO

-- Declare a variable to hold the output
DECLARE @CountResult INT;

-- Execute the procedure for DepartmentID = 3 (IT department)
EXEC sp_GetEmployeeCountByDepartment 
    @DepartmentID = 3, 
    @EmployeeCount = @CountResult OUTPUT;

-- Display the result
SELECT @CountResult AS EmployeeCount;
