using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_App_2
{
    /// <summary>
    /// EXTENSION CLASS
    /// This class has only one attribute
    /// Returns number of chars in a given UserPlayer name
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
    }
}
