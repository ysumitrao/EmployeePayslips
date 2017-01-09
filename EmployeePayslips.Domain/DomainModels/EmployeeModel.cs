using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayslips.Domain.DomainModels
{
    public class EmployeeModel
    {
        public PersonModel Person { get; set; }

        [Display(Name = "Annual Salary")]
        [Required(ErrorMessage = "Annual Salary is required")]
        [Range(0.0, 10000000, ErrorMessage = "Annual Salary must be between 0 and 10000000")]
        public double? AnnualSalary { get; set; }

        [Display(Name = "Super Rate (0% - 50% inclusive)")]
        [Required(ErrorMessage = "Super Rate is required")]
        [Range(0.0, 50, ErrorMessage = "Super Rate must be between 0 and 50")]
        public double? SuperRate { get; set; }

        [Display(Name = "Payment Start Date")]
        [Required(ErrorMessage = "Payment Start Date is required")]
        [DataType(DataType.Date)]
        public DateTime? PaymentStartDate { get; set; }

        [Display(Name = "Pay Period")]
        public string PayPeriod { get; set; }
        [Display(Name = "Gross Income")]
        [DisplayFormat(DataFormatString = "{0:#,###}")]
        public double GrossIncome { get; set; }
        [Display(Name = "Income Tax")]
        [DisplayFormat(DataFormatString = "{0:#,###}")]
        public double IncomeTax { get; set; }
        [Display(Name = "Net Income")]
        [DisplayFormat(DataFormatString = "{0:#,###}")]
        public double NetIncome { get; set; }
        [Display(Name = "Super Amount")]
        [DisplayFormat(DataFormatString = "{0:#,###}")]
        public double SuperAmount { get; set; }
    }
}
