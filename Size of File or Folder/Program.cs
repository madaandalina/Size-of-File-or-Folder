using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Size_of_File_or_Folder
{
    class Program
    {
        static ulong nrBytes = 0;   
        static void Main(string[] args)
        {
            Console.Write("Introdu adresa folderului sau a fisierului: ");
            string adresa = "";
            Console.WriteLine();
            
             if (args.Length > 0)
             {
                 adresa = args[0];
             }
             else
             {
                 adresa = Console.ReadLine();
             }

            Console.WriteLine();
            if (File.Exists(adresa))
            {
                ProcessFile(adresa);
            }
            else if (Directory.Exists(adresa))
            {
                ProcessDirectory(adresa);
            }
            else
            {
                Console.WriteLine($"{adresa} nu este un fisier/folder valid.");
            }
            Console.WriteLine();
        
            Console.WriteLine($"Marimea folderului/fisierului de la adresa \"{adresa}\" este {nrBytes} bytes sau ({nrBytes / 1024f} KB)");
            Console.ReadLine();
        }

        public static void ProcessDirectory(string targetDirectory)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            string[] subDirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subDirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        public static void ProcessFile(string adresa)
        {
            nrBytes += (ulong)File.ReadAllBytes(adresa).Length;
            Console.WriteLine($"\"{adresa}\"");
        }
    }
}