using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    public class StaticShader : ShaderProgram
    {
        const string VERTEX_FILE = "./shaders/vertexShader.txt";
        const string FRAGMENT_FILE = "./shaders/fragmentShader.txt";

        public StaticShader() : base(VERTEX_FILE, FRAGMENT_FILE)
        {
        }

        protected override void bindAttributes()
        {
            base.bindAttribute(0, "position");
            base.bindAttribute(1, "textureCoords");
        }
    }
}
