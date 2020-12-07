using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
        public static class Printer
        {
            public static void IAmPrinting(Document document)
            {
                Console.WriteLine("--------------------------------------\n" + document.GetType());
                Console.WriteLine(document.ToString());
            }
        }
}