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

        private void button1_Click(object sender, EventArgs e)
        {
            uint SelProc = uint.Parse(label1.Text, System.Globalization.NumberStyles.HexNumber);

            SelProcDialog procdialog = new SelProcDialog();
            procdialog.SelectedProcess = SelProc;
            procdialog.ShowDialog();
            SelProc = procdialog.SelectedProcess;

            label1.Text = SelProc.ToString("X4");
        }
    }
}

