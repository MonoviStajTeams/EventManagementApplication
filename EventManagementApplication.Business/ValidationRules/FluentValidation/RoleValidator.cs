using EventManagementApplication.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.ValidationRules.FluentValidation
{
    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Kullanıcı Rolü Boş Olamaz!").Length(0, 50);
        }
    }
}
