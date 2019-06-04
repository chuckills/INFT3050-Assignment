using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Assignment_2.BL
{
    public class BLPassword
    {
        // Generate a random string with a given size
        // Sourced from: https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/
        public static string RandomString(int size, bool lowerCase)
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
            return hashPassword(builder.ToString());
        }

        private static string hashPassword(string pass)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] passHash = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));

                StringBuilder sb = new StringBuilder();

                foreach (byte b in passHash)
                {
                    sb.Append(b.ToString("x2"));
                }

                pass = sb.ToString();
            }

            return pass;
        }
    }
}