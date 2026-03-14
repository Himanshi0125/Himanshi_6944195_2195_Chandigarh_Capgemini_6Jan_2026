# Hospital Management System (Database-First ASP.NET Core MVC)

# Database Setup (SQL Server)

Open **Azure Data Studio** and execute the following SQL commands.

## 1. Create Database

```sql
CREATE DATABASE HospitalDB;
GO

USE HospitalDB;
```

## 2. Create Tables

```sql
CREATE TABLE Patients (
    PatientId INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(100) NOT NULL,
    DateOfBirth DATE,
    ContactNumber NVARCHAR(20)
);

CREATE TABLE Doctors (
    DoctorId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Specialization NVARCHAR(100) NOT NULL
);

CREATE TABLE Appointments (
    AppointmentId INT PRIMARY KEY IDENTITY,
    PatientId INT,
    DoctorId INT,
    AppointmentDate DATETIME,
    Remarks NVARCHAR(200),

    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);
```

After running the script, the database will contain:

* Patients
* Doctors
* Appointments

---

# Project Setup (Terminal)

Navigate to the working directory.

```bash
cd ~/Capegemini_CU_Sec3_dotnetWithAzure_Himanshi/Week10/Day45
```

---

## 1. Create ASP.NET Core MVC Project

```bash
dotnet new mvc -n HospitalMVC
cd HospitalMVC
```

Open project in VS Code (optional):

```bash
code .
```

---

## 2. Install Required Packages

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
```

---

## 3. Install CLI Tools

```bash
dotnet tool install --global dotnet-ef
dotnet tool install --global dotnet-aspnet-codegenerator
```

---

# Entity Framework Core (Database-First)

## Scaffold Models and DbContext

Generate models from the existing database.

```bash
dotnet ef dbcontext scaffold "Server=localhost;Database=HospitalDB;User Id=sa;Password=StrongPassword@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models
```

This generates:

```
Models/
  Patient.cs
  Doctor.cs
  Appointment.cs
  HospitalDbContext.cs
```

---

# Configure Connection String

Edit **appsettings.json**

```json
{
  "ConnectionStrings": {
    "HospitalDB": "Server=localhost;Database=HospitalDB;User Id=sa;Password=StrongPassword@123;TrustServerCertificate=True;"
  }
}
```

---

# Configure DbContext

Update **Program.cs**

```csharp
using Microsoft.EntityFrameworkCore;
using HospitalMVC.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HospitalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HospitalDB")));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
```

---

# Generate Controllers and Views

Use ASP.NET scaffolding to generate CRUD functionality.

## Patients Controller

```bash
dotnet aspnet-codegenerator controller -name PatientsController -m Patient -dc HospitalDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
```

## Doctors Controller

```bash
dotnet aspnet-codegenerator controller -name DoctorsController -m Doctor -dc HospitalDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
```

## Appointments Controller

```bash
dotnet aspnet-codegenerator controller -name AppointmentsController -m Appointment -dc HospitalDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
```

This generates:

```
Controllers/
  PatientsController.cs
  DoctorsController.cs
  AppointmentsController.cs
```

and corresponding **Views**.

---

# Navigation Setup

Update `_Layout.cshtml` to include navigation links.

```
Patients
Doctors
Appointments
```

This allows easy navigation between pages.

---

# Running the Application

Start the application:

```bash
dotnet run
```

Open the browser:

```
https://localhost:5001
```


---

# Project Structure

```
HospitalMVC
 ├── Controllers
 │   ├── PatientsController.cs
 │   ├── DoctorsController.cs
 │   └── AppointmentsController.cs
 ├── Models
 │   ├── Patient.cs
 │   ├── Doctor.cs
 │   ├── Appointment.cs
 │   └── HospitalDbContext.cs
 ├── Views
 │   ├── Patients
 │   ├── Doctors
 │   └── Appointments
 ├── appsettings.json
 └── Program.cs
```
