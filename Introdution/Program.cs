using System;
using System.Collections.Generic;
using System.IO;

namespace Introdution
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Windows";
            ShowLargeFileWithoutLinq(path);
            Console.ReadKey();
        }

        static void ShowLargeFileWithoutLinq(string path)
        {
            var directory = new DirectoryInfo(path);
            var files = directory.GetFiles();

            Array.Sort(files, new FileInfoComparer());

            //foreach (var file in files)
            //{
            //    Console.WriteLine($"{file.Name} : {file.Length}");
            //}

            for (var i = 0; i < 5; i++)
            {
                var file = files[i];
                Console.WriteLine($"{file.Name, -20} : {file.Length, 10:N0}");
            }
        }
    }

    class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
