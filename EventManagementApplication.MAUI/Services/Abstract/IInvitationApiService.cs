﻿using EventManagementApplication.MAUI.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.MAUI.Services.Abstract
{
    public interface IInvitationApiService : IGenericApiService<InvitationApiResponse>
    {
        Task<int> GetLastInvitationIdAsync();
        Task SendInvitationMailAsync(int invitationId);
    }
}
