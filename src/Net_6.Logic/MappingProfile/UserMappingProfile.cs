using AutoMapper;
using Net_6.Logic.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.MappingProfile
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreateUser, User>()
                .ForMember(x => x.UserName, y => y.MapFrom(s => s.CreateUserName));
            CreateMap<User, UserSummaryModel>()
                .ReverseMap();
            CreateMap<User, UserDetailModel>()
                .ReverseMap();
        }
    }
}
