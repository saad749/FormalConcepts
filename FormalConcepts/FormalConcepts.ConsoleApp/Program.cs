using FormalConcepts.Algorithm;

namespace FormalConcepts.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            MinimalCoverage.Extract("This is a Cat. She is very cute. Cats are cute.", "eng");
            Console.WriteLine("Bye, World!");
        }
    }
}