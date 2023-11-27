using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services;
using MoviesAPI.ViewModels;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public MovieService MovieService { get; set; }
        public MoviesController(MovieService moviesService)
        {
            MovieService = moviesService;
        }
        [HttpPost]
        public IActionResult AddMovie([FromBody] MoviesVM movie)
        {
            MovieService.AddMovie(movie);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var allMovies = MovieService.GetAllMovies();
            return Ok(allMovies);
        }
        [HttpGet("id")]
        public IActionResult GetMovieById([FromQuery] int id)
        {
            var movie = MovieService.GetMovieById(id);
            return Ok(movie);
        }

        [HttpPut("id")]
        public IActionResult UpdateMovieById([FromQuery] int id,[FromBody] MoviesVM movieVM)
        {
            var updatedMovie = MovieService.UpdateMovieById(id, movieVM);
            return Ok(updatedMovie);
        }

        [HttpDelete("id")]
        public IActionResult DeleteMovie([FromQuery] int id)
        {
            MovieService.DeleteMovie(id);
            return Ok();
        }

        //[HttpPost]
        //public IActionResult AddMultiple([FromBody] List<MoviesVM> movies)
        //{
        //    MovieService.AddMultiple(movies);
        //    return Ok();
        //}

    }

}
