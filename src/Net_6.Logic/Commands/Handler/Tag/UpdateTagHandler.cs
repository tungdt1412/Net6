﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Commands.Handler
{
    public class UpdateTagHandler : IRequestHandler<UpdateTag,
        BaseCommandResultWithData<Tag>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public UpdateTagHandler(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public Task<BaseCommandResultWithData<Tag>> Handle(
            UpdateTag request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Tag>();

            try
            {
                var tag = database.Tags.FirstOrDefault(x => x.Id == request.Id);

                if (tag != null)
                {
                    mapper.Map(request, tag);
                    tag.SetUpdateInfo(request.UserName ?? string.Empty, AppGlobal.SysDateTime);
                    database.Update(tag);
                    database.SaveChanges();

                    result.Success = true;
                    result.Data = tag;
                }
                else
                {
                    result.Messages = $"Can't not find tag with id is {request.Id}";
                }
            }
            catch (Exception ex)
            {
                result.Messages = ex.Message;
            }

            return Task.FromResult(result);
        }
    }
}
