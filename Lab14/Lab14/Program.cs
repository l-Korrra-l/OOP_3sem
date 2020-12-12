using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
namespace Lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            Check first = new Check("Title", new DateTime (2020,11,12),"Someone","Cool", 100500);
            Check sec = new Check("Title", new DateTime(2020, 11, 12), "Someone", "TheCoolestOrganization", 200500);
            Check third = new Check("Title", new DateTime(2020, 11, 12), "Someone","Look, i can write", 300500);

            CustomSerializer.Serialize("BinarySerialization.bin", first);
            CustomSerializer.Serialize("xmlSerialization.xml",sec);
            CustomSerializer.Serialize("JsonSerialization.json", third);
            Console.WriteLine("--------------------------------------");
            CustomSerializer.Deserialize("BinarySerialization.bin");
            CustomSerializer.Deserialize("xmlSerialization.xml");
            CustomSerializer.Deserialize("JsonSerialization.json");


            XmlSerializer serializer = new XmlSerializer(typeof(List<Check>));
            List<Check> lst = new List<Check>();
            lst.Add(first);
            lst.Add(sec);
            lst.Add(third);

            using (FileStream fs = new FileStream("Collection.xml", FileMode.Create))
            {
                serializer.Serialize(fs, lst);
            }
            Console.WriteLine("\n----------Коллекция---------");
            using (FileStream fr = new FileStream("Collection.xml", FileMode.Open))
            {
                List<Check> newLst = (List<Check>)serializer.Deserialize(fr);
                foreach (var item in newLst)
                {
                    Console.WriteLine($"Десиарелизован: "+item.ToString());
                }
            }

            XmlDocument document = new XmlDocument();
            document.Load("Collection.xml");
            XmlNode xmlRoot = document.DocumentElement;
            XmlNodeList allPlants = xmlRoot.SelectNodes("*");

            foreach (XmlNode item in allPlants)
            {
                Console.WriteLine(item.InnerText);
            }
            
            SocketServer.Socket();


            XElement child;
            XElement name;
            XAttribute year;

            XDocument Children = new XDocument();
            XElement root = new XElement("Дети");

            child = new XElement("child");
            name = new XElement("name");
            name.Value = "Костя";
            year = new XAttribute("year", "2003");
            child.Add(name);
            child.Add(year);
            root.Add(child);

            child = new XElement("child");
            name = new XElement("name");
            name.Value = "Инна";
            year = new XAttribute("year", "1815");
            child.Add(name);
            child.Add(year);
            root.Add(child);

            child = new XElement("child");
            name = new XElement("name");
            name.Value = "Олег";
            year = new XAttribute("year", "2345");
            child.Add(name);
            child.Add(year);
            root.Add(child);

            Children.Add(root);
            Children.Save("Children.xml");



            Console.WriteLine("Введите год для поиска: ");
            string yearXML = Console.ReadLine();
            var allAlbums = root.Elements("child");

            foreach (var item in allAlbums)
            {
                if (item.Attribute("year").Value == yearXML)
                {
                    Console.WriteLine(item.Value);
                }
            }
            Console.ReadKey();
        }
    }
}
