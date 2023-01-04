﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Logic.Commands.Handler
{
    public class ResetPasswordHandler : IRequestHandler<ResetPassword, BaseCommandResult>
    {
        private readonly IMapper mapper;
        private readonly AppDatabase database;
        private readonly UserManager<User> userManager;

        public ResetPasswordHandler(IMapper mapper,
            AppDatabase database,
            UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.database = database;
            this.userManager = userManager;
        }

        public Task<BaseCommandResult> Handle(ResetPassword request,
            CancellationToken cancellationToken)
        {
            var result = new BaseCommandResult();

            try
            {
                var user = userManager.FindByNameAsync(request.ResetUserName).Result;

                if (user != null)
                {
                    var resetToken = userManager.GeneratePasswordResetTokenAsync(user).Result;
                    var resetResult = userManager.ResetPasswordAsync(user, resetToken, request.NewPassword).Result;

                    if (resetResult.Succeeded)
                    {
                        result.Success = true;
                        result.Messages = AppGlobal.DefaultSuccessMessage;
                    }
                    else
                    {
                        result.Messages = string.Join("-", resetResult.Errors.Select(x => x.Description));
                    }
                }
                else
                {
                    result.Messages = "Can't not find user to reset password";
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
