using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.ViewModels.System.User
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").MinimumLength(6).WithMessage("Password has at least 6 characters");
        }
    }
}
