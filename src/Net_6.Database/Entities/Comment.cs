using Net_6.Common.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Database.Entities
{
    public class Comment : BaseEntity
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public int? Parentid { get; set; }

        public int? PostID { get; set; }

        public int? VideoId { get; set; }
    }
}
