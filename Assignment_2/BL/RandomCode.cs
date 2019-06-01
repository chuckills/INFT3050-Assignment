using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Assignment_2.BL
{
    public class RandomCode
    {
        // Generate a random string with a given size
        // Sourced from: https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
    }
}