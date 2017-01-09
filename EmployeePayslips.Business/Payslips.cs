using EmployeePayslips.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayslips.Business
{
    public class Payslips : IPayslips
    {
        public double GetGrossIncome(double annualSalary)
        {
            return Math.Round(annualSalary / 12, MidpointRounding.AwayFromZero);
        }

        public double GetIncomeTax(double annualSalary)
        {
            double incomeTax = 0;
            if (annualSalary > 18200 && annualSalary < 37000)
            {
                incomeTax = 0.19 * (annualSalary - 18200) / 12;
            }
            else if (annualSalary > 37000 && annualSalary < 80000)
            {
                incomeTax = (3572 + (annualSalary - 37000) * 0.325) / 12;
            }
            else if (annualSalary > 80000 && annualSalary < 180000)
            {
                incomeTax = (17547 + (annualSalary - 80000) * 0.37) / 12;
            }
            else if (annualSalary > 180000)
            {
                incomeTax = (54547 + (annualSalary - 180000) * 0.45) / 12;
            }

            return Math.Round(incomeTax, MidpointRounding.AwayFromZero);      
        }

        public double GetNetIncome(double grossIncome, double incomeTax)
        {
            return grossIncome - incomeTax;
        }

        public string GetPayPeriod(DateTime paymentStartDate)
        {
            var firstDayOfMonth = new DateTime(paymentStartDate.Year, paymentStartDate.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            var monthName = paymentStartDate.ToString("MMMM");
            return firstDayOfMonth.Day + " " + monthName + " - " + lastDayOfMonth.Day + " " + monthName;
        }

        public double GetSuperAmount(double grossIncome, double superRate)
        {
            return Math.Round(grossIncome * superRate / 100, MidpointRounding.AwayFromZero);
        }
    }
}
