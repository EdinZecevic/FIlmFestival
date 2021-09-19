using FilmFestival.Entities;
using FilmFestival.Models.Response.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFestival.Models.Response
{
    public class FilmListModel : PagedListModel<FilmListModelItem>
    {
    }
    public class FilmListModelItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int AverageRating { get; set; }
        public List<ActorList> Actors { get; set; }
    }

    public class ActorList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? MovieId { get; set; }
        public int? ShowId { get; set; }
    }
}
