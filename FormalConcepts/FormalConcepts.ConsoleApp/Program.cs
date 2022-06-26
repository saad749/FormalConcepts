using FormalConcepts.Algorithm;

namespace FormalConcepts.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            MinimalCoverage.Extract(
                "This is a Cat. This cat is very cute. Cats are cute. Cats are friendly animals. Most friendly animals are cute. Friendly animals can be Pets.", 
                "eng");
            Console.WriteLine("Bye, World!");
        }
    }
}