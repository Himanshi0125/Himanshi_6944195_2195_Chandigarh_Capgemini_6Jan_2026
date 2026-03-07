using System;

class Person
{
    public string Name;

    public virtual void Show()
    {
        Console.WriteLine("Name: " + Name);
    }
}

class Patient : Person
{
    public string Disease;

    public override void Show()
    {
        Console.WriteLine("Patient Name: " + Name + " Disease: " + Disease);
    }
}

class Doctor : Person
{
    public string Specialization;

    public override void Show()
    {
        Console.WriteLine("Doctor Name: " + Name + " Specialization: " + Specialization);
    }
}

class Nurse : Person
{
    public override void Show()
    {
        Console.WriteLine("Nurse Name: " + Name);
    }
}

class Program
{
    static void Main()
    {
        Patient p = new Patient();
        p.Name = "Rahul";
        p.Disease = "Fever";
        p.Show();

        Doctor d = new Doctor();
        d.Name = "Dr. Mehta";
        d.Specialization = "Cardiology";
        d.Show();
    }
}