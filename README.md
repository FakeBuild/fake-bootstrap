# Fake bootstrapping example

> Note: There are other variants (as branches in this repository) to choose from as well as other [installation options](https://fake.build/fake-gettingstarted.html#Install-FAKE)
> - as paket-cli tool https://github.com/matthid/fake-bootstrap/tree/paket_clitool
> - as local tool https://github.com/matthid/fake-bootstrap/tree/local_tool

This repository shows how to bootstrap FAKE from an dotnet sdk installation.
The `build.sh` and `build.cmd` scripts will:
 - assume .NET Core is installed and available in PATH (check other branches on how to install via script)
 - install FAKE as global dotnet tool with a relative path
 - start fake from the fresh installation

Usage:

Unix (or git bash on windows after https://github.com/dotnet/cli/pull/8491)

```bash
git clone https://github.com/matthid/fake-bootstrap.git
cd fake-bootstrap
git checkout global_tool
./build.sh
```

Windows (powershell/cmd)

```batch
git clone https://github.com/matthid/fake-bootstrap.git
cd fake-bootstrap
git checkout global_tool
.\build.cmd
```

To upgrade to latest packages, just delete `build.fsx.lock` and run fake again.
