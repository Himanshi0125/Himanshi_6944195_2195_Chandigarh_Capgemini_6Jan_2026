CREATE DATABASE EmployeeDB;
GO

USE EmployeeDB;
GO

SET ANSI_NULLS ON;
GO

CREATE TABLE [dbo].[Address]
(
    AddressID INT IDENTITY(1,1) PRIMARY KEY,
    Street NVARCHAR(200) NOT NULL,
    City NVARCHAR(100) NOT NULL,
    State NVARCHAR(100) NOT NULL,
    PostalCode NVARCHAR(20) NOT NULL
);

INSERT INTO [dbo].[Address] (Street, City, State, PostalCode)
VALUES
('1234 Elm Street', 'Springfield', 'Bros', '62704'),
('5678 Oak Street', 'Decatur', 'Alabama', '35601'),
('123 Patia', 'BBSR', 'India', '755019'),
('123 Patia', 'BBSR', 'India', '755019');

CREATE TABLE [dbo].[Employee]
(
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    AddressID INT NOT NULL,
    CONSTRAINT FK_Employee_Address 
        FOREIGN KEY (AddressID) REFERENCES Address(AddressID)
);

INSERT INTO [dbo].[Employee]
(FirstName, LastName, Email, AddressID)
VALUES
('John', 'Doe', 'johndoe@example.com', 1),
('Jane', 'Doe', 'janedoe@example.com', 2),
('Ramesh', 'Sharma', 'Ramesh@example.com', 3),
('Ramesh', 'Sharma', 'Ramesh@example.com', 4);



GO
CREATE PROCEDURE [dbo].[CreateEmployeeWithAddress]
    @FirstName VARCHAR(100),
    @LastName VARCHAR(100),
    @Email VARCHAR(100),
    @Street VARCHAR(255),
    @City VARCHAR(100),
    @State VARCHAR(100),
    @PostalCode VARCHAR(20)
AS
BEGIN
    DECLARE @AddressID INT;
    INSERT INTO Address (Street, City, State, PostalCode)
    VALUES (@Street, @City, @State, @PostalCode);
    SET @AddressID = SCOPE_IDENTITY();
    INSERT INTO Employee (FirstName, LastName, Email, AddressID)
    VALUES (@FirstName, @LastName, @Email, @AddressID);
END;
GO

GO
CREATE PROCEDURE [dbo].[DeleteEmployee]
    @EmployeeID INT
AS
BEGIN
    DECLARE @AddressID INT;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Get AddressID
        SELECT @AddressID = AddressID
        FROM Employee
        WHERE EmployeeID = @EmployeeID;

        -- Delete Employee
        DELETE FROM Employee
        WHERE EmployeeID = @EmployeeID;

        -- Delete Address
        DELETE FROM Address
        WHERE AddressID = @AddressID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllEmployees]
AS
BEGIN
    SELECT 
        e.EmployeeID,
        e.FirstName,
        e.LastName,
        e.Email,
        a.Street,
        a.City,
        a.State,
        a.PostalCode
    FROM Employee e
    INNER JOIN Address a 
        ON e.AddressID = a.AddressID;
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEmployeeByID]
    @EmployeeID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        e.EmployeeID,
        e.FirstName,
        e.LastName,
        e.Email,
        a.Street,
        a.City,
        a.State,
        a.PostalCode
    FROM Employee e
    INNER JOIN Address a 
        ON e.AddressID = a.AddressID
    WHERE e.EmployeeID = @EmployeeID;
END
GO


GO
CREATE PROCEDURE [dbo].[UpdateEmployeeWithAddress]
    @EmployeeID INT,
    @FirstName VARCHAR(100),
    @LastName VARCHAR(100),
    @Email VARCHAR(100),
    @Street VARCHAR(255),
    @City VARCHAR(100),
    @State VARCHAR(100),
    @PostalCode VARCHAR(20),
    @AddressID INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Update Address
        UPDATE Address
        SET Street = @Street,
            City = @City,
            State = @State,
            PostalCode = @PostalCode
        WHERE AddressID = @AddressID;

        -- Update Employee
        UPDATE Employee
        SET FirstName = @FirstName,
            LastName = @LastName,
            Email = @Email,
            AddressID = @AddressID
        WHERE EmployeeID = @EmployeeID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END;
GO

EXEC dbo.CreateEmployeeWithAddress
    @FirstName = 'Aman',
    @LastName = 'Verma',
    @Email = 'aman@example.com',
    @Street = '45 Sector 17',
    @City = 'Chandigarh',
    @State = 'Punjab',
    @PostalCode = '160017';
GO

-- Get All Employees
EXEC dbo.GetAllEmployees;
GO

-- Get Employee By ID
EXEC dbo.GetEmployeeByID 
    @EmployeeID = 1;
GO

EXEC UpdateEmployeeWithAddress
    @EmployeeID = 1,
    @FirstName = 'Sejal',
    @LastName = 'Sharma',
    @Email = 'sejal123@email.com',
    @Street = 'Old Street',
    @City = 'Delhi',
    @State = 'Delhi',
    @PostalCode = '110011',
    @AddressID = 1;
GO

-- Delete Employee
EXEC dbo.DeleteEmployee 
    @EmployeeID = 1;
GO

select * from Address;
select * from Employee;
