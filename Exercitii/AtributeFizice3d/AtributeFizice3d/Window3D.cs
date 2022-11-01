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
   class Window3D : GameWindow
    {
        private KeyboardState previousKeyboard;
        private MouseState previousMouse;
        private readonly Randomizer rando;
        private readonly Axes ax = new Axes();
        private readonly Grid grid = new Grid();
        private readonly Camera3DIsometric cam = new Camera3DIsometric();

        private readonly Color DEFAULT_BACKGROUND_COLOR = Color.FromArgb(49, 50, 51);

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
            KeyboardState currentkeyboard = Keyboard.GetState();
            MouseState currentmouse = Mouse.GetState();

            if (currentkeyboard[Key.Escape]) { Exit(); }
            if (currentkeyboard[Key.R] && !previousKeyboard[Key.R])
            {
                GL.ClearColor(DEFAULT_BACKGROUND_COLOR);
                ax.Show();
                grid.Show();
            }
            if (currentkeyboard[Key.K] && !previousKeyboard[Key.K]) { ax.ToggleVisibility(); }
            if (currentkeyboard[Key.B] && !previousKeyboard[Key.B]){ GL.ClearColor(rando.RandomColor()); }
            if (currentkeyboard[Key.V] && !previousKeyboard[Key.V]) { grid.ToggleVisibility(); }
            if (currentkeyboard[Key.W]) { cam.MoveForward(); }
            if (currentkeyboard[Key.A]) { cam.MoveLeft(); }
            if (currentkeyboard[Key.S]) { cam.MoveBackward(); }
            if (currentkeyboard[Key.D]) { cam.MoveRight(); }
            if (currentkeyboard[Key.Q]) { cam.MoveUp(); }
            if (currentkeyboard[Key.E]) { cam.MoveDown(); }


            previousKeyboard = currentkeyboard;
            previousMouse = currentmouse;

        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            ax.Draw();

            Objectoid obj = new Objectoid();
            obj.Draw();

            SwapBuffers();
        }
    }
}
