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
        public double[,] feetPositionLegs = new double[6,3];

        public FeetPosition()
        {
        }

        public FeetPosition(double bodySideLength, double coxaLength, double femurLength, double tibiaLength)
        {
            this.bodySideLength = bodySideLength;
            this.coxaLength = coxaLength;
            this.femurLength = femurLength;
            this.tibiaLength = tibiaLength;
        }
        public void feetPosition()
        {
            feetPositionLegs[0, 0] = Math.Cos(60 * pi / 180) * (coxaLength + femurLength);
            feetPositionLegs[0, 1] = tibiaLength;
            feetPositionLegs[0, 2] = Math.Sin(60 * pi / 180) * (coxaLength + femurLength);

            feetPositionLegs[1,0] = coxaLength + femurLength;
            feetPositionLegs[1,1] = tibiaLength;
            feetPositionLegs[1,2] = 0;

            feetPositionLegs[2,0] = feetPositionLegs[0,0];
            feetPositionLegs[2,1] = tibiaLength;
            feetPositionLegs[2,2] = Math.Sin(-60 * pi / 180) * (coxaLength + femurLength);

            feetPositionLegs[3,0] = -feetPositionLegs[0,0];
            feetPositionLegs[3,1] = tibiaLength;
            feetPositionLegs[3,2] = feetPositionLegs[2,2];

            feetPositionLegs[4,0] = -feetPositionLegs[1,0];
            feetPositionLegs[4,1] = tibiaLength;
            feetPositionLegs[5,2] = 0;

            feetPositionLegs[5,0] = -feetPositionLegs[0,0];
            feetPositionLegs[5,1] = tibiaLength;
            feetPositionLegs[5,2] = feetPositionLegs[0,2]; 
        }

        public double[,] returnFP()
        {
            return feetPositionLegs;
        }
    }
}
