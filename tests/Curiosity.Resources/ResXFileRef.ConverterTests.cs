// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Drawing;
using System.IO;
using System.Text;
using Xunit;

namespace Curiosity.Resources.Tests
{
    public class ResXFileRef_Converter : IClassFixture<ThreadExceptionFixture>
    {
        [Fact]
        public void ConvertFrom_ReturnNullWhenValueIsNotAString()
        {
            var value = new object();
            var converter = new ResXFileRef.Converter();

            var result = converter.ConvertFrom(null, null, value);

            Assert.Null(result);
        }

        [Fact]
        public void ConvertFrom_ReadsFileAsString()
        {
            var resxFilePath = Path.Combine("TestResources", "Files", "text.ansi.txt");
            var resxFileRefString = $"{resxFilePath};System.String";
            var expected = "Text";
            var converter = new ResXFileRef.Converter();

            var result = (string)converter.ConvertFrom(null, null, resxFileRefString);

            Assert.Equal(expected, result);
        }

        [Fact(Skip = "System.NotSupportedException : Support for UTF-7 is disabled. See https://aka.ms/dotnet-warnings/SYSLIB0001 for more information.")]
        public void ConvertFrom_ReadsFileAsStringUsingEncodingFromRefString()
        {
            var resxFilePath = Path.Combine("TestResources", "Files", "text.utf7.txt");
            var resxFileRefString = $"{resxFilePath};System.String;utf-7";
            var expected = "Привет";
            var converter = new ResXFileRef.Converter();

            var result = (string)converter.ConvertFrom(null, null, resxFileRefString);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertFrom_ReadsFileAsByteArray()
        {
            var resxFilePath = Path.Combine("TestResources", "Files", "text.ansi.txt");
            var resxFileRefString = $"{resxFilePath};System.Byte[]";
            var expected = "Text";
            var converter = new ResXFileRef.Converter();

            var result = (byte[])converter.ConvertFrom(null, null, resxFileRefString);

            Assert.Equal(expected, Encoding.Default.GetString(result));
        }

        [Fact]
        public void ConvertFrom_ReadsFileAsMemoryStream()
        {
            var resxFilePath = Path.Combine("TestResources", "Files", "text.ansi.txt");
            var resxFileRefString = $"{resxFilePath};System.IO.MemoryStream";
            var expected = "Text";
            var converter = new ResXFileRef.Converter();

            var result = (MemoryStream)converter.ConvertFrom(null, null, resxFileRefString);

            Assert.Equal(expected, Encoding.Default.GetString(result.ToArray()));
        }

        [Fact]
        public void ConvertFrom_ReadsFileAsIcon()
        {
            var resxFilePath = Path.Combine("TestResources", "Files", "Error.ico");
            var resxFileRefString = $"{resxFilePath};System.Drawing.Icon, System.Drawing.Common";
            var converter = new ResXFileRef.Converter();

            var result = (Icon)converter.ConvertFrom(null, null, resxFileRefString);

            Assert.NotNull(result);
            Assert.False(result.Size.IsEmpty);
        }

        [Fact(Skip = "Need libgdiplus")]
        public void ConvertFrom_ReadsFileAsIconWhenTypeIsBitmap()
        {
            var resxFilePath = Path.Combine("TestResources", "Files", "Error.ico");
            var iconRefString = $"{resxFilePath};System.Drawing.Icon, System.Drawing.Common";
            var bitmapIconRefString = $"{resxFilePath};System.Drawing.Bitmap, System.Drawing.Common";
            var converter = new ResXFileRef.Converter();

            var iconResult = (Icon)converter.ConvertFrom(null, null, iconRefString);
            var bitmapResult = (Bitmap)converter.ConvertFrom(null, null, bitmapIconRefString);

            Assert.Equal(iconResult.Size, bitmapResult.Size);
        }

        [Fact(Skip = "Need libgdiplus")]
        public void ConvertFrom_ReadsFileAsBitmap()
        {
            var resxFilePath = Path.Combine("TestResources", "Files", "ErrorControl.bmp");
            var resxFileRefString = $"{resxFilePath};System.Drawing.Bitmap, System.Drawing.Common";
            var converter = new ResXFileRef.Converter();

            var result = (Bitmap)converter.ConvertFrom(null, null, resxFileRefString);

            Assert.NotNull(result);
            Assert.False(result.Size.IsEmpty);
        }
    }
}
