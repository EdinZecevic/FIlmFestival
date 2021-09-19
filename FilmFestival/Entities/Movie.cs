using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFestival.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(64)]
        public string Title { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int AverageRating { get; set; }

    }
}
