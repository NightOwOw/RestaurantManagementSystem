﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantSystem.Data;

#nullable disable

namespace RestaurantSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241222181425_AddOrderAndMenuTables")]
    partial class AddOrderAndMenuTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantSystem.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Main Course",
                            Description = "Description of the item goes here",
                            IsAvailable = true,
                            Name = "Menu Item 1",
                            Price = 12.99m
                        },
                        new
                        {
                            Id = 2,
                            Category = "Main Course",
                            Description = "Description of the item goes here",
                            IsAvailable = true,
                            Name = "Menu Item 2",
                            Price = 12.99m
                        },
                        new
                        {
                            Id = 3,
                            Category = "Beverages",
                            Description = "Description of the item goes here",
                            IsAvailable = true,
                            Name = "Menu Item 3",
                            Price = 12.99m
                        });
                });

            modelBuilder.Entity("RestaurantSystem.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Notes")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("RestaurantSystem.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("RestaurantSystem.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("ReservationTime")
                        .HasColumnType("time");

                    b.Property<string>("SpecialRequests")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TableNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RestaurantSystem.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "admin123",
                            Role = "admin",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Password = "user123",
                            Role = "user",
                            Username = "user1"
                        },
                        new
                        {
                            Id = 3,
                            Password = "user456",
                            Role = "user",
                            Username = "user2"
                        });
                });

            modelBuilder.Entity("RestaurantSystem.Models.Order", b =>
                {
                    b.HasOne("RestaurantSystem.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("User");
                });

            modelBuilder.Entity("RestaurantSystem.Models.OrderItem", b =>
                {
                    b.HasOne("RestaurantSystem.Models.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RestaurantSystem.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantSystem.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
