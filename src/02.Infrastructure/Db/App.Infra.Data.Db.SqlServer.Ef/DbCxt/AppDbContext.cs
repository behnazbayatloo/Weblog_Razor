

using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.CommentAgg.Entities;
using App.Domain.Core.PostAgg.Entities;
using App.Domain.Core.UserAgg.Entities;
using Microsoft.EntityFrameworkCore;
namespace App.Infra.Data.Db.SqlServer.Ef.DbCxt
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

           
        }
        
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
