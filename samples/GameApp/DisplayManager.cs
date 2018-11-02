using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameApp
{
    // OpenGL-Tutorial-1/src/renderEngine/DisplayManager.java
    // ; https://github.com/TheThinMatrix/OpenGL-Tutorial-1/blob/master/src/renderEngine/DisplayManager.java
    // ; https://www.youtube.com/watch?v=VS8wlS9hF8E
    public class DisplayManager
    {
        Khronos.KhronosVersion _version;

        public void createDisplay(Khronos.KhronosVersion version)
        {
            _version = version;
        }

        public unsafe void updateDisplay()
        {
        }

        public void closeDisplay()
        {
        }
    }
}
