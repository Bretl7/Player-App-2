using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_App_2
{
    public static class ClassExtension
    {
        public static int NumOfLetters(this string str)
        {
            return str.Length;
        }
    }
}
