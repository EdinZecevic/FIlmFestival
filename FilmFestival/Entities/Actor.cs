using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmFestival.Entities
{
    public class Actor
    {
        public int Id { get; set; }

        public int? MovieId { get; set; }
        [JsonIgnore]
        public virtual Movie Movie { get; set; }

        public int? ShowId { get; set; }
        [JsonIgnore]
        public virtual Show Show { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
