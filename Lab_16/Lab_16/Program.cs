using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_16
{
    class Program
    {
        public static void ErSieve(int n)
        {
            System.Threading.Thread.Sleep(100);
            Stopwatch sw = new Stopwatch();
            sw.Start();

            bool[] flags = new bool[n];

            for (int i = 0; i < flags.Length; i++)
                flags[i] = true;

            flags[1] = false;
            for (int i = 2, j = 0; i < n;)
            {
                if (flags[i])
                {
                    j = i * 2;
                    while (j < n)
                    {
                        flags[j] = false;
                        j += i;
                    }
                }
                i++;
            }

            Console.WriteLine($"Все простые числа до {n}:  ");
            for (int i = 2; i < flags.Length; i++)
            {
                if (flags[i])
                {
                    Console.Write($" {i} ");
                }
            }
            Console.WriteLine();
            sw.Stop();
            Console.WriteLine($"Алгоритм занял {sw.ElapsedMilliseconds} мсек");
        }
        public static CancellationTokenSource tokenSource = new CancellationTokenSource();
        public static void EratosSieve2(int n)
        {
            System.Threading.Thread.Sleep(100);
            Stopwatch sw = new Stopwatch();
            sw.Start();

            bool[] flags = new bool[n];

            for (int i = 0; i < flags.Length; i++)
                flags[i] = true;

            flags[1] = false;
            for (int i = 2, j = 0; i < n;)
            {
                Console.WriteLine($"Выполняется задача №{Task.CurrentId}.");
                System.Threading.Thread.Sleep(200);
                if (flags[i])
                {
                    j = i * 2;
                    while (j < n)
                    {
                        flags[j] = false;
                        j += i;
                    }
                }
                i++;

                if (tokenSource.IsCancellationRequested)
                {
                    Console.WriteLine("\n Процесс преждевременно остановлен.");
                    return;
                }
            }
            Console.WriteLine($"Все простые числа до {n}:  ");
            for (int i = 2; i < flags.Length; i++)
            {
                if (flags[i])
                {
                    Console.Write($" {i} ");
                }
            }
            Console.WriteLine();
            sw.Stop();
            Console.WriteLine($"Алгоритм занял {sw.ElapsedMilliseconds} мсек");
        }
        static void Main(string[] args)
        {
            //-----1----------------------------
            Task task = new Task(() => ErSieve(1000));
            Console.WriteLine($"Task #{task.Id} статус - {task.Status}");
            task.Start();
            while (true)
            {
                System.Threading.Thread.Sleep(10);
                Console.WriteLine($"Task #{task.Id} статус - {task.Status}");
                if (task.Status == TaskStatus.RanToCompletion)
                    break;
                else
                    Console.WriteLine($"Task #{task.Id} статус - {task.Status}");
            }

            Console.WriteLine($"Task #{task.Id} статус - {task.Status}");
            
            //---2------------
            Console.Write("Введите n:");
            int n2;
            n2 = Convert.ToInt32(Console.ReadLine());

            Task task2 = new Task(() => EratosSieve2(n2));
            Console.WriteLine($"Task #{task2.Id}  статус - {task2.Status}");
            task2.Start();

            Console.WriteLine("\nЧтобы остановить задачу нажмите 0:");
            string s = Console.ReadLine();
            if (s == "0")
                tokenSource.Cancel();

            Console.WriteLine($"Task #{task2.Id} статус - выполнено");
            

            //----3-------------------
            Random rand = new Random();
            Task<int> num1 = new Task<int>(() => { Thread.Sleep(1000); return rand.Next(1, 100) / 7; });
            Task<int> num2 = new Task<int>(() => { Thread.Sleep(1000); return rand.Next(1, 100) / 7; });
            Task<int> num3 = new Task<int>(() => { Thread.Sleep(1000); return rand.Next(1, 100) / 7; });

            num1.Start();
            num2.Start();
            num3.Start();

            int sum(int a, int b, int c)
            { return a + b + c; }
            

           //----4----------------
            Task<int> result = new Task<int>(() => sum(num1.Result, num2.Result, num3.Result));
            result.Start();

            Console.WriteLine($"Результат вычислений задачи:{result.Result} ");
            int Sum(int a, int b) => a + b;
            void Display(int sum)
            { Console.WriteLine($"Сумма равна: {sum}"); }

            Task<int> task1 = new Task<int>(() => Sum(4, 5));
            Task task3 = task1.ContinueWith(sum => Display(sum.Result));
            task1.Start();
            
            //--5---------------
            decimal factorial(int x)
            {
                decimal res = 1;
                for (decimal i = 1; i <= x; i++)
                {
                    res *= i;
                }
                return res;
            }

            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            Parallel.ForEach(list, (a) => Console.WriteLine("Факториал !" + a + " равен " + factorial(a)));
           
            //--6----
            Parallel.Invoke
            (
                () => { Console.WriteLine($"Выполняется задача {Task.CurrentId}"); },
                () => { Console.WriteLine($"Выполняется задача {Task.CurrentId}"); },
                () => { Console.WriteLine($"Выполняется задача {Task.CurrentId}"); },
                () => { Console.WriteLine($"Выполняется задача {Task.CurrentId}"); },
                () => { Console.WriteLine($"Выполняется задача {Task.CurrentId}"); }
         
            );
            Console.ReadKey();
            
            //--7------
            BlockingCollection<string> bc = new BlockingCollection<string>(5);
            CancellationTokenSource ts = new CancellationTokenSource();
            CancellationToken token = ts.Token;

            Task[] sellers = new Task[10]
            {
                new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Слово"); } }),
                new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Стол"); } }),
                new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Стул"); } }),
                new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Стоп"); } }),
                new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Сссыыырр"); } }),

                new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Сыворотка"); } }),
                new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Пакет"); } }),
                new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Партер"); } }),
                new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Мыло"); } }),
                new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Клей"); } }),
            };

            Task[] consumers = new Task[5]
            {
                new Task(() => { while(true){ Thread.Sleep(200);   bc.Take(); } }),
                new Task(() => { while(true){ Thread.Sleep(400);   bc.Take(); } }),
                new Task(() => { while(true){ Thread.Sleep(500);   bc.Take(); } }),
                new Task(() => { while(true){ Thread.Sleep(400);   bc.Take(); } }),
                new Task(() => { while(true){ Thread.Sleep(250);   bc.Take(); } })
            };

            foreach (var item in sellers)
                if (item.Status != TaskStatus.Running)
                    item.Start();

            foreach (var item in consumers)
                if (item.Status != TaskStatus.Running)
                    item.Start();
            int count = 0;
            while (true)
            {
                if (bc.Count != count && bc.Count != 0)
                {
                    count = bc.Count;
                    Thread.Sleep(400);
                    Console.Clear();
                    Console.WriteLine("----------------Склад----------------");

                    foreach (var item in bc)
                        Console.WriteLine(item);

                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("\n Процесс остановлен.");
                        return;
                    }
                    Console.WriteLine("--------------------------------------");
                }
            }
            
            //--8-------------------
            void Sum1()
            {
                int result = 1;
                for (int i = 1; i <= 100; i++)
                {
                    result += i;
                }
                Thread.Sleep(1000);
                Console.WriteLine($"Сумма {result}");
            }

            async void SumAsync()
            {
                Console.WriteLine("Начало метода");
                await Task.Run(() => Sum1());
                Console.WriteLine("Конец метода");
            }

            SumAsync();
            Console.WriteLine("main продолжает свое выполнение");
            Console.ReadKey();
            
        }
    }
}
