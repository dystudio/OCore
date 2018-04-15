﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using XCore.EntityFrameworkCore;
using XCore.Environment.Shell.State;

namespace XCore.Migrator.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("XCore.Article.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<int>("Click");

                    b.Property<string>("Content");

                    b.Property<string>("CoverImg");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Description");

                    b.Property<bool>("IsHot");

                    b.Property<bool>("IsRed");

                    b.Property<bool>("IsTop");

                    b.Property<int>("LikeCount");

                    b.Property<string>("SeoDescription");

                    b.Property<string>("SeoKeywords");

                    b.Property<string>("SeoTitle");

                    b.Property<int>("Sort");

                    b.Property<string>("Source")
                        .HasMaxLength(256);

                    b.Property<int>("Status");

                    b.Property<string>("Tags");

                    b.Property<string>("Title")
                        .HasMaxLength(256);

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("XCore_Articles");
                });

            modelBuilder.Entity("XCore.Article.TencentVod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppId");

                    b.Property<string>("CategoryName");

                    b.Property<int>("Click");

                    b.Property<string>("CoverImg");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Description");

                    b.Property<string>("FileId");

                    b.Property<bool>("IsHot");

                    b.Property<bool>("IsRed");

                    b.Property<bool>("IsTop");

                    b.Property<int>("LikeCount");

                    b.Property<int>("Sort");

                    b.Property<int>("Status");

                    b.Property<string>("Title")
                        .HasMaxLength(256);

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("XCore_TencentVods");
                });

            modelBuilder.Entity("XCore.Environment.Shell.Descriptor.Models.ShellDescriptor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SerialNumber");

                    b.HasKey("Id");

                    b.ToTable("XCore_ShellDescriptor");
                });

            modelBuilder.Entity("XCore.Environment.Shell.Descriptor.Models.ShellFeature", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ShellDescriptorId");

                    b.HasKey("Id");

                    b.HasIndex("ShellDescriptorId");

                    b.ToTable("ShellFeature");
                });

            modelBuilder.Entity("XCore.Environment.Shell.Descriptor.Models.ShellParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Component");

                    b.Property<string>("Name");

                    b.Property<int?>("ShellDescriptorId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ShellDescriptorId");

                    b.ToTable("ShellParameter");
                });

            modelBuilder.Entity("XCore.Environment.Shell.State.ShellFeatureState", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EnableState");

                    b.Property<int>("InstallState");

                    b.Property<int?>("ShellStateId");

                    b.HasKey("Id");

                    b.HasIndex("ShellStateId");

                    b.ToTable("ShellFeatureState");
                });

            modelBuilder.Entity("XCore.Environment.Shell.State.ShellState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("XCore_ShellState");
                });

            modelBuilder.Entity("XCore.Identity.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("XCore_Roles");
                });

            modelBuilder.Entity("XCore.Identity.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("XCore_RoleClaims");
                });

            modelBuilder.Entity("XCore.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName")
                        .HasMaxLength(256);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("XCore_Users");
                });

            modelBuilder.Entity("XCore.Identity.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("XCore_UserClaims");
                });

            modelBuilder.Entity("XCore.Identity.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("XCore_UserLogins");
                });

            modelBuilder.Entity("XCore.Identity.UserRole", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("XCore_UserRoles");
                });

            modelBuilder.Entity("XCore.Identity.UserToken", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("XCore_UserTokens");
                });

            modelBuilder.Entity("XCore.Environment.Shell.Descriptor.Models.ShellFeature", b =>
                {
                    b.HasOne("XCore.Environment.Shell.Descriptor.Models.ShellDescriptor")
                        .WithMany("Features")
                        .HasForeignKey("ShellDescriptorId");
                });

            modelBuilder.Entity("XCore.Environment.Shell.Descriptor.Models.ShellParameter", b =>
                {
                    b.HasOne("XCore.Environment.Shell.Descriptor.Models.ShellDescriptor")
                        .WithMany("Parameters")
                        .HasForeignKey("ShellDescriptorId");
                });

            modelBuilder.Entity("XCore.Environment.Shell.State.ShellFeatureState", b =>
                {
                    b.HasOne("XCore.Environment.Shell.State.ShellState")
                        .WithMany("Features")
                        .HasForeignKey("ShellStateId");
                });

            modelBuilder.Entity("XCore.Identity.RoleClaim", b =>
                {
                    b.HasOne("XCore.Identity.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("XCore.Identity.UserClaim", b =>
                {
                    b.HasOne("XCore.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("XCore.Identity.UserLogin", b =>
                {
                    b.HasOne("XCore.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("XCore.Identity.UserRole", b =>
                {
                    b.HasOne("XCore.Identity.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("XCore.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("XCore.Identity.UserToken", b =>
                {
                    b.HasOne("XCore.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
