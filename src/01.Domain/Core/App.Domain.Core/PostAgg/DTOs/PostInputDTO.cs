using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.PostAgg.DTOs
{
    public class PostInputDTO
    {
        public string Title { get; set; }
       
        public string Description { get; set; }
        public IFormFile? Img { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
