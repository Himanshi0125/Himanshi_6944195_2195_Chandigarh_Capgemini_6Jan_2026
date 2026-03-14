# Library Management System (ASP.NET Core MVC – Database First)

# Database Setup (SQL Server)

Open **Azure Data Studio** and run the following SQL commands.

## 1. Create Database

```sql id="f6b0y3"
CREATE DATABASE LibraryDB2;
GO

USE LibraryDB2;
```

---

## 2. Create Tables

```sql id="o7c6q1"
CREATE TABLE Authors (
    AuthorId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Country NVARCHAR(100)
);

CREATE TABLE Books (
    BookId INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(200),
    ISBN NVARCHAR(50),
    AuthorId INT
);

CREATE TABLE Borrowers (
    BorrowerId INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(100),
    Email NVARCHAR(100)
);

CREATE TABLE BookBorrowers (
    BookId INT,
    BorrowerId INT,
    PRIMARY KEY (BookId, BorrowerId),
    FOREIGN KEY (BookId) REFERENCES Books(BookId),
    FOREIGN KEY (BorrowerId) REFERENCES Borrowers(BorrowerId)
);
```

After executing the script, the database will contain the following tables:

* Authors
* Books
* Borrowers
* BookBorrowers

---

# Project Setup (Terminal)

Navigate to your working directory.

cd ~/Capegemini_CU_Sec3_dotnetWithAzure_Himanshi/Week10/Day45


## 1. Create ASP.NET Core MVC Project

dotnet new mvc -n LibraryMVC
cd LibraryMVC

(Optional) Open the project in VS Code:

code .

---

# Install Required Packages

Install Entity Framework Core and scaffolding packages.

dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

---

# Install CLI Tools

dotnet tool install --global dotnet-ef
dotnet tool install --global dotnet-aspnet-codegenerator

---

# Entity Framework Core (Database First)

Generate models and DbContext from the existing database.

dotnet ef dbcontext scaffold "Server=localhost;Database=LibraryDB2;User Id=sa;Password=StrongPassword@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models

This command generates:

Models/
  Author.cs
  Book.cs
  Borrower.cs
  BookBorrower.cs
  LibraryDb2Context.cs

---

# Configure Connection String

Edit **appsettings.json**

{
  "ConnectionStrings": {
    "LibraryDB": "Server=localhost;Database=LibraryDB2;User Id=sa;Password=StrongPassword@123;TrustServerCertificate=True;"
  }
}

---

# Configure DbContext

Update **Program.cs**

using Microsoft.EntityFrameworkCore;
using LibraryMVC.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LibraryDb2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDB")));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

---

# Generate Controllers and Views

Use scaffolding to generate CRUD operations.

## Authors Controller

dotnet aspnet-codegenerator controller -name AuthorsController -m Author -dc LibraryDb2Context --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries

---

## Books Controller

dotnet aspnet-codegenerator controller -name BooksController -m Book -dc LibraryDb2Context --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries

This generates:

Controllers/
  AuthorsController.cs
  BooksController.cs

and corresponding **Views**.

---

# Navigation Setup

Update `_Layout.cshtml` to include navigation links for:

Authors
Books

This allows users to navigate easily between pages.

---

# Running the Application

Run the application using:

dotnet run

Open the application in the browser:

https://localhost:5001
