﻿using Net_6.Logic.Commands.Request;
using System.ComponentModel.DataAnnotations;

namespace Net_6.Website.Models
{
    public class ResetPasswordViewModel : BaseViewModel
    {
        public string ResetUserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string NewPassword { get; set; } = string.Empty;

        public ResetPassword ToResetPasswordCommand()
        {
            return new ResetPassword()
            {
                ResetUserName = ResetUserName,
                NewPassword = NewPassword
            };
        }
    }
}
