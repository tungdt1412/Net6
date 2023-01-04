using AutoMapper;
using Net_6.Logic.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.MappingProfile
{
    public class PlayListMappingProfile : Profile
    {
        public PlayListMappingProfile()
        {
            CreateMap<PlayList, PlayListSummaryModel>();
            CreateMap<PlayList, PlayListDetailModel>();
            CreateMap<CreatePlayList, PlayList>();
            CreateMap<UpdatePlayList, PlayList>();
        }
    }
}
