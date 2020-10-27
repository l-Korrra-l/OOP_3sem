using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{

    class Program
    {
        static void Main()
        {

            Product a = new Product( "Gum", 267395049328, "Orbit", 19000, 56, 111);
            Product b = new Product("Not a gum", 758495083754, "Orbit", 19000, 56, 111);
            Product c = new Product("Gum", 745849509374, "Dirol", 190, 32, 4738);
            //Console.WriteLine(a.ToString());
            a.Info();
            int sum=0; 
            a.Total(ref sum);
            Console.WriteLine("Общая сумма данного продукта: " + sum + " з.д.");

            Console.WriteLine("Type of a element is " + a.GetType());
            Console.WriteLine("---------------------------------");
            if (a.Equals(b))
            {
                Console.WriteLine("Продукты идентичны");
            }
            else
                Console.WriteLine("Продукты различны");

            if (a.Equals(a))
            {
                Console.WriteLine("Продукты идентичны");
            }
            else
                Console.WriteLine("Продукты различны");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Cписок товаров для заданного наименования");
            Product[] arrProd = new Product[4];
            arrProd[0] = new Product(a);
            arrProd[1] = new Product(b);
            arrProd[2] = new Product("Булочка с корицей", 267395049328, "Бабушка", 1234 , 1, 10);
            arrProd[3] = new Product(c);

            Console.WriteLine("Введите наименование необходимого товара");
            string find=Console.ReadLine();
            bool flag = false;
            foreach (Product element in arrProd)
            {
                if (find == element.Name)
                { element.Info(); flag = true; }
            }
            if (!flag) Console.WriteLine("Товар не найден");


            Console.WriteLine("---------------------------------");
            Console.WriteLine("Cписок товаров для заданного наименования, цена которых не превосходит заданную");

            Console.WriteLine("Введите наименование необходимого товара");
            string findd = Console.ReadLine();
            Console.WriteLine("Введите порог цены");
            int price = Convert.ToInt32(Console.ReadLine());
            flag = false;
            bool priceFlag = false;

            foreach (Product element in arrProd)
            {
                if (findd == element.Name && price >= element.Price)
                {
                  element.Info(); 
                  flag = true; 
                  priceFlag = true; 
                }
            }
            if (!flag) Console.WriteLine("Товар не найден");
            else if (!priceFlag) Console.WriteLine("Таких дешевых " + findd + "нет((");

            Console.WriteLine("---------------------------------");
            var prod = new { Name = "Soup", Price = 67 };
            Console.WriteLine("Name: "+prod.Name+" \nPrice: "+prod.Price);
            Console.ReadKey();
        }
    }
}
