using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayslips.Tests.Helpers
{
    public class TestModelHelper
    {
        public static IList<ValidationResult> Validate(object model)
        {           
            var validationContext = new ValidationContext(model, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, validationContext, validationResults);            
            return validationResults;
        }
    }
}
