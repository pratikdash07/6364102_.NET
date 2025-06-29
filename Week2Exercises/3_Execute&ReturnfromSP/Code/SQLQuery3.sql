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
