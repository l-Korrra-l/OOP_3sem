using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Lab12
{
    class Reflector
    {
        static string file = @"C:\Users\User\Documents\ооп\OOP\Lab12\Lab12\file.txt";
        static public void ToFile(string info)
        {
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.WriteLine(info);
            }
        }
        static public string GetConstructor(string classname) //есть ли публичные конструкторы
        {
            Type type = Type.GetType(classname, false, true);
            string str="\nConstructors:";
            foreach (var constr in type.GetConstructors())
                str+="\n- "+constr.Name;
            Console.WriteLine(str);
            return str;
        }

        static public string Pub(string classname) //извлекает все общедоступные публичные методы классa
        {
            Type t = Type.GetType(classname);
            string str="\nList of methods:";

            foreach (MethodInfo cMethod in t.GetMethods()) //GetMethods возвращает все public методы
            {
                str+="\n"+cMethod.Name;
            }
            Console.WriteLine(str);
            return str;
        }
        static public string Field(string classname) //поля и свойства класса
        {
            Type t = Type.GetType(classname);
            string str = "\nList of fields:";
            foreach (FieldInfo fInfo in t.GetFields())
            {
                str += "\n"+fInfo.FieldType.Name + " " + fInfo.Name;
            }
            str += "\nList of properties:";
            foreach (PropertyInfo pInfo in t.GetProperties())
            {
                str+= "\n"+pInfo.PropertyType.Name + " " + pInfo.Name;
            }
            Console.WriteLine(str);
            return str;
        }
        static public string Interface(string classname) // получает все реализованные классом интерфейсы
        {
            Type t = Type.GetType(classname);
            string str="\nList of interfaces:";
            foreach (Type tp in t.GetInterfaces())
            {
                str+=tp.Name;
            }
            Console.WriteLine(str);
            return str;
        }
        static public string MethodForType(string classname, string parametr) //выводит по имени класса имена методов, которые содержат заданный тип параметра
        {
            Type t = Type.GetType(classname);
            MethodInfo[] methods = t.GetMethods();
            string str="\nMethods of class "+classname+" with args type: "+parametr;
            for (int i = 0; i < methods.Length; i++)
            {
                ParameterInfo[] param = methods[i].GetParameters();
                for (int j = 0; j < param.Length; j++)
                {
                    if (parametr == param[j].ParameterType.Name)
                    {
                        str+="\n"+methods[i].Name;
                    }
                }
            }
            Console.WriteLine(str);
            return str;
        }
        public static void Invoke(string className, string methodName) //вызывает метод класса, параметры метода берутся из файла
        {
            Type type = Type.GetType(className);
            List<string> FirstParam = File.ReadAllLines(@"C:\Users\User\Documents\ооп\OOP\Lab12\Lab12\Parameters.txt").ToList();
            List<string>[] parametrs = new List<string>[] { FirstParam };
            try
            {
                object obj = Activator.CreateInstance(type);
                MethodInfo method = type.GetMethod(methodName);
                Console.WriteLine(" Result of execution of method:");
                Console.WriteLine(method.Invoke(obj, parametrs));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static public void Create(string classname, string name) //создает объект переданного типа
        {
            Type t = Type.GetType(classname);
            ConstructorInfo[] p = Type.GetType(classname).GetConstructors();
            object obj = Activator.CreateInstance(t, args: name);
            Console.WriteLine(obj.ToString());
        }
        static public void Name()//Определение имени сборки, в которой определен класс
        {
            Assembly assem = Assembly.GetExecutingAssembly();
            Console.WriteLine(assem.FullName);
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.WriteLine(assem.FullName);
            }
        }

    }
}
