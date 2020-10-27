using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    partial class BoolVector : IEquatable<BoolVector>
    {
        static int created { get; set; }

        public bool  Equals(BoolVector b, BoolVector a)
        {

            return (a==b);
        }
        static public string Information()
        {
            return $"BoolVector instances: {created}";
        }

        private bool[] data;
        private readonly int id;

        private bool checkBounds(int index)
        {
            if (index >= 0 && index < data.Length)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(id, data).GetHashCode();
        }

        public int getZeroes()
        {
            int result = 0;
            for (int i = 0; i < data.Length; ++i)
                if (data[i] == false)
                    ++result;
            return result;
        }

        public int getUnits()
        {
            int result = 0;
            for (int i = 0; i < data.Length; ++i)
                if (data[i] == true)
                    ++result;
            return result;
        }

        public BoolVector()
        {
            data = new bool[1];
            id = created;
            ++created;
        }

        public BoolVector(int size)
        {
            data = new bool[size];
            id = created;
            ++created;
        }

        public BoolVector(bool[] data)
        {
            this.data = data;
            id = created;
            ++created;
        }

        static BoolVector()
        {
            created = 0;
        }
    }
}
