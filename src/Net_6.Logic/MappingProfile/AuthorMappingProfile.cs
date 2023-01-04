using AutoMapper;
using Net_6.Database.Entities;
using Net_6.Logic.Commands.Request;
using Net_6.Logic.Shared.Models;

namespace Net_6.Logic.MappingProfile
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<CreateAuthor, Author>();
            CreateMap<UpdateAuthor, Author>();
            CreateMap<Author, AuthorSummaryModel>()
                .ReverseMap();
            CreateMap<Author, AuthorDetailModel>()
                .ReverseMap();
        }
    }
}
