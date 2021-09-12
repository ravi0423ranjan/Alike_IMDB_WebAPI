using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime Movie_ReleaseDate { get; set; }

        public Producer Producer { get; set; }

        public int ProducerId { get; set; }
        public IList<ActorMovie> Actors { get; set; }

        public Movie()
        {
            this.Actors = new List<ActorMovie>();
        }
    }
}
