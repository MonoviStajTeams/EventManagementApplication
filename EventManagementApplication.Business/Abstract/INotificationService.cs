﻿using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        void SendInvitationNotification(Invitation invitation, User user);
        void SendReminderNotifications();
    }
}
