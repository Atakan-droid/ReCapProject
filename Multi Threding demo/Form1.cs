using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multi_Threding_demo
{
    public partial class Form1 : Form
    {
        
        
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(doldur1);
            th.Start();

        }

        private void doldur1()
        {
            for (int i = 0; i < 1000000001; i++)
            {
                progressBar1.Value = i / 10000000;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(doldur2);
            th.Start();
          
           
        }

        private void doldur2()
        {
            for (int i = 0; i < 1000000001; i++)
            {
                progressBar2.Value = i / 100000000;
            }
        }
    }
}
