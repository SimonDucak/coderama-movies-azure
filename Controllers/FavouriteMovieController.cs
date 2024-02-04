using AutoMapper;
using coderama_movies_server.Interfaces;
using coderama_movies_server.Models;
using Microsoft.AspNetCore.Mvc;

namespace coach_of_people_azure_server.Controllers
{
    [Route("api/[controller]/{userId}")]
    [ApiController]
    public class FavouriteMovieController : Controller
    {
        private readonly IFavouriteMovieRepository _movieRepository;

        public FavouriteMovieController(IFavouriteMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // ********************************************************************************************
        // Chcel som to urobit tak, ze budem volat externu API na ziskanie info o filmoch,
        // ale problem je ze mam iba 1000 volani denne zadarmo. Co by mohlo potom rychlo dojst
        // kedze pre kazde id filmu by som musel volat API. Takze si ukladam vsetok info o filmoch do DB.
        // ********************************************************************************************
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FavouriteMovie>))]
        public IActionResult Get(int userId, int pageSize = 10, int pageNumber = 1)
        {
            var movies = _movieRepository.Get(userId, pageSize, pageNumber);
            return Ok(movies);
        }

        [HttpGet("imdb-ids")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<string>))]
        public IActionResult Get(int userId)
        {
            var movies = _movieRepository.Get(userId);

            var ids = movies.Select(m => m.ImdbID);

            return Ok(ids);
        }

        [HttpPost]
        public IActionResult Add([FromBody] FavouriteMovie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _movieRepository.Add(movie);

            return Ok("Movie added successfully");
        }

        [HttpDelete("{imdbId}")]
        public IActionResult Delete(int userId, string imdbId)
        {
            var movie = _movieRepository.GetByImdbId(userId, imdbId);

            if (movie == null)
                return NotFound();

            _movieRepository.Delete(movie);

            return Ok("Movie deleted successfully");
        }
    }
}