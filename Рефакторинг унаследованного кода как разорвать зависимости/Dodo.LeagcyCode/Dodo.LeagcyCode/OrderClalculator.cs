using System.Collections.Generic;

namespace Dodo.LeagcyCode
{
    public class OrderClalculator
    {
        public void Process(List<Order> orders, int dailyTarget, double interestRate, int compensationPercent)
        {
            ProcessOrders(orders, dailyTarget, interestRate, compensationPercent);
        }

        public void ProcessOrders(List<Order> orders, int dailyTarget, double interestRate, int compensationPercent)
        {
        }
    }
}
