using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.PostAgg.DTOs
{
    public class EditPostDTO
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId {  get; set; }
        public IFormFile? Imag {  get; set; }
        public string? ImgUrl { get; set; }

    }
}
