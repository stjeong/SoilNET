using OpenGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    public abstract class ShaderProgram
    {
        uint _programID;
        uint _vertexShaderID;
        uint _fragmentShaderID;

        public ShaderProgram(string vertexFile, string fragmentFile)
        {
            _vertexShaderID = loadShader(vertexFile, ShaderType.VertexShader);
            _fragmentShaderID = loadShader(fragmentFile, ShaderType.FragmentShader);

            _programID = Gl.CreateProgram();
            Gl.AttachShader(_programID, _vertexShaderID);
            Gl.AttachShader(_programID, _fragmentShaderID);

            Gl.LinkProgram(_programID);
            Gl.ValidateProgram(_programID);

            bindAttributes();
        }

        public void Start()
        {
            Gl.UseProgram(_programID);
        }

        public void Stop()
        {
            Gl.UseProgram(0);
        }

        public void CleanUp()
        {
            Stop();
            Gl.DetachShader(_programID, _vertexShaderID);
            Gl.DetachShader(_programID, _fragmentShaderID);
            Gl.DeleteShader(_vertexShaderID);
            Gl.DeleteShader(_fragmentShaderID);
            Gl.DeleteProgram(_programID);
        }

        protected abstract void bindAttributes();

        protected void bindAttribute(uint attribute, string variableName)
        {
            Gl.BindAttribLocation(_programID, attribute, variableName);
        }

        static uint loadShader(string file, ShaderType type)
        {
            string[] codeText = ReadShaderCode(file);
            uint shaderID = Gl.CreateShader(type);

            Gl.ShaderSource(shaderID, codeText);
            Gl.CompileShader(shaderID);

            int compileResult = Gl.FALSE;
            Gl.GetShader(shaderID, ShaderParameterName.CompileStatus, out compileResult);

            if (compileResult == Gl.FALSE)
            {
                throw new InvalidDataException(OpenGLExtension.GetShaderInfoLog(shaderID));
            }

            return shaderID;
        }

        private static string[] ReadShaderCode(string file)
        {
            List<string> codes = new List<string>();

            foreach (string txt in File.ReadAllLines(file))
            {
                codes.Add(txt + Environment.NewLine);
            }

            return codes.ToArray();
        }
    }
}
