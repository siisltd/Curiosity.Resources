# Curiosity.Resources [![Build and Test](https://github.com/siisltd/Curiosity.Resources/actions/workflows/build.yml/badge.svg)](https://github.com/siisltd/Curiosity.Resources/actions/workflows/build.yml) [![(License)](https://img.shields.io/github/license/siisltd/curiosity.resources.svg)](https://github.com/siisltd/Curiosity.Resources/blob/master/LICENSE) [![nuget](https://img.shields.io/nuget/v/Curiosity.Resources)](https://www.nuget.org/packages/Curiosity.Resources/) [![NuGet](https://img.shields.io/nuget/dt/Curiosity.Resources)](https://www.nuget.org/packages/Curiosity.Resources)

## Install
via Nuget: https://www.nuget.org/packages/Curiosity.Resources/

## Why would you want this library?
If you want to programmatically read/write a ResX file, the standard is to use the `System.Resources.ResXResourceReader` and `System.Resources.ResXResourceWriter`. However these libraries are part of `System.Windows.Forms`. 

This library separates those two classes from `System.Windows.Forms` and packages them for .Net Standard so you can easily include them across
frameworks.

##Sources

This library is almost a direct copy of files from the open sourced winforms respository  
https://github.com/dotnet/winforms/tree/b666dc7a94d8ac87a7d300cfb4fa86332fb79bae/src/System.Windows.Forms/src/System/Resources

## Examples

See how to use `ResXResourceReader` and `ResXResourceWriter` at
- https://docs.microsoft.com/en-us/dotnet/api/system.resources.resxresourcereader?view=netframework-4.8
- https://docs.microsoft.com/en-us/dotnet/api/system.resources.resxresourcewriter?view=netframework-4.8
- https://stackoverflow.com/questions/676312/modifying-resx-file-in-c-sharp
