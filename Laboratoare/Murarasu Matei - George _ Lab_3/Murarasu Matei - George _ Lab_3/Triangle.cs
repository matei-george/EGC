using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Murarasu_Matei___George___Lab_3
{
    class Triangle
    {
        
        private Vector3 pointA;
        private Vector3 pointB;
        private Vector3 pointC;
        private Color color;
        private float size;
        private float Default_Size = 1.0f;
        public Triangle(Randomizer random)
        {

            // Incercare de citire coordonate din Fisier.
            /*foreach (string line in System.IO.File.ReadLines(@"D:\Programare\EGC\Laboratoare\Murarasu Matei - George _ Lab_3\Murarasu Matei - George _ Lab_3\Fisier.txt"))
            {
                pointA = new Vector3(float.Parse(line));
                pointB = new Vector3(float.Parse(line));
                pointB = new Vector3(float.Parse(line));

            }*/

            pointA = new Vector3(5, 1, 3);
            pointB = new Vector3(8, 4, 2);
            pointC = new Vector3(2, 6, 5);
            size = Default_Size;
            color=random.GenRandomColor();
        }
        public void DrawShape()
        {
            // Laborator_3 :: Cerinta nr_9

            GL.LineWidth(3.0f);
            GL.Begin(PrimitiveType.LineLoop);
            
            GL.Vertex3(pointA);
            GL.Color4(color);
            Console.WriteLine("Color for point A > " + color);
            
            GL.Vertex3(pointB);
            GL.Color4(color);
            Console.WriteLine("Color for point B > " + color);
            
            GL.Vertex3(pointC);
            GL.Color4(color);
            Console.WriteLine("Color for point C > " + color);

            GL.End();
        }
        public void SetColor(Randomizer random)
        {
            color = random.GenRandomColor();
        }
    }
}
