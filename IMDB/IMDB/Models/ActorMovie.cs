using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Models
{
    [Table("ActorMovies")]
    public class ActorMovie
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public Actor Actor { get; set; }
    }
}
