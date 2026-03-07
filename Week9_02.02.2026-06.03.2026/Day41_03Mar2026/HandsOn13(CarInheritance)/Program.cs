using System;

abstract class Car
{
    protected bool isSedan;
    protected string seats;
    public Car(bool isSedan, string seats)
    {
        this.isSedan = isSedan;
        this.seats = seats;
    }
    public bool getIsSedan()
    {
        return isSedan;
    }
    public string getSeats()
    {
        return seats;
    }
    public abstract string getMileage();
}

class WagonR : Car
{
    private int mileage;

    public WagonR(int mileage) : base(false, "4")
    {
        this.mileage = mileage;
    }

    public override string getMileage()
    {
        return mileage + " kmpl";
    }
}

class HondaCity : Car
{
    private int mileage;

    public HondaCity(int mileage) : base(true, "4")
    {
        this.mileage = mileage;
    }

    public override string getMileage()
    {
        return mileage + " kmpl";
    }
}

class InnovaCrysta : Car
{
    private int mileage;

    public InnovaCrysta(int mileage) : base(false, "6")
    {
        this.mileage = mileage;
    }

    public override string getMileage()
    {
        return mileage + " kmpl";
    }
}

class Solution
{
    static void Main(String[] args)
    {
        int type = Convert.ToInt32(Console.ReadLine());
        int mileage = Convert.ToInt32(Console.ReadLine());

        Car car;

        if (type == 0)
            car = new WagonR(mileage);
        else if (type == 1)
            car = new HondaCity(mileage);
        else
            car = new InnovaCrysta(mileage);

        Console.WriteLine($"A {car.GetType().Name} is {(car.getIsSedan() ? "" : "not ")}Sedan, is {car.getSeats()}-seater, and has a mileage of around {car.getMileage()}.");
    }
}