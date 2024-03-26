using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;
using TestRating.Models;
using TestRating.Models.enums;

namespace TestRating.Services
{

    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; }
        public void Rate(Policy policy)
        {
            if (policy != null)
                Rating = policy.Rate();
            Console.WriteLine("Rating completed.");
        }

    }
}
