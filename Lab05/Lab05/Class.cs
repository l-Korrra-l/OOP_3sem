using System;

namespace Lab05
{
    interface IDocument
    {
        void Info();
    }
    public abstract class Document
    {
        private readonly int id;
        private string title;
        private DateTime dateOfSignature; //дата подписи
        private Client client;
        private Organization organization;
        public Document(string title, DateTime dateOfSignature, Client client, Organization organization)
        {
            id = (int)title.GetHashCode() + (int)dateOfSignature.GetHashCode();
            this.title = title;
            this.dateOfSignature = dateOfSignature;
            this.client = client;
            this.organization = organization;
        }
        public string Name
        {
            get => client.Name;
            set => client.Name = value;

        }
        public string Lastname
        {
            get => client.Lastname;
            set => client.Lastname = value;

        }
        public string NameOfOrganization
        {
            get => organization.NameOfOrganization;
            set => organization.NameOfOrganization = value;
        }
        public string Title
        {
            get => title;
            set => title = value;
        }
        public DateTime DateOfSignature
        {
            get => dateOfSignature;
            set => dateOfSignature = value;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            Document odin = (Document)obj;
            return this.Title == odin.Title;
        }
        //переопределение GetHashCode
        public override int GetHashCode()
        {
            int hash = 47, d = 32;
            string a = Convert.ToString(Title);
            hash = string.IsNullOrEmpty(a) ? 0 : Title.GetHashCode();
            hash = (hash * 47) + d.GetHashCode();
            return hash;
        }
        public abstract void Info();
        virtual public int GetTotalPrice() { return 0; }
    }
    sealed class Receipt : Document, IDocument //квитанция
    {
        private int servicePrice;

        public Receipt(string title, DateTime dateOfSignature, Client client, Organization organization, int servicePrice)
            : base(title, dateOfSignature, client, organization)
        {
            this.servicePrice = servicePrice;
        }
        public override string ToString()   //переопределение метода(во всех классах)
        {
            return Title + " " + DateOfSignature.ToString("MM/dd/yyyy") + " " + Name + " " + Lastname + " " + NameOfOrganization + " " + servicePrice + "\n--------------------------------------\n";
        }
        public override void Info()
        {
            Console.WriteLine("-----------" + Title + "-----------\n" + "Дата заключения: " + DateOfSignature.ToString("MM/dd/yyyy") + "\n" + "Клиент: " + Name + Lastname + "\n" + "Организация: " + NameOfOrganization + "\n" + "Итоговая стоимость: " + servicePrice);
        }
        override public int GetTotalPrice()
        {
            return servicePrice;
        }
    }
    sealed class Waybill : Document, IDocument //накладная
    {
        private int servicePrice;
        public Waybill(string title, DateTime dateOfSignature, Client client, Organization organization, int servicePrice)
           : base(title, dateOfSignature, client, organization)
        {
            this.servicePrice = servicePrice;
        }
        public override string ToString()   //переопределение метода(во всех классах)
        {
            return Title + " " + DateOfSignature.ToString("MM/dd/yyyy") + " " + Name + " " + Lastname + " " + NameOfOrganization + " " + servicePrice + "\n--------------------------------------\n";
        }
        public override void Info()
        {
            Console.WriteLine("-----------" + Title + "-----------\n" + "Дата заключения: " + DateOfSignature.ToString("MM/dd/yyyy") + "\n" + "Клиент: " + Name + Lastname + "\n" + "Организация: " + NameOfOrganization + "\n" + "Итоговая стоимость: " + servicePrice);
        }
        override public int GetTotalPrice()
        {
            return servicePrice;
        }
    }
    sealed class Check : Document, IDocument //бесплодный класс - нельзя наследовать
    {
        private int totalPrice;
        public Check(string title, DateTime dateOfSignature, Client client, Organization organization, int totalPrice)
               : base(title, dateOfSignature, client, organization)
        {
            this.totalPrice = totalPrice;
        }
        public override string ToString()   //переопределение метода(во всех классах)
        {
            return Title + " " + DateOfSignature.ToString("MM/dd/yyyy") + " " + Name + " " + Lastname + " " + NameOfOrganization + " " + totalPrice + "\n--------------------------------------\n";
        }
        public override void Info()
        {
            Console.WriteLine("-----------" + Title + "-----------\n" + "Дата заключения: " + DateOfSignature.ToString("MM/dd/yyyy") + "\n" + "Клиент: " + Name + Lastname + "\n" + "Организация: " + NameOfOrganization + "\n" + "Итоговая стоимость: " + totalPrice);
        }
        override public int GetTotalPrice()
        {
            return totalPrice;
        }

    }
    public class Client
    {
        private string name;
        private string lastname;

        public Client(string name, string lastname)
        {
            this.name = name;
            this.lastname = lastname;

        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Lastname
        {
            get => lastname;
            set => lastname = value;
        }
    }
    public class Organization
    {
        private string nameOfOrganization;
        public Organization(string nameOfOrganization)
        {
            this.nameOfOrganization = nameOfOrganization;
        }
        public string NameOfOrganization
        {
            get => nameOfOrganization;
            set => nameOfOrganization = value;
        }
    }

    public static class Printer
    {
        public static void IAmPrinting(Document document)
        {
            Console.WriteLine("--------------------------------------\n"+document.GetType());
            Console.WriteLine(document.ToString());
        }
    }
}
