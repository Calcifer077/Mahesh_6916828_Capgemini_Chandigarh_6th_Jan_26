namespace VehicleRentalSystem
{
    internal class Program
    {

        class Vehicle
        {
            public string type { get; set; }
            public string brand { get; set; }
            public int wheels { get; set; }
            public int cost { get; set; }

            public Vehicle(string type, string brand, int wheels, int cost)
            {
                this.type = type;
                this.brand = brand;
                this.wheels = wheels;
                this.cost = cost;
            }
        }

        class Car : Vehicle
        {

            //Vehicle obj;

            public Car(string type, string brand, int wheels, int cost) : base(type, brand, wheels, cost)
            {

            }

            public void DispInfo()
            {
                Console.WriteLine("This is a " + type + " of " + brand + " with " + wheels + " wheels costing " + cost);
            }
        }
        class Bike : Vehicle
        {
            public Bike(string type, string brand, int wheels, int cost) : base(type, brand, wheels, cost)
            {

            }

            public void DispInfo()
            {
                Console.WriteLine("This is a " + type + " of " + brand + " with " + wheels + " wheels costing " + cost);
            }
        }

        class Truck : Vehicle
        {
            public Truck(string type, string brand, int wheels, int cost) : base(type, brand, wheels, cost)
            {

            }

            public void DispInfo()
            {
                Console.WriteLine("This is a " + type + " of " + brand + " with " + wheels + " wheels costing " + cost);
            }
        }

        class Customer
        {
            public string name;

            public Vehicle[] allVeh;

            public Customer(string name, Vehicle[] allVeh)
            {
                this.name = name;
                this.allVeh = allVeh;
            }

            public void dispInfo()
            {
                Console.WriteLine("Customer name is " + name);
                foreach (var item in allVeh)
                {
                    Console.WriteLine("This is a " + item.type + " of " + item.brand + " with " + item.wheels + " wheels costing " + item.cost);
                }
            }

            class RentalTransaction
            {
                public Customer cst;
                int totalCost;

                public RentalTransaction(Customer cst)
                {
                    this.cst = cst;
                }

                public void calcCost()
                {
                    foreach (var item in cst.allVeh)
                    {
                        totalCost += item.cost;
                    }

                    Console.WriteLine("Total cost for this customer is " + totalCost);
                }
            }

            static void Main(string[] args)
            {
                Car c = new Car("Car", "Suzuki", 4, 1000);
                Bike b = new Bike("Bike", "Honda", 2, 500);
                Truck t = new Truck("Truck", "Ashok Leyland", 8, 2000);
                c.DispInfo();
                b.DispInfo();
                t.DispInfo();

                Vehicle[] allVeh = { c, b, t };

                Customer cst = new Customer("Mahesh", allVeh);

                cst.dispInfo();

                RentalTransaction rt = new RentalTransaction(cst);
                rt.calcCost();
            }
        }
    }
}