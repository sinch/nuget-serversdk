@echo off
pushd src\Sinch.ServerSdk
dotnet restore
dotnet build
set BUILD_STATUS=%ERRORLEVEL%
if %BUILD_STATUS%==0 dotnet pack
if not %BUILD_STATUS%==0  echo Build failed.  NuGet package not created.
popd