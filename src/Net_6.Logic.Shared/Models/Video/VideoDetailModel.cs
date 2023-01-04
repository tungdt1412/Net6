using Net_6.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Shared.Models
{
    public class VideoDetailModel : Video
    {
        public List<PlayList> PlayLists { get; set; } = new List<PlayList>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
