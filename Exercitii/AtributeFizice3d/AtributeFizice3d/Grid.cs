using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AtributeFizice3d
{
   class Grid
    {
        private readonly Color colorization;
        private bool visibility;

        private readonly Color GRIDCOLOR = Color.WhiteSmoke;
        private const int GRIDSTEP = 10;
        private const int UNITS = 50;
        private const int POINT_OFFSET = GRIDSTEP * UNITS;

        private const int MICRO_OFFSET = 0;

        public Grid()
        {
            colorization = GRIDCOLOR;
            visibility = true;
        }
        public void Show() { visibility = true; }
        public void Hide() { visibility = false; }

        public void ToggleVisibility() { visibility = !visibility; }
        public void Draw()
        {
            if (visibility)
            {
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(colorization);
                for(int i= -1*GRIDSTEP*UNITS; i<= GRIDSTEP*UNITS; i += GRIDSTEP)
                {
                    GL.Vertex3(i + MICRO_OFFSET, 0, POINT_OFFSET);
                    GL.Vertex3(i + MICRO_OFFSET, 0, -1 * POINT_OFFSET);
                }
            }
        }
    }
}
