using EventManagementApplication.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.ValidationRules.FluentValidation
{
    public class UserDetailValidator : AbstractValidator<UserDetail>
    {
        public UserDetailValidator()
        {
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().WithMessage("Kullanıcı Telefon Numarası Boş Olamaz!").Length(0, 20);
            RuleFor(x => x.ProfileImagePath).NotNull().NotEmpty().WithMessage("Kullanıcı Profil Fotoğrafı Olamaz!");
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("Kullanıcı Id Boş Olamaz!");

        }
    }
}
