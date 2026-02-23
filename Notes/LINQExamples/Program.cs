namespace LINQExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var products = new List<string> { "Pen", "Pencil", "Notebook", "Marker", "Paper" };

            // Step 1: Filter items that start with 'P'
            var startingWithP = products.Where(p => p.StartsWith("P"));

            // Step 2: Project to uppercase
            var upper = startingWithP.Select(p => p.ToUpper());

            // Step 3: Materialize and print
            foreach (var item in upper)
                Console.WriteLine(item);

        }
    }
}