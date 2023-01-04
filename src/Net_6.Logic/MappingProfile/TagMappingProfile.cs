using AutoMapper;
using Net_6.Logic.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.MappingProfile
{
    public class TagMappingProfile : Profile
    {
        public TagMappingProfile()
        {
            CreateMap<CreateTag, Tag>();
            CreateMap<UpdateTag, Tag>();
            CreateMap<Tag, TagSummaryModel>()
                .ReverseMap();
            CreateMap<Tag, TagDetailModel>()
                .ReverseMap();
        }
    }
}
