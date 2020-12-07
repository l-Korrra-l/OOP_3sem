using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class Game<T> : IEnumerable<T> where T : Player
    {
        public BlockingCollection<T> players = new BlockingCollection<T>();
        public Dictionary<int, T> dict = new Dictionary<int, T>();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator<T> GetEnumerator()
        {
            foreach (T foo in this.players)
            {
                yield return foo;
                // yield return (Foo)foo;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)players).GetEnumerator();
        }

        public void Show()
        {
            foreach (var item in players)
            {
                Console.WriteLine(item);
            }
        }
        public void ShowDict()
        {
            foreach (KeyValuePair<int, T> element in dict)
                Console.WriteLine("Ключ: {0}\t\tЗначение: {1}", element.Key, element.Value);
        }
        public void Remove(int numb)
        {
            for (int i = 0; numb > 0; i++)
            {
                if (dict.ContainsKey(i))
                {
                dict.Remove(i);
                numb--;
                }
            }
        }
    }
    public class Player
    {
        public string Name;
        
        public Player(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    class Program
    {
        public static void Ch(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Collection changed with action " + e.Action);
        }
        static void Main(string[] args)
        {
            //--1--Game
            Player frst = new Player("First");
            Player scnd = new Player("Second");
            Player thrd = new Player("Third");
            Player frth = new Player("Fourth");
            Player ffth = new Player("Fifth");

            Game<Player> idkgame = new Game<Player>();

            idkgame.players.Add(frst);
            idkgame.players.Add(scnd);
            idkgame.players.Add(thrd);
            //idkgame.players.CompleteAdding();
            idkgame.Show();
            Console.WriteLine("Attempt to add: "+idkgame.players.TryAdd(frth));
            Console.WriteLine("\n------after attempt to add----");
            idkgame.Show();
            idkgame.players.CompleteAdding();
            idkgame.players.Take();
            Console.WriteLine("\n---------after frst elem-------");
            idkgame.Show();
            idkgame.players.Dispose();

            Console.WriteLine("\n------------------------------");
            Game<Player> NotAgame = new Game<Player>();
            NotAgame.dict.Add(1,frst);
            NotAgame.dict.Add(2, scnd);
            NotAgame.dict.Add(3, thrd);          
            NotAgame.dict.Add(5, ffth);
            NotAgame.dict.Add(4, frth);
            NotAgame.ShowDict();
            NotAgame.dict.Remove(1);
            Console.WriteLine("\n---------deleted elem by key-------");
            NotAgame.ShowDict();
            NotAgame.Remove(2);
            Console.WriteLine("\n---------deleted 2 elems with the smallest keys-------");
            NotAgame.ShowDict();
            Console.WriteLine("\n------------------------------------------------------");
            Console.WriteLine("if contains key '2':" + NotAgame.dict.ContainsKey(2));
            Console.WriteLine("if contains key '6':" + NotAgame.dict.ContainsKey(6));


            ObservableCollection<int> obs = new ObservableCollection<int>();
            obs.CollectionChanged += Ch;
            obs.Add(5);
            obs.Remove(5);

            Console.ReadKey();
        }
    }
}
