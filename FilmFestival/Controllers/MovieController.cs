using FilmFestival.Context;
using FilmFestival.Entities;
using FilmFestival.Models.Request;
using FilmFestival.Models.Response;
using FilmFestival.Service.Definition;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFestival.Controllers
{
    [ApiController]
    [Route("movie")]
    public class MovieController : BaseController
    {
        private IMovieService filmService;
        public MovieController(IMovieService filmService)
        {
            this.filmService = filmService;
        }

        [HttpGet("movies/")]
        public IActionResult Movies(string filter)
        {
            var result = filmService.Movies(filter);
            return Convert(result);
        }

        [HttpPost("raiting/")]
    public async Task<IActionResult> Raiting([FromBody] RaitingDto model)
        {
            var result = await filmService.Raiting(model);
            return Ok();
        }
    }
}
