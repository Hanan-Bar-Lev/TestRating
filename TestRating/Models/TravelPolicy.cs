using System.ComponentModel.DataAnnotations;

namespace TestRating.Models
{
    public class TravelPolicy: Policy
    {

        [Required(ErrorMessage = "Travel policy must specify country.")]
        public string Country { get; set; }
        [Range(1, 180, ErrorMessage = "Travel policy cannot be more then 180 Days.")]
        public int Days { get; set; }

        public override decimal Rate()
        {
            Console.WriteLine("Rating TRAVEL ..");

            Console.WriteLine("Validating policy.");
            if (!Validate())
                return 0;

            decimal Rating = Days * 2.5m;
            if (Country == "Italy")
            {
                Rating *= 3;
            }

            return Rating;

        }

    }
}
