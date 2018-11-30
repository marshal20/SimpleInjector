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
using InjectorAPI;

namespace SimpleInjector
{
    public partial class MainForm : Form
    {
        uint SelectedProcId = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelProcDialog procdialog = new SelProcDialog();
            procdialog.SelectedProcess = SelectedProcId;
            procdialog.ShowDialog();
            SelectedProcId = procdialog.SelectedProcess;

            UpdatePreview();
        }

        private void UpdatePreview()
        {
            Backend.ProcInfo SelectedProcInfo = Backend.GetProcInfo(SelectedProcId);
            ProcName.Text = SelectedProcInfo.name;
            ProcId.Text = SelectedProcInfo.id.ToString("X4");
            ProcPicture.Image = SelectedProcInfo.preview;
        }

        private void DllPathSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog dllDialog = new OpenFileDialog();
            dllDialog.Filter = "Dll file (*.dll)|*.dll|Any file (*.*)|*.*";
            dllDialog.Title = "Select Dll";
            if(dllDialog.ShowDialog() == DialogResult.OK)
            {
                DllPath.Text = dllDialog.FileName;
            }
        }

        private void InjectButton_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(DllPath.Text))
            {
                MessageBox.Show("Invalid Dll path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if(Backend.GetProcInfo(SelectedProcId).id == 0)
            {
                MessageBox.Show("Invalid process.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool InjectionResult = Backend.InjectDll(SelectedProcId, DllPath.Text);
            if(!InjectionResult)
            {
                MessageBox.Show("Can't inject into the process.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

