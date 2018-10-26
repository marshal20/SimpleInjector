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
        uint SelectedProcId = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint SelProc = uint.Parse(ProcId.Text, System.Globalization.NumberStyles.HexNumber);

            SelProcDialog procdialog = new SelProcDialog();
            procdialog.SelectedProcess = SelProc;
            procdialog.ShowDialog();
            SelectedProcId = procdialog.SelectedProcess;

            UpdatePreview();
        }

        private void UpdatePreview()
        {
            ProcListBackend.ProcInfo SelectedProcInfo = ProcListBackend.GetProcInfo(SelectedProcId);
            ProcName.Text = SelectedProcInfo.name;
            ProcId.Text = SelectedProcInfo.id.ToString("X4");
            ProcPicture.Image = SelectedProcInfo.preview;
        }
    }
}

