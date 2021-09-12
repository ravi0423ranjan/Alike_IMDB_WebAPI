using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.ModelResources
{
    public class ActorResource
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }

        public DateTime Actor_DOB { get; set; }

        public string ActorGender { get; set; }
    }
}
