DROP DATABASE bankdb;
GO
CREATE DATABASE bankdb;
GO
USE bankdb;
GO

CREATE TABLE Employeetb
(
    EmpId INT PRIMARY KEY,
    EmpName VARCHAR(20),
    EmpDesg VARCHAR(50),
    EmpDOJ DATE,
    EmpSal INT,
    EmpDept INT
);
GO

INSERT INTO Employeetb VALUES
(101,'Krishna','ProjManager','2010-08-07',45000,10),
(102,'Kumari','Manager','2010-08-06',50000,20),
(103,'Amit','Manager','2010-09-07',44000,30),
(104,'Rohit','Clerk','2010-05-07',55000,20);
GO

SELECT * FROM Employeetb;
GO

-- DELETE PROCEDURE
CREATE PROCEDURE SP_DelRec
AS
BEGIN
    DELETE FROM Employeetb WHERE EmpId = 104;
END;
GO

-- DELETE USING PARAMETER
CREATE PROCEDURE SP_DelRecP 
@PempId INT
AS
BEGIN
    DELETE FROM Employeetb WHERE EmpId = @PempId;
END;
GO

-- INSERT PROCEDURE
CREATE PROCEDURE SPEmp_Insert
(
    @PEmpId INT,
    @PEmpName VARCHAR(20),
    @PEmpDesg VARCHAR(50),
    @PEmpDOJ DATE,
    @PEmpSal INT,
    @PEmpDept INT
)
AS
BEGIN
    INSERT INTO Employeetb
    VALUES(@PEmpId,@PEmpName,@PEmpDesg,
           @PEmpDOJ,@PEmpSal,@PEmpDept);
END;
GO

-- UPDATE PROCEDURE
CREATE PROCEDURE SPEmp_Update
(
    @PEmpId INT,
    @PEmpName VARCHAR(20),
    @PEmpDesg VARCHAR(50),
    @PEmpDOJ DATE,
    @PEmpSal INT,
    @PEmpDept INT
)
AS
BEGIN
    UPDATE Employeetb
    SET EmpName = @PEmpName,
        EmpDesg = @PEmpDesg,
        EmpDOJ  = @PEmpDOJ,
        EmpSal  = @PEmpSal,
        EmpDept = @PEmpDept
    WHERE EmpId = @PEmpId;
END;
GO

-- DELETE PROCEDURE
CREATE PROCEDURE SPEmp_Del 
@PEmpId INT
AS
BEGIN
    DELETE FROM Employeetb WHERE EmpId = @PEmpId;
END;
GO

-- GET SALARY (OUTPUT PARAMETER)
CREATE PROCEDURE SPGetSal
(
    @PEmpId INT,
    @PEmpSal INT OUTPUT
)
AS
BEGIN
    SELECT @PEmpSal = EmpSal
    FROM Employeetb
    WHERE EmpId = @PEmpId;
END;
GO

-- GET FULL DATA (MULTIPLE OUTPUT)
CREATE PROCEDURE SPGetData
(
    @PEmpId INT,
    @PEmpName VARCHAR(50) OUTPUT,
    @PEmpDesg VARCHAR(50) OUTPUT,
    @PEmpDOJ DATE OUTPUT,
    @PEmpSal INT OUTPUT,
    @PEmpDept INT OUTPUT
)
AS
BEGIN
    SELECT 
        @PEmpName = EmpName,
        @PEmpDesg = EmpDesg,
        @PEmpDOJ  = EmpDOJ,
        @PEmpSal  = EmpSal,
        @PEmpDept = EmpDept
    FROM Employeetb
    WHERE EmpId = @PEmpId;
END;
GO

-- TEST EXECUTION EXAMPLES
-- Insert new record
EXEC SPEmp_Insert 105,'Riya','Analyst','2020-01-01',60000,40;

-- Update record
EXEC SPEmp_Update 105,'Riya Sharma','Senior Analyst','2020-01-01',65000,40;

-- Delete using parameter
EXEC SPEmp_Del 105;

-- Output parameter example
DECLARE @Salary INT;
EXEC SPGetSal 101,@Salary OUTPUT;
SELECT @Salary AS EmployeeSalary;

-- Multiple output example
DECLARE 
@Name VARCHAR(50),
@Desg VARCHAR(50),
@DOJ DATE,
@Sal INT,
@Dept INT;

EXEC SPGetData 101,
@Name OUTPUT,
@Desg OUTPUT,
@DOJ OUTPUT,
@Sal OUTPUT,
@Dept OUTPUT;

SELECT @Name AS Name,@Desg AS Designation,
@DOJ AS DOJ,@Sal AS Salary,@Dept AS Department;
GO