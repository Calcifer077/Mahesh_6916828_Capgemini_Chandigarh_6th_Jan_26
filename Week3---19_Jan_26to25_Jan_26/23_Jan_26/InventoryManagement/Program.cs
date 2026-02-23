using System.Security.Cryptography.X509Certificates;

namespace InventoryManagement{
internal class Program
    {
        public class Book
        {
            public string name;
            public int price;
            public bool inStock;

            public Book(string name, int price, bool inStock)
            {
                this.name =name;
                this.price = price;
                this.inStock = inStock;
            }
        }

        public static void dispList(List<Book> listOfBooks)
        {
            foreach(Book b in listOfBooks)
            {
                Console.WriteLine($"Book name: {b.name}, Book price: {b.price}, Book in stock status: {b.inStock}");
            }

            Console.WriteLine("-------------------");
        }

        public static void addNewBooks(List<Book> listOfBooks, Book obj)
        {
            listOfBooks.Add(obj);
        }

        public static List<Book> findBooksCheaper(List<Book> listOfBooks, int price)
        {
            List<Book> res = listOfBooks.FindAll(obj => obj.price < price);

            return res;
        }

        public static List<Book> increasePrice(List<Book> listOfBooks, double percentage)
        {
            return listOfBooks.Select(x => new Book(x.name, x.price + (int)(x.price * percentage), x.inStock)).ToList();
        }

        public static void removeOutOfStockBooks(List<Book> listOfBooks)
        {
            listOfBooks.RemoveAll(x => !x.inStock);
        }

        static void Main(string[] args)
        {
            List<Book> listOfBooks = new List<Book>()
            {
                new Book("The stranger", 2000, true),
                new Book("The Little prince", 2300, true),
                new Book("Three comrades", 5000, true)
            };

            dispList(listOfBooks);

            addNewBooks(listOfBooks, new Book("Girl with Pearl earing", 4000, false));

            dispList(listOfBooks);

            dispList(findBooksCheaper(listOfBooks, 3000));

            dispList(increasePrice(listOfBooks, (double)0.2));

            removeOutOfStockBooks(listOfBooks);
            dispList(listOfBooks);
            
        }
    }
}