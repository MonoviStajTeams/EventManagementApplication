using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.ValidationRules.FluentValidation;
using EventManagementApplication.Core.Aspects.TransactionAspects;
using EventManagementApplication.Core.Aspects.ValidationAspects;
using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

      
        public void Create(User user)
        {
            _unitOfWork.Users.Add(user);
            _unitOfWork.Save();
        }

      
        public void Delete(int id)
        {
            var user = _unitOfWork.Users.GetById(id);
            if (user != null)
            {
                _unitOfWork.Users.Remove(user);
                _unitOfWork.Save();
            }
        }

      
        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.Users.GetAll();
        }

        public User GetById(int id)
        {
            return _unitOfWork.Users.GetById(id);
        }

        public User GetByMail(string mail)
        {
            return _unitOfWork.Users.GetUserByMail(mail);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _unitOfWork.Users.GetClaims(user);
        }



        public void Update(User entity)
        {
            _unitOfWork.Users.Update(entity);
            _unitOfWork.Save();
        }

        public IEnumerable<User> GetUsers()
        {
            var users = _unitOfWork.Users.GetAll();
            return users;
        }


    }
}