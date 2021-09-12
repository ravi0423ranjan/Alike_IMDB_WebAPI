using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Models
{
    public class Producer
    {
        public int ProducerId { get; set; }
        public string ProducerName { get; set; }

        public DateTime Producer_DOB { get; set; }

        public string Producer_CompanyName { get; set; }

        public string ProducerGender { get; set; }

        public IList<Movie> Movies { get; set; }

        public Producer()
        {
            this.Movies = new List<Movie>();
        }
    }
}
