using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExistingMemberIdAttribute : ValidationAttribute
    {
       
       
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var dbContext = (CoronaDb)validationContext.GetService(typeof(CoronaDb));
                var memberId = (string)value;

                // Check if the member with the provided memberId exists in the database
                var memberExists = dbContext.Members.Any(m => m.Id == memberId);

                if (!memberExists)
                {
                    return new ValidationResult("The provided member Id does not exist in the system.");
                }

                return ValidationResult.Success;
            }
        }
    }

