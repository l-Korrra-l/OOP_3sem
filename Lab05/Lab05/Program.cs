using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{

    class Program
    {
        static void Main(string[] args)
        {
            Client first_client = new Client("Каролина", "Мергель");

            Waybill first_waybill = new Waybill("Накладная на машину", new DateTime(2012,05,12), first_client, new Organization("Пока не придумала"), 7800);
            Receipt first_receipt = new Receipt("Квитанция об оплате", new DateTime(2020,05,12), first_client, new Organization("Netflix"), 49);
            Check first_check = new Check("Чек", new DateTime(2020,10,15), first_client, new Organization("McDonalds"), 5);
            first_waybill.Info();

            Console.WriteLine();

            Document firsdoc = first_waybill;
            Document seconddoc = first_receipt;

            Document thirddoc = first_check as Check;
            Console.WriteLine(thirddoc is Check);
            Console.WriteLine(firsdoc is Document);
            Console.WriteLine();

            //вызов одноименных методов
            firsdoc.Info();
            Console.WriteLine();

            ((IDocument)seconddoc).Info();
            Console.WriteLine();

            //создание массива
            Document[] mas = { firsdoc, seconddoc, thirddoc };
            for (int i = 0; i < mas.Length; i++)
            {
                Printer.IAmPrinting(mas[i]);
            }

            Console.ReadKey();
        }
    }
}
