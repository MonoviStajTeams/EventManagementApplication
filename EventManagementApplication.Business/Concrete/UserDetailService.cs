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
    //[TransactionScopeAspect]
    public class UserDetailService : IUserDetailService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(UserDetail entity)
        {

            _unitOfWork.UserDetails.Add(entity);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var userDetail = _unitOfWork.UserDetails.GetById(id);
            if (userDetail != null)
            {
                _unitOfWork.UserDetails.Remove(userDetail);
                _unitOfWork.Save();
            }
        }

        public IEnumerable<UserDetail> GetAll()
        {
            return _unitOfWork.UserDetails.GetAll();
        }

        public UserDetail GetById(int id)
        {
            return _unitOfWork.UserDetails.GetById(id);

        }

        public void Update(UserDetail entity)
        {
            _unitOfWork.UserDetails.Update(entity);
            _unitOfWork.Save();
        }


        public UserDetail GetUserDetailByUserId(int id)
        {
            return _unitOfWork.UserDetails.GetUserDetailByUserId(id);
        }
    }
}
