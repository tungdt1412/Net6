﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Commands.Request
{
    public class DeleteCategory : IIdentifiedCommand,
        IRequest<BaseCommandResult>
    {
        public int Id { get; set; }
        public string? RequestId { get; set; }
        public string? IpAddress { get; set; }
        public string? UserName { get; set; }
    }
}
