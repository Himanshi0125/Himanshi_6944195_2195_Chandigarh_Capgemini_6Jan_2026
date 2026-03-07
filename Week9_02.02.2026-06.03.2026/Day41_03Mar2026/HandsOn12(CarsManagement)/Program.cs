using System;
using System.Collections.Generic;
using System.Linq;

public class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Price { get; set; }

    public Car(string brand, string model, int price)
    {
        Brand = brand;
        Model = model;
        Price = price;
    }
}

public class CarManager
{
    private List<Car> cars;

    public CarManager(List<Car> cars)
    {
        this.cars = cars;
    }

    public Car MostExpensiveCar()
    {
        return cars.OrderByDescending(c => c.Price).First();
    }

    public Car CheapestCar()
    {
        return cars.OrderBy(c => c.Price).First();
    }

    public int AveragePriceOfCars()
    {
        return (int)Math.Round(cars.Average(c => c.Price));
    }

    public Dictionary<string, Car> MostExpensiveModelForEachBrand()
    {
        return cars
            .GroupBy(c => c.Brand)
            .OrderBy(g => g.Key)
            .ToDictionary(
                g => g.Key,
                g => g.OrderByDescending(c => c.Price).First()
            );
    }
}

class Solution
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            var parts = Console.ReadLine().Split();

            string brand = parts[0];
            string model = parts[1];
            int price = int.Parse(parts[2]);

            cars.Add(new Car(brand, model, price));
        }

        CarManager manager = new CarManager(cars);

        var mostExp = manager.MostExpensiveCar();
        Console.WriteLine($"The most expensive car is {mostExp.Brand} {mostExp.Model}");

        var cheapest = manager.CheapestCar();
        Console.WriteLine($"The cheapest car is {cheapest.Brand} {cheapest.Model}");

        Console.WriteLine($"The average price of all cars is {manager.AveragePriceOfCars()}");

        var dict = manager.MostExpensiveModelForEachBrand();

        foreach (var item in dict)
        {
            Console.WriteLine($"The most expensive model for brand {item.Key} is {item.Value.Model} having price {item.Value.Price}");
        }
    }
}