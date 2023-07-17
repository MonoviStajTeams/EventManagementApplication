using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.ValidationRules.FluentValidation;
using EventManagementApplication.Core.Aspects.TransactionAspects;
using EventManagementApplication.Core.Aspects.ValidationAspects;
using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.Concrete
{
    [TransactionScopeAspect]
    public class UserInvitationMappingService : IUserInvitationMappingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserInvitationMappingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [FluentValidateAspect(typeof(UserInvitationMappingValidator))]
        public void Create(UserInvitationMapping entity)
        {

            _unitOfWork.UserInvitationMappings.Add(entity);
            _unitOfWork.Save();
        }

       
        public void Delete(int id)
        {
            var userInvitation = _unitOfWork.UserInvitationMappings.GetById(id);
            if (userInvitation != null)
            {
                _unitOfWork.UserInvitationMappings.Remove(userInvitation);
                _unitOfWork.Save();
            }
        }

     
        public IEnumerable<UserInvitationMapping> GetAll()
        {
            return _unitOfWork.UserInvitationMappings.GetAll();
        }

    
        public UserInvitationMapping GetById(int id)
        {
            return _unitOfWork.UserInvitationMappings.GetById(id);

        }

        [FluentValidateAspect(typeof(UserInvitationMappingValidator))]
        public void Update(UserInvitationMapping entity)
        {
            _unitOfWork.UserInvitationMappings.Update(entity);
            _unitOfWork.Save();
        }
    }
}
