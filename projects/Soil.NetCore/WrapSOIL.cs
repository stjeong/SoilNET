using System;
using System.Runtime.InteropServices;

namespace Soil.NET
{
    public class WrapSOIL
    {
        [DllImport("SoilProxy32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetSoilLastError")]
        static extern int GetSoilLastError32();

        [DllImport("SoilProxy32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "Initialize")]
        static extern int Initialize32(string openglDllFileName);

        [DllImport("SoilProxy32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "Uninitialize")]
        static extern int Uninitialize32();

        [DllImport("SoilProxy32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "load_OGL_texture")]
        static extern uint load_OGL_texture32(string filename, SOIL_LOAD force_channels, SOIL_NEW reuse_texture_ID, SOIL_FLAG flags);



        [DllImport("SoilProxy64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetSoilLastError")]
        static extern int GetSoilLastError64();

        [DllImport("SoilProxy64.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "Initialize")]
        static extern int Initialize64(string openglDllFileName);

        [DllImport("SoilProxy64.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "Uninitialize")]
        static extern int Uninitialize64();

        [DllImport("SoilProxy64.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "load_OGL_texture")]
        static extern uint load_OGL_texture64(string filename, SOIL_LOAD force_channels, SOIL_NEW reuse_texture_ID, SOIL_FLAG flags);


        public static SOILErrorResult GetSoilLastError()
        {
            if (IntPtr.Size == 4)
            {
                return (SOILErrorResult)GetSoilLastError32();
            }

            return (SOILErrorResult)GetSoilLastError64();
        }

        public static bool Initialize(string openglDllFileName = "opengl32.dll")
        {
            if (IntPtr.Size == 4)
            {
                return Initialize32(openglDllFileName) == 1;
            }

            return Initialize64(openglDllFileName) == 1;
        }

        public static bool Uninitialize(string openglDllFileName)
        {
            if (IntPtr.Size == 4)
            {
                return Uninitialize32() == 1;
            }

            return Uninitialize64() == 1;
        }

        public static uint load_OGL_texture(string filename, SOIL_LOAD force_channels, SOIL_NEW reuse_texture_ID, SOIL_FLAG flags)
        {
            if (IntPtr.Size == 4)
            {
                return load_OGL_texture32(filename, force_channels, reuse_texture_ID, flags);
            }

            return load_OGL_texture64(filename, force_channels, reuse_texture_ID, flags);
        }

        public enum SOIL_LOAD
        {
            AUTO = 0,
            L,
            LA,
            RGB,
            RGBA
        }

        public enum SOIL_NEW : uint
        {
            ID = 0,
        }

        [Flags]
        public enum SOIL_FLAG : uint
        {
            POWER_OF_TWO = 1,
            MIPMAPS = 2,
            TEXTURE_REPEATS = 4,
            MULTIPLY_ALPHA = 8,
            INVERT_Y = 16,
            COMPRESS_TO_DXT = 32,
            DDS_LOAD_DIRECT = 64,
            NTSC_SAFE_RGB = 128,
            CoCg_Y = 256,
            TEXTURE_RECTANGLE = 512
        }

        public enum SOILErrorResult
        {
            SOIL_SUCCESS = 0,
            SOIL_ERROR_LOADLIBRARY = 1,
            SOIL_ERROR_GETPROCADDRESS = 2,
        }
    }
}
