using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bug
{
    class FeetPosition : RobotGeometry
    {
        //feet position
        public double[] feetPositionLeg1 = new double[3];
        public double[] feetPositionLeg2 = new double[3];
        public double[] feetPositionLeg3 = new double[3];
        public double[] feetPositionLeg4 = new double[3];
        public double[] feetPositionLeg5 = new double[3];
        public double[] feetPositionLeg6 = new double[3];

        public void feetPosition()
        {
            feetPositionLeg1[0] = Math.Cos(60 * pi / 180) * (coxaLength + femurLength);
            feetPositionLeg1[1] = tibiaLength;
            feetPositionLeg1[2] = Math.Sin(60 * pi / 180) * (coxaLength + femurLength);

            feetPositionLeg2[0] = coxaLength + femurLength;
            feetPositionLeg2[1] = tibiaLength;
            feetPositionLeg2[2] = 0;

            feetPositionLeg3[0] = feetPositionLeg1[0];
            feetPositionLeg3[1] = tibiaLength;
            feetPositionLeg3[2] = Math.Sin(-60 * pi / 180) * (coxaLength + femurLength);

            feetPositionLeg4[0] = -feetPositionLeg1[0];
            feetPositionLeg4[1] = tibiaLength;
            feetPositionLeg4[2] = feetPositionLeg3[2];

            feetPositionLeg5[0] = -feetPositionLeg2[0];
            feetPositionLeg5[1] = tibiaLength;
            feetPositionLeg5[2] = 0;

            feetPositionLeg6[0] = -feetPositionLeg1[0];
            feetPositionLeg6[1] = tibiaLength;
            feetPositionLeg6[2] = feetPositionLeg1[2];
        }
    }
}
