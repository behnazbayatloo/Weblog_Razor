using App.Domain.Core.PostAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.EntitiesConfigs
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(p => p.Description).HasMaxLength(4000);
            builder.HasOne(p=>p.User).WithMany(u=>u.Posts).HasForeignKey(p=>p.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p=>p.Category).WithMany(c=>c.Posts).HasForeignKey(p=>p.CategoryId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(p=>p.Comments).WithOne(c=>c.Post).HasForeignKey(c=>c.PostId).OnDelete(DeleteBehavior.NoAction);
            builder.HasQueryFilter(u =>!u.IsDeleted);
        }
    }
}
