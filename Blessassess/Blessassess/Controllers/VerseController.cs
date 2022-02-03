using Blessassess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blessassess.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class VerseController : ControllerBase
    {
        private readonly BlessDbContext blessdbcontext;
        public VerseController(BlessDbContext blessDbContext)
        {
            blessdbcontext = blessDbContext;
        }



        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return blessdbcontext.movie.ToList();
        }
        [HttpGet("GetMovieById")]
        public Movie GetMovieById(int Id)
        {
            return blessdbcontext.movie.Find(Id);
        }

        [HttpPost("InsertMovie")]
        public IActionResult InsertMovie([FromBody] Movie movie)
        {
            if (movie.Id.ToString() != "")
            {

                blessdbcontext.movie.Add(movie);
                blessdbcontext.SaveChanges();
                return Ok("Movie details saved successfully");
            }
            else
                return BadRequest();
        }

        [HttpPut("UpdateMovie")]
        public IActionResult UpdateMovie([FromBody] Movie movies)
        {
            if (movies.Id.ToString() != "")
            {

                blessdbcontext.Entry(movies).State = EntityState.Modified;
                blessdbcontext.SaveChanges();
                return Ok("Updated successfully");
            }
            else
                return BadRequest();
        }

        [HttpDelete("DeleteTutorial")]
        public IActionResult DeleteTutorial(int Id)
        {
            
            var result = blessdbcontext.movie.Find(Id);
            blessdbcontext.movie.Remove(result);
            blessdbcontext.SaveChanges();
            return Ok("Deleted successfully");
        }

    }
}
