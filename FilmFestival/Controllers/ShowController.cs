using FilmFestival.Context;
using FilmFestival.Service.Definition;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFestival.Controllers
{
    [ApiController]
    [Route("show")]
    public class ShowController : BaseController
    {
        private IShowService showService;

        public ShowController(IShowService showService)
        {
            this.showService = showService;
        }

        [HttpGet("shows/")]
        public IActionResult Shows(string filter)
        {
            var result = showService.Shows(filter);
            return Convert(result);
        }
    }
}
