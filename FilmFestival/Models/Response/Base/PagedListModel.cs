using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFestival.Models.Response.Base
{
   
        public class PagedListModel<T> : ListModel<T>
        {
            /// <summary>
            /// Prazan konstruktor
            /// </summary>
            public PagedListModel()
            {
                Page = 1;
                Sve = false;
            }
            /// <summary>
            /// Broj stranice rezultata
            /// </summary>
            public int Page { get; set; }
            /// <summary>
            /// Ukupan broj rezultata koji mogu da se vrate
            /// </summary>
            public int Total { get; set; }
            /// <summary>
            /// Koristi se u slučajevima kada je potrebno sve
            /// </summary>
            public bool Sve { get; set; }
        }
    
}
