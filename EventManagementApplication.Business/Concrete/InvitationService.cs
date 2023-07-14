using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using EventManagementApplication.Entities.Concrete;
using EventManagementApplication.Business.Abstract;
using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Core.Aspects.TransactionAspects;

namespace EventManagementApplication.Business.Concrete
{
    public class InvitationService : IInvitationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvitationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [TransactionScopeAspect]
        public void Create(Invitation entity)
        {
            _unitOfWork.Invitations.Add(entity);
            _unitOfWork.Save();
        }

        [TransactionScopeAspect]
        public void Delete(int id)
        {
            var invitation = _unitOfWork.Invitations.GetById(id);
            if (invitation != null)
            {
                _unitOfWork.Invitations.Remove(invitation);
                _unitOfWork.Save();
            }
        }

        [TransactionScopeAspect]
        public IEnumerable<Invitation> GetAll()
        {
            return _unitOfWork.Invitations.GetAll();
        }

        [TransactionScopeAspect]
        public Invitation GetById(int id)
        {
            return _unitOfWork.Invitations.GetById(id);
        }

        [TransactionScopeAspect]
        public void Update(Invitation entity)
        {
            _unitOfWork.Invitations.Update(entity);
            _unitOfWork.Save();
        }

        [TransactionScopeAspect]
        public void SendInvitationMail(int invitationId)  //maile gönderme
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


                            //var mailMessage = new MailMessage();
                            //mailMessage.Subject = subject;
                            //mailMessage.Body = body;
                            //mailMessage.To.Add(selectedUser);
                            //smtpClient.Send(mailMessage);
                        }
                    
                }
            }
        }

    }
}
