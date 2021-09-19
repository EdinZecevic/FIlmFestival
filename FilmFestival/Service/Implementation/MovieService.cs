using Autofac;
using FilmFestival.Context;
using FilmFestival.Entities;
using FilmFestival.Models.Request;
using FilmFestival.Models.Response;
using FilmFestival.Service.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFestival.Service.Implementation
{
    public class MovieService : Service, IMovieService
    {
        private DataBaseContext context;

        public MovieService(DataBaseContext context) //: base(scope) ILifetimeScope scope, 
        {
            this.context = context;
        }

        public ServiceResult<FilmListModel> Movies(string filter)
        {
            var movies = context.Movies.Select(x => new FilmListModelItem
            { Id = x.Id, Title = x.Title, Description = x.Description, ReleaseDate = x.ReleaseDate, AverageRating = x.AverageRating, Actors = context.Actors.Where(w => w.MovieId == x.Id).Select(y => new ActorList {Name = y.Name, Surname = y.Surname }).ToList()}).OrderByDescending(x => x.AverageRating).ToList();

            if (!String.IsNullOrWhiteSpace(filter))
            {
                var lowerFilter = filter.ToLower();
                movies = movies.Where(s => s.Title.ToLower().Contains(lowerFilter) || s.Description.ToLower().Contains(lowerFilter) || 
                s.Actors.Where(a => a.Surname.ToLower().Contains(lowerFilter) || a.Name.ToLower().Contains(lowerFilter)).Any()).ToList();

            }

            var total = movies.Count();

            var filmListModel = new FilmListModel
            {
                Items = movies,
                Page = 1,
                Total = total
            };

            return Ok(filmListModel);
        }

        public async Task<ServiceResult<Nothing>> Raiting(RaitingDto model)
        {
            var movie = context.Movies.Where(x => x.Id == model.Id).FirstOrDefault();

            var rate = new MovieRaiting { 
                MovieId = movie.Id,
                Raiting = model.Raiting
            };

            context.MovieRaitings.Add(rate);
            await context.SaveChangesAsync();

            var movieRatesSum = context.MovieRaitings.Where(x => x.MovieId == model.Id).Select(x => x.Raiting).Sum();
            var movieRaitingsNumber = context.MovieRaitings.Where(x => x.MovieId == model.Id).ToList().Count();
            var average = movieRatesSum / movieRaitingsNumber;

            movie.AverageRating = average;

            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
