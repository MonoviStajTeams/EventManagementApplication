using EventManagementApplication.MAUI.Models.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Validators
{
    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            RuleFor(vm => vm.Firstname).NotEmpty().WithMessage("First name is required.");
            RuleFor(vm => vm.Lastname).NotEmpty().WithMessage("Last name is required.");
            RuleFor(vm => vm.Mail).NotEmpty().EmailAddress().WithMessage("Valid email address is required.");
            RuleFor(vm => vm.Password).NotEmpty().WithMessage("Password is required.");
            RuleFor(vm => vm.Confirmpassword).Equal(vm => vm.Password).WithMessage("Passwords do not match.");
        }
    }
}
