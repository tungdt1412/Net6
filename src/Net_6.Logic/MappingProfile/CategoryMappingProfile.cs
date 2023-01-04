global using Net_6.Database.Entities;
global using Net_6.Logic.Commands.Request;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net_6.Logic.Shared.Models;

namespace Net_6.Logic.MappingProfile
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CreateCategory, Category>();
            CreateMap<UpdateCategory, Category>();
            CreateMap<Category, CategorySummaryModel>()
                .ReverseMap();
            CreateMap<Category, CategoryDetailModel>()
                .ReverseMap();
        }
    }
}
