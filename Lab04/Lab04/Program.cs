using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Класс  список List.Дополнительно перегрузить следующие операции: +  добавить элемент в начало (item+list); --  удалить первый элемент из списка(--list); 
//!=  проверка на неравенство; * - объединение двух списков.
//Методы расширения:
//1) Подсчет количества слов с заглавной буквы
//2) Проверка на повторяющиеся элементы в списке
namespace Lab04
{
    class Program
    {
        static void Main()
        {
            List a = new List();
            List b = new List();
            b = "What's " + "up" + "?" + b;
            b.Listt();
            string s = "fist";
            a=s + a;
            a = "Sec" + a;
            a = "no" + a;
            a = "Hey" + a;
            a = "no" + a;
            a.Listt();
            Console.WriteLine(a.Letters()+" element(s) with a capital letter");
            if (a.Repeat()) Console.WriteLine("There are duplicate elements");
            else Console.WriteLine("No duplicates");
            a =a--;
            a.Listt();
            if (a.Repeat()) Console.WriteLine("There are duplicate elements");
            else Console.WriteLine("No duplicates");
            a = a * b;
            a.Listt();

            List.Owner owner = new List.Owner();
            Console.WriteLine(owner);
            List.Date date = new List.Date(24, 10, 2020);
            date.ShowDate();

            Console.WriteLine("Sum of array: " + StatisticOperation.CountSum(a));
            Console.WriteLine("Delta: " + StatisticOperation.CountDelta(a));
            Console.WriteLine("Number of elements: " + StatisticOperation.Number(a));

            string str = "Let's go home and sleep enough.Please!";
            Console.WriteLine($"-----string-----\n{str}");
            Console.WriteLine("Sentences in phrase: " + str.CountPhrases());
            string str1 = "Кошка съела паука! Тра-та-та";
            Console.WriteLine($"-----string-----\n{str1}");
            Console.WriteLine("Sentences in phrase: " + str1.CountPhrases());
            Console.ReadKey();
        }
    }
}
