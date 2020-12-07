using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab09
{
    public class Programmer
    {
        public delegate void List(string message);
        public event List DeleteEvent;
        public event List MutateEvent;
        public List<string> list;
        public Programmer(List<string> list)
        {
            this.list = list;
        }
        public void Delete()
        {
            list.RemoveAt(0);
            DeleteEvent?.Invoke("Произошло удаление первого элемента");
        }

        public void Mutate()
        {
            list = list.OrderBy(x => Guid.NewGuid().ToString()).ToList();
            MutateEvent?.Invoke("Произошло мутирование...");

        }
        public void Show()
        {
            foreach (string str in list)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();
        }
    }
}
