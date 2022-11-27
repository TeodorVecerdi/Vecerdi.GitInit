# Vecerdi.GitInit

[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/Vecerdi.GitInit)](https://www.nuget.org/packages/Vecerdi.GitInit)

A .NET tool to initialize a git repository

## Installation

```bash
dotnet tool install -g Vecerdi.GitInit
```

### Building and installing from source

```bash
git clone https://github.com/TeodorVecerdi/Vecerdi.GitInit
cd Vecerdi.GitInit
dotnet pack -c Release
dotnet tool install -g --add-source ./nupkg Vecerdi.GitInit
```

## Usage

```bash
$ gitinit --help

Description:
  Initialize a git repository

Usage:
  gitinit [options]

Options:
  -a, --accept-defaults                  Accept all defaults
  -i, --ignores <ignores>                Comma-separated list of ignores to add to .gitignore
  -I, --no-gitignore                     Do not create a .gitignore file
  -l, --license <license>                License type (SPDX identifier)
  -L, --no-license                       Do not create a LICENSE file
  -m, --commit-message <commit-message>  Commit message
  -M, --no-commit                        Do not commit the initial commit
  -A, --dont-add-all                     Do not add all files to the initial commit
  -d, --dry-run                          Do not actually run any commands
  --version                              Show version information
  -?, -h, --help                         Show help and usage information
```
