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
        public double bodySideLength;    //Длина тела 
        public double coxaLength;             
        public double femurLength;
        public double tibiaLength;


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

        public double[] returnRG()
        {
            double[] robotG = new double[4];
            robotG[0] = bodySideLength;
            robotG[1] = coxaLength;
            robotG[2] = femurLength;
            robotG[3] = tibiaLength;
                return robotG;
        }
    }

}
