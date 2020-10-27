using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    partial class Product
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Product b = obj as Product;
            if (b == null)
                return false;
            return this.Name == b.Name && this.Number==b.Number && this.Price==b.Price && this.ShelfLife==b.ShelfLife
                && this.id==b.id && this.Manufacturer==b.Manufacturer && this.upc==b.upc;
        }

        public override int GetHashCode()
        {
            return ((int)upc * 2) / 3;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Manufacturer: {Manufacturer}"; ;
        }
    }
}
