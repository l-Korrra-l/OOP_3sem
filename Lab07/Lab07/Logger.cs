using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab06
{
    static class Logger
    {

        public static void Writelog(Exception ex, string log = @"C:\Users\User\Documents\ооп\OOP\Lab07\Lab07\log.txt", bool fflag = false)
        {
            DateTime time = DateTime.Now;


            string toLog = $"\n{time} \nINFO:\n" + $"{ex.ToString()}" ;

            if (fflag)
            {
                using (StreamWriter writer = new StreamWriter(log))
                {
                    writer.Write(toLog);
                }
            }
            else
                Console.WriteLine(toLog);
        }
        public class ConsoleLogger
        {
            public static void WriteLog(Exception ex, string log = @"C:\Users\User\Documents\ооп\OOP\Lab07\Lab07\log.txt")
            {
                Logger.Writelog(ex,  log);
            }
        }
        public class FileLogger
        {
            public static void WriteLog(Exception ex, string log = @"C:\Users\User\Documents\ооп\OOP\Lab07\Lab07\log.txt")
            {
                Logger.Writelog(ex, log, true);
            }
        }
    }
}