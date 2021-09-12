using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalaryCalculatorTestProject
{
    [TestClass]
    public class UnitTestSalaryCalculator
    {
        [TestMethod]
        public void HourlySalaryTest()
        {
            //Arrange
            SalaryCalculator salaryCalculator = new SalaryCalculator();
            float expectedPerHourSalary = 48.08f;
            float annualSalary = 100006.40f;

            //Act
            float actualPerHourSalary = salaryCalculator.GetPerHourSalary(annualSalary);

            //Assert
            Assert.AreEqual(expectedPerHourSalary, actualPerHourSalary);
        }

        [TestMethod]
        public void AnnualSalaryTest()
        {
            //Arrange
            SalaryCalculator salaryCalculator = new SalaryCalculator();
            float expectedAnnualSalary = 100006.40f;
            float perHourSalary = 48.08f;

            //Act
            float actualAnnualSalary = salaryCalculator.GetAnnualSalary(perHourSalary);

            //Assert
            Assert.AreEqual(expectedAnnualSalary, actualAnnualSalary);
        }
    }
}
