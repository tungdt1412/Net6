using Net_6.Common.Shared.Interface;
using Net_6.Common.Shared.Model;
using Net_6.Database.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Commands.Request
{
    public class CreateAuthor : Author,
        IIdentifiedCommand,
        IRequest<BaseCommandResultWithData<Author>>
    {
        public string? RequestId { get; set; }
        public string? IpAddress { get; set; }
        public string? UserName { get; set; }
    }
}
