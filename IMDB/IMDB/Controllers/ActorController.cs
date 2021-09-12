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
    [Route("api/[Controller]")]
    public class ActorController :Controller
    {
        private readonly IMapper mapper;
        private readonly IMDB_DbContext context;
        private readonly ILogger logger;

        public ActorController(IMapper mapper,IMDB_DbContext context,ILogger<ActorController> logger)
        {
            this.mapper = mapper;
            this.context = context;
            this.logger = logger;
        }

        [HttpPost]
        public ActionResult CreateActor([FromBody] ActorResource actorResource)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var actor = mapper.Map<ActorResource, Actor>(actorResource);
                context.Actors.Add(actor);
                context.SaveChanges();
                var result = mapper.Map<Actor, ActorResource>(actor);
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
