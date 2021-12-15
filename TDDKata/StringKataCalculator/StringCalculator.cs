using System;

namespace StringKataCalculator
{
    //From https://www.youtube.com/watch?v=ONLEIhZZbQg
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            return numbers.Equals(String.Empty) == true ?  0 :  int.Parse(numbers);
        }
    }
}
