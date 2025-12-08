using Files.Contrcat;
using Microsoft.AspNetCore.Http;

namespace Files.Service
{
    public class FileService:IFileService
    {
        public async Task Delete(string fileName, CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return;

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);

            if (File.Exists(fullPath))
            {
                await Task.Run(() => File.Delete(fullPath),ct);
            }
        }

        public async Task<string> Upload(IFormFile file, string folder, CancellationToken ct)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", folder);

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

           await using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            {
             await   file.CopyToAsync(stream,ct);
            }

            return Path.Combine("Files", folder, uniqueFileName);
        }
    }
}
