using System;
using System.IO;
using System.Xml.Serialization;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Program
{
    static void Main()
    {
        Student s = new Student { Id = 2, Name = "Alice" };

        XmlSerializer xs = new XmlSerializer(typeof(Student));

        using (StreamWriter sw = new StreamWriter("student.xml"))
        {
            xs.Serialize(sw, s);
        }

        using (StreamReader sr = new StreamReader("student.xml"))
        {
            Student obj = (Student)xs.Deserialize(sr);
            Console.WriteLine(obj.Id + " " + obj.Name);
        }
    }
}