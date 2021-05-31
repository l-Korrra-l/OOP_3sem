using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
    
namespace Lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------First task------------------");
            Processes.GetAllProcesses();
            Console.WriteLine("---------------Second task------------------");


            Processes.DomainInfo();
            Console.WriteLine("---------------Third task------------------");
            Thread mythread = new Thread((new Element()).begin);
            mythread.Name = "Thread";
            mythread.Priority = ThreadPriority.Highest;
            mythread.Start();

            Console.WriteLine("---------------Fourth task------------------");
            Thread thread1, thread2;
            Numbers numbers = new Numbers();
            thread1 = new Thread(numbers.Odd);
            thread2 = new Thread(numbers.Even);
            thread1.IsBackground = true;
            thread2.IsBackground = true;
            thread1.Priority = ThreadPriority.AboveNormal;
            thread1.Start();
            thread2.Start();
            Thread.Sleep(1000);


            Thread thread3 = new Thread(numbers.OddWait);
            Thread thread4 = new Thread(numbers.EvenWait);
            thread3.IsBackground = true;
            thread4.IsBackground = true;
            thread3.Priority = ThreadPriority.AboveNormal;
            thread3.Start();
            thread4.Start();
            Console.Write("\nPlease wait...");
            TimerCallback a = new TimerCallback(numbers.ForTimer);
            Timer timer = new Timer(a, 10, 1000, 1000);
            Console.ReadKey();
        }
    }
}
