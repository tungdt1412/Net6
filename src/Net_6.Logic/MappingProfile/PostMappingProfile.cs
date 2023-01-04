using AutoMapper;
using Net_6.Logic.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.MappingProfile
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<CreatePost, Post>();
            CreateMap<UpdatePost, Post>();
            CreateMap<Post, PostSummaryModel>()
                .ReverseMap();
            CreateMap<Post, PostDetailModel>()
                .ReverseMap();
        }
    }
}
