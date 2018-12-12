What is it?
================================

SOIL is a tiny C library used primarily for uploading textures into OpenGL. You can get original source codes at [https://www.lonesock.net/soil.html](https://www.lonesock.net/soil.html)

However, SOIL doesn't provide any library for .NET Framework, then SoilNET repo is created for providing bindings for .NET Framework based on SOIL.

Supported environments

    * .NET Framework 4 or later
    * .NET Standard 2 or later

Currently, I just need "SOIL_load_OGL_texture" function only, so this function is implemeneted in SoilNET. IF you need other functions open an issue at [https://github.com/stjeong/SoilNET/issues](https://github.com/stjeong/SoilNET/issues), then I'll provide it and publish to NuGet repo. (Or pull requests are always welcome.)

How to install
================================


```
Install-Package SoilDotnet
```

How to use
================================

See /samples/GameApp.csproj.

```
// glControl_ContextCreated at MainForm.cs

private void glControl_ContextCreated(object sender, OpenGL.GlControlEventArgs e)
{
    // ...[omitted for brevity]...

    bool result = Soil.NET.WrapSOIL.Initialize();
    if (result == false)
    {
        MessageBox.Show("SOIL: Not initialized: " + Soil.NET.WrapSOIL.GetSoilLastError());
        return;
    }

    // ...[omitted for brevity]...
}
```

```
// loadTexture at Loader.cs

public uint loadTexture(string fileName)
{
    string filePath = $".\\res\\{fileName}.png";

    uint tex2d_id = Soil.NET.WrapSOIL.load_OGL_texture(filePath,
        Soil.NET.WrapSOIL.SOIL_LOAD.AUTO, Soil.NET.WrapSOIL.SOIL_NEW.ID,
        Soil.NET.WrapSOIL.SOIL_FLAG.MIPMAPS | Soil.NET.WrapSOIL.SOIL_FLAG.INVERT_Y | 
        Soil.NET.WrapSOIL.SOIL_FLAG.NTSC_SAFE_RGB | Soil.NET.WrapSOIL.SOIL_FLAG.COMPRESS_TO_DXT);

    _textures.Add(tex2d_id);
    return tex2d_id;
}
```


How to build
================================
If you want to make binaries from this project, just load and compile in Visual Studio 2017, or run build.bat in "Developer Command Prompt for VS 2017".


Change Log
================================

1.0.3 - Dec 12, 2018

* Add check code whether opengl context is created.

1.0.2 - Dec 12, 2018

* Fixed: bug in GameApp sample code
 
1.0.1 - Nov 02, 2018

* No changes for binaries.

1.0.0 - Nov 02, 2018

* Initial checked-in


Reqeuests or Contributing to Repository
================================
If you need some features or whatever, make an issue at [https://github.com/stjeong/SoilNET/issues](https://github.com/stjeong/SoilNET/issues)

Any help and advices for this repo are welcome.

License
================================
Apache License V2.0

(Refer to LICENSE.txt)