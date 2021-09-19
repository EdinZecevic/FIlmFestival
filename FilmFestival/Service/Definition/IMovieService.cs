using FilmFestival.Models.Request;
using FilmFestival.Models.Response;
using Microsoft.Exchange.WebServices.Data;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFestival.Service.Definition
{
    public interface IMovieService : IService
    {
        ServiceResult<FilmListModel> Movies(string filter);
        Task<ServiceResult<Nothing>>Raiting(RaitingDto model);
    }
}
