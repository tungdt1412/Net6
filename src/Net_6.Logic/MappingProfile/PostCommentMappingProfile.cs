﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.MappingProfile
{
    public class PostCommentMappingProfile : Profile
    {
        public PostCommentMappingProfile()
        {
            CreateMap<CreateComment, Comment>();
        }
    }
}
