using AutoMapper;
using IMDB.ModelResources;
using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Model to ModelResource
            CreateMap<Movie, MovieResource>()
                .ForMember(mr=>mr.MovieName,opt=>opt.MapFrom(m=>m.MovieName))
                .ForMember(mr=>mr.Movie_ReleaseDate,opt=>opt.MapFrom(m=>m.Movie_ReleaseDate))
                .ForMember(mr=>mr.ProducerId,opt=>opt.MapFrom(m=>m.ProducerId))
                .ForMember(mr=>mr.ActorsId,opt=>opt.MapFrom(m=>m.Actors.Select(a=>a.ActorId)));
            CreateMap<Producer, ProducerResource>()
                .ForMember(pr=>pr.ProducerName,opt=>opt.MapFrom(p=>p.ProducerName))
                .ForMember(pr=>pr.Producer_CompanyName,opt=>opt.MapFrom(p=>p.Producer_CompanyName))
                .ForMember(pr=>pr.Producer_DOB,opt=>opt.MapFrom(p=>p.Producer_DOB))
                .ForMember(pr=>pr.ProducerGender,opt=>opt.MapFrom(p=>p.ProducerGender));
            CreateMap<Actor, ActorResource>()
                .ForMember(ar=>ar.ActorName,opt=>opt.MapFrom(a=>a.ActorName))
                .ForMember(ar => ar.Actor_DOB, opt => opt.MapFrom(a => a.Actor_DOB))
                .ForMember(ar => ar.ActorGender, opt => opt.MapFrom(a => a.ActorGender));

            //ModelResource to Model
            CreateMap<MovieResource, Movie>()
                .ForMember(m => m.MovieId, opt => opt.MapFrom(mr=>mr.MovieId))
                .ForMember(m => m.MovieName, opt => opt.MapFrom(mr => mr.MovieName))
                .ForMember(m => m.Movie_ReleaseDate, opt => opt.MapFrom(mr => mr.Movie_ReleaseDate))
                .ForMember(m => m.Actors, opt => opt.MapFrom(mr => mr.ActorsId.Select(id => new ActorMovie { ActorId = id })));
                //.ForMember(m => m.Actors, opt => opt.Ignore())
                //.AfterMap((mr, m) => {
                //    // Remove actors
                //    var removedActors = m.Actors.Where(ab => !mr.ActorsId.Contains(ab.ActorId)).ToList();
                //    foreach (var ra in removedActors)
                //        m.Actors.Remove(ra);

                //    // Add new actors
                //    var addedActors = mr.ActorsId.Where(id => !m.Actors.Any(ab => ab.ActorId == id)).Select(id => new ActorMovie { ActorId = id }).ToList();
                //    foreach (var aa in addedActors)
                //        m.Actors.Add(aa);
                //});

            CreateMap<ProducerResource, Producer>()
                .ForMember(p => p.ProducerName, opt => opt.MapFrom(pr => pr.ProducerName))
                .ForMember(p => p.Producer_CompanyName, opt => opt.MapFrom(mr => mr.Producer_CompanyName))
                .ForMember(p => p.Producer_DOB, opt => opt.MapFrom(mr => mr.Producer_DOB))
                .ForMember(p => p.ProducerGender, opt => opt.MapFrom(mr => mr.ProducerGender));

            CreateMap<ActorResource, Actor>()
                .ForMember(a => a.ActorName, opt => opt.MapFrom(ar => ar.ActorName))
                .ForMember(a => a.Actor_DOB, opt => opt.MapFrom(ar => ar.Actor_DOB))
                .ForMember(a => a.ActorGender, opt => opt.MapFrom(ar => ar.ActorGender));
        }
    }
}
