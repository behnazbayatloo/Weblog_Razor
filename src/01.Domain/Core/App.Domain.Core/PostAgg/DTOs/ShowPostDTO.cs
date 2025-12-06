using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.PostAgg.DTOs
{
    public class ShowPostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string? Img { get; set; }
        public string Author { get; set; }
    }
}
