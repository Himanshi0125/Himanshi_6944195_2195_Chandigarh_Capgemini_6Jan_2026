using System;

public abstract class Computer
{
    protected string type;
    protected string model;
    protected string cpu;
    protected bool isTurnedOn = false;

    public Computer(string type, string model, string cpu)
    {
        this.type = type;
        this.model = model;
        this.cpu = cpu;
    }

    public string GetComputerType()
    {
        return type;
    }

    public string GetComputerModel()
    {
        return model;
    }

    public string GetComputerCpu()
    {
        return cpu;
    }

    public bool GetComputerStatus()
    {
        return isTurnedOn;
    }

    public void SwitchComputerStatus()
    {
        isTurnedOn = !isTurnedOn;
    }
}

public class PersonalComputer : Computer
{
    public PersonalComputer(string model, string cpu)
        : base("PersonalComputer", model, cpu)
    {
    }
}

public class ServerComputer : Computer
{
    public ServerComputer(string model, string cpu)
        : base("ServerComputer", model, cpu)
    {
    }
}

class Solution
{
    static void PrintStatus(Computer c)
    {
        if (c.GetComputerStatus())
            Console.WriteLine(c.GetComputerModel() + " is turned on");
        else
            Console.WriteLine(c.GetComputerModel() + " is turned off");
    }

    static void Main()
    {
        var pcInput = Console.ReadLine().Split();
        var serverInput = Console.ReadLine().Split();

        PersonalComputer pc = new PersonalComputer(pcInput[0], pcInput[1]);
        ServerComputer server = new ServerComputer(serverInput[0], serverInput[1]);

        Console.WriteLine("PersonalComputer info: Type - " + pc.GetComputerType() +
                          ", Model - " + pc.GetComputerModel() +
                          ", CPU - " + pc.GetComputerCpu());

        PrintStatus(pc);

        Console.WriteLine("Switching");
        pc.SwitchComputerStatus();
        PrintStatus(pc);

        Console.WriteLine("Switching");
        pc.SwitchComputerStatus();
        PrintStatus(pc);

        Console.WriteLine("ServerComputer info: Type - " + server.GetComputerType() +
                          ", Model - " + server.GetComputerModel() +
                          ", CPU - " + server.GetComputerCpu());

        PrintStatus(server);

        Console.WriteLine("Switching");
        server.SwitchComputerStatus();
        PrintStatus(server);

        Console.WriteLine("Switching");
        server.SwitchComputerStatus();
        PrintStatus(server);
    }
}