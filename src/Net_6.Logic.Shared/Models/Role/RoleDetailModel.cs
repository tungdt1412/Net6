using Net_6.Database.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Shared.Models
{
    public class RoleDetailModel : IdentityRole<string>
    {
        public List<User> Users { get; set; } = new List<User>();
    }
}
