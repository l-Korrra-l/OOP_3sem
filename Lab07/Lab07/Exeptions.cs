using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{

    public class EmptyException: Exception
    {
        public EmptyException(string mess) : base(mess) { }
    }
    public class LongException: Exception
    {
        public LongException(string mess) : base(mess) { }
    }
    public class PriceException: Exception
    {
        public PriceException(string mess) : base(mess) { }
    }
    public class IndexException : Exception
    {
        public IndexException(string mess) : base(mess) { }
    }
}
