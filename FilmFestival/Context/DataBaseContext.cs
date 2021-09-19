using FilmFestival.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FilmFestival.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public override async Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            return await base.SaveChangesAsync(token);
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieRaiting> MovieRaitings { get; set; }
    }
}
