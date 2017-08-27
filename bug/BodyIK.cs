using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bug
{
    class BodyIK : FeetPosition
    {
        int posX = 0;
        int posY = 0;
        int posZ = 0;

        int rotX = 0;
        int rotY = 0;
        int rotZ = 0;

        public double[] newPosX = new double[6];
        public double[] newPosY = new double[6];
        public double[] newPosZ = new double[6];

        double[,] bodyIKs = new double[6,12];

        public BodyIK()
        { }

        public BodyIK(double bodySideLength, double coxaLength, double femurLength, double tibiaLength)
        {
            this.bodySideLength = bodySideLength;
            this.coxaLength = coxaLength;
            this.femurLength = femurLength;
            this.tibiaLength = tibiaLength;
        }

        public void bodyIK(List<double> bodyCenterOffsetX, List<double> bodyCenterOffsetY, double[,] feetPositionLegs)
        {
            for (int i = 0; i < 6; i++)
            {
                bodyIKs[i, 0] = feetPositionLegs[i, 0] + bodyCenterOffsetX[i] + posX;
                bodyIKs[i, 1] = feetPositionLegs[i, 2] + bodyCenterOffsetY[i] + posZ;
                bodyIKs[i, 2] = feetPositionLegs[i, 1];
                bodyIKs[i, 3] = Math.Sin(rotX * pi / 180);                                     
                bodyIKs[i, 4] = Math.Cos(rotX * pi / 180);                                 
                bodyIKs[i, 5] = Math.Sin(rotZ * pi / 180);                                 
                bodyIKs[i, 6] = Math.Cos(rotZ * pi / 180);                                 
                bodyIKs[i, 7] = Math.Sin(rotY * pi / 180);                                 
                bodyIKs[i, 8] = Math.Cos(rotY * pi / 180);
                bodyIKs[i, 9] = bodyIKs[i, 0] * bodyIKs[i, 6] * bodyIKs[i, 8]
                        - bodyIKs[i, 1] * bodyIKs[i, 6] * bodyIKs[i, 7]
                        + bodyIKs[i, 2] * bodyIKs[i, 5]
                        - bodyIKs[i, 0];                                                       
                bodyIKs[i, 10] = (bodyIKs[i, 0] * bodyIKs[i, 4] * bodyIKs[i, 7]
                        + bodyIKs[i, 0] * bodyIKs[i, 8] * bodyIKs[i, 5] * bodyIKs[i, 3]
                        + bodyIKs[i, 1] * bodyIKs[i, 8] * bodyIKs[i, 4]
                        - bodyIKs[i, 1] * bodyIKs[i, 7] * bodyIKs[i, 5] * bodyIKs[i, 3]
                        - bodyIKs[i, 2] * bodyIKs[i, 6] * bodyIKs[i, 3]) - bodyIKs[i, 1];               
                bodyIKs[i, 11] = (bodyIKs[i, 0] * bodyIKs[i, 7] * bodyIKs[i, 3]
                        - bodyIKs[i, 0] * bodyIKs[i, 8] * bodyIKs[i, 4] * bodyIKs[i, 5]
                        + bodyIKs[i, 1] * bodyIKs[i, 8] * bodyIKs[i, 3]
                        + bodyIKs[i, 1] * bodyIKs[i, 4] * bodyIKs[i, 7] * bodyIKs[i, 5]
                        + bodyIKs[i, 2] * bodyIKs[i, 6] * bodyIKs[i, 4]) - bodyIKs[i, 2];
            }
        }

        public void changPos(int posX, int posY, int posZ)
        {
            this.posX = posX;
            this.posY = posY;
            this.posZ = posZ;
        }

        public void changRot(int rotX, int rotY, int rotZ)
        {
            this.rotX = rotX;
            this.rotY = rotY;
            this.rotZ = rotZ;
        }

        public void newPos(double[,] feetPositionLegs)
        {
            for (int i = 0; i < 6; i++)
            {
                newPosX[i] = bodyIKs[i, 9] + feetPositionLegs[i, 0] + posX;
                newPosZ[i] = bodyIKs[i, 10] + feetPositionLegs[i, 2] + posZ;
                newPosY[i] = bodyIKs[i, 11] + feetPositionLegs[i, 1] + posY;
            }
        }

        public double[,] returnBIKs()
        {
            return bodyIKs;
        }  
       
        public double[] returnPosX()
        {
            return newPosX;
        }
        public double[] returnPosY()
        {
            return newPosY;
        }
        public double[] returnPosZ()
        {
            return newPosZ;
        }
    }
}
