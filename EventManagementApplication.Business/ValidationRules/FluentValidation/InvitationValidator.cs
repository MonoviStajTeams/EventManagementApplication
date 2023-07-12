using EventManagementApplication.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.ValidationRules.FluentValidation
{
    public class InvitationValidator : AbstractValidator<Invitation>
    {
        public InvitationValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("Etkinlik Başlıkğı Boş Olamaz!").Length(0, 300);
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Etkinlik Açıklaması Boş Olamaz!");
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("Davetiye Oluşturan Id Boş Olamaz!");
            RuleFor(x => x.EventId).NotNull().NotEmpty().WithMessage("Etkinlik Id Boş Olamaz!");
        }
    }
}
