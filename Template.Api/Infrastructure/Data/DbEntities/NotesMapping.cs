using AutoMapper;
using System;
using Template.Api.Domain.SeedWork;
using Template.Api.Domain.Aggregates;

namespace Template.Api.Infrastructure.Data.DbEntities {
    public class NotesMappings : Profile {

        public NotesMappings() {

            CreateMap<Notes, NotesDbEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NoteId, opt => opt.MapFrom(src => src.NoteId))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .ForMember(dest => dest.MessageCreatedDate, opt => opt.MapFrom(src => src.MessageCreatedDate.ToString()));

             CreateMap<NotesDbEntity, Notes>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NoteId, opt => opt.MapFrom(src => src.NoteId))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .ForMember(dest => dest.MessageCreatedDate, opt => opt.MapFrom(src => DateTime.Parse(src.MessageCreatedDate)));
        }
    }
}
