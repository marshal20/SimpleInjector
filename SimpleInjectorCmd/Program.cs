using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjectorCmd
{
    class Program
    {
        static void PrintUsage()
        {
            Console.WriteLine("Usage: SimpleInjectorCmd.exe <-p/-pid> <process_name/process_id> dll_path");
        }

        static void Main(string[] args)
        {
            if(args.Length != 3)
            {
                PrintUsage();
                return;
            }

            String DllPath = args[2];
            uint ProcId = 0u;

            if(args[0] == "-p")
            {
                // Name
            }
            else if(args[0] == "-pid")
            {
                // ID
            }
            else
            {
                PrintUsage();
                return;
            }

        }
    }
}
