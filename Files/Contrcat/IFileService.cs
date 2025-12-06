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
        string Upload(IFormFile file, string folder);
        void Delete(string fileName);

    }
}
