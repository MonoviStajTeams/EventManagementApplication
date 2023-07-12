using EventManagementApplication.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.ValidationRules.FluentValidation
{
    public class UserInvitationMappingValidator : AbstractValidator<UserInvitationMapping>
    {
        public UserInvitationMappingValidator()
        {
            RuleFor(x => x.InvitedId).NotNull().NotEmpty().WithMessage("Davetli Id Boş Olamaz!");
            RuleFor(x => x.InvitationId).NotNull().NotEmpty().WithMessage("Davetiye Id Boş Olamaz!");
        }
    }
}
