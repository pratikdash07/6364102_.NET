-- Declare a variable to hold the output
DECLARE @CountResult INT;

-- Execute the procedure for DepartmentID = 3 (IT department)
EXEC sp_GetEmployeeCountByDepartment 
    @DepartmentID = 3, 
    @EmployeeCount = @CountResult OUTPUT;

-- Display the result
SELECT @CountResult AS EmployeeCount;
