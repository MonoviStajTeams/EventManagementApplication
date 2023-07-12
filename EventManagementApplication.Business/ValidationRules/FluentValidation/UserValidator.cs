using EventManagementApplication.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FullName).NotNull().NotEmpty().WithMessage("Kullanıcı Ad ve Soyad Boş Olamaz!").Length(0, 100);
            RuleFor(x => x.Mail).NotNull().NotEmpty().WithMessage("Kullanıcı Maili Boş Olamaz!").Length(0, 100);
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Kullanıcı Şifre Boş Olamaz!");
            RuleFor(x => x.ConfirmPassword).NotNull().NotEmpty().WithMessage("Kullanıcı Onay Şifresi Boş Olamaz!");
            RuleFor(x => x.RoleId).NotNull().NotEmpty().WithMessage("Kullanıcı Rolü Boş Olamaz!");
        }
    }
}
