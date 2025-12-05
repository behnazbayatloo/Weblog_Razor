using App.Domain.Core.PostAgg.Entities;
using App.Domain.Core.UserAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CategoryAgg.Entities
{
    public class Category
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

        #region Audit
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        #endregion
    }
}
