﻿using AutoMapper;
using Net_6.Database;
using Net_6.Logic.Commands.Request;
using Net_6.Ultils.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Commands.Handler
{
    public class CreateAuthorHandler 
        : IRequestHandler<CreateAuthor, BaseCommandResultWithData<Author>>
    {
        private readonly IMapper mapper;
        private readonly AppDatabase database;

        public CreateAuthorHandler(IMapper mapper,
            AppDatabase database)
        {
            this.mapper = mapper;
            this.database = database;
        }

        public Task<BaseCommandResultWithData<Author>> Handle(CreateAuthor request,
            CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Author>();

            try
            {
                var author = mapper.Map<Author>(request);
                database.Authors.Add(author);

                author.SetCreateInfo(request.UserName ?? string.Empty, AppGlobal.SysDateTime);

                database.SaveChanges();

                result.Data = author;
                result.Success = true;
            }
            catch(Exception ex)
            {
                result.Messages = ex.Message;
            }

            return Task.FromResult(result);
        }
    }
}
