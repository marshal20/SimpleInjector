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
            uint SelProc = 0;
            try
            {
                SelProc = uint.Parse(label1.Text, System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                SelProc = 0;
            }
            SelProcDialog procdialog = new SelProcDialog
            { SelectedProcess = SelProc };
            procdialog.ShowDialog();
            label1.Text = procdialog.SelectedProcess.ToString("X4");
        }
    }
}

