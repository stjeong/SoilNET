using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static unsafe void Main(string [] args)
        {
            if (args.Length > 0)
            {
                string envDebug = args[0];
                if (envDebug == "DEBUG=GL")
                {
                    KhronosApi.Log += delegate (object sender, Khronos.KhronosLogEventArgs e)
                    {
                        Console.WriteLine(e.ToString());
                    };
                    KhronosApi.LogEnabled = true;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
