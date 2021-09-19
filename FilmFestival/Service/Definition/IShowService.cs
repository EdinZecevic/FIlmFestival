using FilmFestival.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFestival.Service.Definition
{
    public interface IShowService : IService
    {
        ServiceResult<FilmListModel> Shows(string filter);
    }
}
