namespace DailyNotes
{
    internal class Program
    {

    // class Animal {
    //     public void Eat() => Console.WriteLine("Eating...");
    // }
    // class Dog : Animal {
    //     public void Bark() => Console.WriteLine("Barking...");
    // }

        // class Animal {
        //      public virtual void Speak() => Console.WriteLine("Animal sound");
        // }
        // class Dog : Animal {
        //     public override void Speak() => Console.WriteLine("Woof!");
        // }

//         abstract class Shape {
//     public abstract void Draw();
// }
// class Circle : Shape {
//     public override void Draw() => Console.WriteLine("Drawing Circle");
// }

// class MathOps {
//     public int Add(int a, int b) => a + b;
//     public double Add(double a, double b) => a + b;
// }

class Base {
    public virtual void Show() => Console.WriteLine("Base Show");
}
class Derived : Base {
    public override void Show() => Console.WriteLine("Derived Show");
}

        static void Main(string[] args)
        {
            // Dog d = new Dog(); d.Eat(); d.Bark();
            // Animal a = new Dog(); a.Speak(); // Woof!
            // Shape s = new Circle(); s.Draw();
            // MathOps m = new MathOps(); Console.WriteLine(m.Add(2,3));
            Base b = new Derived(); b.Show(); // Derived Show
        }
    }
}
