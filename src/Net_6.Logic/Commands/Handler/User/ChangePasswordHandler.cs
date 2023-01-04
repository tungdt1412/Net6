using Microsoft.AspNetCore.Identity;

namespace Net_6.Logic.Commands.Handler
{
    public class ChangePasswordHandler : IRequestHandler<ChangePassword, BaseCommandResult>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public ChangePasswordHandler(AppDatabase database,
            IMapper mapper,
            UserManager<User> userManager)
        {
            this.database = database;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public Task<BaseCommandResult> Handle(ChangePassword request, 
            CancellationToken cancellationToken)
        {
            var result = new BaseCommandResult();

            try
            {
                var user = userManager.FindByNameAsync(request.ChangPasswordUserName).Result;

                if(user != null)
                {
                    var resetToken = userManager.GeneratePasswordResetTokenAsync(user).Result;
                    var resetResult = userManager.ResetPasswordAsync(user, resetToken, request.NewPassowrd).Result;

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
                    result.Messages = $"Can't fint user with {request.UserName} to change password";
                }
            }
            catch(Exception ex)
            {
                result.Messages = ex.Message;
            }

            return Task.FromResult(result);
        }
    }
}
