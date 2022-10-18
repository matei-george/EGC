using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Tema_Laborator_3
{

    class Aplicatie : GameWindow
    {
        public Aplicatie() : base(800, 600, new GraphicsMode(32, 24, 0, 16))
        {
            VSync = VSyncMode.On;

            Console.WriteLine("OpenGl versiunea: " + GL.GetString(StringName.Version));
            Title = "OpenGl versiunea: " + GL.GetString(StringName.Version) + " Prima Aplicatie";

        }
        protected override void OnLoad(EventArgs e) //> Se executa doar o singura data.
        {
            base.OnLoad(e);
            GL.ClearColor(Color.Beige);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);

            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Width / Height, 1, 128);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);

            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState tastatura = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            if (tastatura[Key.Escape]) //> Inchidere aplicatie cu ajutorul Escape
            {
                Exit();
            }
            if (mouse.Y > 250) //> Rotirea obiectelor prin pozitionarea mouse-ului
            {
                GL.Rotate(5, 0, 1, 0);
            }
            if (mouse.X > 250) //> Rotirea obiectelor prin pozitionarea mouse-ului
            {
                GL.Rotate(5, 0, -1, 1);
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            DrawAxes();
            SwapBuffers();
        }
        private void DrawAxes()
        {
            KeyboardState tastatura = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            GL.LineWidth(5.0f);

            // Desenam cateva figuri geometrice

            //Triunghi de culoare Crimson Red
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(Color.Crimson);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(2, 4, 8);
            GL.Vertex3(5, 8, 10);
            GL.End();

            //Quad de Culoare Cyan
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.Cyan);
            GL.Vertex3(10, 4, 5);
            GL.Vertex3(20, 4, 6);
            GL.Vertex3(26, 8, 4);
            GL.Vertex3(5, 5, 1);
            GL.End();

            // Realizam controlul obiectelor cu ajutorul tastelor
            if (tastatura[Key.W] && tastatura[Key.A]) //> Inchidere aplicatie cu ajutorul Escape+Enter
            {
                GL.Begin(PrimitiveType.Quads);
                GL.Color3(Color.Chocolate);
                GL.Vertex3(20, 4, 5);
                GL.Vertex3(30, 4, 6);
                GL.Vertex3(46, 8, 4);
                GL.Vertex3(5, 5, 1);
                GL.End();
            }
            if (mouse.X > 500 || mouse.Y > 500)
            {
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(Color.DarkSeaGreen);
                GL.Vertex3(4, 0, 0);
                GL.Vertex3(6, 4, 8);
                GL.Vertex3(8, 8, 10);
                GL.End();
            }
        }
        [STAThread]
        static void Main(string[] args)
        {
            using (Aplicatie appExemplu = new Aplicatie())
            {
                appExemplu.Run(30.0, 0.0);
            }
        }
    }
}