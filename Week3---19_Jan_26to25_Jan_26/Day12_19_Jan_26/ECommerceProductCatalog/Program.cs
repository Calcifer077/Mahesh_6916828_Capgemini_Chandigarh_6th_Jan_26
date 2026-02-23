namespace ECommerceProductCatalog
{
    internal class Program
    {
        class Product {
            public string name { get; set;  }
            public string type { get; set; }
            public int cost { get; set; }
            public bool inCart {get; set;}

            public Product(string type, string name, int cost, bool inCart)
            {
                this.type = type;
                this.name = name;
                this.cost = cost;
                this.inCart = inCart;
            }
        }

        class Electronics : Product{ 
            public Electronics(string name, int cost) : base("Electronics", name, cost, false)
            {
                
            }

            public void moveToCart()
            {
                Console.WriteLine($"Adding {name} to cart.");
                inCart = true;
            }

            public void dispInfo()
            {
                Console.WriteLine($"Type: {type}, Name: {name}, Cost: {cost}, In Cart: {inCart}");
            }
        }
        
        class Clothing : Product
        {
            public Clothing(string name, int cost) : base("Clothing", name, cost, false)
            {
                
            }

            public void moveToCart()
            {
                Console.WriteLine($"Adding {name} to cart.");
                inCart = true;
            }

            public void dispInfo()
            {
                Console.WriteLine($"Type: {type}, Name: {name}, Cost: {cost}, In Cart: {inCart}");
            }
        }
        
        class Books : Product
        {
            
            public Books(string name, int cost) : base("Books", name, cost, false){}

            public void moveToCart()
            {
                Console.WriteLine($"Adding {name} to cart.");
                inCart = true;
            }

            public void dispInfo()
            {
                Console.WriteLine($"Type: {type}, Name: {name}, Cost: {cost}, In Cart: {inCart}");
            }
        }
        
        class Customer
        {
            public string name { get; set; }
            public Product[] prd;
            
            public Customer(string name, Product[] prd)
            {
                this.name = name;
                this.prd = prd;
            }

            public void dispInfo()
            {
                Console.WriteLine($"Customer Name: {name}");
                foreach (var item in prd)
                {
                    Console.WriteLine($"Product Type: {item.type}, Name: {item.name}, Cost: {item.cost}, In Cart: {item.inCart}");
                }
            }
        }

        class Order
        {
            Customer cust;
            public int cost;

            public Order(Customer cust)
            {
                this.cust = cust;
            }

            public void calcTotal()
            {
                int total = 0;
                foreach (var item in cust.prd)
                {
                    if (item.inCart)
                    {
                        total += item.cost;
                    }
                }
                cost = total;
                
                Console.WriteLine($"Total Order Cost: {cost}");
            }

        }

        static void Main(string[] args)
        {
            Electronics laptop = new Electronics("Laptop", 1000);
            Clothing tshirt = new Clothing("T-Shirt", 200);
            Books novel = new Books("Novel", 150);

            laptop.dispInfo();
            tshirt.dispInfo();
            novel.dispInfo();

            laptop.moveToCart();
            tshirt.moveToCart();

            Product[] products = {
                laptop, tshirt, novel
            };

            Customer customer = new Customer("Mahesh", products);
            customer.dispInfo();
            Order order = new Order(customer);
            order.calcTotal();
        }
    }
}