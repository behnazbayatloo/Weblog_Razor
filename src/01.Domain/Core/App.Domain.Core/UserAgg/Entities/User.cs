using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.CommentAgg.Entities;
using App.Domain.Core.PostAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.UserAgg.Entities
{
    public class User
    {   
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public string? AboutMe { get; set; }
        public List<Post>? Posts { get; set; }
        public List<Category>? Categories { get; set; }
        public List<Comment> Comments { get; set; }
        #region Audit
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; } //همیشه به وسیله خودش ایجاد میشود
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        #endregion
    }
}
