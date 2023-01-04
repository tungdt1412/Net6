﻿using Net_6.Common.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Database.Entities
{
    public class PlayList : BaseEntity
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? UrlMeta { get; set; }

        public string? Keywords { get; set; }

        public int? SortIndex { get; set; }
    }
}
