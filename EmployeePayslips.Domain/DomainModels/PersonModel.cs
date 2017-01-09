using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayslips.Domain.DomainModels
{
    public class PersonModel
    {
        [Required(ErrorMessage = "First Name is required")]        
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
       
        [Display(Name = "Name")]
        public string PersonName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public DateTime? DateOfBirth { get; set; }
    }
}
