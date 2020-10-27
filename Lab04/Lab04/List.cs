using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab04
{
    //Класс  список List.Дополнительно перегрузить следующие операции: +  добавить элемент в начало (item+list); --  удалить первый элемент из списка(--list); 
    //!=  проверка на неравенство; * - объединение двух списков.
    //Методы расширения:
    //1) Подсчет количества слов с заглавной буквы
    //2) Проверка на повторяющиеся элементы в списке
    class List
    {
        protected internal string[] listArr;
        private int size = 0;
        protected internal int length = 0;
        private int tmp;

        public List()
        {
            size = 10;
            listArr = new string[size];
        }

        public List(int size)
        {
            listArr = new string[size];
        }

        public static List operator +(string item, List list)
        {
            for (int i = list.size - 1; i > 0; i--)
            {
                list.listArr[i] = list.listArr[i - 1];
            }
            list.listArr[0] = item;
            list.length++;
            return list;
        }

        public static List operator --(List list)
        {
            int i = 0;
            for (; i < list.length; i++)
            {
                list.listArr[i] = list.listArr[i + 1];
            }
            list.listArr[i] = null;
            list.length--;
            return list;
        }


        public static bool operator ==(List list, List item)
        {
            return list.length == item.length;
        }

        public static bool operator !=(List list, List item)
        {

            return list.length != item.length;
        }

        public static List operator *(List list, List item)
        {

            for (int i = 0; i < item.length; i++)
            {
                list = item.listArr[i] + list;
            }
            return list;
        }


        public class Owner
        {
            private string name { get; set; }
            private string organization { get; set; }
            private int id { get; set; }

            public Owner()
            {
                this.name = "Caroline";
                this.organization = "BSTU";
                this.id = 1;
            }

            public override string ToString()
            {
                return $"\n---Info about owner---\nName: {this.name}\nOrganization: {this.organization}\nID: {this.id}\n----------------------\n";
            }
        }

        public class Date
        {
            private int day = 24;
            private int month = 10;
            private int year = 2020;

            public Date(int day, int month, int year)
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }

            public void ShowDate()
            {
                Console.WriteLine($"Date of creating: {day}:{month}:{year}");
            }
        }

        public int Letters()
        {
            int count = 0;
            for (int i=0; i<this.length;i++)
            {
                char str = this.listArr[i][0];
                if ((str >= 'A' && str <= 'Z')|| (str >= 'А' && str <= 'Я'))
                    count++;
            }
            return count;
        }

        public bool Repeat()
        {
            bool a = false;
            for (int i = 0; i < this.length; i++)
            {
                for (int j = i + 1; j < this.length; j++)
                {
                    if (String.Equals(this.listArr[i], this.listArr[j]) == true) a=true;
                }
            }

            return a;
        }

        public void Listt()
        {
            Console.WriteLine("\n-----List------");
            for (int i = 0; i < this.length; i++)
                Console.WriteLine(listArr[i]);
            Console.WriteLine("---------------\n");
        }
    }


    static class StatisticOperation
    {
        public static string CountSum(List list)
        {
            string str = "";
            for (int i = 0; i < list.length; i++)
            {
                str += list.listArr[i]+" ";
            }
            return str;
        }

        public static string CountDelta(List list)
        {
            string strMin = "";
            string strMax = "";
            int min = 100;
            int max = 0;
            for (int i = 0; i < list.length; i++)
            {
                if (list.listArr[i].Length >= max)
                {
                    strMax = list.listArr[i];
                    max = list.listArr[i].Length;
                }
                else if (list.listArr[i].Length <= min)
                {
                    strMin = list.listArr[i];
                    min = list.listArr[i].Length;
                }
            }


            return strMax.Substring(min);
        }

        public static int Number(List list)
        {
            return list.length;
        }

        //public static double CountMedium(this Stack stack)
        //{
        //    double num = 0;
        //    if (Stack.GetCount(stack) % 2 == 1)
        //    {
        //        num = Stack.GetCount(stack) / 2;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Stack contains an even elements");
        //    }
        //    return Math.Ceiling(num);
        //}
    }
}