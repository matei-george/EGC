using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtributeFizice3d
{
   class Program:GameWindow
    {
        [STAThread]
        static void Main(String[] args)
        {
            Window3D window3d = new Window3D();
            window3d.Run(30.0, 0.0);
        }
    }
}
