FOR /F %%I IN ("%0") DO SET CURRENTDIR=%%~dpI
SET SOLUTIONDIR=%CURRENTDIR%

SET PlatformTarget=Win32
msbuild ./projects/SoilProxy/SoilProxy.vcxproj /p:Platform=%PlatformTarget%;Configuration=Release;SolutionDir=%SOLUTIONDIR%
SET PlatformTarget=x64
msbuild ./projects/SoilProxy/SoilProxy.vcxproj /p:Platform=%PlatformTarget%;Configuration=Release;SolutionDir=%SOLUTIONDIR%

SET PlatformTarget=AnyCPU
dotnet restore ./projects/Soil.NetCore/Soil.NetCore.csproj
msbuild ./projects/Soil.NetCore/Soil.NetCore.csproj /p:Platform=%PlatformTarget%;Configuration=Release /t:Rebuild

msbuild ./projects/Soil.NetFX4/Soil.NetFX4.csproj /p:Platform=%PlatformTarget%;Configuration=Release /t:Rebuild

rmdir /q /s %SOLUTIONDIR%\nuget_package
rmdir /q /s %SOLUTIONDIR%\nuget_package
rmdir /q /s %SOLUTIONDIR%\Output
rmdir /q /s %SOLUTIONDIR%\Output

robocopy ./projects/Soil.NetCore/bin/Release/netstandard2.0 ./Output/lib/netstandard2.0
robocopy ./x64/Release ./Output/lib/netstandard2.0 SoilProxy64.dll SoilProxy64.pdb
robocopy ./projects/Soil.NetFX4/bin/Release/ ./Output/lib/net40
robocopy ./x64/Release ./Output/lib/net40 SoilProxy64.dll SoilProxy64.pdb

robocopy . ./Output SoilNET.nuspec

mkdir nuget_package
pushd Output
nuget pack SoilNET.nuspec -OutputDirectory ..\nuget_package
popd

if EXIST d:\settings\my.nuget.txt (
    SET /p NUGETKEY=<d:\settings\my.nuget.txt
    nuget push .\nuget_package\SoilDotnet.1.0.0.nupkg %NUGETKEY% -src https://www.nuget.org/api/v2/package
)


REM Install-Package SoilDotnet -Version 1.0.0