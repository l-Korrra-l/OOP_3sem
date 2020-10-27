using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    //Создать класс Product: id, Наименование, UPC, Производитель, Цена, Срок хранения, Количество. Свойства и конструкторы должны обеспечивать проверку корректности.
    //    Добавить метод вывода общей суммы продукта. Создать массив объектов.Вывести: a) список товаров для заданного наименования; b) список товаров для заданного 
    //    наименования, цена которых не превосходит заданную;
    partial class Product
    {
        public readonly int id;
        public string Name { get; set; }
        public long upc;
        public string Manufacturer { get; set; }
        public int Price;
        public int ShelfLife;
        private int Number = 0;
        static int numberOfProducts = 0;

        private long UPC
        {
            get
            {
                return upc;
            }
            set
            {
                if (value >= 100000000000 && value < 1000000000000) upc = value;
            }
        }

        public Product(string name = "", long upc = 0, string manufacturer = "", int price = 0, int shelflife = 0, int number = 0)
        {
            ++numberOfProducts;
            Name = name;
            UPC = upc;
            Manufacturer = manufacturer;
            Price = price;
            ShelfLife = shelflife;
            Number = number;
            id = this.GetHashCode();
           Product c=new Product();
        }

        public Product(Product a)
        {
            ++numberOfProducts;
            Name = a.Name;
            UPC = a.UPC;
            Manufacturer = a.Manufacturer;
            Price = a.Price;
            ShelfLife = a.ShelfLife;
            Number = a.Number;
            id = this.GetHashCode();
        }

        static Product()
        {
            Console.WriteLine("Создана первая запись");
        }

        private Product()
        {
            numberOfProducts++;
            Console.WriteLine("Будущая запись");
        }

        public void Info()
        {
            Console.WriteLine();
            Console.WriteLine("Наименование продукта: " + Name);
            Console.WriteLine("Производитель: " + Manufacturer);
            Console.WriteLine("UPC: " + UPC);
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Цена: " + Price + " з.д. (заморских деняк)");
            Console.WriteLine("Срок хранения: " + ShelfLife+ (ShelfLife==1 ? " день":" дней"));
            Console.WriteLine("Количество товара: " + Number);
        }

        public void Total(ref int sum)
        {
            sum = Number * Price;
        }

    }
}