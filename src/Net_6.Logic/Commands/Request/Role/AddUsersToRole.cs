﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Commands.Request
{
    public class AddUsers : IdentityRole,
        IIdentifiedCommand,
        IRequest<BaseCommandResultWithData<IdentityRole>>
    {
        public List<User> Users { get; set; } = new List<User>();
        public string? Password { get; set; }
        public string? RequestId { get; set; }
        public string? IpAddress { get; set; }
        public string? UserName { get; set; }
    }
}
