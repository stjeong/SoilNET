using GameApp.Model;
using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    class Renderer
    {
        public void Prepare()
        {
            Gl.ClearColor(1, 0, 0, 1);
            Gl.Clear(ClearBufferMask.ColorBufferBit);
        }

        public void Render(TextureModel textureModel)
        {
            RawModel model = textureModel.RawModel;
            Gl.BindVertexArray(model.VaoID);
            Gl.EnableVertexAttribArray(0);
            Gl.EnableVertexAttribArray(1);

            Gl.ActiveTexture(TextureUnit.Texture0);
            Gl.BindTexture(TextureTarget.Texture2d, textureModel.Texture.ID);
            Gl.DrawElements(PrimitiveType.Triangles, model.VertexCount, DrawElementsType.UnsignedInt, IntPtr.Zero);

            Gl.DisableVertexAttribArray(0);
            Gl.DisableVertexAttribArray(1);
            Gl.BindVertexArray(0);
        }
    }
}
