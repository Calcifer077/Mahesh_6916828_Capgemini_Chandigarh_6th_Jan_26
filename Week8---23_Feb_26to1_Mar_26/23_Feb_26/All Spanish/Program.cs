namespace All_Spanish
{
    class Dish
    {
        public string dishName {  get; set; }
    }

    class DishTest
    {
        public List<Dish> AddYummyToName(List<Dish> ls, string Name)
        {
            for(int i = 0; i < ls.Count; i++)
            {
                ls[i].dishName = ls[i].dishName + " " + Name;
            }

            return ls;
            
        }

        public long CountDishes(List<Dish> ls, string str)
        {
            long count = 0;

            foreach(var item in ls)
            {
                if (item.dishName.Contains(str))
                {
                    count++;
                }
            }

            return count;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // Create list of dishes
            List<Dish> dishes = new List<Dish>
        {
            new Dish { dishName = "Paella" },
            new Dish { dishName = "Tacos" },
            new Dish { dishName = "Spicy Burrito" },
            new Dish { dishName = "Churros" }
        };

            DishTest test = new DishTest();

            // Append "Yummy" to each dish name
            dishes = test.AddYummyToName(dishes, "Yummy");

            Console.WriteLine("After Appending:");
            foreach (var dish in dishes)
            {
                Console.WriteLine(dish.dishName);
            }

            Console.WriteLine();

            // Count dishes containing a specific string
            long result = test.CountDishes(dishes, "Spicy");

            Console.WriteLine("Number of dishes containing 'Spicy': " + result);

        }
    }
}
