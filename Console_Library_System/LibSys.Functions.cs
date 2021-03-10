using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Library_System
{
    public static partial class LibSys
    {
        public static class Functions
        {
            public static string RowDivider(char startChar, char fillChar, char endChar)
            {
                string divider = "";

                divider += startChar;

                for (int i = 1; i < Console.WindowWidth - 2; i++)
                {
                    divider += fillChar;
                }

                divider += endChar;
                
                return divider;
            }
        }
    }
}
