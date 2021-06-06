﻿// <auto-generated />
using System;
using Cine__backend.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cine__backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210606155211_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cine__backend.Models.BookEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Expense")
                        .HasColumnType("float");

                    b.Property<double>("Income")
                        .HasColumnType("float");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BookEntries");
                });

            modelBuilder.Entity("Cine__backend.Models.ClubMember", b =>
                {
                    b.Property<Guid>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateOfDeath")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.ToTable("ClubMembers");
                });

            modelBuilder.Entity("Cine__backend.Models.ClubMemberGenre", b =>
                {
                    b.Property<Guid>("ClubMemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ClubMemberId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("clubMemberGenres");
                });

            modelBuilder.Entity("Cine__backend.Models.Film", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("Cine__backend.Models.FilmFilmStaffMemberFilmRol", b =>
                {
                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FilmStaffMemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FilmRolId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FilmId", "FilmStaffMemberId", "FilmRolId");

                    b.HasIndex("FilmRolId");

                    b.HasIndex("FilmStaffMemberId");

                    b.ToTable("FilmFilmStaffMemberFilmRols");
                });

            modelBuilder.Entity("Cine__backend.Models.FilmGenre", b =>
                {
                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FilmId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("FilmGenres");
                });

            modelBuilder.Entity("Cine__backend.Models.FilmRol", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FilmRols");
                });

            modelBuilder.Entity("Cine__backend.Models.FilmScreening", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StarTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.HasIndex("RoomId");

                    b.ToTable("FilmScreenings");
                });

            modelBuilder.Entity("Cine__backend.Models.FilmScreeningPriceModification", b =>
                {
                    b.Property<Guid>("FilmScreeningId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PriceModificationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Optional")
                        .HasColumnType("bit");

                    b.HasKey("FilmScreeningId", "PriceModificationId");

                    b.HasIndex("PriceModificationId");

                    b.ToTable("FilmScreeningPriceModifications");
                });

            modelBuilder.Entity("Cine__backend.Models.FilmStaffMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FilmStaffMembers");
                });

            modelBuilder.Entity("Cine__backend.Models.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = new Guid("779e3a84-ec60-47af-8970-f12e88322805"),
                            Name = "Drama"
                        },
                        new
                        {
                            Id = new Guid("751337ed-731f-4a79-b2e7-0423a0f75bf9"),
                            Name = "Comedia"
                        },
                        new
                        {
                            Id = new Guid("94eab560-61bb-41fb-a7d0-399eeb1f7058"),
                            Name = "Romántica"
                        },
                        new
                        {
                            Id = new Guid("ba8d2e11-8837-4f44-ad8d-086f681d6be4"),
                            Name = "Suspenso"
                        },
                        new
                        {
                            Id = new Guid("7ea09a3f-2f24-43aa-b6d2-2b33b3edd2d2"),
                            Name = "Terror"
                        });
                });

            modelBuilder.Entity("Cine__backend.Models.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid?>("PurchaseOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PurchaseOrderId");

                    b.ToTable("Items");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");
                });

            modelBuilder.Entity("Cine__backend.Models.Level", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("Cine__backend.Models.PriceModification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PriceModifications");
                });

            modelBuilder.Entity("Cine__backend.Models.PurchaseOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BoxOffice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CredictCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PurchaseTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("Cine__backend.Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Cine__backend.Models.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("Cine__backend.Models.SeatSectionLevelRoom", b =>
                {
                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.Property<Guid>("SectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LevelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SeatId", "SectionId", "LevelId", "RoomId");

                    b.HasIndex("LevelId");

                    b.HasIndex("RoomId");

                    b.HasIndex("SectionId");

                    b.ToTable("SeatSectionLevelRooms");
                });

            modelBuilder.Entity("Cine__backend.Models.Section", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Cine__backend.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Cine__backend.Models.UserFilm", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("UserId", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("UserFilms");
                });

            modelBuilder.Entity("Cine__backend.Models.Reservation", b =>
                {
                    b.HasBaseType("Cine__backend.Models.Item");

                    b.Property<Guid>("FilmSreeningId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.HasIndex("FilmSreeningId");

                    b.HasIndex("SeatId");

                    b.HasDiscriminator().HasValue("Reservation");
                });

            modelBuilder.Entity("Cine__backend.Models.ClubMemberGenre", b =>
                {
                    b.HasOne("Cine__backend.Models.ClubMember", "ClubMember")
                        .WithMany()
                        .HasForeignKey("ClubMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cine__backend.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClubMember");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Cine__backend.Models.FilmFilmStaffMemberFilmRol", b =>
                {
                    b.HasOne("Cine__backend.Models.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Cine__backend.Models.FilmRol", "FilmRol")
                        .WithMany()
                        .HasForeignKey("FilmRolId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Cine__backend.Models.FilmStaffMember", "FilmStaffMember")
                        .WithMany()
                        .HasForeignKey("FilmStaffMemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("FilmRol");

                    b.Navigation("FilmStaffMember");
                });

            modelBuilder.Entity("Cine__backend.Models.FilmGenre", b =>
                {
                    b.HasOne("Cine__backend.Models.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Cine__backend.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Cine__backend.Models.FilmScreening", b =>
                {
                    b.HasOne("Cine__backend.Models.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Cine__backend.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Cine__backend.Models.FilmScreeningPriceModification", b =>
                {
                    b.HasOne("Cine__backend.Models.FilmScreening", "FilmScreening")
                        .WithMany()
                        .HasForeignKey("FilmScreeningId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Cine__backend.Models.PriceModification", "PriceModification")
                        .WithMany()
                        .HasForeignKey("PriceModificationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FilmScreening");

                    b.Navigation("PriceModification");
                });

            modelBuilder.Entity("Cine__backend.Models.Item", b =>
                {
                    b.HasOne("Cine__backend.Models.PurchaseOrder", null)
                        .WithMany("Items")
                        .HasForeignKey("PurchaseOrderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Cine__backend.Models.PurchaseOrder", b =>
                {
                    b.HasOne("Cine__backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cine__backend.Models.SeatSectionLevelRoom", b =>
                {
                    b.HasOne("Cine__backend.Models.Level", "Level")
                        .WithMany()
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Cine__backend.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Cine__backend.Models.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Cine__backend.Models.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Level");

                    b.Navigation("Room");

                    b.Navigation("Seat");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("Cine__backend.Models.UserFilm", b =>
                {
                    b.HasOne("Cine__backend.Models.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Cine__backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cine__backend.Models.Reservation", b =>
                {
                    b.HasOne("Cine__backend.Models.FilmScreening", "FilmScreening")
                        .WithMany()
                        .HasForeignKey("FilmSreeningId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Cine__backend.Models.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FilmScreening");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("Cine__backend.Models.PurchaseOrder", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
