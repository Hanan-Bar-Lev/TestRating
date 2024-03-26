using System.ComponentModel.DataAnnotations;

namespace TestRating.Models
{
    public  class HealthPolicy : Policy
    {

        [Required(ErrorMessage = "Health policy must specify Gender")]
        public string Gender { get; set; }
        public decimal Deductible { get; set; }

        public override decimal Rate()
        {
            Console.WriteLine("Rating HEALTH policy...");

            Console.WriteLine("Validating policy.");
            if (!Validate())
                return 0;

            decimal Rating;
            if (Gender == "Male")
            {
                if (Deductible < 500)
                    Rating = 1000m;
                else
                    Rating = 900m;
            }
            else
            {
                if (Deductible < 800)
                    Rating = 1100m;
                else
                    Rating = 1000m;
            }

            return Rating;
        }

 
    }
}
