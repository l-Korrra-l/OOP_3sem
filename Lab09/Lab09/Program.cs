using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Создать класс Программист с событиями Удалить и Мутировать.
//В main создать некоторое количество объектов (списков).
//Реакция на события может быть следующая: удаление первого/последнего элемента списка, случайное перемещение строк и т.п.
//Проверить результаты изменения состояния объектов после наступления событий, возможно не однократном
namespace Lab09
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> FirstList = new List<string>() { "fist", "second", "hmmmm", "stop", "idk", "smth else" };
            Programmer programmer = new Programmer(FirstList);

            List<string> SecList = new List<string>() { "fist", "second", "hmmmm", "stop", "idk", "smth else" };
            Programmer prmmer = new Programmer(SecList);


            programmer.Show();

            programmer.DeleteEvent += (string message) => Console.WriteLine(message);

            programmer.MutateEvent += (string message) =>Console.WriteLine(message);


            programmer.Delete();
            programmer.Show();

            programmer.Mutate();
            programmer.Show();

            programmer.Mutate();
            programmer.Show();

            Console.WriteLine("\n---------------------------------------\n");

            string str = "Работа со строками, и как бы да, но нет, когда всегда...";
            Console.WriteLine("\nИсходная строка: "+str);
            Func<string, string> A = null;
            A = StringRe.Remove;
            Console.WriteLine("\nБез знаков препинания: {0}", A(str));
            A = StringRe.AddToString;
            Console.WriteLine("\nДобавление строки: {0}", A(str));
            A = StringRe.Upper;
            Console.WriteLine("\nЗаглавные буквы: {0}", str=A(str));
            A = StringRe.Lower;
            Console.WriteLine("\nПрописные: {0}", A(str));
            Console.ReadKey();
        }
    }
}
