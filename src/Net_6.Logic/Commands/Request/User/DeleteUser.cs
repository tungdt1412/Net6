﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Commands.Request
{
    public class DeleteUser : IIdentifiedCommand,
        IRequest<BaseCommandResult>
    {
        public string? RequestId { get; set; }
        public string? IpAddress { get; set; }
        public string? UserName { get; set; } = string.Empty;
        public string? DeleteUserName { get; set; } = string.Empty;
    }
}
