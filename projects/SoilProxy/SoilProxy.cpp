// SoilDLL.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "..\\..\\src\\soil.h"

extern "C"
{
    __declspec(dllexport) int __stdcall GetSoilLastError();
    __declspec(dllexport) int __stdcall Initialize(wchar_t *openglDLLFileName);
    __declspec(dllexport) int __stdcall Uninitialize();
    __declspec(dllexport) unsigned int __stdcall load_OGL_texture(const char *filename, int force_channels, unsigned int reuse_texture_ID, unsigned int flags);
};

__declspec(dllexport) int __stdcall GetSoilLastError()
{
    return SOIL_GetLastError();
}

__declspec(dllexport) int __stdcall Initialize(wchar_t *openglDLLFileName)
{
    return SOIL_Initialize(openglDLLFileName);
}

__declspec(dllexport) int __stdcall Uninitialize()
{
    return SOIL_Uninitialize();
}

__declspec(dllexport) unsigned int __stdcall load_OGL_texture(const char *filename, int force_channels, unsigned int reuse_texture_ID, unsigned int flags)
{
    return SOIL_load_OGL_texture(filename, force_channels, reuse_texture_ID, flags);
}