using FilmFestival.Service;
using FilmFestival.Service.Definition;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFestival.Context
{
    public class BaseController : Controller
    {
        public IActionResult Convert<T>(ServiceResult<T> result)
        {
            var visitor = new ActionResultVisitor<T>();
            return result.Visit(visitor);
        }
    }
}
