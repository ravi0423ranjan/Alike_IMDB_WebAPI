using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.ModelResources
{
    public class ProducerResource
    {
        public int ProducerId { get; set; }
        public string ProducerName { get; set; }

        public DateTime Producer_DOB { get; set; }

        public string Producer_CompanyName { get; set; }

        public string ProducerGender { get; set; }

    }
}
