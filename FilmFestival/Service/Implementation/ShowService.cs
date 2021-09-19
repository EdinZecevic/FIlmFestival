using FilmFestival.Context;
using FilmFestival.Models.Response;
using FilmFestival.Service.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFestival.Service.Implementation
{
    public class ShowService : Service, IShowService
    {
        private DataBaseContext context;

        public ShowService(DataBaseContext context) //: base(scope) ILifetimeScope scope, 
        {
            this.context = context;
        }

        public ServiceResult<FilmListModel> Shows(string filter)
        {
            var shows = context.Shows.Select(x => new FilmListModelItem
            { Id = x.Id, Title = x.Title, Description = x.Description, ReleaseDate = x.ReleaseDate, AverageRating = x.AverageRating, Actors = context.Actors.Where(w => w.ShowId == x.Id).Select(y => new ActorList { Name = y.Name, Surname = y.Surname }).ToList() }).OrderByDescending(x => x.AverageRating).ToList();

            if (!String.IsNullOrWhiteSpace(filter))
            {
                var lowerFilter = filter.ToLower();
                shows = shows.Where(s => s.Title.ToLower().Contains(lowerFilter) || s.Description.ToLower().Contains(lowerFilter)).ToList();
            }

            var total = shows.Count();

            var filmListModel = new FilmListModel
            {
                Items = shows,
                Page = 1,
                Total = total
            };

            return Ok(filmListModel);
        }
    }
}
