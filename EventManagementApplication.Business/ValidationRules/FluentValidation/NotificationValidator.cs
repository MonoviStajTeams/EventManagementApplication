using EventManagementApplication.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.ValidationRules.FluentValidation
{
    public class NotificationValidator : AbstractValidator<Notification>
    {
        public NotificationValidator()
        {
            RuleFor(x => x.ReceivingId).NotNull().NotEmpty().WithMessage("Bildirim Alan Id Boş Olamaz!");
            RuleFor(x => x.InvitationId).NotNull().NotEmpty().WithMessage("Bildirim Gönderen Id Boş Olamaz!");
        }
    }
}
