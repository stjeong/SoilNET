using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    class OpenGLExtension
    {
        public static string GetShaderInfoLog(uint shaderId, int maxLength = 1024)
        {
            int length = 0;
            StringBuilder sb = new StringBuilder(maxLength);
            Gl.GetShaderInfoLog(shaderId, maxLength, out length, sb);

            return sb.ToString();
        }
    }
}
