﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240621230746_AddEnum")]
    partial class AddEnum
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("Domain.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUser")
                        .HasColumnType("INTEGER");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdUser = 3,
                            State = 0
                        },
                        new
                        {
                            Id = 2,
                            IdUser = 4,
                            State = 0
                        },
                        new
                        {
                            Id = 3,
                            IdUser = 5,
                            State = 0
                        });
                });

            modelBuilder.Entity("Domain.Entities.Sneaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Brand")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("sneakers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = 0,
                            Category = 1,
                            Name = "Air Max",
                            Price = 120,
                            Stock = 50
                        },
                        new
                        {
                            Id = 2,
                            Brand = 1,
                            Category = 1,
                            Name = "Classic",
                            Price = 100,
                            Stock = 30
                        },
                        new
                        {
                            Id = 3,
                            Brand = 0,
                            Category = 2,
                            Name = "ZoomX",
                            Price = 150,
                            Stock = 20
                        },
                        new
                        {
                            Id = 4,
                            Brand = 1,
                            Category = 2,
                            Name = "Superstar",
                            Price = 80,
                            Stock = 40
                        },
                        new
                        {
                            Id = 5,
                            Brand = 1,
                            Category = 0,
                            Name = "Gel-Kayano",
                            Price = 140,
                            Stock = 25
                        },
                        new
                        {
                            Id = 6,
                            Brand = 2,
                            Category = 1,
                            Name = "Chuck Taylor",
                            Price = 60,
                            Stock = 35
                        },
                        new
                        {
                            Id = 7,
                            Brand = 1,
                            Category = 0,
                            Name = "Ultraboost",
                            Price = 180,
                            Stock = 15
                        },
                        new
                        {
                            Id = 8,
                            Brand = 0,
                            Category = 2,
                            Name = "Pegasus",
                            Price = 110,
                            Stock = 45
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmailAddress = "Ana@example.com",
                            Name = "Ana",
                            Password = "Pass1",
                            Type = 2
                        },
                        new
                        {
                            Id = 2,
                            EmailAddress = "delfina@example.com",
                            Name = "Delfina",
                            Password = "Pass2",
                            Type = 2
                        },
                        new
                        {
                            Id = 3,
                            EmailAddress = "juan.doe@example.com",
                            Name = "Juan",
                            Password = "Pass3",
                            Type = 1
                        },
                        new
                        {
                            Id = 4,
                            EmailAddress = "vicky.sosa@example.com",
                            Name = "Victoria",
                            Password = "Pass4",
                            Type = 1
                        },
                        new
                        {
                            Id = 5,
                            EmailAddress = "lautaro.rb@example.com",
                            Name = "Lautaro",
                            Password = "Pass5",
                            Type = 1
                        });
                });

            modelBuilder.Entity("ReservationSneaker", b =>
                {
                    b.Property<int>("ReservationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SneakersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReservationId", "SneakersId");

                    b.HasIndex("SneakersId");

                    b.ToTable("ReservationSneaker");
                });

            modelBuilder.Entity("Domain.Entities.Reservation", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReservationSneaker", b =>
                {
                    b.HasOne("Domain.Entities.Reservation", null)
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Sneaker", null)
                        .WithMany()
                        .HasForeignKey("SneakersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}