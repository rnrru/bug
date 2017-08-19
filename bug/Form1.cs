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

        RobotGeometry rG = new RobotGeometry();

        RobotGeometry rG1 = new RobotGeometry(40,40,20,20);

        BodyCenterOffset bodyCO = new BodyCenterOffset();

        FeetPosition fP = new FeetPosition();

        BodyIK bIK = new BodyIK();
        int k = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            string com = "Com6";
            //Com_connect cP = new Com_connect();
            cP.Create_connect(com);
            cP.Open_connect();   
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cP.Close_connect();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cP.Wrire_str("W");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool _continue = true;
            while (_continue)
            {
                try
                {
                    string message = cP.Read_str();
                    richTextBox1.Text += message;
                }
                catch (TimeoutException) { }
                //finally
                //{
                //    _continue = false;
                //}
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<double> bodyCenterOffsetsX = new List<double>();
            List<double> bodyCenterOffsetsY = new List<double>();

            bodyCO.bodyCenterOffset();

            bodyCenterOffsetsX = bodyCO.putBodyOffsetsX();
            bodyCenterOffsetsY = bodyCO.putBodyOffsetsY();

            fP.feetPosition();

            bIK.bodyIK(bodyCenterOffsetsX, bodyCenterOffsetsY);
        }
    }
}
