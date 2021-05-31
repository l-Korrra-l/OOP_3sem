using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Lab15
{
    public class Element
    {
        public void begin()
        {
            Console.WriteLine("Имя потока: " + Thread.CurrentThread.Name);
            Console.WriteLine("Приоритет потока: " + Thread.CurrentThread.Priority.ToString());
            Console.WriteLine("Id потока: " + Thread.CurrentThread.ManagedThreadId.ToString());
            Console.WriteLine("Статус потока: " + Thread.CurrentThread.ThreadState.ToString());
            int n;
            Console.WriteLine("Enter number:");
            int.TryParse(Console.ReadLine(), out n);
            EasyNumbers(n);
            Console.WriteLine("-Press key to continue-");
            Console.ReadKey();
        }
        public void EasyNumbers(int n)
        {
            StreamWriter fout = new StreamWriter("num.txt");
            for (int i = 1; i <= n; i++)
            {
                
                    fout.WriteLine(i.ToString());
                    Console.WriteLine(i.ToString());
                    Thread.Sleep(500);

            }
            fout.Close();
        }
    }
    public class Numbers
    {
        private int n;
        public StreamWriter file = new StreamWriter("OddEven.txt", false);
        public Numbers()
        {
            ReadN();
        }
        ~Numbers()
        {
            try { file.Close(); }
            catch { };
        }
        private void ReadN()
        {
           
            while (true)
            {
                Console.WriteLine("Enter number:");
                if (!int.TryParse(Console.ReadLine(), out n))
                    Console.WriteLine("Wrong num");
                else break;
            }
        }
        public void ForTimer(object obj)
        {
            Console.Write("...");
            Console.WriteLine();
        }
        public void Odd()
        {
            if (file.BaseStream == null)
                file = new StreamWriter("OddEven.txt", true);
            for (int i = 1; i <= n; i++)
            {
                Thread.Sleep(30);
                if (i % 2 != 0)
                {
                    if (file.BaseStream == null)
                        file = new StreamWriter("OddEven.txt", true);
                    file.WriteLine(i);
                    Console.WriteLine(i);
                }
            }
            if (file.BaseStream != null)
                file.Close();
        }
        public void Even()
        {
            lock (this)
            {
                if (file.BaseStream == null)
                    file = new StreamWriter("OddEven.txt", true);
                for (int i = 1; i <= n; i++)
                    if (i % 2 == 0)
                    {
                        file.WriteLine(i);  
                        Console.WriteLine(i);
                    }
                if (file.BaseStream != null)
                    file.Close();
            }
        }
        public void OddWait()
        {
            Monitor.Enter(this);
            {
                if (file.BaseStream == null)
                    file = new StreamWriter("OddEven.txt", true);
                for (int i = 1; i <= n; i++)
                {
                    Thread.Sleep(5);
                    if (i % 2 != 0)
                    {
                        Monitor.Wait(this, 1);
                        if (file.BaseStream == null)
                            file = new StreamWriter("OddEven.txt", true);
                        file.WriteLine(i);
                        Console.WriteLine(i);
                    }
                }
                if (file.BaseStream != null)
                    file.Close();
            }
        }
        public void EvenWait()
        {
            Monitor.Enter(this);
            {
                if (file.BaseStream == null)
                    file = new StreamWriter("OddEven.txt", true);
                for (int i = 1; i <= n; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (file.BaseStream == null)
                            file = new StreamWriter("OddEven.txt", true);
                        file.WriteLine(i);
                        Console.WriteLine(i);
                        Monitor.Wait(this, 6);
                    }
                }
                if (file.BaseStream != null)
                    file.Close();
            }
        }
    }
}
