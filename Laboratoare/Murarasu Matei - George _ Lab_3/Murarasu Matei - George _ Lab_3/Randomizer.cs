using System;
using System.Drawing;

namespace Murarasu_Matei___George___Lab_3
{
    class Randomizer
    {
        private Random rand;
        private int LOW_VALUE = -50;
        private int HIGH_VALUE = 50;
        public Randomizer()
        {
            rand = new Random();
        }
        public Color GenRandomColor()
        {
            int genR = rand.Next(0, 255);
            int genG = rand.Next(0, 255);
            int genB = rand.Next(0, 255);
            int genA = rand.Next(0, 255);
            Color color = Color.FromArgb(genR, genG, genB, genA);

            return color;
        }
        public int GenRandomInt()
        {
            int index = rand.Next(LOW_VALUE, HIGH_VALUE);
            return index;
        }
    }
}
