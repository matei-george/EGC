﻿using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AtributeFizice3d
{
    class Randomizer
    {
        private Random r;

        private const int LOW_INT_VAL = -25;    
        private const int HIGH_INT_VAL = 25;
        private const int LOW_COORD_VAL = -50;
        private const int HIGH_COORD_VAL = 50;
        
        public Randomizer() { r = new Random(); }

        public Color RandomColor()
        {
            int genR = r.Next(0, 255);
            int genG = r.Next(0, 255);
            int genB = r.Next(0, 255);

            Color col=Color.FromArgb(genR,genG,genB);
            return col;
        }

        public Vector3 Random3DPoint()
        {
            int genA = r.Next(LOW_COORD_VAL, HIGH_COORD_VAL);
            int genB = r.Next(LOW_COORD_VAL, HIGH_COORD_VAL);
            int genC = r.Next(LOW_COORD_VAL, HIGH_COORD_VAL);

            Vector3 vec = new Vector3(genA, genB, genC);
            return vec;
        }
        public int randomInt()
        {
            int i = r.Next(LOW_INT_VAL, HIGH_INT_VAL);
            return i;
        }
        public int randomInt(int minval,int maxval)
        {
            int i = r.Next(minval,maxval);
            return i;
        }
        public int randomInt(int maxval)
        {
            int i = r.Next(maxval);
            return i;
        }
    }
}
