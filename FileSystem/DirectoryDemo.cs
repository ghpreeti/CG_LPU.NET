using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileSystem
{
    internal class DirectoryDemo
    {
        public void DirectoryDemoFunc(string directoryName) 
        {
            if (Directory.Exists(directoryName))
            {
                Console.WriteLine("The directory exists.");
            }
            else
            {
                Directory.CreateDirectory(directoryName);
                Console.WriteLine("The directory was created.");
            }
              //Directory dir = new Directory();
        }

        public void DriveInfoFunc(string driveName)
        {
            DriveInfo dInfo = new DriveInfo(driveName);
            System.Console.WriteLine($"Drive Name : {dInfo.Name}");
            System.Console.WriteLine($"Drive Name : {dInfo.DriveType}");
            System.Console.WriteLine($"Drive Name : {dInfo.DriveFormat}");
            System.Console.WriteLine($"Drive Name : {dInfo.TotalFreeSpace}");
            System.Console.WriteLine($"Drive Name : {dInfo.TotalSize}");
        }

        public void PathDemoFunc()
        {
            //@ if we use this before string then \ will be considered as path separator
            string s = @"C:\temp\MyData.text\Machine.config\Alok\Dummy\ABC.cs"; 
            System.Console.WriteLine(Path.GetFileName(s));
            System.Console.WriteLine(Path.GetTempPath());


        }
    }
}
