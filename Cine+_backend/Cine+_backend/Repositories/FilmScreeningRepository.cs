﻿using Cine__backend.Interfaces;
using Cine__backend.Models;
using Cine__backend.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine__backend.Repositories
{
    public class FilmScreeningRepository: IFilmScreeningRepository
    {
        private AppDbContext _context;
        public FilmScreeningRepository(AppDbContext context)
        {
            _context = context;
        }

        public FilmScreening AddFilmScreening(FilmScreening filmScreening)
        {
            filmScreening.Id = Guid.NewGuid();
            if (filmScreening.StarTime.Length > 5 || int.Parse(filmScreening.StarTime.Split(":")[0]) > 24 || int.Parse(filmScreening.StarTime.Split(":")[1]) > 59)
                throw new FormatException("La hora de la puesta en escena no es válida");

            _context.FilmScreenings.Add(filmScreening);
            _context.SaveChanges();
            return filmScreening;
        }

        public void RemoveFilmScreening(Guid filmScreeningId)
        {
            var currFilmScreening = _context.FilmScreenings.Find(filmScreeningId);
            if (currFilmScreening == null)
            {
                throw new KeyNotFoundException("No se encuntra la puesta en escena especificada");
            }
            _context.FilmScreenings.Remove(currFilmScreening);
            _context.SaveChanges();
            return;
        }

        public DTOFilmScreening GetFilmScreening(Guid filmScreeningId)
        {
            var filmScreening = _context.FilmScreenings.Include(c => c.Film).Include(c => c.Room).SingleOrDefault(c => c.Id == filmScreeningId);
            if (filmScreening == null)
            {
                throw new KeyNotFoundException("No fue encontrada la puesta en escena especificada");
            }
            List<Genre> genres = _context.FilmGenres.Include(c => c.Genre).Where(c => c.FilmId == filmScreening.FilmId).Select(c => c.Genre).ToList();
            DTOFilmScreening filmScreeningDTO = new DTOFilmScreening { FilmScreeningId = filmScreeningId, Film = new DTOFilm { Film = filmScreening.Film, Genres = genres }, Room = filmScreening.Room, StartTime = filmScreening.StarTime };
            return filmScreeningDTO;
        }

        public List<DTOFilmScreening> GetFilmScreenings()
        {
            var filmsSreenings = _context.FilmScreenings.Include(c => c.Film).Include(c => c.Room).ToList();
            List<DTOFilmScreening> filmScreeningsDTO = new List<DTOFilmScreening>();
            foreach(var filmScreening in filmsSreenings)
            {
                List<Genre> genres = _context.FilmGenres.Include(c => c.Genre).Where(c => c.FilmId == filmScreening.FilmId).Select(c => c.Genre).ToList();
                filmScreeningsDTO.Add(new DTOFilmScreening { FilmScreeningId = filmScreening.Id, Film = new DTOFilm { Film = filmScreening.Film, Genres = genres }, Room = filmScreening.Room, StartTime = filmScreening.StarTime });
            }
            return filmScreeningsDTO;
        }

        public FilmScreening UpdateFilmScreening(FilmScreening filmScreening)
        {
            var currFilmScreening = _context.FilmScreenings.Find(filmScreening.Id);
            if (currFilmScreening == null)
            {
                throw new KeyNotFoundException("No se encuntra la puesta en escena especificada");
            }
            currFilmScreening.FilmId = filmScreening.FilmId;
            currFilmScreening.RoomId = filmScreening.RoomId;
            if (filmScreening.StarTime.Length > 5 || int.Parse(filmScreening.StarTime.Split(":")[0]) > 24 || int.Parse(filmScreening.StarTime.Split(":")[1]) > 59)
                throw new FormatException("La hora de la puesta en escena no es válida");
            currFilmScreening.StarTime = filmScreening.StarTime;
            _context.FilmScreenings.Update(currFilmScreening);
            _context.SaveChanges();
            currFilmScreening = _context.FilmScreenings.Include(c => c.Film).Include(c => c.Room).SingleOrDefault(c => c.Id == filmScreening.Id);
            return currFilmScreening;
        }
    }
}
