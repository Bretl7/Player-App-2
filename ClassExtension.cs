using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_App_2
{
    /// <summary>
    /// EXTENSION CLASS
    /// This class has two attributes
    /// Returns number of chars in a given UserPlayer name
    /// Adds one power level to every user
    /// </summary>
    public static class ClassExtension
    {
        /// <summary>
        /// This method returns length of name
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int NumOfLetters(this string str)
        {
            return str.Length;
        }

        /// <summary>
        /// Adds one level of power evertime user cycles through program
        /// </summary>
        /// <param name="a"></param>
        public static int AddPowerLevel(this int a)
        {
            return ++a;
        }
    }
}
