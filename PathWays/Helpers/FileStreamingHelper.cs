using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GraphQL.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

#pragma warning disable SA1009 // Closing parenthesis must be spaced correctly

namespace PathWays.Helpers
{
    public static class FileStreamingHelper
    {
        private static readonly int BondaryLengthLimit = 1024;

        public static async Task<IActionResult> GetFile(string filePath, string fileMimeType)
        {
            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;
            return new FileStreamResult(memory, fileMimeType);
        }

        public static async Task<(T model, List<LocalMultipartFileInfo> file)>
            ParseRequestForm<T>(
            this HttpContext context, string tempFolder, T model)
            where T : class
        {
            var files = await ParseRequest(context.Request, tempFolder);
            return (model, files);
        }

        private static async Task<List<LocalMultipartFileInfo>>
            ParseRequest(HttpRequest request, string tempLoc, Func<MultipartSection, Task> fileHandler = null)
        {
            var files = new List<LocalMultipartFileInfo>();

            if (fileHandler == null)
            {
                fileHandler = HandleFileSection;
            }

            var boundary = MultipartRequestHelper.GetBoundary(
                MediaTypeHeaderValue.Parse(request.ContentType),
                BondaryLengthLimit);

            using (var sr = request.ReadAsStream())
            {
                var reader = new MultipartReader(boundary, sr);

                var section = await reader.ReadNextSectionAsync();

                while (section != null)
                {
                    var hasContentDispositionHeader =
                        ContentDispositionHeaderValue.TryParse(
                            section.ContentDisposition,
                            out ContentDispositionHeaderValue contentDisposition);

                    if (hasContentDispositionHeader)
                    {
                        if (MultipartRequestHelper.HasFileContentDisposition(contentDisposition))
                        {
                            await fileHandler(section);
                        }
                    }

                    section = await reader.ReadNextSectionAsync();
                }
            }

            return files;

            async Task HandleFileSection(MultipartSection fileSection)
            {
                string targetFilePath;
                var guid = Guid.NewGuid();

                targetFilePath = Path.Combine(tempLoc, guid.ToString());

                using (var targetStream = File.Create(targetFilePath))
                {
                    await fileSection.Body.CopyToAsync(targetStream);
                    targetStream.Position = 0;
                }

                if (fileSection.Body.Length == 0)
                {
                    throw new InvalidDataException("Trying to upload empty file");
                }

                var formFile = new LocalMultipartFileInfo
                {
                    Name = fileSection.AsFileSection().FileName,
                    FileName = fileSection.AsFileSection().Name,
                    OriginalFileName = fileSection.AsFileSection().FileName,
                    ContentType = fileSection.ContentType,
                    Length = fileSection.Body.Length,
                    TemporaryLocation = targetFilePath,
                };

                files.Add(formFile);
            }
        }
    }

#pragma warning restore SA1009 // Closing parenthesis must be spaced correctly

    public class MultipartFileInfo
    {
        public long Length { get; set; }

        public string FileName { get; set; }

        public string OriginalFileName { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }
    }

    public class LocalMultipartFileInfo : MultipartFileInfo
    {
        public string TemporaryLocation { get; set; }
    }
}