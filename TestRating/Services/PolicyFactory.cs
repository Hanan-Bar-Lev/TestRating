using Newtonsoft.Json.Linq;
using TestRating.Models;

namespace TestRating.Services
{
    public class PolicyFactory
    {
        public static Policy CreatePolicy(string json)
        {
            try
            {
                var jsonObject = JObject.Parse(json);
                var type = jsonObject["type"].ToString();

                switch (type)
                {
                    case "Health":
                        return jsonObject.ToObject<HealthPolicy>();
                    case "Travel":
                        return jsonObject.ToObject<TravelPolicy>();
                    case "Life":
                        return jsonObject.ToObject<LifePolicy>();
                    default:
                        Console.WriteLine($"Unknown policy type: {type}");
                        return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }

        }
    }

}
