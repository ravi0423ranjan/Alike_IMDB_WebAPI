using AutoMapper;
using IMDB.ModelResources;
using IMDB.Models;
using IMDB.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly IMDB_DbContext context;
        private readonly IMapper mapper;
        private readonly ILogger<MovieController> logger;

        public MovieController(IMDB_DbContext context,IMapper mapper,ILogger<MovieController> logger)
        {
            this.context = context;
            this.mapper = mapper;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult GetMovies()
        {
            try
            {
                var moviesJSON = (from movie in context.Movies
                              select new
                              {
                                  MovieName = movie.MovieName,
                                  ReleaseDate = movie.Movie_ReleaseDate,
                                  Producer = (from p in context.Producers where p.ProducerId == movie.ProducerId select p.ProducerName).FirstOrDefault(),
                                  Actors = (from a in context.Actors
                                            join am in context.ActorMovies on a.ActorId equals am.ActorId
                                            where am.MovieId == movie.MovieId
                                            select a.ActorName).ToArray()
                              });
                return Ok(moviesJSON);
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Source + "-" + ex.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody]MovieResource movieResource)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var movie = mapper.Map<MovieResource, Movie>(movieResource);
                context.Movies.Add(movie);
                context.SaveChanges();
                var result = mapper.Map<Movie, MovieResource>(movie);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Source + "-" + ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditMovie(int ?id, [FromBody] MovieResource movieResource)
        {
            try
            {
                //validations
                if ((id ?? 0) == 0) { return BadRequest(ModelState); }
                if (id != movieResource.MovieId) { return BadRequest(); }
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var movie= context.Movies.Where(a=>a.MovieId == id).FirstOrDefault();
                if (movie == null)
                {
                    return NotFound();
                }
                //populating the model
                movie.MovieName = movieResource.MovieName;
                movie.Movie_ReleaseDate = movieResource.Movie_ReleaseDate;
                movie.ProducerId = movieResource.ProducerId;
                //Removing previous movie Actors relationed rows
                var movieActors = (from a in context.ActorMovies.Where(exp => exp.MovieId == id) select a).ToList();
                context.ActorMovies.RemoveRange(movieActors);
                await context.SaveChangesAsync();
                //Addition of new movie Actors relationed rows
                var newMovieactors = (from a in movieResource.ActorsId select new ActorMovie { ActorId = a, MovieId = (id ?? 0) }).ToList();
                context.ActorMovies.AddRange(newMovieactors);
                await context.SaveChangesAsync();
                //Updating the movie table row
                context.Movies.Update(movie);
                await context.SaveChangesAsync();

                var result = mapper.Map<Movie, MovieResource>(movie);
                return Ok(result);
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Source + "-" + ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieDetails(int ?id)
        {
            try
            {
               if((id ?? 0) == 0) { return BadRequest(ModelState); }
               var movieJSON = (from movie in context.Movies where movie.MovieId == id
                              select new
                              {
                                  MovieName = movie.MovieName,
                                  ReleaseDate = movie.Movie_ReleaseDate,
                                  Producer = (from p in context.Producers where p.ProducerId == movie.ProducerId select p.ProducerName).FirstOrDefault(),
                                  Actors = (from a in context.Actors
                                            join am in context.ActorMovies on a.ActorId equals am.ActorId
                                            where am.MovieId == movie.MovieId
                                            select a.ActorName).ToArray()
                              });
                return Ok(movieJSON);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Source + "-" + ex.Message);
                return BadRequest();
            }
        }
            
    }
}
