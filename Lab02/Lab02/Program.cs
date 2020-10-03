using System;
using System.Linq;
using System.Text;

namespace OOP_Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            //-----------------------------------------1a-initialization---out---in------------------------------------------------
            //bool boo = true; //true/false
            //byte by = 255;    //0 to 255
            //sbyte sby = -128;  //
            //char c = 'a';
            //decimal dec = 42;   //Integer literals
            //double doub = 375.1;
            //float fl = 5;
            //int inn = -8;
            //uint uinn = 0;
            //long lo = -945893859345;
            //ulong ulo = 309503534;
            //short sh = -53;
            //ushort ush = 3453;
            //Console.WriteLine($"Types:\nbool\t{boo}\nbyte\t{by}\nsbyte\t{sby}\nchar\t{c}\ndecimal\t{dec}" +
            //    $"\ndouble\t{doub}\nfloat\t{fl}\nint\t{inn}\nuint\t{uinn}\nlong\t{lo}\nulong\t{ulo}\nshort\t{sh}\nushort\t{ush}");
            //Console.Write("Enter any int: ");
            //int booo = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine($"Output: {booo}");

            //NumberFormatInfo NumbInf = new NumberFormatInfo()  //разн региональные настройки ОС
            //{
            //    NumberDecimalSeparator = ".",
            //};
            //Console.Write("Enter any double: ");
            //double dooo = Convert.ToDouble(Console.ReadLine(),NumbInf);
            //Console.WriteLine($"Output: {dooo}");
            //Console.Write("Enter any letter: ");
            //string chooo = Console.ReadLine();
            //Console.WriteLine($"Output: {chooo}");
            ////--------------------1b--------
            ////явные
            //int a = (int)fl;     double b = (double)fl;         long d = (long)inn;
            ////неявные
            //long e = a;          float f = sh;                  double h = b;

            ////-------------------1c
            //int val = 5;
            //object obj = val;     // присваивание сопровождается упаковкой
            //int valUnboxed = (int)obj; //распаковка
            ////1d
            //var vvv = 11;
            //var www = 22;
            //var sum = vvv + www;
            ////1e
            //int? nll = null;
            //double? nll2 = 6;
            //Nullable<bool> nullbool = null;
            //Nullable<float> nllfloat = 7;

            ////1d---------------????????????????????
            //var vr = 5;
            //vr = 'a';

            ////2a
            //string str = "Лучше быть последним-первым";
            //string str1 = ", чем первым-последним";
            //string str2 = "АУФ";
            //Console.WriteLine("\nCompare");
            //Console.WriteLine(str == str1);
            ////2b
            //Console.WriteLine($"Concatenation : {str + str1}");
            //Console.WriteLine($"Copy : {str1 = str2}");
            //Console.WriteLine($"Substring : {str.Substring(10)}");
            //string[] words = str.Split(new char[] { ' ' });

            //foreach (string s in words)
            //{
            //    Console.WriteLine(s);
            //}


            ////2c
            //string sEmpty = "";
            //int? iNull = null;

            //Console.WriteLine("sEmpty" + sEmpty + " is empty");
            //Console.WriteLine("iNull" + iNull + " is null");

            //////2d
            StringBuilder builder = new StringBuilder("Base string");
            builder[0] = 'w';
            builder.Remove(1, 3);
            builder.Insert(0, "ra");
            builder.Insert(builder.Length, " or not");
            Console.WriteLine(builder);

            ////3a
            //char[,] aArr = new char[3, 3] { { 'к', 'i', 'т' }, { ',', 'т', 'и' }, { 'д', 'е', '?' } };
            //Console.WriteLine();
            //Console.WriteLine("Array");
            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        Console.Write(aArr[i, j]+"\t");
            //    }
            //    Console.WriteLine();
            //}

            ////3b
            //Console.WriteLine();
            //string[] sArr = new String[] { "Deal", "with", "it" };
            //Console.WriteLine();
            //foreach (string sString in sArr)
            //{
            //    Console.WriteLine(sString + ": " + sString.Length);
            //}
            //Console.WriteLine("Array length:"+sArr.Length);

            ////3c
            //int[][] aStepArr = new int[3][];
            //aStepArr[0] = new int[2];
            //aStepArr[1] = new int[3];
            //aStepArr[2] = new int[4];

            //for (int i = 0; i < aStepArr.Length; i++)
            //{
            //    for (int j = 0; j < aStepArr[i].Length; j++)
            //    {
            //        aStepArr[i][j] = Convert.ToInt16(Console.ReadLine());
            //    }
            //}

            //foreach (int[] arr in aStepArr)
            //{
            //    foreach (int a in arr)
            //    {
            //        Console.Write(a + "\t");
            //    }
            //    Console.WriteLine();
            //}

            //3d
            var aNontypedArr = new[] { 1, 2 };
            var sNontypedStr = new[] { "Hello" };

            ////4a
            ValueTuple<int, string, char, string, ulong> smth1 = (1, "булочка с корицей", 'и', "какао ", 7845);

            ////4b
            (int i1, string s1, char c1, string s2, ulong u1) smth = (1, "печенька", 'и', "какао ", 7845);
            Console.WriteLine(smth.s2);
            Console.WriteLine(smth.c1);
            Console.WriteLine(smth.s1);
            Console.WriteLine(smth1.Item3);
            Console.WriteLine(smth1.Item3);
            Console.WriteLine(smth1.Item2);
            ////4c
            int i1 = smth.Item1;
            string s1 = smth.Item2;
            char c1 = smth.Item3;
            string s2 = smth.Item4;
            ulong u1 = smth.Item5;

            //4d
            if (smth == smth1)
            {
                Console.WriteLine("Tuples are equal");
            }
            else
            {
                Console.WriteLine("Tuples are not equal");
            }
            if (smth.Item4 == smth1.Item4)
            {
                Console.WriteLine("Parts are equal");
            }
            else
            {
                Console.WriteLine("Parts are not equal");
            }

            ////5
            System.Tuple<int,int,int,char> main(int[] mass, string st)
            {
                int max, min, sum;
                char let;
                max = mass.Max<int>();
                min = mass.Min<int>();
                sum = mass.Sum();
                let = st[0];
                var tup = Tuple.Create(max, min, sum, let);
                return tup;
            }

            int[] m = { 5, 8, 1, 10, 93, 7 };
            string hello = "Hello";
            Console.WriteLine(main(m, hello));
            ////6
             void func1()
            {
                try
                {
                    checked
                    {
                        Console.WriteLine("checked:");
                        int a = 2147483647;
                        a += 1;
                        Console.WriteLine(a);
                    }
                }
                catch(OverflowException)
                {
                    Console.WriteLine("Overflow");
                }

            }

            void func2()
            {
                try
                {
                    unchecked
                {
                    Console.WriteLine("unchecked:");
                    int a = 2147483647;
                    a += 1;
                    Console.WriteLine(a);
                }
            }
                catch (OverflowException)
            {
                Console.WriteLine("Overflow");
            }
        }

            func1();
            func2();
            Console.ReadKey();
        }
    }
}
