using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace bug
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int posX = 0; int posY = 0; int posZ = 0;
        int rotX = 0; int rotY = 0; int rotZ = 0;

        string leg1; string leg2; string leg3;      
        string leg4; string leg5; string leg6;

        int gait = 1;

        string rn = "\r\n";
        //Leg1
        string ch1 = "#1P"; string dt1 = "T800";
        string ch2 = "#2P"; string ch3 = "#4P";
        //Leg2
        string ch4 = "#5P"; string dt2 = "T800";
        string ch5 = "#6P"; string ch6 = "#8P";
        //Leg3
        string ch7 = "#9P"; string dt3 = "T800";
        string ch8 = "#10P"; string ch9 = "#12P";
        //Leg4
        string ch10 = "#13P"; string dt4 = "T800";
        string ch11 = "#14P"; string ch12 = "#16P";
        //Leg5
        string ch13 = "#17P"; string dt5 = "T800";
        string ch14 = "#18P"; string ch15 = "#20P";
        //Leg6
        string ch16 = "#21P"; string dt6 = "T800";
        string ch17 = "#22P"; string ch18 = "#24P";

        Com_connect cP = new Com_connect();

        RobotGeometry rG = new RobotGeometry(45,12,35,72);

        BodyCenterOffset bodyCO = new BodyCenterOffset(45);

        FeetPosition fP = new FeetPosition(45, 12, 35, 72);

        BodyIK bIK = new BodyIK(45, 12, 35, 72);

        LegIK lIK = new LegIK(45, 12, 35, 72);

        //Open ComConnect
        private void button1_Click(object sender, EventArgs e)
        {
            string com = comboBox1.Text;
            if (comboBox1.Text != "")
            {                
                cP.Create_connect(com);
                cP.Open_connect();
            }
            else 
            {
                MessageBox.Show("Can't find com ports");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cP.Close_connect();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cP.Wrire_str(leg1);
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

        //Calculate feets position
        public void calculate()
        {
            List<double> bodyCenterOffsetsX = new List<double>();
            List<double> bodyCenterOffsetsY = new List<double>();

            bodyCO.bodyCenterOffset();
            bodyCenterOffsetsX = bodyCO.putBodyOffsetsX();
            bodyCenterOffsetsY = bodyCO.putBodyOffsetsY();

            fP.feetPosition();

            double[,] feetPos = fP.returnFP();

            bIK.changPos(posX, posY, posZ);
            bIK.changRot(rotX, rotY, rotZ);

            bIK.bodyIK(bodyCenterOffsetsX, bodyCenterOffsetsY, feetPos);
            bIK.returnBIKs();
            bIK.newPos(feetPos);

            double[] returnPosX = bIK.returnPosX();
            double[] returnPosY = bIK.returnPosY();
            double[] returnPosZ = bIK.returnPosZ();

            lIK.legIK(returnPosX, returnPosY, returnPosZ);
            lIK.legAngles();

            double[] servoPWMcoxa = lIK.returnPWMc();
            double[] servoPWMfemur = lIK.returnPWMf();
            double[] servoPWMtibia = lIK.returnPWMt();

            richTextBox1.Text = " ";

            richTextBox1.Text = "leg1: " + "\n"
                 + "Coxa angle = " + servoPWMcoxa[0] + "\n"
                 + "Femur angle = " + servoPWMfemur[0] + "\n"
                 + "Tibia angle = " + servoPWMtibia[0] + "\n"

                 + "leg2: " + "\n"
                 + "Coxa angle = " + servoPWMcoxa[1] + "\n"
                 + "Femur angle = " + servoPWMfemur[1] + "\n"
                 + "Tibia angle = " + servoPWMtibia[1] + "\n"

                 + "leg2: " + "\n"
                 + "Coxa angle = " + servoPWMcoxa[2] + "\n"
                 + "Femur angle = " + servoPWMfemur[2] + "\n"
                 + "Tibia angle = " + servoPWMtibia[2] + "\n"

                 + "leg2: " + "\n"
                 + "Coxa angle = " + servoPWMcoxa[3] + "\n"
                 + "Femur angle = " + servoPWMfemur[3] + "\n"
                 + "Tibia angle = " + servoPWMtibia[3] + "\n"

                 + "leg2: " + "\n"
                 + "Coxa angle = " + servoPWMcoxa[4] + "\n"
                 + "Femur angle = " + servoPWMfemur[4] + "\n"
                 + "Tibia angle = " + servoPWMtibia[4] + "\n"

                 + "leg2: " + "\n"
                 + "Coxa angle = " + servoPWMcoxa[5] + "\n"
                 + "Femur angle = " + servoPWMfemur[5] + "\n"
                 + "Tibia angle = " + servoPWMtibia[5] + "\n";

            leg1 = ch1 + Math.Round(servoPWMcoxa[0]) + ch2 + Math.Round(servoPWMfemur[0])
                        + ch3 + Math.Round(servoPWMtibia[0]) + dt1 + rn;
            richTextBox1.Text = richTextBox1.Text + leg1;

            leg2 = ch4 + Math.Round(servoPWMcoxa[1]) + ch5 + Math.Round(servoPWMfemur[1])
                        + ch6 + Math.Round(servoPWMtibia[1]) + dt2 + rn;
            richTextBox1.Text = richTextBox1.Text + leg2;

            leg3 = ch7 + Math.Round(servoPWMcoxa[2]) + ch8 + Math.Round(servoPWMfemur[2])
                        + ch9 + Math.Round(servoPWMtibia[2]) + dt3 + rn;
            richTextBox1.Text = richTextBox1.Text + leg3;

            leg4 = ch10 + Math.Round(servoPWMcoxa[3]) + ch11 + Math.Round(servoPWMfemur[3])
                         + ch12 + Math.Round(servoPWMtibia[3]) + dt4 + rn;
            richTextBox1.Text = richTextBox1.Text + leg4;

            leg5 = ch13 + Math.Round(servoPWMcoxa[4]) + ch14 + Math.Round(servoPWMfemur[4])
                        + ch15 + Math.Round(servoPWMtibia[4]) + dt5 + rn;
            richTextBox1.Text = richTextBox1.Text + leg5;

            leg6 = ch16 + Math.Round(servoPWMcoxa[5]) + ch17 + Math.Round(servoPWMfemur[5])
                        + ch18 + Math.Round(servoPWMtibia[5]) + dt6 + rn;
            richTextBox1.Text = richTextBox1.Text + leg6;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (posX < 20)
            {
                posX = posX + 2;
                positX.Text = Convert.ToString(posX);
                calculate();
            }            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (posX > -20)
            {
                posX = posX - 2;
                positX.Text = Convert.ToString(posX);
                calculate();
            }            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (posY < 20)
            {
                posY = posY + 2;
                positY.Text = Convert.ToString(posY);
                calculate();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (posY > -20)
            {
                posY = posY - 2;
                positY.Text = Convert.ToString(posY);
                calculate();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (posZ < 20)
            {
                posZ = posZ + 2;
                positZ.Text = Convert.ToString(posZ);
                calculate();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (posZ > -20)
            {
                posZ = posZ - 2;
                positZ.Text = Convert.ToString(posZ);
                calculate();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (rotX < 20)
            {
                rotX = rotX + 2;
                rotationX.Text = Convert.ToString(rotX);
                calculate();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (rotX > -20)
            {
                rotX = rotX - 2;
                rotationX.Text = Convert.ToString(rotX);
                calculate();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (rotY < 20)
            {
                rotY = rotY + 2;
                rotationY.Text = Convert.ToString(rotY);
                calculate();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (rotY > -20)
            {
                rotY = rotY - 2;
                rotationY.Text = Convert.ToString(rotY);
                calculate();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (rotZ < 20)
            {
                rotZ = rotZ + 2;
                rotationZ.Text = Convert.ToString(rotZ);
                calculate();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (rotZ > -20)
            {
                rotZ = rotZ - 2;
                rotationZ.Text = Convert.ToString(rotZ);
                calculate();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (gait < 6)
            {
                gait++;
                gaits.Text = Convert.ToString(gait);
                calculate();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (gait > 1)
            {
                gait--;
                gaits.Text = Convert.ToString(gait);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            positX.Text = "0"; rotationX.Text = "0";
            positY.Text = "0"; rotationY.Text = "0";
            positZ.Text = "0"; rotationZ.Text = "0";

            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
            comboBox1.SelectedIndex = 0;
        }

        //comboBox reload
        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string[] ports = SerialPort.GetPortNames();            
            comboBox1.Items.AddRange(ports);
            comboBox1.SelectedIndex = 0;
        }
    }
}
