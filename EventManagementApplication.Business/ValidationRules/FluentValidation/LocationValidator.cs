using EventManagementApplication.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.ValidationRules.FluentValidation
{
    public class LocationValidator : AbstractValidator<Location>
    {
        public LocationValidator()
        {
            RuleFor(x => x.Line).NotNull().NotEmpty().WithMessage("Entkinlik Adres Satırı Boş Olamaz!").Length(0, 300);
            RuleFor(x => x.City).NotNull().NotEmpty().WithMessage("Etkinlik Şehri Boş Olamaz!").Length(0, 50);
            RuleFor(x => x.District).NotNull().NotEmpty().WithMessage("Etkinlik İlçesi Boş Olamaz!").Length(0, 50);
            RuleFor(x => x.ZipCode).NotNull().NotEmpty().WithMessage("Etkinlik Adresin Zip Kodu Boş Olamaz!").Length(0, 6);
            RuleFor(x => x.EventId).NotNull().NotEmpty().WithMessage("Etkinlik Id Boş Olamaz!");
        }
    }
}
