using TestRating.Models;
using TestRating.Services;

namespace TestRating
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insurance Rating System Starting...");

            // Load policy from JSON file
            string policyJson = File.ReadAllText("..\\..\\..\\Data\\policy.json");
            var policy = PolicyFactory.CreatePolicy(policyJson);

            // Create a new rating engine
            var engine = new RatingEngine();

            // Rate the policy
            engine.Rate(policy);

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating: {engine.Rating}");
            }
            else
            {
                Console.WriteLine("No rating produced.");
            }
        }
    }
}