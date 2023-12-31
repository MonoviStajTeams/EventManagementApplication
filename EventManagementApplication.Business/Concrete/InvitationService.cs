using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using EventManagementApplication.Entities.Concrete;
using EventManagementApplication.Business.Abstract;
using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Core.Aspects.TransactionAspects;
using EventManagementApplication.Business.ValidationRules.FluentValidation;
using EventManagementApplication.Core.Aspects.ValidationAspects;

namespace EventManagementApplication.Business.Concrete
{
    public class InvitationService : IInvitationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvitationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void Create(Invitation entity)
        {
            _unitOfWork.Invitations.Add(entity);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var invitation = _unitOfWork.Invitations.GetById(id);
            if (invitation != null)
            {
                _unitOfWork.Invitations.Remove(invitation);
                _unitOfWork.Save();
            }
        }

        public IEnumerable<Invitation> GetAll()
        {
            return _unitOfWork.Invitations.GetAll();
        }

        public Invitation GetById(int id)
        {
            return _unitOfWork.Invitations.GetById(id);
        }
        public void Update(Invitation entity)
        {
            _unitOfWork.Invitations.Update(entity);
            _unitOfWork.Save();
        }

        public void SendInvitationMail(int invitationId)  //maile g�nderme
        {
            var invitation = _unitOfWork.Invitations.GetById(invitationId);

            if (invitation != null)
            {

                var selectedEvent = _unitOfWork.Events.GetAll().Where(e => e.Id == invitation.EventId);

                if (selectedEvent != null)
                {
                        var selectedUser = _unitOfWork.Users.GetAll().Where(u => u.Id == invitation.UserId);
                        var subject = invitation.Title;
                        var body = invitation.Description;

                        if (selectedUser != null)
                        {
                            var smtpClient = new SmtpClient("mail.yipadanismanlik.com", 465);
                            smtpClient.EnableSsl = true;
                            smtpClient.Timeout = 10000;
                            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtpClient.UseDefaultCredentials = false;
                            smtpClient.Credentials = new System.Net.NetworkCredential("test@yipadanismanlik.com", "monovi1234");


                        var mailMessage = new MailMessage("test@yipadanismanlik.com", "test@yipadanismanlik.com", subject,body);
              
                        smtpClient.Send(mailMessage);
                    }
                    
                }
            }
        }

        public int GetLastInvitationId()
        {
            int lastUsedId = _unitOfWork.Invitations.GetLastInvitationId();
            if (lastUsedId == null)
            {
                lastUsedId = 10;
            }

            int newId = lastUsedId + 1;

            return newId;
        }

        public IEnumerable<User> GetUsers()
        {
            var users = _unitOfWork.Users.GetAll();
            return users;
        }

        public IEnumerable<Invitation> GetInvitationsByUserId(int id)
        {
            var invitationMappings = _unitOfWork.UserInvitationMappings.GetByUserId(id);

            var invitations = new List<Invitation>();

            foreach (var invitationMapping in invitationMappings)
            {
                var invitation = _unitOfWork.Invitations.GetByIdWithIncludes(invitationMapping.InvitationId,x=>x.Event);
                invitations.Add(invitation);
            }

            return invitations;
        }

        public void AcceptInvitation(int userId, int invitationId)
        {
            var mapping = _unitOfWork.UserInvitationMappings.GetByUserId(userId).FirstOrDefault(x => x.InvitationId == invitationId);
            mapping!.Status = true;
            _unitOfWork.UserInvitationMappings.Update(mapping!);
            _unitOfWork.Save();
        }

        public void RejectInvitation(int userId, int invitationId)
        {
            var mapping = _unitOfWork.UserInvitationMappings.GetByUserId(userId).FirstOrDefault(x => x.InvitationId == invitationId);
            _unitOfWork.UserInvitationMappings.Remove(mapping!);
            _unitOfWork.Save();
        }
    }
}
