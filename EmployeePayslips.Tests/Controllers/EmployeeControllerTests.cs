using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayslips.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using EmployeePayslips.Interfaces;
using Microsoft.Practices.Unity;
using EmployeePayslips.Domain.DomainModels;
using System.Web.Mvc;
using EmployeePayslips.Tests.Helpers;

namespace EmployeePayslips.Controllers.Tests
{
    [TestClass()]
    public class EmployeeControllerTests
    {
        private Mock<IPayslips> _payslips;

        [TestInitialize]
        public void SetupTest()
        {
            _payslips = new Mock<IPayslips>();
            IUnityContainer container = new UnityContainer();
            container.RegisterInstance(_payslips.Object);
        }

        [TestMethod()]
        public void EmployeeDetailsTest()
        {
            var employeeDetails = new EmployeeController(_payslips.Object);
            ViewResult result = employeeDetails.EmployeeDetails() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void EmployeePayslipTestInvalidPersonModel()
        {
            PersonModel personModel = new PersonModel();            
            var results = TestModelHelper.Validate(personModel);
            Assert.AreEqual(results[0].ErrorMessage, "First Name is required");
            Assert.AreEqual(results[1].ErrorMessage, "Last Name is required");
        }

        [TestMethod()]
        public void EmployeePayslipTestInvalidEmployeeModel()
        {
            EmployeeModel employeeModel = new EmployeeModel();           
            var results = TestModelHelper.Validate(employeeModel);
            Assert.AreEqual(results[0].ErrorMessage, "Annual Salary is required");
            Assert.AreEqual(results[1].ErrorMessage, "Super Rate is required");
            Assert.AreEqual(results[2].ErrorMessage, "Payment Start Date is required");
        }

        [TestMethod()]
        public void EmployeePayslipTest()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            string payPeriod = "1 March - 31 March";
            double grossIncome = 5004;
            double incomeTax = 922;
            double netIncome = 4082;
            double superAmount = 450;
            employeeModel.PaymentStartDate = DateTime.Now;
            employeeModel.AnnualSalary = 60050;
            employeeModel.SuperRate = 9;
            _payslips.Setup(x => x.GetPayPeriod(It.IsAny<DateTime>())).Returns(payPeriod);
            _payslips.Setup(x => x.GetGrossIncome(It.IsAny<double>())).Returns(grossIncome);
            _payslips.Setup(x => x.GetIncomeTax(It.IsAny<double>())).Returns(incomeTax);
            _payslips.Setup(x => x.GetNetIncome(It.IsAny<double>(), It.IsAny<double>())).Returns(netIncome);
            _payslips.Setup(x => x.GetSuperAmount(It.IsAny<double>(), It.IsAny<double>())).Returns(superAmount);
            var employeeDetails = new EmployeeController(_payslips.Object);
            ViewResult result = employeeDetails.EmployeePayslip(employeeModel) as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}