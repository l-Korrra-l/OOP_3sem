    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            MKADiskInfo diskInfo = new MKADiskInfo();
            diskInfo.DiskInfo();

            MKAFileInfo fileInfo = new MKAFileInfo();
            fileInfo.FileData(@"C:\Users\User\Documents\ооп\OOP\Lab13\Lab13\Class.cs");

            MKADirInfo dirInfo = new MKADirInfo();
            dirInfo.DirInfo(@"C:\Users\User\Documents\ооп\OOP\Lab13\Lab13");

            MKALog.SearchByString("FileInfo:");

            Console.ReadKey();
        }
    }
}
