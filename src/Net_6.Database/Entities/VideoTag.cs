﻿using Net_6.Common.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Database.Entities
{
    public class VideoTag : BaseEntity
    {
        public int Id { get; set; }
        public int VideoId { get; set; }
        public int TagId { get; set; }
    }
}
