using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polymorphism;

namespace PolymorphismTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEmployee()
        {
            //Arrange
            Employee employee = new Employee();
            int weeklyHours = 55;
            int wage = 70;
            string expectedWeeklySalaryStr = "This ANGRY EMPLOYEE worked 55 hrs. Paid for 40 hrs at $ 70 hr = $2800";

            //Act
            string actualWeeklySalaryStr = employee.CalculateWeeklySalary(weeklyHours, wage);

            //Assert
            Assert.AreEqual(expectedWeeklySalaryStr, actualWeeklySalaryStr);
        }

        [TestMethod]
        public void TestContractor()
        {
            //Arrange
            Employee contractor = new Contractor();
            int weeklyHours = 55;
            int wage = 70;
            string expectedWeeklySalaryStr = "This HAPPY CONTRACTOR worked 55 hrs. Paid for 55 hrs at $ 70 hr = $3850";

            //Act
            string actualWeeklySalaryStr = contractor.CalculateWeeklySalary(weeklyHours, wage);

            //Assert
            Assert.AreEqual(expectedWeeklySalaryStr, actualWeeklySalaryStr);
        }
    }
}