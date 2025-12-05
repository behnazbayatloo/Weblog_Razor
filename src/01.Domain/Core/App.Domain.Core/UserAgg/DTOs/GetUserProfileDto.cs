using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.CommentAgg.Entities;
using App.Domain.Core.PostAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.UserAgg.DTOs
{
    public class GetUserProfileDto
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set;}
        public string? Aboutme { get; set; }
        public List<Post>? Posts { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Category>? Categories { get; set; }


    }
}
