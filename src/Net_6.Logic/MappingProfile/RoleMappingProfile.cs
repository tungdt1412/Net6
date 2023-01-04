using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Net_6.Logic.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.MappingProfile
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<CreateRole, IdentityRole>();
            CreateMap<IdentityRole, RoleSummaryModel>()
                .ReverseMap();
            CreateMap<IdentityRole, RoleDetailModel>()
                .ReverseMap();
        }
    }
}
