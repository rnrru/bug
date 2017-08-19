using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bug
{
    class RobotGeometry
    {
        public double pi = 3.14159;
        //Robot Geometry
        public double bodySideLength = 45.0;
        public double coxaLength = 12.0;
        public double femurLength = 35.0;
        public double tibiaLength = 72.0;

        //feet position
        public double[] feetPositionLeg1 = new double[3];
        public double[] feetPositionLeg2 = new double[3];
        public double[] feetPositionLeg3 = new double[3];
        public double[] feetPositionLeg4 = new double[3];
        public double[] feetPositionLeg5 = new double[3];
        public double[] feetPositionLeg6 = new double[3];

        public RobotGeometry()
        {

        }
        public RobotGeometry(double bodySideLength, double coxaLength, double femurLength, double tibiaLength)
        {
            this.bodySideLength = bodySideLength;
            this.coxaLength = coxaLength;
            this.femurLength = femurLength;
            this.tibiaLength = tibiaLength;
        }

    }

}
