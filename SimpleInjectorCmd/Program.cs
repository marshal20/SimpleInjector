using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InjectorAPI;

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

            // Parse the process ID.
            if(args[0] == "-p") // Name
            {
                Backend.GetProcInfo(args[1]);
            }
            else if(args[0] == "-pid") // ID
            {
                ProcId = uint.Parse(args[1]);
            }
            else
            {
                PrintUsage();
                return;
            }

            // Check if the process ID is valid.
            if(Backend.GetProcInfo(ProcId).id == 0)
            {
                Console.WriteLine("Invalid process.");
            }

            // Finally we inject the dll into the process.
            Backend.InjectDll(ProcId, DllPath);

            Console.Write("The dll was successfully injected into {0} process.", ProcId);
        }
    }
}
