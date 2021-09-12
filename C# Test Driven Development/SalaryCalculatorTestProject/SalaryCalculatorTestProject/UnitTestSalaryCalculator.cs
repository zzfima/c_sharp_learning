using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalaryCalculatorTestProject
{
    [TestClass]
    public class UnitTestSalaryCalculator
    {
        [TestMethod]
        public void HourlySalaryTest1()
        {
            //Arrange
            SalaryCalculator salaryCalculator = new SalaryCalculator();
            float expectedPerHourSalary = 48.08f;
            float annualSalary = 100006.40f;

            //Act
            float actualPerHourSalary = salaryCalculator.GetPerHourSalary(annualSalary);

            //Assert
            Assert.AreEqual(expectedPerHourSalary, actualPerHourSalary, 0.1);
        }

        [TestMethod]
        public void HourlySalaryTest2()
        {
            //Arrange
            SalaryCalculator salaryCalculator = new SalaryCalculator();
            float expectedPerHourSalary = 96.15f;
            float annualSalary = 200000f;

            //Act
            float actualPerHourSalary = salaryCalculator.GetPerHourSalary(annualSalary);

            //Assert
            Assert.AreEqual(expectedPerHourSalary, actualPerHourSalary, 0.1);
        }

        [TestMethod]
        public void AnnualSalaryTest1()
        {
            //Arrange
            SalaryCalculator salaryCalculator = new SalaryCalculator();
            float expectedAnnualSalary = 100006.40f;
            float perHourSalary = 48.08f;

            //Act
            float actualAnnualSalary = salaryCalculator.GetAnnualSalary(perHourSalary);

            //Assert
            Assert.AreEqual(expectedAnnualSalary, actualAnnualSalary, 0.1);
        }

        [TestMethod]
        public void AnnualSalaryTest2()
        {
            //Arrange
            SalaryCalculator salaryCalculator = new SalaryCalculator();
            float expectedAnnualSalary = 52000f;
            float perHourSalary = 25f;

            //Act
            float actualAnnualSalary = salaryCalculator.GetAnnualSalary(perHourSalary);

            //Assert
            Assert.AreEqual(expectedAnnualSalary, actualAnnualSalary, 0.1);
        }
    }
}
