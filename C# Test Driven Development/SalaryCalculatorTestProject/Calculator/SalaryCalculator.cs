namespace Calculator
{
    public class SalaryCalculator
    {
        private const int HoursInYear = 2080;

        public float GetPerHourSalary(float annualSalary) => annualSalary / HoursInYear;
        public float GetAnnualSalary(float perHourSalary) => perHourSalary * HoursInYear;

    }
}