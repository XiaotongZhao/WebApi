using Domain.MenuService.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.RepositoryImplement
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        public virtual DbSet<Menu> menus { get; set; }
        public virtual DbSet<ChildMenu> childmenus { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
