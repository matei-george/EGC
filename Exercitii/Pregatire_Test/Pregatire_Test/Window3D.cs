using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

// > TODO : 
//          - program de baza cu implementare [  ]
//          - diferite forme cu diferite culori, eventual gradient [  ]

namespace Pregatire_Test
{
    class Window3D : GameWindow
    {
        public Window3D() : base(800, 600, new GraphicsMode(256, 64, 8, 128)) {
            VSync = VSyncMode.On;

            Console.WriteLine("OpenGL v." + GL.GetString(StringName.Version));
            Title = "Aplicatii cu versiunea de OpenGL " + GL.GetString(StringName.Version);
        } 
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color4.FloralWhite);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PointSmoothHint, HintMode.Nicest);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
            float aRatio = Width / Height;

            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aRatio, 1, 512);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);

            Matrix4 eye = Matrix4.LookAt(10, 10, 10, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref eye);

        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

           
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e); 

            GL.Clear(ClearBufferMask.DepthBufferBit);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            SwapBuffers();
        }
    }

}
