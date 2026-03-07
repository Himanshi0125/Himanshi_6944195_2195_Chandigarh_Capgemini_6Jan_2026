using System;
using System.Collections.Generic;
using System.Linq;

// =======================
// Patient Class
// =======================
class Patient
{
    private string _name;
    private int _age;
    private string _illness;
    private string _city;

    // Default constructor
    public Patient()
    {
    }

    // 4-argument constructor
    public Patient(string Name, int Age, string Illness, string City)
    {
        this._name = Name;
        this._age = Age;
        this._illness = Illness;
        this._city = City;
    }

    // Properties
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int Age
    {
        get { return _age; }
        set { _age = value; }
    }

    public string Illness
    {
        get { return _illness; }
        set { _illness = value; }
    }

    public string City
    {
        get { return _city; }
        set { _city = value; }
    }

    // ToString override
    public override string ToString()
    {
        return string.Format("{0,-21}{1,-6}{2,-17}{3,-20}",
                             this._name,
                             this._age,
                             this._illness,
                             this._city);
    }
}

// =======================
// PatientBO Class
// =======================
class PatientBO
{
    public void DisplayPatientDetails(List<Patient> patientList, string name)
    {
        List<Patient> result = (from p in patientList
                                where p.Name == name
                                select p).ToList();

        if (result.Count == 0)
        {
            Console.WriteLine("Patient named {0} not found", name);
        }
        else
        {
            Console.WriteLine("Name                 Age   Illness          City");
            foreach (Patient p in result)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }

    public void DisplayYoungestPatientDetails(List<Patient> patientList)
    {
        int minAge = (from p in patientList
                      select p.Age).Min();

        var youngest = from p in patientList
                       where p.Age == minAge
                       select p;

        Console.WriteLine("The Youngest Patient Details");
        Console.WriteLine("Name                 Age   Illness          City");
        foreach (Patient p in youngest)
        {
            Console.WriteLine(p.ToString());
        }
    }

    public void displayPatientsFromCity(List<Patient> patientList, string cname)
    {
        List<Patient> result = (from p in patientList
                                where p.City == cname
                                select p).ToList();

        if (result.Count == 0)
        {
            Console.WriteLine("City named {0} not found", cname);
        }
        else
        {
            Console.WriteLine("Name                 Age   Illness          City");
            foreach (Patient p in result)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}

// =======================
// Program Class (Main)
// =======================
class Program
{
    static void Main(string[] args)
    {
        List<Patient> patientList = new List<Patient>();

        Console.WriteLine("Enter the number of patients");
        int n = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter patient " + (i + 1) + " details:");
            Console.WriteLine("Enter the name");
            string name = Console.ReadLine()!;

            Console.WriteLine("Enter the age");
            int age = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter the illness");
            string illness = Console.ReadLine()!;

            Console.WriteLine("Enter the city");
            string city = Console.ReadLine()!;

            Patient p = new Patient(name, age, illness, city);
            patientList.Add(p);
        }

        PatientBO patientBO = new PatientBO();
        string opt;

        do
        {
            Console.WriteLine("Enter your choice:");
            Console.WriteLine("1)Display Patient Details");
            Console.WriteLine("2)Display Youngest Patient Details");
            Console.WriteLine("3)Display Patients from City");

            int choice = int.Parse(Console.ReadLine()!);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter patient name:");
                    string pname = Console.ReadLine()!;
                    patientBO.DisplayPatientDetails(patientList, pname);
                    break;

                case 2:
                    patientBO.DisplayYoungestPatientDetails(patientList);
                    break;

                case 3:
                    Console.WriteLine("Enter city");
                    string cname = Console.ReadLine()!;
                    patientBO.displayPatientsFromCity(patientList, cname);
                    break;
            }

            Console.WriteLine("Do you want to continue(Yes/No)?");
            opt = Console.ReadLine()!;

        } while (opt.Equals("Yes"));
    }
}
