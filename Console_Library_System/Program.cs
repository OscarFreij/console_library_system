using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Console_Library_System
{
    class Program
    {
        public static XmlDocument XML;
        static void Main(string[] args)
        {
            XML = LibSys.FileManager.LoadDoc();

            LibSys.Library.LoadLibrary(XML);

            Console.ReadKey();

            LibSys.Book.Create("Test title",0,"TEST");


            LibSys.Library.SaveLibrary();

            Console.ReadKey();
        }
    }
}
