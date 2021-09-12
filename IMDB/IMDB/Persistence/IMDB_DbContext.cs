using IMDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Persistence
{
    public class IMDB_DbContext : DbContext
    {
        public IMDB_DbContext(DbContextOptions<IMDB_DbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<ActorMovie> ActorMovies { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ActorMovie>().HasKey(am =>
              new { am.MovieId, am.ActorId });

            builder.Entity<Actor>().HasData(
               new Actor
               {
                   ActorId = 1,
                   ActorName = "VBN",
                   Actor_DOB = new DateTime(2020, 11, 09),
                   ActorGender = "Male",
               },
               new Actor
               {
                   ActorId = 2,
                   ActorName = "SDF",
                   Actor_DOB = new DateTime(2020, 11, 24),
                   ActorGender = "Female",
               });
            builder.Entity<Producer>().HasData(
               new Producer
               {
                   ProducerId = 1,
                   ProducerName = "Sam",
                   Producer_DOB = new DateTime(2020, 10, 19),
                   ProducerGender = "Male",
                   Producer_CompanyName = "DF Productions"
               },
               new Producer
               {
                   ProducerId = 2,
                   ProducerName = "Jennifer",
                   Producer_DOB = new DateTime(2020, 10, 04),
                   ProducerGender = "Female",
                   Producer_CompanyName = "KL Productions"
               });
            builder.Entity<Movie>().HasData(
               new Movie
               {
                   MovieId = 1,
                   MovieName = "BJKM",
                   Movie_ReleaseDate = DateTime.Now,
                   ProducerId =1
               },
               new Movie
               {
                   MovieId = 2,
                   MovieName = "YUIO",
                   Movie_ReleaseDate = new DateTime(2020, 11, 23),
                   ProducerId=2
               });
            builder.Entity<ActorMovie>().HasData(
              new ActorMovie
              {
                  MovieId = 1,
                  ActorId = 1
              },
              new ActorMovie
              {
                  MovieId = 2,
                  ActorId=2
              });
        }

    }
}
