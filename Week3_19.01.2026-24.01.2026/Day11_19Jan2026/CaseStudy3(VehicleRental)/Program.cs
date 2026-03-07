using System;

namespace VehicleRentalSystem
{
    // Base Class
    class Vehicle
    {
        private int vehicleId;
        private string model;
        protected double rentPerDay;
        private bool isAvailable = true;

        public Vehicle(int id, string model, double rent)
        {
            vehicleId = id;
            this.model = model;
            rentPerDay = rent;
        }

        public bool IsAvailable()
        {
            return isAvailable;
        }

        public void RentVehicle()
        {
            isAvailable = false;
        }

        public void ReturnVehicle()
        {
            isAvailable = true;
        }

        public virtual double CalculateRent(int days)
        {
            return rentPerDay * days;
        }

        public void DisplayVehicle()
        {
            Console.WriteLine($"ID: {vehicleId}, Model: {model}, Rent/Day: ₹{rentPerDay}, Available: {isAvailable}");
        }
    }

    // Derived Class - Car
    class Car : Vehicle
    {
        public Car(int id, string model)
            : base(id, model, 2000) { }
    }

    // Derived Class - Bike
    class Bike : Vehicle
    {
        public Bike(int id, string model)
            : base(id, model, 800) { }
    }

    // Derived Class - Truck
    class Truck : Vehicle
    {
        public Truck(int id, string model)
            : base(id, model, 4000) { }
    }

    // Customer Class
    class Customer
    {
        private int customerId;
        private string name;

        public Customer(int id, string name)
        {
            customerId = id;
            this.name = name;
        }

        public void DisplayCustomer()
        {
            Console.WriteLine($"Customer ID: {customerId}, Name: {name}");
        }
    }

    // Rental Transaction Class
    class RentalTransaction
    {
        private Customer customer;
        private Vehicle vehicle;
        private int rentalDays;

        public RentalTransaction(Customer cust, Vehicle veh, int days)
        {
            customer = cust;
            vehicle = veh;
            rentalDays = days;
        }

        public void ProcessRental()
        {
            if (vehicle.IsAvailable())
            {
                vehicle.RentVehicle();
                double cost = vehicle.CalculateRent(rentalDays);
                Console.WriteLine("Rental successful.");
                Console.WriteLine("Total Rent: ₹" + cost);
            }
            else
            {
                Console.WriteLine("Vehicle not available.");
            }
        }

        public void ReturnVehicle()
        {
            vehicle.ReturnVehicle();
            Console.WriteLine("Vehicle returned successfully.");
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = new Car(1, "Honda City");
            Vehicle bike = new Bike(2, "Royal Enfield");
            Vehicle truck = new Truck(3, "Tata Truck");

            Customer customer = new Customer(101, "Himanshi");

            car.DisplayVehicle();
            bike.DisplayVehicle();

            RentalTransaction rental = new RentalTransaction(customer, car, 3);
            rental.ProcessRental();

            car.DisplayVehicle();

            rental.ReturnVehicle();
            car.DisplayVehicle();

            Console.ReadLine();
        }
    }
}
