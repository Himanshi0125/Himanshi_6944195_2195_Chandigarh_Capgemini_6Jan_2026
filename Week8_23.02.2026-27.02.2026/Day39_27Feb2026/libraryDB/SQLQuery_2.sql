CREATE DATABASE UniversityDB;
GO
USE UniversityDB;
GO

-- Departments
CREATE TABLE Departments (
    DeptId INT PRIMARY KEY IDENTITY(1,1),
    DeptName NVARCHAR(100) NOT NULL
);

-- Courses
CREATE TABLE Courses (
    CourseId INT PRIMARY KEY IDENTITY(1,1),
    CourseName NVARCHAR(100) NOT NULL,
    DeptId INT FOREIGN KEY REFERENCES Departments(DeptId)
);

-- Students
CREATE TABLE Students (
    StudentId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100),
    DeptId INT FOREIGN KEY REFERENCES Departments(DeptId)
);

-- Enrollments
CREATE TABLE Enrollments (
    EnrollmentId INT PRIMARY KEY IDENTITY(1,1),
    StudentId INT FOREIGN KEY REFERENCES Students(StudentId),
    CourseId INT FOREIGN KEY REFERENCES Courses(CourseId),
    Grade CHAR(2)
);


INSERT INTO Departments (DeptName)
VALUES ('Computer Science'), ('Mathematics'), ('Physics');

INSERT INTO Courses (CourseName, DeptId)
VALUES 
('Data Structures', 1),
('Algorithms', 1),
('Linear Algebra', 2),
('Quantum Mechanics', 3);

INSERT INTO Students (FirstName, LastName, Email, DeptId)
VALUES
('Alice', 'Johnson', 'alice@uni.com', 1),
('Bob', 'Smith', 'bob@uni.com', 2),
('Charlie', 'Brown', 'charlie@uni.com', 3);

INSERT INTO Enrollments (StudentId, CourseId, Grade)
VALUES
(1, 1, 'A'),
(1, 2, 'B'),
(2, 3, 'A'),
(3, 4, 'C');


GO
CREATE PROCEDURE InsertStudent
@FirstName NVARCHAR(50),
@LastName NVARCHAR(50),
@Email NVARCHAR(100),
@DeptId INT
AS
BEGIN
INSERT INTO Students (FirstName, LastName, Email, DeptId)
VALUES (@FirstName, @LastName, @Email, @DeptId)
END
GO

GO
CREATE PROCEDURE GetAllStudents
AS
BEGIN
SELECT s.StudentId, s.FirstName, s.LastName, s.Email, d.DeptName
FROM Students s
JOIN Departments d ON s.DeptId = d.DeptId
END
GO

GO
CREATE PROCEDURE GetStudentById
@StudentId INT
AS
BEGIN
SELECT * FROM Students WHERE StudentId = @StudentId
END
GO

GO
CREATE PROCEDURE UpdateStudent
@StudentId INT,
@FirstName NVARCHAR(50),
@LastName NVARCHAR(50),
@Email NVARCHAR(100),
@DeptId INT
AS
BEGIN
UPDATE Students
SET FirstName=@FirstName,
    LastName=@LastName,
    Email=@Email,
    DeptId=@DeptId
WHERE StudentId=@StudentId
END
GO

GO
CREATE PROCEDURE DeleteStudent
@StudentId INT
AS
BEGIN
DELETE FROM Students WHERE StudentId=@StudentId
END
GO


select * from Departments;
select * from Courses;
select * from Students;
select * from Enrollments;

GO
ALTER PROCEDURE DeleteStudent
@StudentId INT
AS
BEGIN
    -- First delete enrollments
    DELETE FROM Enrollments
    WHERE StudentId = @StudentId;

    -- Then delete student
    DELETE FROM Students
    WHERE StudentId = @StudentId;
END
GO