using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pregatire_Test
{
    class Program:GameWindow
    {
        [STAThread]
        public static void Main(String[] args)
        {
            Window3D window = new Window3D();
            window.Run(144, 144);
        }
    }
}
