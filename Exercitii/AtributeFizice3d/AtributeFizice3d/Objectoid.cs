using OpenTK;
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
     class Objectoid
    {
        private bool visibility;
        private bool isGravityBound;
        private Color colour;
        private Randomizer rando;
        private List<Vector3> coordList;

        private const int GRAVITY_OFFSET = 1;

        public Objectoid()
        {
            rando = new Randomizer();

            visibility = true;
            colour = rando.RandomColor();
            coordList = new List<Vector3>();
            int size_offset = rando.randomInt(3,7);
            int height_offset = rando.randomInt(40, 60);
            int radial_offset = rando.randomInt(5, 15);

            coordList.Add(new Vector3(0 * size_offset + radial_offset, 0 * size_offset + height_offset, 1 * size_offset + radial_offset));
            coordList.Add(new Vector3(0 * size_offset + radial_offset, 0 * size_offset + height_offset, 0 * size_offset + radial_offset));
            coordList.Add(new Vector3(1 * size_offset + radial_offset, 0 * size_offset + height_offset, 1 * size_offset + radial_offset));
            coordList.Add(new Vector3(1 * size_offset + radial_offset, 0 * size_offset + height_offset, 0 * size_offset + radial_offset));
            coordList.Add(new Vector3(1 * size_offset + radial_offset, 1 * size_offset + height_offset, 1 * size_offset + radial_offset));
            coordList.Add(new Vector3(1 * size_offset + radial_offset, 1 * size_offset + height_offset, 0 * size_offset + radial_offset));
            coordList.Add(new Vector3(0 * size_offset + radial_offset, 1 * size_offset + height_offset, 1 * size_offset + radial_offset));
            coordList.Add(new Vector3(0 * size_offset + radial_offset, 1 * size_offset + height_offset, 0 * size_offset + radial_offset));
        }
        public void Draw()
        {
            GL.Color3(colour);
            GL.Begin(PrimitiveType.QuadStrip);
            foreach(Vector3 v in coordList)
            {
                GL.Vertex3(v);
            }
            GL.End();
        }
        public void ToggleVisibility()
        {
            visibility = !visibility;
        }
        public void ToggleGravity()
        {
            isGravityBound = !isGravityBound;
        }
        public void setGravity()
        {
            isGravityBound = true;
        }
        public void unsetGravity()
        {
            isGravityBound = false;
        }
    }
}
