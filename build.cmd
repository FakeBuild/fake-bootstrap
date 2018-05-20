@ECHO OFF

SET BUILD_PACKAGES=BuildPackages

IF NOT EXIST "%BUILD_PACKAGES%\fake.exe" (
  dotnet tool install fake-cli ^
    --tool-path ./%BUILD_PACKAGES% ^
    --source-feed https://www.myget.org/F/fake-vsts/api/v3/index.json ^
    --version 5.0.0-rc*
)

REM comments following lines once you are done with your script, the idea is to be sure paket install regenerate the lock file if we add new nuget in the fsx
IF EXIST ".fake"          (RMDIR /Q /S ".fake"         )
IF EXIST "build.fsx.lock" (DEL         "build.fsx.lock")

"%BUILD_PACKAGES%/fake.exe" run build.fsx --target Deploy