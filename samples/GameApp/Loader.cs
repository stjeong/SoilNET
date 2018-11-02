using GameApp.Model;
using OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    class Loader
    {
        List<uint> _vaos = new List<uint>();
        List<uint> _vbos = new List<uint>();
        List<uint> _textures = new List<uint>();

        public RawModel loadToVAO(float [] positions, float [] textures, int[] indices)
        {
            uint vaoID = createVAO();

            bindIndicesBuffer(indices);
            storeDataInAttributeList(0, 3, positions);
            storeDataInAttributeList(1, 2, textures);

            unbindVAO();

            return new RawModel(vaoID, positions.Length);
        }

        public uint loadTexture(string fileName)
        {
            string filePath = $".\\res\\{fileName}.png";

            uint tex2d_id = Soil.NET.WrapSOIL.load_OGL_texture(filePath, Soil.NET.WrapSOIL.SOIL_LOAD.AUTO, Soil.NET.WrapSOIL.SOIL_NEW.ID,
                Soil.NET.WrapSOIL.SOIL_FLAG.MIPMAPS | Soil.NET.WrapSOIL.SOIL_FLAG.INVERT_Y | Soil.NET.WrapSOIL.SOIL_FLAG.NTSC_SAFE_RGB | Soil.NET.WrapSOIL.SOIL_FLAG.COMPRESS_TO_DXT);

            _textures.Add(tex2d_id);
            return tex2d_id;
        }

        public void CleanUp()
        {
            foreach (uint vao in _vaos)
            {
                Gl.DeleteVertexArrays(vao);
            }

            foreach (uint vbo in _vbos)
            {
                Gl.DeleteBuffers(vbo);
            }

            foreach (uint texture in _textures)
            {
                Gl.DeleteTextures(texture);
            }
        }

        uint createVAO()
        {
            uint vaoID = Gl.GenVertexArray();
            _vaos.Add(vaoID);
            Gl.BindVertexArray(vaoID);
            return vaoID;
        }

        unsafe void storeDataInAttributeList(uint attributeNumber, int coordinateSize, float [] data)
        {
            uint vboID = Gl.GenBuffer();
            _vbos.Add(vboID);
            Gl.BindBuffer(BufferTarget.ArrayBuffer, vboID);

            Gl.BufferData(BufferTarget.ArrayBuffer, (uint)(data.Length * sizeof(float)), data, BufferUsage.StaticDraw);

            Gl.VertexAttribPointer(attributeNumber, coordinateSize, VertexAttribType.Float, false, 0, IntPtr.Zero);
            Gl.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        int GetMaxVertexAttribs()
        {
            ulong[] values = new ulong[1];
            Gl.GetIntegerNV(Gl.MAX_VERTEX_ATTRIBS, values);

            return (int)values[0];
        }

        void unbindVAO()
        {
            Gl.BindVertexArray(0);
        }

        void bindIndicesBuffer(int[] indices)
        {
            uint vboID = Gl.GenBuffer();
            _vbos.Add(vboID);
            Gl.BindBuffer(BufferTarget.ElementArrayBuffer, vboID);

            Gl.BufferData(BufferTarget.ElementArrayBuffer, (uint)(indices.Length * sizeof(int)), indices, BufferUsage.StaticDraw);
        }
    }
}
