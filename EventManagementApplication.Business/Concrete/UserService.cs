using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.ValidationRules.FluentValidation;
using EventManagementApplication.Core.Aspects.TransactionAspects;
using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [TransactionScopeAspect]
        public void Create(User user)
        {
            _unitOfWork.Users.Add(user);
            _unitOfWork.Save();
        }

        [TransactionScopeAspect]
        public void Delete(int id)
        {
            var user = _unitOfWork.Users.GetById(id);
            if (user != null)
            {
                _unitOfWork.Users.Remove(user);
                _unitOfWork.Save();
            }
        }

        [TransactionScopeAspect]
        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.Users.GetAll();
        }

        [TransactionScopeAspect]
        public User GetById(int id)
        {
            return _unitOfWork.Users.GetById(id);
        }

        [TransactionScopeAspect]
        public void Update(User entity)
        {
            _unitOfWork.Users.Update(entity);
            _unitOfWork.Save();
        }
    }
}