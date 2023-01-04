using Net_6.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Shared.Models
{
    public class PostSummaryModel : Post
    {
        public string AuthorName { get; set; } = string.Empty;
        public int TotalComment { get; set; }
    }
}
