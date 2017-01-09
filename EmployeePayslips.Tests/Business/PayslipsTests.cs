using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayslips.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayslips.Business.Tests
{
    [TestClass()]
    public class PayslipsTests
    {
        [TestMethod()]
        public void GetGrossIncomeTest_WithoutRounding()
        {
            double annualSalary = 12000;
            Payslips payslips = new Business.Payslips();
            double grossIncome = payslips.GetGrossIncome(annualSalary);
            Assert.AreEqual(grossIncome, 1000);
        }

        [TestMethod()]
        public void GetGrossIncomeTest_WithRounding()
        {
            double annualSalary = 12200;
            Payslips payslips = new Business.Payslips();
            double grossIncome = payslips.GetGrossIncome(annualSalary);
            Assert.AreEqual(grossIncome, 1017);
        }

        [TestMethod()]
        public void GetIncomeTaxTest_NoTax()
        {
            double annualSalary = 18000;
            Payslips payslips = new Business.Payslips();
            double incomeTax = payslips.GetIncomeTax(annualSalary);
            Assert.AreEqual(incomeTax, 0);
        }

        [TestMethod()]
        public void GetIncomeTaxTest_TaxSlab1()
        {
            double annualSalary = 30000;
            Payslips payslips = new Business.Payslips();
            double incomeTax = payslips.GetIncomeTax(annualSalary);
            Assert.AreEqual(incomeTax, 187);
        }

        [TestMethod()]
        public void GetIncomeTaxTest_TaxSlab2()
        {
            double annualSalary = 60050;
            Payslips payslips = new Business.Payslips();
            double incomeTax = payslips.GetIncomeTax(annualSalary);
            Assert.AreEqual(incomeTax, 922);
        }

        [TestMethod()]
        public void GetIncomeTaxTest_TaxSlab3()
        {
            double annualSalary = 125000;
            Payslips payslips = new Business.Payslips();
            double incomeTax = payslips.GetIncomeTax(annualSalary);
            Assert.AreEqual(incomeTax, 2850);
        }

        [TestMethod()]
        public void GetIncomeTaxTest_TaxSlab4()
        {
            double annualSalary = 200000;
            Payslips payslips = new Business.Payslips();
            double incomeTax = payslips.GetIncomeTax(annualSalary);
            Assert.AreEqual(incomeTax, 5296);
        }

        [TestMethod()]
        public void GetNetIncomeTest()
        {
            double grossIncome = 5004;
            double incomeTax = 922;
            Payslips payslips = new Business.Payslips();
            double netIncome = payslips.GetNetIncome(grossIncome, incomeTax);
            Assert.AreEqual(netIncome, 4082);
        }

        [TestMethod()]
        public void GetPayPeriodTest()
        {
            DateTime dtPayPeriod = Convert.ToDateTime("1/3/2016");
            Payslips payslips = new Business.Payslips();
            string payPerisod = payslips.GetPayPeriod(dtPayPeriod);
            Assert.AreEqual(payPerisod, "1 March - 31 March");
        }

        [TestMethod()]
        public void GetSuperAmountTest()
        {
            double grossIncome = 5004;
            double superRate = 9;
            Payslips payslips = new Business.Payslips();
            double superAmount = payslips.GetSuperAmount(grossIncome, superRate);
            Assert.AreEqual(superAmount, 450);
        }
    }
}