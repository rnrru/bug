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
        }
    }
}
