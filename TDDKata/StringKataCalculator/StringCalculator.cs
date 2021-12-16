using System.Collections.Generic;
using System.Linq;

namespace StringKataCalculator
{
    //From https://www.youtube.com/watch?v=ONLEIhZZbQg
    public class StringCalculator : IStringCalculator
    {
        public int Add(string numbers)
        {
            var nums_as_strings = numbers.Split(',');
            var nums = new List<int>();

            foreach (var num_str in nums_as_strings)
            {
                var hasParse = int.TryParse(num_str, out var res);
                if (!hasParse)
                    return 0;

                nums.Add(res);
            }

            return nums.Sum();
        }
    }
}
