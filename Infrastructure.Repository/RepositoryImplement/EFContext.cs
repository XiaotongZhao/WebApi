using Domain.MenuService.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.RepositoryImplement
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Menu> menus { get; set; }
        public virtual DbSet<ChildMenu> childmenus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>().HasData(
                new Menu() { Id = 1, MenuName = "Contract Management", CreatedOn = DateTime.Now },
                new Menu() { Id = 2, MenuName = "Component Management", CreatedOn = DateTime.Now });

            modelBuilder.Entity<ChildMenu>().HasData(
                new ChildMenu() { Id = 1, MenuId = 1, ViewId = "div-Contract-VersionControl", Url= "/ContractInformationManage/VersionControl", ChildMenuName = "Version Control Management", CreatedOn = DateTime.Now },
                new ChildMenu() { Id = 2, MenuId = 2, ViewId = "div-Component-ReviewCompoentManagement", Url = "/ComponentManageMent/ReviewComponentManagement", ChildMenuName = "Test Function", CreatedOn = DateTime.Now });
        }
    }
}
