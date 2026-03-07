-- IF DB_ID('functionProcedureDb') IS NOT NULL
DROP DATABASE functionProcedureDb;
GO

CREATE DATABASE functionProcedureDb;
GO

USE functionProcedureDb;
GO

CREATE TABLE Employee
(
 EmpID INT PRIMARY KEY,
 FirstName VARCHAR(50),
 LastName VARCHAR(50),
 Salary INT,
 Address VARCHAR(100)
);
GO

INSERT INTO Employee VALUES
(1,'Mohan','Chauhan',22000,'Delhi'),
(2,'Asif','Khan',15000,'Delhi'),
(3,'Bhuvnesh','Shakya',19000,'Noida'),
(4,'Deepak','Kumar',19000,'Noida'),
(5,'Deepika','Kumari',25000,'Noida');
GO


CREATE FUNCTION sumTwo()
RETURNS INT
AS
BEGIN
    RETURN 10 + 20;
END;
GO

SELECT dbo.sumTwo();
GO

CREATE FUNCTION Total(@A INT,@B INT,@C INT)
RETURNS INT
AS
BEGIN
    RETURN @A+@B+@C;
END;
GO

SELECT dbo.Total(3,5,4);
GO

CREATE FUNCTION multiplys(@num1 INT,@num2 INT)
RETURNS INT
AS
BEGIN
    RETURN @num1*@num2;
END;
GO

SELECT dbo.multiplys(3,4);
GO


CREATE PROCEDURE MySum
@A INT,@B INT,@C INT=0,@D INT=0,@E INT=0
AS
BEGIN
    PRINT @A+@B+@C+@D+@E;
END;
GO

EXEC MySum 10,20;
EXEC MySum 10,20,30;
GO

CREATE PROCEDURE callingfunct
@firstnum1 INT,
@secnum2 INT
AS
BEGIN
    SELECT dbo.multiplys(@firstnum1,@secnum2) AS Result;
END;
GO

EXEC callingfunct 3,4;
GO


CREATE FUNCTION fnGetEmpFullName
(
 @FirstName VARCHAR(50),
 @LastName VARCHAR(50)
)
RETURNS VARCHAR(101)
AS
BEGIN
    RETURN @FirstName + ' ' + @LastName;
END;
GO

SELECT dbo.fnGetEmpFullName(FirstName,LastName) AS Name, Salary 
FROM Employee;
GO

-- INLINE TABLE VALUED FUNCTION

CREATE FUNCTION fnGetEmployee()
RETURNS TABLE
AS
RETURN (SELECT * FROM Employee);
GO

SELECT * FROM fnGetEmployee();
GO

-- MULTI STATEMENT TABLE FUNCTION

CREATE FUNCTION fnGetMulEmployee()
RETURNS @Emp TABLE
(
 EmpID INT,
 FirstName VARCHAR(50),
 Salary INT
)
AS
BEGIN
    INSERT INTO @Emp
    SELECT EmpID,FirstName,Salary FROM Employee;

    UPDATE @Emp SET Salary=25000 WHERE EmpID=1;
    RETURN;
END;
GO

SELECT * FROM fnGetMulEmployee();
GO

--SWAP PROCEDURE

CREATE PROCEDURE Swap
@X INT OUTPUT,
@Y INT OUTPUT
AS
BEGIN
    DECLARE @T INT;
    SET @T=@X;
    SET @X=@Y;
    SET @Y=@T;
END;
GO

DECLARE @A INT=10,@B INT=20;
EXEC Swap @A OUTPUT,@B OUTPUT;
SELECT @A AS A,@B AS B;
GO

-- CURSOR EXAMPLE

CREATE TABLE EmployeeCursor
(
 EmpID INT PRIMARY KEY,
 EmpName VARCHAR(50),
 Salary INT,
 Address VARCHAR(200)
);
GO

INSERT INTO EmployeeCursor VALUES
(1,'Mohan',12000,'Noida'),
(2,'Pavan',25000,'Delhi'),
(3,'Amit',22000,'Dehradun'),
(4,'Sonu',22000,'Noida'),
(5,'Deepak',28000,'Gurgaon');
GO

DECLARE @Id INT,@name VARCHAR(50),@salary INT;

DECLARE cur_emp CURSOR FOR
SELECT EmpID,EmpName,Salary FROM EmployeeCursor;

OPEN cur_emp;
FETCH NEXT FROM cur_emp INTO @Id,@name,@salary;

WHILE @@FETCH_STATUS = 0
BEGIN
 PRINT 'ID : '+CAST(@Id AS VARCHAR)+
 ', Name : '+@name+
 ', Salary : '+CAST(@salary AS VARCHAR);
 FETCH NEXT FROM cur_emp INTO @Id,@name,@salary;
END

CLOSE cur_emp;
DEALLOCATE cur_emp;
GO

-- TRIGGERS

CREATE TABLE Employee_Demo
(
 Emp_ID INT IDENTITY PRIMARY KEY,
 Emp_Name VARCHAR(55),
 Emp_Sal DECIMAL(10,2)
);
GO

CREATE TABLE Employee_Demo_Audit
(
 Emp_ID INT,
 Emp_Name VARCHAR(55),
 Emp_Sal DECIMAL(10,2),
 Audit_Action VARCHAR(100),
 Audit_Timestamp DATETIME
);
GO

/* AFTER INSERT TRIGGER */

CREATE TRIGGER trgAfterInsert
ON Employee_Demo
AFTER INSERT
AS
BEGIN
 INSERT INTO Employee_Demo_Audit
 SELECT i.Emp_ID,i.Emp_Name,i.Emp_Sal,
 'Inserted Record',
 GETDATE()
 FROM inserted i;
END;
GO

INSERT INTO Employee_Demo VALUES ('Amit',1000);
SELECT * FROM Employee_Demo;
SELECT * FROM Employee_Demo_Audit;
GO

/* AFTER UPDATE TRIGGER */

CREATE TRIGGER trgAfterUpdate
ON Employee_Demo
AFTER UPDATE
AS
BEGIN
 INSERT INTO Employee_Demo_Audit
 SELECT i.Emp_ID,i.Emp_Name,i.Emp_Sal,
 'Updated Record',
 GETDATE()
 FROM inserted i;
END;
GO

UPDATE Employee_Demo SET Emp_Sal=1500 WHERE Emp_ID=1;
GO

/* AFTER DELETE TRIGGER */

CREATE TRIGGER trgAfterDelete
ON Employee_Demo
AFTER DELETE
AS
BEGIN
 INSERT INTO Employee_Demo_Audit
 SELECT d.Emp_ID,d.Emp_Name,d.Emp_Sal,
 'Deleted Record',
 GETDATE()
 FROM deleted d;
END;
GO

DELETE FROM Employee_Demo WHERE Emp_ID=1;
GO

SELECT * FROM Employee_Demo;
SELECT * FROM Employee_Demo_Audit;
GO