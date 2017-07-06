using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Vidlyv2.Models
{
    class StockRange0To20 : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            if (movie.NumberInStock > 0 && movie.NumberInStock <= 20)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Stock number should be between 0 and 20");
                
                
            }

        }
    }
}
