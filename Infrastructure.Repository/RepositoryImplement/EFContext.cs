using Domain.Blog.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.RepositoryImplement
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public virtual DbSet<Blog> blogs { get; set; }
        public virtual DbSet<BlogType> blogTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
