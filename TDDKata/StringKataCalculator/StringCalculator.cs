﻿using System;

namespace StringKataCalculator
{
    //From https://www.youtube.com/watch?v=ONLEIhZZbQg
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            var hasParse = int.TryParse(numbers, out var res);
            return hasParse ? res : 0;
        }
    }
}
