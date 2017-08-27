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
        int posX = 0;
        int posY = 0;
        int posZ = 0;

        int rotX = 0;
        int rotY = 0;
        int rotZ = 0;

        string leg1;
        string leg2;
        string leg3;
        string leg4;
        string leg5;
        string leg6;

        Com_connect cP = new Com_connect();

        RobotGeometry rG = new RobotGeometry(45,12,35,72);

        BodyCenterOffset bodyCO = new BodyCenterOffset();

        FeetPosition fP = new FeetPosition(45, 12, 35, 72);

        BodyIK bIK = new BodyIK(45, 12, 35, 72);

        LegIK lIK = new LegIK(45, 12, 35, 72);

        //LegAngles lA = new LegAngles();


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

        private void button5_Click(object sender, EventArgs e)
        {
            List<double> bodyCenterOffsetsX = new List<double>();
            List<double> bodyCenterOffsetsY = new List<double>();

            double[] mas = rG.returnRG();

            bodyCO.bodyCenterOffset(mas[0]);
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

            lIK.legIK(returnPosX,returnPosY,returnPosZ);
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

            string rn = "\r\n";
            //Leg1
            string ch1 = "#1P"; string dt1 = "T800";
            string ch2 = "#2P"; string ch3 = "#4P";

            leg1 = ch1 + Math.Round(servoPWMcoxa[0]) + ch2 + Math.Round(servoPWMfemur[0])
                        + ch3 + Math.Round(servoPWMtibia[0]) + dt1;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (posX < 10)
            {
                posX++;
                positX.Text = Convert.ToString(posX);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (posX > -10)
            {
                posX--;
                positX.Text = Convert.ToString(posX);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (posY < 10)
            {
                posY++;
                positY.Text = Convert.ToString(posY);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (posY > -10)
            {
                posY--;
                positY.Text = Convert.ToString(posY);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (posZ < 10)
            {
                posZ++;
                positZ.Text = Convert.ToString(posZ);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (posZ > -10)
            {
                posZ--;
                positZ.Text = Convert.ToString(posZ);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (rotX < 10)
            {
                rotX++;
                rotationX.Text = Convert.ToString(rotX);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (rotX > -10)
            {
                rotX--;
                rotationX.Text = Convert.ToString(rotX);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (rotY < 10)
            {
                rotY++;
                rotationY.Text = Convert.ToString(rotY);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (rotY > -10)
            {
                rotY--;
                rotationY.Text = Convert.ToString(rotY);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (rotZ < 10)
            {
                rotZ++;
                rotationZ.Text = Convert.ToString(rotZ);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (rotZ > -10)
            {
                rotZ--;
                rotationZ.Text = Convert.ToString(rotZ);
            }
        }
    }
}
