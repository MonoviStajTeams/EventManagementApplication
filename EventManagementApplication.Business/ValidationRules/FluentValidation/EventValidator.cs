using EventManagementApplication.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.ValidationRules.FluentValidation
{
    public class EventValidator : AbstractValidator<Event>
    {
        public EventValidator()
        {

            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("Etkinlik Başlıkğı Boş Olamaz!").Length(0, 300);
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Etkinlik Açıklaması Boş Olamaz!");
            RuleFor(x => x.Type).NotNull().NotEmpty().WithMessage("Etkinlik Tipi Boş Olamaz!").Length(0, 150);
            RuleFor(x => x.StartTime).NotNull().NotEmpty().WithMessage("Etkinlik Başlangıç Saati Boş Olamaz!").Length(0, 10);
            RuleFor(x => x.EndTime).NotNull().NotEmpty().WithMessage("Etkinlik Bitiş Saati Boş Olamaz!").Length(0, 10);
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("Etkinliği Oluşturan  Boş Olamaz!");
        }
    }
}
