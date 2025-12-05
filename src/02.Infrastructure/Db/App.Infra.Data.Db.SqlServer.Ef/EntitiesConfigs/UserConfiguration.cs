using App.Domain.Core.UserAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.EntitiesConfigs
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           builder.Property(u=>u.AboutMe).HasMaxLength(1000);
            builder.Property(u=>u.FirstName).HasMaxLength(200);
            builder.Property(u=>u.LastName).HasMaxLength(200);
            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(u=>u.CreatedBy).HasComputedColumnSql("[Id]");
            builder.HasMany(u => u.Categories).WithOne(c => c.User).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(u => u.Comments).WithOne(c => c.User).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.NoAction);

          
        }
    }
}
