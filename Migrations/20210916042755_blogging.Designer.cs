﻿// <auto-generated />
using System;
using BloggingSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BloggingSystem.Migrations
{
    [DbContext(typeof(BloggingDbContext))]
    [Migration("20210916042755_blogging")]
    partial class blogging
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BloggingSystem.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PicPath")
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime>("RegisteredAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("BloggingSystem.Models.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("BloggingSystem.Models.Comment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PostId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("PublishedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("isAccept")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("BloggingSystem.Models.Post", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("PublishedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("BloggingSystem.Models.PostPics", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PicPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("PostPics");
                });

            modelBuilder.Entity("BloggingSystem.Models.PostVideos", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PostId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VideoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("PostVideos");
                });

            modelBuilder.Entity("BloggingSystem.Models.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("BloggingSystem.Models.RoleUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("BloggingSystem.Models.Comment", b =>
                {
                    b.HasOne("BloggingSystem.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.HasOne("BloggingSystem.Models.ApplicationUser", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BloggingSystem.Models.Post", b =>
                {
                    b.HasOne("BloggingSystem.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId");

                    b.HasOne("BloggingSystem.Models.ApplicationUser", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId");

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BloggingSystem.Models.PostPics", b =>
                {
                    b.HasOne("BloggingSystem.Models.Post", "Post")
                        .WithMany("Pics")
                        .HasForeignKey("PostId");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("BloggingSystem.Models.PostVideos", b =>
                {
                    b.HasOne("BloggingSystem.Models.Post", "Post")
                        .WithMany("Videos")
                        .HasForeignKey("PostId");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("BloggingSystem.Models.RoleUser", b =>
                {
                    b.HasOne("BloggingSystem.Models.Role", "Role")
                        .WithMany("roleUsers")
                        .HasForeignKey("RoleId");

                    b.HasOne("BloggingSystem.Models.ApplicationUser", "User")
                        .WithMany("roleUsers")
                        .HasForeignKey("UserId");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BloggingSystem.Models.ApplicationUser", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Posts");

                    b.Navigation("roleUsers");
                });

            modelBuilder.Entity("BloggingSystem.Models.Category", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("BloggingSystem.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Pics");

                    b.Navigation("Videos");
                });

            modelBuilder.Entity("BloggingSystem.Models.Role", b =>
                {
                    b.Navigation("roleUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
