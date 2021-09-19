using Autofac;
using FilmFestival.Service.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFestival.Service.Implementation
{
    public class Service : IService
    {
        public ILifetimeScope Scope { get; set; }
        public Service() //ILifetimeScope scope)
        {
            //this.Scope = scope;
        }

        public OkServiceResult Ok()
        {
            return new OkServiceResult();
        }
        public OkServiceResult<T> Ok<T>(T value)
        {
            return new OkServiceResult<T>(value);
        }
    }
}
