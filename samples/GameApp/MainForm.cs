using GameApp.Model;
using Khronos;
using OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameApp
{
    public partial class MainForm : Form
    {
        DisplayManager _displayManager = new DisplayManager();

        public MainForm()
        {
            InitializeComponent();
        }

        private void glControl_ContextCreated(object sender, OpenGL.GlControlEventArgs e)
        {
            GlControl glControl = (GlControl)sender;

            if (Gl.CurrentExtensions != null && Gl.CurrentExtensions.DebugOutput_ARB)
            {
                Gl.DebugMessageCallback(GLDebugMessageCallbackProc, null);
                Gl.DebugMessageControl(Gl.DebugSource.DontCare, Gl.DebugType.DontCare, Gl.DebugSeverity.DontCare, 0, null, true);
            }

            _displayManager.createDisplay(Gl.CurrentVersion);

            if (Gl.CurrentVersion != null && Gl.CurrentVersion.Api == KhronosVersion.ApiGl && glControl.MultisampleBits > 0)
            {
                Gl.Enable(EnableCap.Multisample);
            }

            bool result = Soil.NET.WrapSOIL.Initialize();
            if (result == false)
            {
                MessageBox.Show("SOIL: Not initialized: " + Soil.NET.WrapSOIL.GetSoilLastError());
                return;
            }

            _model = _loader.loadToVAO(_vertices, _textureCoords, _indices);
            _texture = new ModelTexture(_loader.loadTexture("image"));
            _textureModel = new TextureModel(_model, _texture);
            _shader = new StaticShader();
        }

        private void GLDebugMessageCallbackProc(Gl.DebugSource source, Gl.DebugType type, uint id, Gl.DebugSeverity severity, int length, IntPtr message, IntPtr userParam)
        {
            string strMessage;

            unsafe
            {
                strMessage = Encoding.ASCII.GetString((byte*)message.ToPointer(), length);
            }

            Console.WriteLine($"{source}, {type}, {severity}: {strMessage}");
        }

        private void glControl_ContextUpdate(object sender, GlControlEventArgs e)
        {
        }

        private void glControl_ContextDestroying(object sender, GlControlEventArgs e)
        {
            _loader.CleanUp();
            _shader.CleanUp();
        }

        private void glControl_Render(object sender, OpenGL.GlControlEventArgs e)
        {
            Control senderControl = (Control)sender;
            Gl.Viewport(0, 0, senderControl.ClientSize.Width, senderControl.ClientSize.Height);

            _renderer.Prepare();
            _shader.Start();
            _renderer.Render(_textureModel);
            _shader.Stop();

            _displayManager.updateDisplay();
        }

        RawModel _model;
        Loader _loader = new Loader();
        Renderer _renderer = new Renderer();
        StaticShader _shader;

        ModelTexture _texture;
        TextureModel _textureModel;

        float[] _vertices =
        {
            -0.5f, 0.5f, 0f,   // V0
            -0.5f, -0.5f, 0f,  // V1
            0.5f, -0.5f, 0f,   // V2
            0.5f, 0.5f, 0f   // V3
        };

        int[] _indices =
        {
            0, 1, 3,  // Top left triangle (V0, V1, V3)
            3, 1, 2   // Bottom right triangle (V3, V1, V2)
        };

        float[] _textureCoords =
        {
            0,0, // V0
            0,1, // V1
            1,1, // V2
            1,0, // V3
        };
    }
}
