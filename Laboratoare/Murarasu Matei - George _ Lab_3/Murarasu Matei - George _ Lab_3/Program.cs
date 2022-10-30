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
// TODO
// > La apasarea unui set de taste modificam culoarea triunghiului (coord in fisier text).[LEFT TODO]
// > Manipularea valorilor RGB pentru fiecare vertex definit + afisare valori in consola. [DONE]
namespace Murarasu_Matei___George___Lab_3
{
   class Program : GameWindow{
       
        [STAThread]
        static void Main(string[] args) {
            Window3D window3D = new Window3D();
            window3D.Run(30.0, 0.0);
        }
    }
}
