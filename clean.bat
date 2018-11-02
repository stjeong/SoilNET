FOR /F %%I IN ("%0") DO SET CURRENTDIR=%%~dpI
SET SOLUTIONDIR=%CURRENTDIR%

rmdir /q /s %SOLUTIONDIR%\nuget_package
rmdir /q /s %SOLUTIONDIR%\nuget_package

rmdir /q /s %SOLUTIONDIR%\Output
rmdir /q /s %SOLUTIONDIR%\Output

rmdir /q /s %SOLUTIONDIR%\Debug
rmdir /q /s %SOLUTIONDIR%\Release
rmdir /q /s %SOLUTIONDIR%\x64
rmdir /q /s %SOLUTIONDIR%\x64

rmdir /q /s %SOLUTIONDIR%\projects\SOIL\Debug
rmdir /q /s %SOLUTIONDIR%\projects\SOIL\Release
rmdir /q /s %SOLUTIONDIR%\projects\SOIL\x64
rmdir /q /s %SOLUTIONDIR%\projects\SOIL\x64

rmdir /q /s %SOLUTIONDIR%\projects\SoilProxy\Debug
rmdir /q /s %SOLUTIONDIR%\projects\SoilProxy\Release
rmdir /q /s %SOLUTIONDIR%\projects\SoilProxy\x64
rmdir /q /s %SOLUTIONDIR%\projects\SoilProxy\x64

rmdir /q /s %SOLUTIONDIR%\projects\Soil.NETCore\bin
rmdir /q /s %SOLUTIONDIR%\projects\Soil.NETCore\obj
rmdir /q /s %SOLUTIONDIR%\projects\Soil.NETCore\bin
rmdir /q /s %SOLUTIONDIR%\projects\Soil.NETCore\obj

rmdir /q /s %SOLUTIONDIR%\projects\Soil.NetFX4\bin
rmdir /q /s %SOLUTIONDIR%\projects\Soil.NetFX4\obj
rmdir /q /s %SOLUTIONDIR%\projects\Soil.NetFX4\bin
rmdir /q /s %SOLUTIONDIR%\projects\Soil.NetFX4\obj