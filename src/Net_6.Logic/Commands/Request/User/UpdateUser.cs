﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Commands.Request
{
    public class UpdateUser : User,
        IIdentifiedCommand,
        IRequest<BaseCommandResultWithData<User>>
    {
        public string? RequestId { get; set; }
        public string? IpAddress { get; set; }
        public string UpdateUserName { get; set; } = string.Empty;
    }
}
