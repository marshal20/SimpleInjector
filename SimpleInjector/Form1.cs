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
using System.Drawing;

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
            update_list();
        }

        private void update_list()
        {
            listView1.Items.Clear();
            IntPtr snap_shot = new IntPtr();
            WinAPI.PROCESSENTRY32 proc_entry = new WinAPI.PROCESSENTRY32();

            snap_shot = WinAPI.CreateToolhelp32Snapshot(WinAPI.SnapshotFlags.Process, 0);
            proc_entry.dwSize = (uint)Marshal.SizeOf(typeof(WinAPI.PROCESSENTRY32));
            if (WinAPI.Process32First(snap_shot, ref proc_entry) == true)
            {
                while (WinAPI.Process32Next(snap_shot, ref proc_entry) == true)
                {
                    ListViewItem new_item = new ListViewItem("");
                    new_item.SubItems.Add(new ListViewItem.ListViewSubItem(new_item, proc_entry.szExeFile));
                    new_item.SubItems.Add(new ListViewItem.ListViewSubItem(new_item, proc_entry.th32ProcessID.ToString("X4")));

                    IntPtr proc = WinAPI.OpenProcess(
                        WinAPI.ProcessAccessFlags.QueryInformation | WinAPI.ProcessAccessFlags.VirtualMemoryRead, 
                        false, (int)proc_entry.th32ProcessID);
                    StringBuilder path = new StringBuilder(256);
                    if(WinAPI.GetModuleFileNameEx(proc, (IntPtr)0, path, 256) <= 0)
                    {
                        path.Clear();
                    }
                    WinAPI.CloseHandle(proc);

                    new_item.SubItems.Add(new ListViewItem.ListViewSubItem(new_item, path.ToString()));

                    listView1.Items.Add(new_item);
                }
            }
            WinAPI.CloseHandle(snap_shot);

            update_images();
        }

        private void update_images()
        {
            var imageList = new ImageList();

            foreach(ListViewItem item in listView1.Items)
            {
                if (string.IsNullOrEmpty(item.SubItems[3].Text))
                {
                    continue;
                }

                Image preview = get_exe_image(item.SubItems[3].Text);
                if (preview == null)
                {
                    continue;
                }
                imageList.Images.Add(preview);
                item.ImageIndex = imageList.Images.Count - 1;
            }

            listView1.LargeImageList = imageList;
            listView1.SmallImageList = imageList;
        }

        private Image get_exe_image(string path)
        {
            if(string.IsNullOrEmpty(path))
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

