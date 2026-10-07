#!/usr/bin/env bash
# Builds the whole solution on macOS/Linux.
# The .NET Framework projects need Mono's msbuild; the .NET 8 project needs the dotnet SDK.
# On Windows, just build HPlusSport.sln in Visual Studio.
set -euo pipefail
cd "$(dirname "$0")"
# Restore packages.config packages (the packages/ folder is gitignored)
nuget restore HPlusSport.Web/packages.config -PackagesDirectory packages
nuget restore HPlusSport.API/packages.config -PackagesDirectory packages
msbuild HPlusSport.Web/HPlusSport.Web.csproj -v:m
msbuild HPlusSport.API/HPlusSport.API.csproj -v:m
dotnet build HPlusSport.MinCore.API/HPlusSport.MinCore.API.csproj
