using EmployeePayslips.Domain.DomainModels;
using EmployeePayslips.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeePayslips.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IPayslips _payslips;
        public EmployeeController(IPayslips payslips)
        {
            _payslips = payslips;
        }

        public ActionResult EmployeeDetails()
        {
            return View();
        }

        public ActionResult EmployeePayslip(EmployeeModel employee)
        {
            if (!ModelState.IsValid)
            {
                return View("EmployeeDetails");
            }
            else
            {
                employee.PayPeriod = _payslips.GetPayPeriod(employee.PaymentStartDate.Value);
                employee.GrossIncome = _payslips.GetGrossIncome(employee.AnnualSalary.Value);
                employee.IncomeTax = _payslips.GetIncomeTax(employee.AnnualSalary.Value);
                employee.NetIncome = _payslips.GetNetIncome(employee.GrossIncome, employee.IncomeTax);
                employee.SuperAmount = _payslips.GetSuperAmount(employee.GrossIncome, employee.SuperRate.Value);
                return View(employee);
            }
        }
    }
}