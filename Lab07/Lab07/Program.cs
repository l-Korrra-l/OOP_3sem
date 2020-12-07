using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
    // Квитанция, Накладная, Документ, Чек, Дата, Организация.
    //Собрать Бухгалтерию.
    //Найти суммарную стоимость продукции заданного наименования по всем накладным, количество чеков. Вывести две документы за указанный период времени.
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //var a = 0;
                //a = 2 / a;
                Client client = new Client("Каролина", "Мергель");
                Organization org = new Organization("Пока не придумала");
               Organization org_exc = new Organization("");
                // Organization org_e = new Organization("12345678901234567890123457890");
                Waybill waybill = new Waybill("Накладная на машину", new DateTime(2012, 05, 12), client, new Organization("Пока не придумала"), 7800);
                Receipt receipt = new Receipt("Квитанция об оплате", new DateTime(2020, 05, 12), client, new Organization("Netflix"), 49);
                Check check = new Check("Чек", new DateTime(2020, 10, 15), client, new Organization("McDonalds"), 5);

                Waybill waybill2 = new Waybill("Накладная на машину", new DateTime(2012, 05, 12), client, org, 7800);
                Waybill waybill3 = new Waybill("Накладная на машину", new DateTime(2012, 05, 12), client, org, 7800);
                Waybill waybill4 = new Waybill("Накладная на машину", new DateTime(2012, 05, 12), client, new Organization("Пока не придумала"), 7800);
                Waybill waybill5 = new Waybill("Накладная на машину", new DateTime(2012, 05, 12), client, new Organization("Пока не придумала"), 7800);


                Bookkeeping bkkeeping = new Bookkeeping();
                BookkeepingController controll = new BookkeepingController();
                bkkeeping.AddReceipt(receipt);
                bkkeeping.AddWaybill(waybill);
                bkkeeping.AddCheck(check);

                bkkeeping.AddWaybill(waybill2);
                bkkeeping.AddWaybill(waybill3);
                bkkeeping.AddWaybill(waybill4);
                bkkeeping.AddWaybill(waybill5);

                bkkeeping.ShowList();
                Console.WriteLine();

                Console.WriteLine("Суммарную стоимость продукции заданного наименования по всем накладным = {0}", bkkeeping.GetWaybillPrice("Накладная на машину"));
                Console.WriteLine();

                bkkeeping.GetDocuments(new DateTime(2020, 01, 01), new DateTime(2021, 01, 01));
                Console.WriteLine();
                Console.WriteLine("Количество чеков: {0}", controll.Count(bkkeeping));
            }
            catch(EmptyException e)
            {
                Console.WriteLine(e.ToString());
                Logger.FileLogger.WriteLog(e);
            }
            catch (LongException e)
            {
                Console.WriteLine(e.ToString());
                Logger.FileLogger.WriteLog(e);
            }
            catch (PriceException e)
            {
                Console.WriteLine(e.ToString());
                Logger.FileLogger.WriteLog(e);
            }
            catch (IndexException e)
            {
                Console.WriteLine(e.ToString());
                Logger.FileLogger.WriteLog(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.FileLogger.WriteLog(e);
            }
            finally
            {
                Console.WriteLine("\n--------------------finally-------------------- \n She'll be right ;)");
            }
            Console.ReadKey();
        }
    }
}
