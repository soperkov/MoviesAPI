﻿using MoviesAPI.Data;
using MoviesAPI.ViewModels;

namespace MoviesAPI.Services
{
    public class MovieService
    {
        private AppDbContext _context;
        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }
        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.Id == id);
        }

        public Movie UpdateMovieById(int id, MoviesVM movieVM)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie != null)
            {
                movie.Name = movieVM.Name;
                movie.Year = movieVM.Year;
                movie.Genre = movieVM.Genre;
                _context.SaveChanges();
            }
            return movie;
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        public void AddMovie(MoviesVM movie)
        {
            var newMovie = new Movie()
            {
                Name = movie.Name,
                Year = movie.Year,
                Genre = movie.Genre,
            };
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
        }

        //public void AddMultiple(List<MoviesVM> movies)
        //{
        //    foreach (var movie in movies)
        //    {
        //        var newMovie = new Movie()
        //        {
        //            Name = movie.Name,
        //            Year = movie.Year,
        //            Genre = movie.Genre,
        //        };
        //        _context.Movies.Add(newMovie);
        //        _context.SaveChanges();
        //    }
        //}


    }

}
