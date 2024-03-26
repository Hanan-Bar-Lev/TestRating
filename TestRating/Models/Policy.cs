using System;
using System.ComponentModel.DataAnnotations;
using TestRating.Models.enums;
using TestRating.Services.Validation;

namespace TestRating.Models
{

    public abstract class Policy:IValidatePolicy
    {

        public PolicyType Type { get; set; }

        #region General Policy Prop
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        #endregion

        public abstract decimal Rate();

        public virtual bool Validate()
        {
            var context = new ValidationContext(this, null, null);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(this, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return false;
            }

            return true;
        }

    }
}