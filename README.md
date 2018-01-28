# Fake bootstrapping example

This repository shows how to bootstrap FAKE from nothing.
The `fake.sh` and `fake.cmd` scripts will:
 - install .NET Core with the provided install scripts (https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-install-script)
 - restore FAKE as dotnet-fake cli tool via `dotnet-fake.csproj` (we hope to have a better way in the future)
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