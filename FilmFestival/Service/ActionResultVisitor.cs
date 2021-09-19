using FilmFestival.Service.Definition;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFestival.Service
{
    public class ActionResultVisitor<T> : IServiceResultVisitor<T, IActionResult>
    {
        public IActionResult VisitOk(OkServiceResult<T> result)
        {
            return new OkObjectResult(result.Value);
        }
    }
}
