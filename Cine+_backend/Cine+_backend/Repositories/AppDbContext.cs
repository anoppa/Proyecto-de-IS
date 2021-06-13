﻿using Cine__backend.Authentication;
using Cine__backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Cine__backend.Repositories
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Dictionary<int, char> rowIntToChar = new Dictionary<int, char> { { 0, 'A' }, { 1, 'B' }, { 2, 'C' }, { 3, 'D' }, { 4, 'E' }, { 5, 'F' }, { 6, 'G' }, { 7, 'H' } };
            List<Seat> seats = new List<Seat>();
            List<Room> RoomsAdd = new List<Room> { new Room { Id = Guid.NewGuid(), Name = "Sala 1" }, new Room { Id = Guid.NewGuid(), Name = "Sala 2" } };
            List<Section> SectionsAdd = new List<Section> { new Section { Id = Guid.NewGuid(), Name = "Sección 1" }, new Section { Id = Guid.NewGuid(), Name = "Sección 2" }, new Section { Id = Guid.NewGuid(), Name = "Sección 3" } };
            List<Level> LevelAdd = new List<Level> { new Level { Id = Guid.NewGuid(), Name = "Platea Baja", PercentOfPriceIncrement = 10 }, new Level { Id = Guid.NewGuid(), Name = "Platea Alta", PercentOfPriceIncrement = 0 } };
            List<SeatSectionLevelRoom> seatsRoomsAdd = new List<SeatSectionLevelRoom>();

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 0; l < ((j == 0) ? 8 : 6); l++)
                        {
                            if (j == 0 && (k == 0 || k == 2))
                            {
                                for (int m = 1; m <= 3; m++)
                                {
                                    Seat tempSeat = new Seat { Id = Guid.NewGuid(), Code = rowIntToChar[l].ToString() + m.ToString() };
                                    seats.Add(tempSeat);
                                    seatsRoomsAdd.Add(new SeatSectionLevelRoom { RoomId = RoomsAdd[i].Id, LevelId = LevelAdd[j].Id, SectionId = SectionsAdd[k].Id, SeatId = tempSeat.Id });
                                }
                            }
                            if (j == 0 && k == 1)
                            {
                                for (int m = 1; m <= 2; m++)
                                {
                                    Seat tempSeat = new Seat { Id = Guid.NewGuid(), Code = rowIntToChar[l].ToString() + m.ToString() };
                                    seats.Add(tempSeat);
                                    seatsRoomsAdd.Add(new SeatSectionLevelRoom { RoomId = RoomsAdd[i].Id, LevelId = LevelAdd[j].Id, SectionId = SectionsAdd[k].Id, SeatId = tempSeat.Id });
                                }
                            }
                            if (j == 1 && (k == 0 || k == 2))
                            {
                                for (int m = 1; m <= l + 1; m++)
                                {
                                    Seat tempSeat = new Seat { Id = Guid.NewGuid(), Code = rowIntToChar[l].ToString() + m.ToString() };
                                    seats.Add(tempSeat);
                                    seatsRoomsAdd.Add(new SeatSectionLevelRoom { RoomId = RoomsAdd[i].Id, LevelId = LevelAdd[j].Id, SectionId = SectionsAdd[k].Id, SeatId = tempSeat.Id });
                                }
                            }
                            if (j == 1 && k == 1)
                            {
                                for (int m = 1; m <= 7 - l; m++)
                                {
                                    Seat tempSeat = new Seat { Id = Guid.NewGuid(), Code = rowIntToChar[l].ToString() + m.ToString() };
                                    seats.Add(tempSeat);
                                    seatsRoomsAdd.Add(new SeatSectionLevelRoom { RoomId = RoomsAdd[i].Id, LevelId = LevelAdd[j].Id, SectionId = SectionsAdd[k].Id, SeatId = tempSeat.Id });
                                }
                            }
                        }
                    }
                }
            }
            base.OnModelCreating(modelBuilder);
            //Seats
            modelBuilder.Entity<Seat>()
                .HasData(seats);
            //Room
            modelBuilder.Entity<Room>()
                .HasData(RoomsAdd.ToArray());
            //Level
            modelBuilder.Entity<Level>()
                .HasData(LevelAdd.ToArray());
            //Section
            modelBuilder.Entity<Section>()
                .HasData(SectionsAdd.ToArray());
            //SeatSectionLevelRoom
            modelBuilder.Entity<SeatSectionLevelRoom>()
                .HasData(seatsRoomsAdd.ToArray());
            //Genre
            modelBuilder.Entity<Genre>()
                .HasData(new Genre { Id = Guid.NewGuid(), Name = "Drama" }, new Genre { Id = Guid.NewGuid(), Name = "Comedia" }, new Genre { Id = Guid.NewGuid(), Name = "Romántica" }, new Genre { Id = Guid.NewGuid(), Name = "Suspenso" }, new Genre { Id = Guid.NewGuid(), Name = "Terror" }, new Genre { Id = Guid.NewGuid(), Name = "Tragicomedia" }, new Genre { Id = Guid.NewGuid(), Name = "Hístorico" }, new Genre { Id = Guid.NewGuid(), Name = "Documental" }, new Genre { Id = Guid.NewGuid(), Name = "Ficción" }, new Genre { Id = Guid.NewGuid(), Name = "Ciencia Ficción" }, new Genre { Id = Guid.NewGuid(), Name = "Aventura" }, new Genre { Id = Guid.NewGuid(), Name = "Musical" }, new Genre { Id = Guid.NewGuid(), Name = "Erótico" });
            //FilmRol
            modelBuilder.Entity<FilmRol>()
                .HasData(new FilmRol { Id = Guid.NewGuid(), Name = "Actor" }, new FilmRol { Id = Guid.NewGuid(), Name = "Director" }, new FilmRol { Id = Guid.NewGuid(), Name = "Productor" }, new FilmRol { Id = Guid.NewGuid(), Name = "Asistente de dirección" }, new FilmRol { Id = Guid.NewGuid(), Name = "Productor Ejecutivo" }, new FilmRol { Id = Guid.NewGuid(), Name = "Guionista" }, new FilmRol { Id = Guid.NewGuid(), Name = "Diseñador de Vestuario" }, new FilmRol { Id = Guid.NewGuid(), Name = "Técnico de Sonido" });
            //ClubMember
            modelBuilder.Entity<ClubMemberGenre>()
                .HasKey(c => new { c.ClubMemberId, c.GenreId } );
            //BookEntry
            modelBuilder.Entity<BookEntry>()
                .Property(e => e.PaymentMethod)
                .HasConversion(
                    v => v.ToString(),
                    v => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), v));
            //FilmScreening
            modelBuilder.Entity<FilmScreening>()
                .HasOne(c => c.Film).WithMany().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<FilmScreening>()
                .HasOne(c => c.Room).WithMany().OnDelete(DeleteBehavior.Cascade);
            //FilmGenre
            modelBuilder.Entity<FilmGenre>()
                .HasKey(c => new { c.FilmId, c.GenreId });
            modelBuilder.Entity<FilmGenre>()
                .HasOne(c => c.Film).WithMany().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<FilmGenre>()
                .HasOne(c => c.Genre).WithMany().OnDelete(DeleteBehavior.Cascade);
            //FilmFilmRol
            modelBuilder.Entity<FilmFilmRol>()
               .HasKey(c => new { c.FilmId, c.FilmRolId, c.MemberRol });
            modelBuilder.Entity<FilmFilmRol>()
                .HasOne(c => c.Film).WithMany().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<FilmFilmRol>()
                .HasOne(c => c.FilmRol).WithMany().OnDelete(DeleteBehavior.Cascade);
            //UserFilm
            modelBuilder.Entity<UserFilm>()
                .HasKey(c => new { c.UserId, c.FilmId });

            modelBuilder.Entity<UserFilm>()
                .HasOne(c => c.User).WithMany().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserFilm>()
                .HasOne(c => c.Film).WithMany().OnDelete(DeleteBehavior.Cascade);
            //FilmScreeningPriceModification
            modelBuilder.Entity<FilmScreeningPriceModification>()
                .HasKey(c => new { c.FilmScreeningId, c.PriceModificationId });
            modelBuilder.Entity<FilmScreeningPriceModification>().HasOne(c => c.FilmScreening).WithMany().
                                                                    OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FilmScreeningPriceModification>().HasOne(c => c.PriceModification).WithMany().
                                                                    OnDelete(DeleteBehavior.Cascade);
            //SeatSectionLevelRoom
            modelBuilder.Entity<SeatSectionLevelRoom>()
                .HasKey(c => new { c.SeatId, c.SectionId, c.LevelId, c.RoomId });
            modelBuilder.Entity<SeatSectionLevelRoom>()
                .HasOne(c => c.Seat)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SeatSectionLevelRoom>()
                .HasOne(c => c.Section)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SeatSectionLevelRoom>()
                .HasOne(c => c.Level)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SeatSectionLevelRoom>()
                .HasOne(c => c.Room)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Reservation>()
                .HasOne(c => c.FilmScreening)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Reservation>()
                .HasOne(c => c.Seat)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            //PurchaseOrder
            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(c => c.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(c => c.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.State)
                .HasConversion(
                    v => v.ToString(),
                    v => (StatePurchaseOrder)Enum.Parse(typeof(StatePurchaseOrder), v));
            //Top10
            modelBuilder.Entity<Top10Film>()
                .HasOne(c => c.Film)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ClubMember> ClubMembers { get; set; }
        public DbSet<ClubMemberGenre> ClubMemberGenres { get; set; }
        public DbSet<BookEntry> BookEntries { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<PriceModification> PriceModifications { get; set; }
        public DbSet<FilmRol> FilmRols { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmFilmRol> FilmFilmRols { get; set; }
        public DbSet<FilmScreening> FilmScreenings { get; set; }
        public DbSet<FilmGenre> FilmGenres { get; set; }
        public DbSet<UserFilm> UserFilms { get; set; }
        public DbSet<FilmScreeningPriceModification> FilmScreeningPriceModifications { get; set; }
        public DbSet<SeatSectionLevelRoom> SeatSectionLevelRooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<Top10Film> Top10 { get; set; }
    }
}
