﻿// <auto-generated />
using System;
using Infrastructure.Repository.RepositoryImplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Repository.Migrations
{
    [DbContext(typeof(EFContext))]
    partial class EFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.MenuService.Entity.ChildMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ChildMenuName");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<DateTime?>("LastModifyOn");

                    b.Property<int>("MenuId");

                    b.Property<string>("Url");

                    b.Property<string>("ViewId");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("childmenus");
                });

            modelBuilder.Entity("Domain.MenuService.Entity.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<DateTime?>("LastModifyOn");

                    b.Property<string>("MenuName");

                    b.HasKey("Id");

                    b.ToTable("menus");
                });

            modelBuilder.Entity("Domain.MenuService.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<DateTime?>("LastModifyOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.MenuService.Entity.ChildMenu", b =>
                {
                    b.HasOne("Domain.MenuService.Entity.Menu", "Menu")
                        .WithMany("childMenus")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
