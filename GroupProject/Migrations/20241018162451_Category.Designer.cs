﻿// <auto-generated />
using GroupProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GroupProject.Migrations
{
    [DbContext(typeof(ContactContext))]
    [Migration("20241018162451_Category")]
    partial class Category
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GroupProject.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            Name = "Family"
                        },
                        new
                        {
                            CategoryID = 2,
                            Name = "Friend"
                        },
                        new
                        {
                            CategoryID = 3,
                            Name = "Work"
                        },
                        new
                        {
                            CategoryID = 4,
                            Name = "School"
                        },
                        new
                        {
                            CategoryID = 5,
                            Name = "Social"
                        },
                        new
                        {
                            CategoryID = 6,
                            Name = "Service Provider"
                        },
                        new
                        {
                            CategoryID = 7,
                            Name = "Community"
                        });
                });

            modelBuilder.Entity("GroupProject.Models.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            ContactID = 1,
                            CategoryID = 4,
                            Email = "huda.judeh@southeasttech.edu",
                            FirstName = "Huda",
                            LastName = "Judeh",
                            Organization = "Southeast Technial College",
                            Phone = "605-555-1234"
                        },
                        new
                        {
                            ContactID = 2,
                            CategoryID = 2,
                            Email = "ducotemike@yahoo.com",
                            FirstName = "Michael",
                            LastName = "Ducote",
                            Phone = "225-987-5555"
                        },
                        new
                        {
                            ContactID = 3,
                            CategoryID = 3,
                            Email = "tom.winker@winfieldcorp.com",
                            FirstName = "Thomas",
                            LastName = "Winker",
                            Organization = "Winfield Corporation",
                            Phone = "605-555-6789"
                        },
                        new
                        {
                            ContactID = 4,
                            CategoryID = 6,
                            Email = "drmattb@siouxfallschiro.com",
                            FirstName = "Matt",
                            LastName = "Brandner",
                            Organization = "Sioux Falls Chiropractic",
                            Phone = "605-555-9876"
                        },
                        new
                        {
                            ContactID = 5,
                            CategoryID = 7,
                            Email = "arends.em@gmail.com",
                            FirstName = "Emma",
                            LastName = "Arends",
                            Phone = "320-456-7890"
                        });
                });

            modelBuilder.Entity("GroupProject.Models.Contact", b =>
                {
                    b.HasOne("GroupProject.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
