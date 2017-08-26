﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bug
{
    class LegIK : BodyIK
    {
        double[,] legIKs = new double[6, 11];

        public LegIK()
        { }

        public LegIK(double bodySideLength, double coxaLength, double femurLength, double tibiaLength)
        {
            this.bodySideLength = bodySideLength;
            this.coxaLength = coxaLength;
            this.femurLength = femurLength;
            this.tibiaLength = tibiaLength;
        }

        public void legIK(double[] newPosX, double[] newPosY, double[] newPosZ)
        {
            for (int i = 0; i < 6; i++)
            {
                legIKs[i, 0] = newPosX[0] * Math.Cos(30 * pi / 180)
                                - newPosZ[0] * Math.Sin(30 * pi / 180);
                legIKs[i, 1] = newPosX[0] * Math.Sin(30 * pi / 180)
                                + newPosZ[0] * Math.Cos(30 * pi / 180);                             
                legIKs[i, 2] = newPosY[0];                                                 
                legIKs[i, 3] = Math.Sqrt(legIKs[i, 0] * legIKs[i, 0] + legIKs[i, 1] * legIKs[i, 1]);
                legIKs[i, 4] = Math.Sqrt((legIKs[i, 3] - coxaLength)                          
                                * (legIKs[i, 3] - coxaLength) + legIKs[i, 2] * legIKs[i, 2]);                
                legIKs[i, 5] = Math.Atan((legIKs[i, 3] - coxaLength) / legIKs[i, 2]);            
                legIKs[i, 6] = Math.Acos((tibiaLength * tibiaLength - femurLength * femurLength
                                - legIKs[i, 4] * legIKs[i, 4]) / (-2 * legIKs[i, 4] * femurLength));         
                legIKs[i, 7] = Math.Acos((legIKs[i, 4] * legIKs[i, 4] - tibiaLength * tibiaLength
                                - femurLength * femurLength) / (-2 * femurLength * tibiaLength));   
                legIKs[i, 8] = 90 - legIKs[i, 7] * 180 / pi;                                  
                legIKs[i, 9] = (legIKs[i, 5] + legIKs[i, 6]) * 180 / pi - 90;                    
                legIKs[i, 10] = Math.Atan2(legIKs[i, 0], legIKs[i, 1]) * 180 / pi;               
            }
        }
    }
}