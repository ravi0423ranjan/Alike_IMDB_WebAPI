using AutoMapper;
using IMDB.ModelResources;
using IMDB.Models;
using IMDB.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Controllers
{
    [Route("api/[controller]")]
    public class ProducerController : Controller
    {
        private readonly IMapper mapper;
        private readonly IMDB_DbContext context;
        private readonly ILogger<ProducerController> logger;

        public ProducerController(IMapper mapper,IMDB_DbContext context,ILogger<ProducerController> logger)
        {
            this.mapper = mapper;
            this.context = context;
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult CreateProducer([FromBody] ProducerResource producerResource)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var producer = mapper.Map<ProducerResource, Producer>(producerResource);
                context.Producers.Add(producer);
                context.SaveChanges();
                var result = mapper.Map<Producer, ProducerResource>(producer);
                return Ok(result);
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Source + "-" + ex.Message);
                return BadRequest();
            }
        }

    }
}
