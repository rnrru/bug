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

        double[] newPosX = new double[6];
        double[] newPosY = new double[6];
        double[] newPosZ = new double[6];

        double[] bodyIK1 = new double[12];
        double[] bodyIK2 = new double[12];
        double[] bodyIK3 = new double[12];
        double[] bodyIK4 = new double[12];
        double[] bodyIK5 = new double[12];
        double[] bodyIK6 = new double[12];


        double[] legIK1 = new double[11];
        double[] legIK2 = new double[11];
        double[] legIK3 = new double[11];
        double[] legIK4 = new double[11];
        double[] legIK5 = new double[11];
        double[] legIK6 = new double[11];

        public BodyIK()
        { }

        public BodyIK(double bodySideLength, double coxaLength, double femurLength, double tibiaLength)
        {
            this.bodySideLength = bodySideLength;
            this.coxaLength = coxaLength;
            this.femurLength = femurLength;
            this.tibiaLength = tibiaLength;
        }

        public void bodyIK(List<double> bodyCenterOffsetX, List<double> bodyCenterOffsetY)
        {
            bodyIK1[0] = feetPositionLeg1[0] + bodyCenterOffsetX[0] + posX;
            bodyIK1[1] = feetPositionLeg1[2] + bodyCenterOffsetY[0] + posZ;         
            bodyIK1[2] = feetPositionLeg1[1];                                       
            bodyIK1[3] = Math.Sin(rotX * pi / 180);                                     
            bodyIK1[4] = Math.Cos(rotX * pi / 180);                                 
            bodyIK1[5] = Math.Sin(rotZ * pi / 180);                                 
            bodyIK1[6] = Math.Cos(rotZ * pi / 180);                                 
            bodyIK1[7] = Math.Sin(rotY * pi / 180);                                 
            bodyIK1[8] = Math.Cos(rotY * pi / 180);                                 
            bodyIK1[9] = bodyIK1[0] * bodyIK1[6] * bodyIK1[8]
                - bodyIK1[1] * bodyIK1[6] * bodyIK1[7]
                + bodyIK1[2] * bodyIK1[5]
                - bodyIK1[0];                                                       
            bodyIK1[10] = (bodyIK1[0] * bodyIK1[4] * bodyIK1[7]
                + bodyIK1[0] * bodyIK1[8] * bodyIK1[5] * bodyIK1[3]
                + bodyIK1[1] * bodyIK1[8] * bodyIK1[4]
                - bodyIK1[1] * bodyIK1[7] * bodyIK1[5] * bodyIK1[3]
                - bodyIK1[2] * bodyIK1[6] * bodyIK1[3]) - bodyIK1[1];               
            bodyIK1[11] = (bodyIK1[0] * bodyIK1[7] * bodyIK1[3]
                - bodyIK1[0] * bodyIK1[8] * bodyIK1[4] * bodyIK1[5]
                + bodyIK1[1] * bodyIK1[8] * bodyIK1[3]
                + bodyIK1[1] * bodyIK1[4] * bodyIK1[7] * bodyIK1[5]
                + bodyIK1[2] * bodyIK1[6] * bodyIK1[4]) - bodyIK1[2];

            bodyIK2[0] = feetPositionLeg2[0] + bodyCenterOffsetX[1] + posX;         //0-TotalX_1
            bodyIK2[1] = feetPositionLeg2[2] + bodyCenterOffsetY[1] + posZ;         //1-TotalZ_1
            bodyIK2[2] = feetPositionLeg2[1];                                       //2-TotalY_1
            bodyIK2[3] = Math.Sin(rotX * pi / 180);                                 //3-Sin(rotX)
            bodyIK2[4] = Math.Cos(rotX * pi / 180);                                 //4-Cos(rotX)
            bodyIK2[5] = Math.Sin(rotZ * pi / 180);                                 //5-Sin(rotZ)
            bodyIK2[6] = Math.Cos(rotZ * pi / 180);                                 //6-Cos(rotZ)
            bodyIK2[7] = Math.Sin(rotY * pi / 180);                                 //7-Sin(rotY)
            bodyIK2[8] = Math.Cos(rotY * pi / 180);                                 //8-Cos(rotY)
            bodyIK2[9] = bodyIK2[0] * bodyIK2[6] * bodyIK2[8]
                - bodyIK2[1] * bodyIK2[6] * bodyIK2[7]
                + bodyIK2[2] * bodyIK2[5]
                - bodyIK2[0];                                                       //9-BodyIKX
            bodyIK2[10] = (bodyIK2[0] * bodyIK2[4] * bodyIK2[7]
                + bodyIK2[0] * bodyIK2[8] * bodyIK2[5] * bodyIK2[3]
                + bodyIK2[1] * bodyIK2[8] * bodyIK2[4]
                - bodyIK2[1] * bodyIK2[7] * bodyIK2[5] * bodyIK2[3]
                - bodyIK2[2] * bodyIK2[6] * bodyIK2[3]) - bodyIK2[1];               //10-BodyIKZ
            bodyIK2[11] = (bodyIK2[0] * bodyIK2[7] * bodyIK2[3]
                - bodyIK2[0] * bodyIK2[8] * bodyIK2[4] * bodyIK2[5]
                + bodyIK2[1] * bodyIK2[8] * bodyIK2[3]
                + bodyIK2[1] * bodyIK2[4] * bodyIK2[7] * bodyIK2[5]
                + bodyIK2[2] * bodyIK2[6] * bodyIK2[4]) - bodyIK2[2];               //11-BodyIKY

            bodyIK3[0] = feetPositionLeg3[0] + bodyCenterOffsetX[2] + posX;         //0-TotalX_1
            bodyIK3[1] = feetPositionLeg3[2] + bodyCenterOffsetY[2] + posZ;         //1-TotalZ_1
            bodyIK3[2] = feetPositionLeg3[1];                                       //2-TotalY_1
            bodyIK3[3] = Math.Sin(rotX * pi / 180);                                 //3-Sin(rotX)
            bodyIK3[4] = Math.Cos(rotX * pi / 180);                                 //4-Cos(rotX)
            bodyIK3[5] = Math.Sin(rotZ * pi / 180);                                 //5-Sin(rotZ)
            bodyIK3[6] = Math.Cos(rotZ * pi / 180);                                 //6-Cos(rotZ)
            bodyIK3[7] = Math.Sin(rotY * pi / 180);                                 //7-Sin(rotY)
            bodyIK3[8] = Math.Cos(rotY * pi / 180);                                 //8-Cos(rotY)
            bodyIK3[9] = bodyIK3[0] * bodyIK3[6] * bodyIK3[8]
                - bodyIK3[1] * bodyIK3[6] * bodyIK3[7]
                + bodyIK3[2] * bodyIK3[5]
                - bodyIK3[0];                                                       //9-BodyIKX
            bodyIK3[10] = (bodyIK3[0] * bodyIK3[4] * bodyIK3[7]
                + bodyIK3[0] * bodyIK3[8] * bodyIK3[5] * bodyIK3[3]
                + bodyIK3[1] * bodyIK3[8] * bodyIK3[4]
                - bodyIK3[1] * bodyIK3[7] * bodyIK3[5] * bodyIK3[3]
                - bodyIK3[2] * bodyIK3[6] * bodyIK3[3]) - bodyIK3[1];               //10-BodyIKZ
            bodyIK3[11] = (bodyIK3[0] * bodyIK3[7] * bodyIK3[3]
                - bodyIK3[0] * bodyIK3[8] * bodyIK3[4] * bodyIK3[5]
                + bodyIK3[1] * bodyIK3[8] * bodyIK3[3]
                + bodyIK3[1] * bodyIK3[4] * bodyIK3[7] * bodyIK3[5]
                + bodyIK3[2] * bodyIK3[6] * bodyIK3[4]) - bodyIK3[2];               //11-BodyIKY

            bodyIK4[0] = feetPositionLeg4[0] + bodyCenterOffsetX[3] + posX;         //0-TotalX_1
            bodyIK4[1] = feetPositionLeg4[2] + bodyCenterOffsetY[3] + posZ;         //1-TotalZ_1
            bodyIK4[2] = feetPositionLeg4[1];                                       //2-TotalY_1
            bodyIK4[3] = Math.Sin(rotX * pi / 180);                                 //3-Sin(rotX)
            bodyIK4[4] = Math.Cos(rotX * pi / 180);                                 //4-Cos(rotX)
            bodyIK4[5] = Math.Sin(rotZ * pi / 180);                                 //5-Sin(rotZ)
            bodyIK4[6] = Math.Cos(rotZ * pi / 180);                                 //6-Cos(rotZ)
            bodyIK4[7] = Math.Sin(rotY * pi / 180);                                 //7-Sin(rotY)
            bodyIK4[8] = Math.Cos(rotY * pi / 180);                                 //8-Cos(rotY)
            bodyIK4[9] = bodyIK4[0] * bodyIK4[6] * bodyIK4[8]
                - bodyIK4[1] * bodyIK4[6] * bodyIK4[7]
                + bodyIK4[2] * bodyIK4[5]
                - bodyIK4[0];                                                       //9-BodyIKX
            bodyIK4[10] = (bodyIK4[0] * bodyIK4[4] * bodyIK4[7]
                + bodyIK4[0] * bodyIK4[8] * bodyIK4[5] * bodyIK4[3]
                + bodyIK4[1] * bodyIK4[8] * bodyIK4[4]
                - bodyIK4[1] * bodyIK4[7] * bodyIK4[5] * bodyIK4[3]
                - bodyIK4[2] * bodyIK4[6] * bodyIK4[3]) - bodyIK4[1];               //10-BodyIKZ
            bodyIK4[11] = (bodyIK4[0] * bodyIK4[7] * bodyIK4[3]
                - bodyIK4[0] * bodyIK4[8] * bodyIK4[4] * bodyIK4[5]
                + bodyIK4[1] * bodyIK4[8] * bodyIK4[3]
                + bodyIK4[1] * bodyIK4[4] * bodyIK4[7] * bodyIK4[5]
                + bodyIK4[2] * bodyIK4[6] * bodyIK4[4]) - bodyIK4[2];               //11-BodyIKY

            bodyIK5[0] = feetPositionLeg5[0] + bodyCenterOffsetX[4] + posX;         //0-TotalX_1
            bodyIK5[1] = feetPositionLeg5[2] + bodyCenterOffsetY[4] + posZ;         //1-TotalZ_1
            bodyIK5[2] = feetPositionLeg5[1];                                       //2-TotalY_1
            bodyIK5[3] = Math.Sin(rotX * pi / 180);                                 //3-Sin(rotX)
            bodyIK5[4] = Math.Cos(rotX * pi / 180);                                 //4-Cos(rotX)
            bodyIK5[5] = Math.Sin(rotZ * pi / 180);                                 //5-Sin(rotZ)
            bodyIK5[6] = Math.Cos(rotZ * pi / 180);                                 //6-Cos(rotZ)
            bodyIK5[7] = Math.Sin(rotY * pi / 180);                                 //7-Sin(rotY)
            bodyIK5[8] = Math.Cos(rotY * pi / 180);                                 //8-Cos(rotY)
            bodyIK5[9] = bodyIK5[0] * bodyIK5[6] * bodyIK5[8]
                - bodyIK5[1] * bodyIK5[6] * bodyIK5[7]
                + bodyIK5[2] * bodyIK5[5]
                - bodyIK5[0];                                                       //9-BodyIKX
            bodyIK5[10] = (bodyIK5[0] * bodyIK5[4] * bodyIK5[7]
                + bodyIK5[0] * bodyIK5[8] * bodyIK5[5] * bodyIK5[3]
                + bodyIK5[1] * bodyIK5[8] * bodyIK5[4]
                - bodyIK5[1] * bodyIK5[7] * bodyIK5[5] * bodyIK5[3]
                - bodyIK5[2] * bodyIK5[6] * bodyIK5[3]) - bodyIK5[1];               //10-BodyIKZ
            bodyIK5[11] = (bodyIK5[0] * bodyIK5[7] * bodyIK5[3]
                - bodyIK5[0] * bodyIK5[8] * bodyIK5[4] * bodyIK5[5]
                + bodyIK5[1] * bodyIK5[8] * bodyIK5[3]
                + bodyIK5[1] * bodyIK5[4] * bodyIK5[7] * bodyIK5[5]
                + bodyIK5[2] * bodyIK5[6] * bodyIK5[4]) - bodyIK5[2];               //11-BodyIKY

            bodyIK6[0] = feetPositionLeg6[0] + bodyCenterOffsetX[5] + posX;         //0-TotalX_1
            bodyIK6[1] = feetPositionLeg6[2] + bodyCenterOffsetY[5] + posZ;         //1-TotalZ_1
            bodyIK6[2] = feetPositionLeg6[1];                                       //2-TotalY_1
            bodyIK6[3] = Math.Sin(rotX * pi / 180);                                 //3-Sin(rotX)
            bodyIK6[4] = Math.Cos(rotX * pi / 180);                                 //4-Cos(rotX)
            bodyIK6[5] = Math.Sin(rotZ * pi / 180);                                 //5-Sin(rotZ)
            bodyIK6[6] = Math.Cos(rotZ * pi / 180);                                 //6-Cos(rotZ)
            bodyIK6[7] = Math.Sin(rotY * pi / 180);                                 //7-Sin(rotY)
            bodyIK6[8] = Math.Cos(rotY * pi / 180);                                 //8-Cos(rotY)
            bodyIK6[9] = bodyIK6[0] * bodyIK6[6] * bodyIK6[8]
                - bodyIK6[1] * bodyIK6[6] * bodyIK6[7]
                + bodyIK6[2] * bodyIK6[5]
                - bodyIK6[0];                                                       //9-BodyIKX
            bodyIK6[10] = (bodyIK6[0] * bodyIK6[4] * bodyIK6[7]
                + bodyIK6[0] * bodyIK6[8] * bodyIK6[5] * bodyIK6[3]
                + bodyIK6[1] * bodyIK6[8] * bodyIK6[4]
                - bodyIK6[1] * bodyIK6[7] * bodyIK6[5] * bodyIK6[3]
                - bodyIK6[2] * bodyIK6[6] * bodyIK6[3]) - bodyIK6[1];               //10-BodyIKZ
            bodyIK6[11] = (bodyIK6[0] * bodyIK6[7] * bodyIK6[3]
                - bodyIK6[0] * bodyIK6[8] * bodyIK6[4] * bodyIK6[5]
                + bodyIK6[1] * bodyIK6[8] * bodyIK6[3]
                + bodyIK6[1] * bodyIK6[4] * bodyIK6[7] * bodyIK6[5]
                + bodyIK6[2] * bodyIK6[6] * bodyIK6[4]) - bodyIK6[2];               //11-BodyIKY

            newPosX[0] = bodyIK1[9] + feetPositionLeg1[0] + posX;
            newPosX[1] = bodyIK2[9] + feetPositionLeg2[0] + posX;
            newPosX[2] = bodyIK3[9] + feetPositionLeg3[0] + posX;
            newPosX[3] = bodyIK4[9] + feetPositionLeg4[0] + posX;
            newPosX[4] = bodyIK5[9] + feetPositionLeg5[0] + posX;
            newPosX[5] = bodyIK6[9] + feetPositionLeg6[0] + posX;

            newPosZ[0] = bodyIK1[10] + feetPositionLeg1[2] + posZ;
            newPosZ[1] = bodyIK2[10] + feetPositionLeg2[2] + posZ;
            newPosZ[2] = bodyIK3[10] + feetPositionLeg3[2] + posZ;
            newPosZ[3] = bodyIK4[10] + feetPositionLeg4[2] + posZ;
            newPosZ[4] = bodyIK5[10] + feetPositionLeg5[2] + posZ;
            newPosZ[5] = bodyIK6[10] + feetPositionLeg6[2] + posZ;

            newPosY[0] = bodyIK1[11] + feetPositionLeg1[1] + posY;
            newPosY[1] = bodyIK2[11] + feetPositionLeg2[1] + posY;
            newPosY[2] = bodyIK3[11] + feetPositionLeg3[1] + posY;
            newPosY[3] = bodyIK4[11] + feetPositionLeg4[1] + posY;
            newPosY[4] = bodyIK5[11] + feetPositionLeg5[1] + posY;
            newPosY[5] = bodyIK6[11] + feetPositionLeg6[1] + posY;
        }

        public void legIK()
        {
            legIK1[0] = newPosX[0] * Math.Cos(30 * pi / 180)
                - newPosZ[0] * Math.Sin(30 * pi / 180);                             //0-Transform X
            legIK1[1] = newPosX[0] * Math.Sin(30 * pi / 180)
                + newPosZ[0] * Math.Cos(30 * pi / 180);                             //1-Transform Z
            legIK1[2] = newPosY[0];                                                 //2-Transform Y
            legIK1[3] = Math.Sqrt(legIK1[0] * legIK1[0] + legIK1[1] * legIK1[1]);
            legIK1[4] = Math.Sqrt((legIK1[3] - coxaLength)                          //3-CoxaFeetDist
                * (legIK1[3] - coxaLength) + legIK1[2] * legIK1[2]);                //4-IKSW
            legIK1[5] = Math.Atan((legIK1[3] - coxaLength) / legIK1[2]);            //5-IKA1
            legIK1[6] = Math.Acos((tibiaLength * tibiaLength - femurLength * femurLength
                - legIK1[4] * legIK1[4]) / (-2 * legIK1[4] * femurLength));         //6-IKA2
            legIK1[7] = Math.Acos((legIK1[4] * legIK1[4] - tibiaLength * tibiaLength
                - femurLength * femurLength) / (-2 * femurLength * tibiaLength));   //7-TAngle
            legIK1[8] = 90 - legIK1[7] * 180 / pi;                                  //8-IKTibiaAngle
            legIK1[9] = (legIK1[5] + legIK1[6]) * 180 / pi - 90;                    //9-IKFemurAngle
            legIK1[10] = Math.Atan2(legIK1[0], legIK1[1]) * 180 / pi;               //10-IKCoxaAngle

            legIK2[0] = newPosX[1] * Math.Cos(90 * pi / 180)
                - newPosZ[1] * Math.Sin(90 * pi / 180);                             //0-Transform X
            legIK2[1] = newPosX[1] * Math.Sin(90 * pi / 180)
                + newPosZ[1] * Math.Cos(90 * pi / 180);                             //1-Transform Z
            legIK2[2] = newPosY[1];                                                 //2-Transform Y
            legIK2[3] = Math.Sqrt(legIK2[0] * legIK2[0] + legIK2[1] * legIK2[1]);
            legIK2[4] = Math.Sqrt((legIK2[3] - coxaLength)                          //3-CoxaFeetDist
                * (legIK2[3] - coxaLength) + legIK2[2] * legIK2[2]);                //4-IKSW
            legIK2[5] = Math.Atan((legIK2[3] - coxaLength) / legIK2[2]);            //5-IKA1
            legIK2[6] = Math.Acos((tibiaLength * tibiaLength - femurLength * femurLength
                - legIK2[4] * legIK2[4]) / (-2 * legIK2[4] * femurLength));          //6-IKA2
            legIK2[7] = Math.Acos((legIK2[4] * legIK2[4] - tibiaLength * tibiaLength
                - femurLength * femurLength) / (-2 * femurLength * tibiaLength));    //7-TAngle
            legIK2[8] = 90 - legIK2[7] * 180 / pi;                                   //8-IKTibiaAngle
            legIK2[9] = (legIK2[5] + legIK2[6]) * 180 / pi - 90;                     //9-IKFemurAngle
            legIK2[10] = Math.Atan2(legIK2[0], legIK2[1]) * 180 / pi;                //10-IKCoxaAngle

            legIK3[0] = newPosX[2] * Math.Cos(150 * pi / 180)
                - newPosZ[2] * Math.Sin(150 * pi / 180);                            //0-Transform X
            legIK3[1] = newPosX[2] * Math.Sin(150 * pi / 180)
                + newPosZ[2] * Math.Cos(150 * pi / 180);                            //1-Transform Z
            legIK3[2] = newPosY[2];                                                //2-Transform Y
            legIK3[3] = Math.Sqrt(legIK3[0] * legIK3[0] + legIK3[1] * legIK3[1]);
            legIK3[4] = Math.Sqrt((legIK3[3] - coxaLength)                         //3-CoxaFeetDist
                * (legIK3[3] - coxaLength) + legIK3[2] * legIK3[2]);               //4-IKSW
            legIK3[5] = Math.Atan((legIK3[3] - coxaLength) / legIK3[2]);           //5-IKA1
            legIK3[6] = Math.Acos((tibiaLength * tibiaLength - femurLength * femurLength
                - legIK3[4] * legIK3[4]) / (-2 * legIK3[4] * femurLength));         //6-IKA2
            legIK3[7] = Math.Acos((legIK3[4] * legIK3[4] - tibiaLength * tibiaLength
                - femurLength * femurLength) / (-2 * femurLength * tibiaLength));   //7-TAngle
            legIK3[8] = 90 - legIK3[7] * 180 / pi;                                  //8-IKTibiaAngle
            legIK3[9] = (legIK3[5] + legIK3[6]) * 180 / pi - 90;                    //9-IKFemurAngle
            legIK3[10] = Math.Atan2(legIK3[0], legIK3[1]) * 180 / pi;               //10-IKCoxaAngle

            legIK4[0] = newPosX[3] * Math.Cos(210 * pi / 180)
                - newPosZ[3] * Math.Sin(210 * pi / 180);                            //0-Transform X
            legIK4[1] = newPosX[3] * Math.Sin(210 * pi / 180)
                + newPosZ[3] * Math.Cos(210 * pi / 180);                            //1-Transform Z
            legIK4[2] = newPosY[3];                                                //2-Transform Y
            legIK4[3] = Math.Sqrt(legIK4[0] * legIK4[0] + legIK4[1] * legIK4[1]);
            legIK4[4] = Math.Sqrt((legIK4[3] - coxaLength)                         //3-CoxaFeetDist
                * (legIK4[3] - coxaLength) + legIK4[2] * legIK4[2]);               //4-IKSW
            legIK4[5] = Math.Atan((legIK4[3] - coxaLength) / legIK4[2]);           //5-IKA1
            legIK4[6] = Math.Acos((tibiaLength * tibiaLength - femurLength * femurLength
                - legIK4[4] * legIK4[4]) / (-2 * legIK4[4] * femurLength));         //6-IKA2
            legIK4[7] = Math.Acos((legIK4[4] * legIK4[4] - tibiaLength * tibiaLength
                - femurLength * femurLength) / (-2 * femurLength * tibiaLength));   //7-TAngle
            legIK4[8] = 90 - legIK4[7] * 180 / pi;                                  //8-IKTibiaAngle
            legIK4[9] = (legIK4[5] + legIK4[6]) * 180 / pi - 90;                    //9-IKFemurAngle
            legIK4[10] = Math.Atan2(legIK4[0], legIK4[1]) * 180 / pi;               //10-IKCoxaAngle

            legIK5[0] = newPosX[4] * Math.Cos(270 * pi / 180)
                - newPosZ[4] * Math.Sin(270 * pi / 180);                            //0-Transform X
            legIK5[1] = newPosX[4] * Math.Sin(270 * pi / 180)
                + newPosZ[4] * Math.Cos(270 * pi / 180);                            //1-Transform Z
            legIK5[2] = newPosY[4];                                                //2-Transform Y
            legIK5[3] = Math.Sqrt(legIK5[0] * legIK5[0] + legIK5[1] * legIK5[1]);
            legIK5[4] = Math.Sqrt((legIK5[3] - coxaLength)                         //3-CoxaFeetDist
                * (legIK5[3] - coxaLength) + legIK5[2] * legIK5[2]);               //4-IKSW
            legIK5[5] = Math.Atan((legIK5[3] - coxaLength) / legIK5[2]);           //5-IKA1
            legIK5[6] = Math.Acos((tibiaLength * tibiaLength - femurLength * femurLength
                - legIK5[4] * legIK5[4]) / (-2 * legIK5[4] * femurLength));         //6-IKA2
            legIK5[7] = Math.Acos((legIK5[4] * legIK5[4] - tibiaLength * tibiaLength
                - femurLength * femurLength) / (-2 * femurLength * tibiaLength));   //7-TAngle
            legIK5[8] = 90 - legIK5[7] * 180 / pi;                                  //8-IKTibiaAngle
            legIK5[9] = (legIK5[5] + legIK5[6]) * 180 / pi - 90;                    //9-IKFemurAngle
            legIK5[10] = Math.Atan2(legIK5[0], legIK5[1]) * 180 / pi;               //10-IKCoxaAngle

            legIK6[0] = newPosX[5] * Math.Cos(330 * pi / 180)
                - newPosZ[5] * Math.Sin(330 * pi / 180);                            //0-Transform X
            legIK6[1] = newPosX[5] * Math.Sin(330 * pi / 180)
                + newPosZ[5] * Math.Cos(330 * pi / 180);                            //1-Transform Z
            legIK6[2] = newPosY[5];                                                //2-Transform Y
            legIK6[3] = Math.Sqrt(legIK6[0] * legIK6[0] + legIK6[1] * legIK6[1]);
            legIK6[4] = Math.Sqrt((legIK6[3] - coxaLength)                         //3-CoxaFeetDist
                * (legIK6[3] - coxaLength) + legIK6[2] * legIK6[2]);               //4-IKSW
            legIK6[5] = Math.Atan((legIK6[3] - coxaLength) / legIK6[2]);           //5-IKA1
            legIK6[6] = Math.Acos((tibiaLength * tibiaLength - femurLength * femurLength
                - legIK6[4] * legIK6[4]) / (-2 * legIK6[4] * femurLength));         //6-IKA2
            legIK6[7] = Math.Acos((legIK6[4] * legIK6[4] - tibiaLength * tibiaLength
                - femurLength * femurLength) / (-2 * femurLength * tibiaLength));   //7-TAngle
            legIK6[8] = 90 - legIK6[7] * 180 / pi;                                  //8-IKTibiaAngle
            legIK6[9] = (legIK6[5] + legIK6[6]) * 180 / pi - 90;                    //9-IKFemurAngle
            legIK6[10] = Math.Atan2(legIK6[0], legIK6[1]) * 180 / pi;               //10-IKCoxaAngle
        }
    }
}
