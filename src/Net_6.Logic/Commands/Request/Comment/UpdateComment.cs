﻿using Net_6.Logic.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Commands.Request
{
    public class UpdateComment : CommentModel,
        IIdentifiedCommand,
        IRequest<BaseCommandResultWithData<Comment>>
    {
        public string? RequestId { get; set; }
        public string? IpAddress { get; set; }
        public string? UserName { get; set; }
    }
}
