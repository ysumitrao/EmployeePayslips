using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayslips.Interfaces
{
    public interface IPayslips
    {
        string GetPayPeriod(DateTime paymentStartDate);
        double GetGrossIncome(double annualSalary);
        double GetIncomeTax(double annualSalary);
        double GetNetIncome(double grossIncome, double incomeTax);
        double GetSuperAmount(double grossIncome, double superRate);
    }
}
