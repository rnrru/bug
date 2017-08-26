using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bug
{
    class BodyCenterOffset : RobotGeometry
    {
        double[] bodyCenterOffsetX = new double[6];
        double[] bodyCenterOffsetY = new double[6];

        List<double> bodyCenterOffsetsX = new List<double>();
        List<double> bodyCenterOffsetsY = new List<double>();

        double bodySideLength;

        double bodyCenterOffset1;       //bodyCenterOffsetX
        double bodyCenterOffset2;       //bodyCenterOffsetZ
        public BodyCenterOffset()
        {
        }
        public BodyCenterOffset(double bodySideLength)
        {
            this.bodySideLength = bodySideLength;
        }

        public void bodyCenterOffset(double bodySideLength)
        {
            this.bodySideLength = bodySideLength;

            bodyCenterOffset1 = bodySideLength / 2;
            bodyCenterOffset2 = Math.Sqrt(bodySideLength * bodySideLength 
                                - bodyCenterOffset1 * bodyCenterOffset1);
                       
            bodyCenterOffsetX[0] = bodyCenterOffset1;
            bodyCenterOffsetX[1] = bodySideLength;
            bodyCenterOffsetX[2] = bodyCenterOffset1;
            bodyCenterOffsetX[3] = -bodyCenterOffset1;
            bodyCenterOffsetX[4] = -bodySideLength;
            bodyCenterOffsetX[5] = -bodyCenterOffset1;

            bodyCenterOffsetY[0] = bodyCenterOffset2;
            bodyCenterOffsetY[1] = 0;
            bodyCenterOffsetY[2] = -bodyCenterOffset2;
            bodyCenterOffsetY[3] = -bodyCenterOffset2;
            bodyCenterOffsetY[4] = 0;
            bodyCenterOffsetY[5] = bodyCenterOffset2;                  
        }

        public List<double> putBodyOffsetsX()
        {
            for (int i = 0; i < 6; i++)
            {
                bodyCenterOffsetsX.Add(bodyCenterOffsetX[i]);
            }
            
            return bodyCenterOffsetsX;
        }

        public List<double> putBodyOffsetsY()
        {
            for (int i = 0; i < 6; i++)
            {
                bodyCenterOffsetsY.Add(bodyCenterOffsetY[i]);
            }

            return bodyCenterOffsetsY;
        }
    }
}
