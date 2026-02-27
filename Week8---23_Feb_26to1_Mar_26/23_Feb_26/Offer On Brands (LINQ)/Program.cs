using System;
using System.Collections.Generic;
using System.Linq;

namespace Offer_On_Brands__LINQ_
{
    class Model
    {
        public string ModelName { get; set; }
        public int CarSpeed { get; set; }
    }

    class Implementation
    {
        public List<string> GetModelName(List<Model> ls)
        {
            return ls.Select(item => item.ModelName).ToList();
        }

        public Model GetModelInfo(List<Model> ls, string Name, int speed)
        {
            return ls
                .Where(item => item.ModelName == Name && item.CarSpeed == speed)
                .FirstOrDefault();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Model> carList = new List<Model>()
            {
                new Model { ModelName = "BMW", CarSpeed = 250 },
                new Model { ModelName = "Audi", CarSpeed = 240 },
                new Model { ModelName = "Tesla", CarSpeed = 260 },
                new Model { ModelName = "Mercedes", CarSpeed = 245 }
            };

            Implementation obj = new Implementation();

            var names = obj.GetModelName(carList);
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            var model = obj.GetModelInfo(carList, "Tesla", 260);

            if (model != null)
            {
                Console.WriteLine("Model Found:");
                Console.WriteLine("Name: " + model.ModelName);
                Console.WriteLine("Speed: " + model.CarSpeed);
            }
            else
            {
                Console.WriteLine("Model not found");
            }
        }
    }
}