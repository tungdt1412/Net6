using Net_6.Common.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Database.Entities
{
    public class Author : BaseEntity
    {
        public int Id { get; set; }

        public string? FullName { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public string? Phone { get; set; } = string.Empty;

        public string? ShortName { get; set; } = string.Empty;

    }
}
