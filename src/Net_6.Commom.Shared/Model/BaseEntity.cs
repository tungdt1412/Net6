using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Common.Shared.Model
{
    public class BaseEntity
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public BaseEntity SetCreateInfo(string user, DateTime date)
        {
            CreatedAt = date;
            CreatedBy = user;
            return this;
        }

        public BaseEntity SetUpdateInfo(string user, DateTime date)
        {
            LastUpdatedBy = user;
            LastUpdatedAt = date;
            return this;
        }

        public BaseEntity MarkAsDelete(string user, DateTime date)
        {
            IsDeleted = true;
            LastUpdatedBy = user;
            LastUpdatedAt = date;
            return this;
        }
    }
}
