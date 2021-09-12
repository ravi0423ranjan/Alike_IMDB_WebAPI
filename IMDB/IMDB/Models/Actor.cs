using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }

        public DateTime Actor_DOB { get; set; }

        public string ActorGender { get; set; }

        public IList<ActorMovie> Movies { get; set; }

        public Actor()
        {
            this.Movies = new List<ActorMovie>();
        }
    }
}
