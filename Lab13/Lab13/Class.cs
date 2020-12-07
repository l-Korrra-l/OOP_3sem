using System;
using System.IO.Compression;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab13
{
    public static class MKALog
    {
        public const string sourceFile = @"C:\Users\User\Documents\ооп\OOP\Lab13\Lab13\mkalogfile.txt";
        static MKALog() //очистка файла
        {
            using (StreamWriter w = new StreamWriter(sourceFile, false)) {
                w.WriteLine(DateTime.Now);
            }
        }
        public static void WriteLine(string str)
        {
            try
            {
                using (StreamWriter w = new StreamWriter(sourceFile, true))
                {
                    w.WriteLine(str);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
        public static void SearchByString(string str)
        {
            using (StreamReader sr = new StreamReader(sourceFile, false))
            {
                while (!sr.EndOfStream)
                {
                    if (sr.ReadLine().StartsWith(str))
                        Console.WriteLine(sr.ReadLine());
                }
            }
        }

    }

    public class MKADiskInfo
    {
        public void DiskInfo()
        {
            MKALog.WriteLine("DiskInfo:");
            DriveInfo[] drives = DriveInfo.GetDrives(); //получение массива дисков
            foreach (DriveInfo drive in drives)
            {
                MKALog.WriteLine("\tName: " + drive.Name);
                MKALog.WriteLine("\tType: " + drive.DriveType);
                if (drive.IsReady)
                {
                    MKALog.WriteLine("\tFileSystem: " + drive.DriveFormat);
                    MKALog.WriteLine($"\tFreeSpace: total - {drive.TotalFreeSpace / 1000 / 1000 / 1000} GB, available - { drive.AvailableFreeSpace / 1024 / 1024 / 1024} GB");
                    MKALog.WriteLine($"\tTotalSize: {drive.TotalSize / 1024 / 1024 / 1024} GB");
                    MKALog.WriteLine("\tVolumeLabel: " + drive.VolumeLabel);
                }
                MKALog.WriteLine("");
            }
        }
    }


    public class MKAFileInfo
    {
        public void FileData(string path)
        {
            MKALog.WriteLine("FileInfo:");
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                MKALog.WriteLine($"\tAll way : {fileInf.DirectoryName}");
                MKALog.WriteLine($"\tName: {fileInf.Name}");
                MKALog.WriteLine($"\tCapacity: {fileInf.Length}\n\tExtension: {fileInf.Extension}\n\tCreationTime: {fileInf.CreationTime}");
            }
            else
            {
                MKALog.WriteLine("This file doesn't exists");
            }
        }
    }

    public class MKADirInfo
    {
        public void DirInfo(string dirName)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            MKALog.WriteLine("\nDirInfo:");

            MKALog.WriteLine($"\tFilesCount: {dirInfo.GetFiles().Count()}");
            MKALog.WriteLine($"\tCreateon time: {dirInfo.CreationTime}");
            MKALog.WriteLine($"\tSubDirectories: {dirInfo.GetDirectories("*", SearchOption.AllDirectories).Count()}");
            MKALog.WriteLine($"\tParents: {dirInfo.Parent}");
        }
    }

    public class MKAFileManager
    {
        public void FileManager(string path)
        {
            try
            {
                DriveInfo driveInfo = new DriveInfo(path);
                DirectoryInfo dirInfo = Directory.CreateDirectory(driveInfo.Name + "MKAInspect");
                using (StreamWriter writer = File.CreateText(dirInfo.FullName + "\\mkadirinfo.txt"))
                {
                    writer.WriteLine("This is information");
                }
                File.Copy(dirInfo.FullName + "\\mkadirinfo.txt", dirInfo.FullName + "\\copied.txt");
                File.Delete(dirInfo.FullName + "\\mkadirinfo.txt");


                using (StreamWriter writer = File.CreateText(dirInfo.FullName + "\\mkadirinfo.txt"))
                {
                    writer.WriteLine("This is information");
                }
                File.Copy(dirInfo.FullName + "\\mkadirinfo.txt", dirInfo.FullName + "\\copied.txt");
                File.Delete(dirInfo.FullName + "\\mkadirinfo.txt");



                DirectoryInfo dirInfo1 = Directory.CreateDirectory(driveInfo.Name + "MKAFiles");
                DirectoryInfo currentDirectory = new DirectoryInfo("./");
                foreach (var item in currentDirectory.GetFiles())   
                    item.CopyTo(dirInfo1.FullName + "\\" + item.Name, true);
                dirInfo1.MoveTo(dirInfo.FullName + "\\" + dirInfo1.Name);



                string dirpath = @"MKAInspect\MKAFiles";
                string zippath = @"MKAInspect\MKAFiles.zip";
                string unzippath = @"Unzipped";

                //ZipFile.CreateFromDirectory(dirpath, zippath);
                //ZipFile.ExtractToDirectory(zippath, unzippath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
