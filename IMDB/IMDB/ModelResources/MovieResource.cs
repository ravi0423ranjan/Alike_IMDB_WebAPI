using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.ModelResources
{
    public class MovieResource
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime Movie_ReleaseDate { get; set; }

        public int ProducerId { get; set; }
        public IList<int> ActorsId { get; set; }

        public MovieResource()
        {
            this.ActorsId = new List<int>();
        }
    }
}
