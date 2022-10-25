using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Murarasu_Matei___George___Lab_3
{
    class Window3D : GameWindow
    {
        public Window3D() : base(800, 600, new GraphicsMode(256, 64, 0, 64))
        {
            VSync = VSyncMode.On;

            Console.WriteLine("OpenGL v." + GL.GetString(StringName.Version));
            Title = "OpenGL v." + GL.GetString(StringName.Version) + " tema laborator 3";
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color4.Azure);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
            float AspectRatio = Width / Height;

            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, AspectRatio, 1, 256);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);

            Matrix4 lookat = Matrix4.LookAt(40, 40, 40, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState tastatura = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            if (tastatura[Key.Escape])
            {
                Exit();
            }

        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            DrawLineAxes();
            DrawEntities();
            DrawLines();

            SwapBuffers();
        }
        // Laborator_3 :: Cerinta nr_1
        void DrawLineAxes()
        {
            //Desenam axele de coordonate in 3 culori 
            GL.Begin(PrimitiveType.Lines);
            GL.Color4(Color4.Crimson);
            // Reprezentam axa OX
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(60, 0, 0);
            // Reprezentam axa OY
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 60, 0);
            // Reprezentam axa OZ
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 60);
            GL.End();
        }
        // Laborator_3 :: Cerinta nr_3
        void DrawEntities()
        {
            // GL.LineWidth(4.0f) > Modificarea latimii liniei randate pe 
            // GL.PointSize(50.0f); > Modificarea dimensiunii punctului randat pe ecran.
            // Reprezentam un obiect de tip linie
            GL.Begin(PrimitiveType.Lines);
            GL.Color4(Color4.SkyBlue);
            GL.Vertex3(1, 1, 1);
            GL.Vertex3(2, 4, 2);
            GL.End();
        }
        // Laborator_3 :: Cerinta nr_4
        void DrawLines()
        {
            GL.LineWidth(3.0f);
            // Utilizand LineLoop
            GL.Begin(PrimitiveType.LineLoop);
            GL.Color4(Color4.Green);
            GL.Vertex3(3, 4, 5);
            GL.Vertex3(5, 7, 10);
            GL.Vertex3(2, 8, 5);
            GL.Vertex3(2, 7, 9);
            GL.End();

            // Utilizand LineStrip
            GL.Begin(PrimitiveType.LineStrip);
            GL.Color4(Color4.Yellow);
            GL.Vertex3(3, 6, 0);
            GL.Color4(Color4.Crimson);
            GL.Vertex3(4, 1, 3);
            GL.Color4(Color4.Violet);
            GL.Vertex3(2, 5, 1);
            GL.End();

            // Utilizand TriangleStrip
            GL.Begin(PrimitiveType.TriangleStrip);
            GL.Color4(Color4.CadetBlue);
            GL.Vertex3(15, 6, 3);
            GL.Vertex3(11, 6, 3);
            GL.Vertex3(14, 6, 3);
            GL.Color4(Color4.Crimson);
            GL.Vertex3(13, 8, 3);
            GL.Vertex3(14, 8, 3);
            GL.Vertex3(12, 8, 3);
            GL.Color4(Color4.DarkGoldenrod);
            GL.Vertex3(13, 10, 3);
            GL.Vertex3(14, 10, 3);
            GL.Vertex3(12, 10, 3);
            GL.End();

            // Utilizand TriangleFan
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Color4(Color4.CadetBlue);
            GL.Vertex3(25, 6, 3);
            GL.Vertex3(21, 6, 3);
            GL.Vertex3(24, 6, 3);
            GL.Color4(Color4.Crimson);
            GL.Vertex3(23, 8, 3);
            GL.Vertex3(24, 8, 3);
            GL.Vertex3(22, 8, 3);
            GL.Color4(Color4.DarkGoldenrod);
            GL.Vertex3(23, 10, 3);
            GL.Vertex3(24, 10, 3);
            GL.Vertex3(22, 10, 3);
            GL.End();
        }
    }
}
