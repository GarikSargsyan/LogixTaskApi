﻿// <auto-generated />
using System;
using LogixTaskApi.Models.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogixTaskApi.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LogixTaskApi.Models.DataBase.ClassDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A beginner-level course for learning C# programming basics.",
                            Name = "Introduction to C# Programming"
                        },
                        new
                        {
                            Id = 2,
                            Description = "An advanced course covering Python programming concepts and best practices.",
                            Name = "Advanced Python Development"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Learn front-end and back-end web development using JavaScript and related technologies.",
                            Name = "Web Development with JavaScript"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Explore data science and machine learning concepts using the Python programming language.",
                            Name = "Data Science with Python"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Build cross-platform mobile apps using the Flutter framework and Dart programming language.",
                            Name = "Mobile App Development with Flutter"
                        });
                });

            modelBuilder.Entity("LogixTaskApi.Models.DataBase.ClassUser", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ClassId");

                    b.HasIndex("ClassId");

                    b.ToTable("ClassUsers");
                });

            modelBuilder.Entity("LogixTaskApi.Models.DataBase.UserProfileDBModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserProfileDBModels");

                    b.HasData(
                        new
                        {
                            Id = new Guid("96081aa4-82b9-41f6-bae4-92c1d11be2e7"),
                            Address = "859 ADAMS AVE 7",
                            DateOfBirth = "12/07/2023",
                            Email = "admin",
                            FirstName = "William",
                            FullName = "William Lenon",
                            IsActive = true,
                            LastName = "Lenon",
                            Password = "admin",
                            PhoneNumber = "(999) 999 - 9999",
                            Role = "admin"
                        });
                });

            modelBuilder.Entity("LogixTaskApi.Models.DataBase.ClassUser", b =>
                {
                    b.HasOne("LogixTaskApi.Models.DataBase.ClassDbModel", "Class")
                        .WithMany("ClassUsers")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogixTaskApi.Models.DataBase.UserProfileDBModel", "User")
                        .WithMany("ClassUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LogixTaskApi.Models.DataBase.ClassDbModel", b =>
                {
                    b.Navigation("ClassUsers");
                });

            modelBuilder.Entity("LogixTaskApi.Models.DataBase.UserProfileDBModel", b =>
                {
                    b.Navigation("ClassUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
