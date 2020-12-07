using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int n=7; //3-9
            Console.WriteLine($"Months with str lengths {n}:");
            IEnumerable<string> result = from t in months
                                         where t.Length == n
                                         select t;
            foreach (string month in result) Console.WriteLine("- "+month);
            Console.WriteLine($"Summer and winter months:");
            IEnumerable<string> wintsum = from t in months
                                          where t== "January"|| t == "February" || t == "June" || t == "July" || t == "August" || t == "December" 
                                          select t;
            foreach (string month in wintsum) Console.WriteLine("- " + month);
            Console.WriteLine($"Alphabet order:");
            IEnumerable<string> alp = from t in months
                                          orderby t
                                          select t;
            foreach (string month in alp) Console.WriteLine("- " + month);
            Console.WriteLine($"Count 'u' and length>=4:"+ months.Count(t => t.Contains('u') && t.Length >= 4));
            Console.WriteLine("------------------------------------------");
            List<Product> products = new List<Product>() { new Product("chocolate", 222211, "India", 5, new DateTime(2020, 5, 8), 19),
                                                           new Product("pillow", 2332211, "USA", 99, new DateTime(2019, 6, 1), 12),
                                                           new Product("rat", 111345, "Russia", 79, new DateTime(2020, 7, 16), 33),
                                                           new Product("coffee", 667721, "UK", 105, new DateTime(2019, 8, 15), 12),
                                                           new Product("tea", 2332211, "Belarus", 8, new DateTime(2018, 9, 22), 88),
                                                           new Product("table", 111223, "Belarus", 15, new DateTime(2015, 10, 18), 7),
                                                           new Product("computer", 2299922, "China", 19, new DateTime(2017, 11, 15), 38),
                                                           new Product("cup", 2111122, "Turkmenistan", 159, new DateTime(2018, 1, 30), 16),
                                                           new Product("phone", 22, "China", 9, new DateTime(2017, 2, 18), 7),
                                                           new Product("glass", 3232322, "Belarus", 4, new DateTime(2018, 6, 18), 10) };

            
            Console.Write("Enter name:");
            string name = "cup";//Console.ReadLine();
            var lst1 = from prod in products where prod.Name == name select prod;
            foreach (var prod in lst1) prod.Info();
            Console.Write("Enter price:");
            int price = 100;//int.Parse(Console.ReadLine());
            lst1 = from prod in lst1 where prod.Price <= price select prod;
            foreach (var prod in lst1) prod.Info();
            Console.WriteLine($"Number of products which price is more then 100: {(from prod in products where prod.Price > 100 select prod).Count()}");
            Console.WriteLine($"Highest price of products: {(from prod in products select prod.Price).Max()}");
            Console.WriteLine($"Alphabet order:");
            var sortProd = products.OrderBy(p => p.Manufacturer).ThenBy(p => p.Price).Select(p => p);
            foreach (var prod in sortProd)  Console.WriteLine("- "+prod.Name);

            Console.WriteLine("\n---------------------------------------------------\n");

            Console.WriteLine("Own request:");
            var own = products
                .Where(p => p.Price < 20)
                .OrderBy(p => p.Price)
                .ThenByDescending(p => p)
                .Where(p => p.Name.Contains('e'))
                .Select(p => p);
            foreach (var p in own) Console.WriteLine("- "+p.Name);

            Console.WriteLine("\n---------------------------------------------------\n");



            List<Person> owners = new List<Person>() { new Person("I", "cup"), new Person("You", "chocolate") };

            var res = products.Join(owners, 
                         p => p.Name, 
                         o => o.Item, 
                         (p, o) => new { Owner = o.Name, Name = p.Name, Producer = p.Manufacturer}); // результат

            foreach (var item in res)
                Console.WriteLine($"{item.Owner} bought {item.Name} from {item.Producer}");
            Console.ReadKey();
        }
    }
}
