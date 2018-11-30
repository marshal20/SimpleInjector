using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InjectorAPI;

namespace SimpleInjector
{
    public partial class SelProcDialog : Form
    {
        public uint SelectedProcess = 0;

        public SelProcDialog()
        {
            InitializeComponent();
        }

        private void SelProcDialog_Load(object sender, EventArgs e)
        {
            UpdateList();
            ProcList.Items[ProcList.Items.Count - 1].EnsureVisible();

            foreach (ListViewItem item in ProcList.Items)
            {
                uint procId = uint.Parse(item.SubItems[2].Text, System.Globalization.NumberStyles.HexNumber);
                if (procId == SelectedProcess)
                {
                    item.Selected = true;
                    item.Focused = true;
                    item.EnsureVisible();
                    ProcList.Select();
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
            var imageList = new ImageList();

            List<Backend.ProcInfo> ProcInfoList = Backend.GetProcList();
            foreach (Backend.ProcInfo pInfo in ProcInfoList)
            {
                ListViewItem NewItem = new ListViewItem("");
                NewItem.SubItems.Add(new ListViewItem.ListViewSubItem(NewItem, pInfo.name));
                NewItem.SubItems.Add(new ListViewItem.ListViewSubItem(NewItem, pInfo.id.ToString("X4")));
                NewItem.SubItems.Add(new ListViewItem.ListViewSubItem(NewItem, pInfo.path.ToString()));
                if (pInfo.preview != null)
                {
                    imageList.Images.Add(pInfo.preview);
                    NewItem.ImageIndex = imageList.Images.Count - 1;
                }
                ProcList.Items.Add(NewItem);
            }

            ProcList.LargeImageList = imageList;
            ProcList.SmallImageList = imageList;
        }

    }
}
