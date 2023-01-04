using Net_6.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Shared.Models
{
    public class TagDetailModel : Tag
    {
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Video> Videos { get; set; } = new List<Video>();
    }
}
