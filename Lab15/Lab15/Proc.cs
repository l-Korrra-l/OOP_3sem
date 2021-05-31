using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Lab15
{
    static class Processes
    {
        public static void GetAllProcesses()
        {
            Console.WriteLine("Инфо Процессов:");
            var allProcesses = Process.GetProcesses();
            Console.Write("{0,-10}", "ID:");
            Console.Write("{0,-40}", "Process Name:");
            Console.Write("{0,-10}", "Priority:\n");
            foreach (var process in allProcesses)
            {
                Console.Write("{0,-10}", $"{process.Id}");
                Console.Write("{0,-40}", $"{process.ProcessName}");
                Console.Write("{0,-10}", $"{process.BasePriority}");
                Console.WriteLine();
            }
        }
        public static void DomainInfo() { 

            Console.WriteLine("Инфо домена:");
            var thisAppDomain = Thread.GetDomain();

            Console.WriteLine($"\n\n\nName:  {thisAppDomain.FriendlyName}");
            Console.WriteLine($"Setup Information:  {thisAppDomain.SetupInformation.ToString()}");
            Console.WriteLine("Assemblies:");

            foreach (var item in thisAppDomain.GetAssemblies())
            {
                Console.WriteLine("    " + item.FullName.ToString());
            }
        }
    }
}

