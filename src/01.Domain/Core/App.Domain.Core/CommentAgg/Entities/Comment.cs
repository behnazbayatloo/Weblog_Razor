using App.Domain.Core.CommentAgg.Enums;
using App.Domain.Core.PostAgg.Entities;
using App.Domain.Core.UserAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CommentAgg.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText {  get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public StatusEnum Status { get; set; } = StatusEnum.Pending;

        public int? Rate { get; set; }

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
