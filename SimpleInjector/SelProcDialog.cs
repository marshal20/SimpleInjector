using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SimpleInjector
{
    public partial class SelProcDialog : Form
    {
        public uint SelectedProcess = 0;

        public SelProcDialog(uint selproc)
        {
            InitializeComponent();
            UpdateList();
            SelectedProcess = selproc;
            foreach (ListViewItem item in ProcList.Items)
            {
                uint procId = uint.Parse(item.SubItems[2].Text, System.Globalization.NumberStyles.HexNumber);
                if (procId == SelectedProcess)
                {
                    ProcList.Select();
                    item.Selected = true;
                    item.Focused = true;
                    ProcList.Select();
                    break;
                }
            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            SelectedProcess = uint.Parse(ProcList.SelectedItems[0].SubItems[2].Text, System.Globalization.NumberStyles.HexNumber);
            this.Close();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void UpdateList()
        {
            ProcList.Items.Clear();
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
                    if (WinAPI.GetModuleFileNameEx(proc, (IntPtr)0, path, 256) <= 0)
                    {
                        path.Clear();
                    }
                    WinAPI.CloseHandle(proc);

                    new_item.SubItems.Add(new ListViewItem.ListViewSubItem(new_item, path.ToString()));

                    if (new_item.SubItems[1].Text == "svchost.exe")
                        continue;

                    ProcList.Items.Add(new_item);
                }
            }
            WinAPI.CloseHandle(snap_shot);

            UpdateImages();
        }

        private void UpdateImages()
        {
            var imageList = new ImageList();

            foreach (ListViewItem item in ProcList.Items)
            {
                if (string.IsNullOrEmpty(item.SubItems[3].Text))
                {
                    continue;
                }

                Image preview = GetExeImage(item.SubItems[3].Text);
                if (preview == null)
                {
                    continue;
                }
                imageList.Images.Add(preview);
                item.ImageIndex = imageList.Images.Count - 1;
            }

            ProcList.LargeImageList = imageList;
            ProcList.SmallImageList = imageList;
        }

        private Image GetExeImage(string path)
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
