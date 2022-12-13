using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Common.Shared.Model
{
    public class BaseEntity
    {
        public string CreatedBy { get; set; } = string.Empty;

        public DateTime? CreateAt { get; set; }

        public string LastUpdatedBy { get; set; } = string.Empty;

        public DateTime? LastUpdateAt { get; set; }

        public bool IsDeleted { get; set; }
        public BaseEntity SetCreateInfo(string user, DateTime date)
        {
            CreateAt = date;
            CreatedBy = user;
            return this;
        }

        public BaseEntity SetUpdateInfo(string user, DateTime date)
        {
            LastUpdatedBy = user;
            LastUpdateAt = date;
            return this;
        }
    }
}
