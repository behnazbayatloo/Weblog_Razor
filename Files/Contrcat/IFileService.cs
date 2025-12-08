using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files.Contrcat
{
    public interface IFileService
    {
        Task<string> Upload(IFormFile file, string folder, CancellationToken ct);
        Task Delete(string fileName, CancellationToken ct);

    }
}
