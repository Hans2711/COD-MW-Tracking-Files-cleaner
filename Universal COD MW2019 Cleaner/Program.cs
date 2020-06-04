using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Universal_COD_MW2019_Cleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "Universal COD MW 2019 Tracking files cleaner";
            Console.WriteLine("Open COD MW 2019 and the cleaner will detect it.");
            while(Process.GetProcessesByName("ModernWarfare").Length == 0)
            {
                Thread.Sleep(100);
            }
            if(Process.GetProcessesByName("ModernWarfare").Length != 0)
            {
                Process p = Process.GetProcessesByName("ModernWarfare")[0];
                string CodDir = p.MainModule.FileName;
                string[] sep = { "\\" };
                string[] title1 = CodDir.Split(sep, StringSplitOptions.None);
                CodDir = "";
                for (var i = 0; i < title1.Length - 1; i++)
                {
                    CodDir += title1[i];
                    if (i != title1.Length - 2)
                    {
                        CodDir += "\\";
                    }
                }
                Console.WriteLine("COD Directory: " + CodDir);
                p.Kill();
                Console.WriteLine("Killed COD\nDeleting Files...");
                string[] traces =
                {
                    "..MW..\\main\\recipes\\cmr_hist",
                    "..MW..\\main\\data0.dcache",
                    "..MW..\\main\\data1.dcache",
                    "..MW..\\main\\toc0.dcache",
                    "..MW..\\main\\toc1.dcache",
                    "..MW..\\Data\\data\\shmem",
                    "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Battle.net\\Cache",
                    "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Battle.net\\Logs",
                    "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Battle.net\\CachedData.db",
                    "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Blizzard Entertainment",
                };

                for(int i = 0; i < traces.Length; i++)
                {
                    traces[i] = traces[i].Replace("..MW..", CodDir);
                    DeleteFile(traces[i]);
                    DeleteFolder(traces[i]);
                }
                Console.WriteLine("Done Cleaning!");
                Console.Read();
            }
        }
        public static void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Deleted: " + path);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch
            {
            }
        }
        public static void DeleteFolder(string path)
        {
            try
            {
                Directory.Delete(path, true);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Deleted: " + path);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch
            {
            }
        }
    }
}
