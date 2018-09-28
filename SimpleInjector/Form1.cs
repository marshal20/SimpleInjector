using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleInjector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            IntPtr snap_shot = new IntPtr();
            WinAPI.PROCESSENTRY32 proc_entry = new WinAPI.PROCESSENTRY32();

            snap_shot = WinAPI.CreateToolhelp32Snapshot(WinAPI.SnapshotFlags.Process, 0);
            proc_entry.dwSize = (uint)Marshal.SizeOf(typeof(WinAPI.PROCESSENTRY32));
            if (WinAPI.Process32First(snap_shot, ref proc_entry) == true)
            {
                while(WinAPI.Process32Next(snap_shot, ref proc_entry) == true)
                {
                    ListViewItem new_item = new ListViewItem("");
                    new_item.SubItems.Add(new ListViewItem.ListViewSubItem(new_item, proc_entry.szExeFile));
                    new_item.SubItems.Add(new ListViewItem.ListViewSubItem(new_item, proc_entry.th32ProcessID.ToString("X4")));
                    listView1.Items.Add(new_item);
                }
            }
            WinAPI.CloseHandle(snap_shot);
        }
    }
}

