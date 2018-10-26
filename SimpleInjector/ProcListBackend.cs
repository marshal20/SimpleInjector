﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;

namespace SimpleInjector
{
    class ProcListBackend
    {
        public struct ProcInfo
        {
            public Image preview;
            public string name;
            public uint id;
            public string path;
        }

        public static List<ProcInfo> GetList()
        {
            List<ProcInfo> procs = new List<ProcInfo>();
            IntPtr snap_shot = new IntPtr();
            WinAPI.PROCESSENTRY32 proc_entry = new WinAPI.PROCESSENTRY32();

            snap_shot = WinAPI.CreateToolhelp32Snapshot(WinAPI.SnapshotFlags.Process, 0);
            proc_entry.dwSize = (uint)Marshal.SizeOf(typeof(WinAPI.PROCESSENTRY32));
            if (WinAPI.Process32First(snap_shot, ref proc_entry) == true)
            {
                while (WinAPI.Process32Next(snap_shot, ref proc_entry) == true)
                {
                    ProcInfo CurProcInfo = new ProcInfo();
                    CurProcInfo.name = proc_entry.szExeFile;
                    CurProcInfo.id = proc_entry.th32ProcessID;

                    IntPtr proc = WinAPI.OpenProcess(
                        WinAPI.ProcessAccessFlags.QueryInformation | WinAPI.ProcessAccessFlags.VirtualMemoryRead,
                        false, (int)proc_entry.th32ProcessID);
                    StringBuilder path = new StringBuilder(256);
                    if (WinAPI.GetModuleFileNameEx(proc, (IntPtr)0, path, 256) <= 0)
                    {
                        path.Clear();
                    }
                    WinAPI.CloseHandle(proc);

                    CurProcInfo.path = path.ToString();
                    CurProcInfo.preview = GetExeImage(CurProcInfo.path);

                    procs.Add(CurProcInfo);
                }
            }
            WinAPI.CloseHandle(snap_shot);

            return procs;
        }

        private static Image GetExeImage(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            try
            {
                Icon icon = Icon.ExtractAssociatedIcon(path);
                return icon.ToBitmap();
            }
            catch
            {
                return null;
            }
        }
    }
}
