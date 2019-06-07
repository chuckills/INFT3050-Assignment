using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Contains all password functions required by application.
/// </summary>

namespace Assignment_2.BL
{
    public class BLPassword
    {
        /// <summary>
        /// Generates a randomised password of a given size and then returns that password once hashed.
        /// Sourced from: https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/
        /// </summary>
        /// <param name="size"></param>
        /// <param name="lowerCase"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Performs MD5 Hash function on input string.
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static string hashPassword(string pass)
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