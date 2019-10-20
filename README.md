# Fake bootstrapping example

> Note: There are other variants (as branches in this repository) to choose from as well as other [installation options](https://fake.build/fake-gettingstarted.html#Install-FAKE)
> - as paket-cli tool https://github.com/matthid/fake-bootstrap/tree/paket_clitool
> - as global tool https://github.com/matthid/fake-bootstrap/tree/global_tool

This repository shows how to bootstrap FAKE from nothing.
The `fake.sh` and `fake.cmd` scripts will:
 - install .NET Core with the provided install scripts (https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-install-script)
 - restore FAKE as local cli tool via `dotnet tool restore`
 - redirect the given arguments `fake <args>` to `dotnet fake <args>`.

If dotnet is already a given you can edit the scripts accordingly.

Usage:

Unix (or git bash on windows after https://github.com/dotnet/cli/pull/8491)

```bash
git clone https://github.com/matthid/fake-bootstrap.git
cd fake-bootstrap
./fake.sh run myscript.fsx 
```

Windows (powershell/cmd)

```batch
git clone https://github.com/matthid/fake-bootstrap.git
cd fake-bootstrap
.\fake.cmd run myscript.fsx
```

To upgrade to latest packages, just delete `myscript.fsx.lock` and run fake again.
