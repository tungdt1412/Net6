﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Shared.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int? ParentId { get; set; }
        public int? PostId { get; set; }
        public int? VideoId { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
