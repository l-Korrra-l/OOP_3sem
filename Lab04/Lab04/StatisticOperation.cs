using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    static class StatisticOperation
    {
        public static string CountSum(List list)
        {
            string str = "";
            for (int i = 0; i < list.length; i++)
            {
                str += list.listArr[i] + " ";
            }
            return str;
        }

        public static string CountDelta(List list)
        {
            string strMin = "";
            string strMax = "";
            int min = 100;
            int max = 0;
            for (int i = 0; i < list.length; i++)
            {
                if (list.listArr[i].Length >= max)
                {
                    strMax = list.listArr[i];
                    max = list.listArr[i].Length;
                }
                else if (list.listArr[i].Length <= min)
                {
                    strMin = list.listArr[i];
                    min = list.listArr[i].Length;
                }
            }


            return strMax.Substring(min);
        }

        public static int Number(List list)
        {
            return list.length;
        }

        public static int CountPhrases(this string str)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] == '.')|| (str[i] == '!') || (str[i] == '?'))
                {
                    counter++;
                }
            }
            if (counter == 0) return ++counter;
            return (str[str.Length-1] =='.' || str[str.Length - 1] == '!' || str[str.Length - 1] == '?') ? counter:++counter;
        }

    }
}
