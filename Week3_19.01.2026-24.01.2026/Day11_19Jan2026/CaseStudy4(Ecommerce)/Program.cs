using System;
using System.Collections.Generic;

namespace ECommerceProductCatalog
{
    // Base Class
    class Product
    {
        private int productId;
        private string name;
        protected double price;
        protected int stock;

        public Product(int id, string name, double price, int stock)
        {
            productId = id;
            this.name = name;
            this.price = price;
            this.stock = stock;
        }

        public bool IsAvailable()
        {
            return stock > 0;
        }

        public void ReduceStock(int qty)
        {
            stock -= qty;
        }

        public virtual void DisplayProduct()
        {
            Console.WriteLine($"ID: {productId}, Name: {name}, Price: ₹{price}, Stock: {stock}");
        }
    }

    // Derived Class - Electronics
    class Electronics : Product
    {
        private int warrantyYears;

        public Electronics(int id, string name, double price, int stock, int warranty)
            : base(id, name, price, stock)
        {
            warrantyYears = warranty;
        }

        public override void DisplayProduct()
        {
            base.DisplayProduct();
            Console.WriteLine("Category: Electronics, Warranty: " + warrantyYears + " years");
        }
    }

    // Derived Class - Clothing
    class Clothing : Product
    {
        private string size;

        public Clothing(int id, string name, double price, int stock, string size)
            : base(id, name, price, stock)
        {
            this.size = size;
        }

        public override void DisplayProduct()
        {
            base.DisplayProduct();
            Console.WriteLine("Category: Clothing, Size: " + size);
        }
    }

    // Derived Class - Books
    class Books : Product
    {
        private string author;

        public Books(int id, string name, double price, int stock, string author)
            : base(id, name, price, stock)
        {
            this.author = author;
        }

        public override void DisplayProduct()
        {
            base.DisplayProduct();
            Console.WriteLine("Category: Books, Author: " + author);
        }
    }

    // Cart Class
    class Cart
    {
        private List<Product> items = new List<Product>();

        public void AddToCart(Product product)
        {
            if (product.IsAvailable())
            {
                items.Add(product);
                product.ReduceStock(1);
                Console.WriteLine("Product added to cart.");
            }
            else
            {
                Console.WriteLine("Product out of stock.");
            }
        }

        public double GetTotal()
        {
            double total = 0;
            foreach (var item in items)
            {
                total += item.price;
            }
            return total;
        }
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

    // Order Class
    class Order
    {
        private Customer customer;
        private Cart cart;

        public Order(Customer cust, Cart cart)
        {
            customer = cust;
            this.cart = cart;
        }

        public void PlaceOrder()
        {
            Console.WriteLine("Order placed successfully.");
            Console.WriteLine("Total Amount: ₹" + cart.GetTotal());
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            Product laptop = new Electronics(1, "Laptop", 60000, 5, 2);
            Product tshirt = new Clothing(2, "T-Shirt", 1200, 10, "M");
            Product book = new Books(3, "C# Programming", 800, 7, "Herbert Schildt");

            Cart cart = new Cart();
            Customer customer = new Customer(101, "Himanshi");

            laptop.DisplayProduct();
            tshirt.DisplayProduct();
            book.DisplayProduct();

            cart.AddToCart(laptop);
            cart.AddToCart(book);

            Order order = new Order(customer, cart);
            order.PlaceOrder();

            Console.ReadLine();
        }
    }
}
