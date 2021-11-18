using MessagePrinter;
using System;
using System.Collections.Generic;

namespace SimpleDependency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = new MessagePrintingService();
            s.PrintMessage();
            Console.ReadLine();

            //descending sorted list by EventTableSortOrder value
            List<EventGuiData> sortedList = m_EventsList.OrderByDescending(e => e.EventTableSortOrder).ToList();

            //loop on sorted list
            for (int i = 0; i < sortedList.Count;)
            {
                // if same place as in source (sorting do not change the place)
                if (m_EventsList[i] != sortedList[i])
                {
                    //swap, stay on same index
                    EventGuiData item = m_EventsList[i];
                    //remove it form source
                    m_EventsList.RemoveAt(i);
                    //insert in same place
                    m_EventsList.Insert(sortedList.IndexOf(item), item);
                }
                else
                {
                    //continue
                    i++;
                }
            }
        }
    }
}
