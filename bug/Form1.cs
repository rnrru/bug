using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bug
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Com_connect cP = new Com_connect();
        private void button1_Click(object sender, EventArgs e)
        {
            string com = "Com6";
            //Com_connect cP = new Com_connect();
            cP.Create_connect(com);
            cP.Open_connect();      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cP.Close_conncet();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cP.Wrire_str("W");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = cP.Read_str();
            textBox1.Text = str;
        }
    }
}
