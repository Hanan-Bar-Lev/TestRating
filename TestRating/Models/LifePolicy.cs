using System.ComponentModel.DataAnnotations;
using TestRating.Services.Validation;

namespace TestRating.Models
{
    [ValidDateOfBirthAttribute]
    public class LifePolicy : Policy
    {
        public bool IsSmoker { get; set; }
        [Required(ErrorMessage = "Life policy must include an Amount.")]
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; }
        public override decimal Rate()
        {
            Console.WriteLine("Rating LIFE ..");

            Console.WriteLine("Validating policy.");
            if (!Validate())
                return 0;
            
            int age = DateTime.Today.Year - DateOfBirth.Year;
            
            if (DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < DateOfBirth.Day ||
                DateTime.Today.Month < DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = Amount * age / 200;

            return IsSmoker ? baseRate * 2 : baseRate;
            
        }

      
    }
}
