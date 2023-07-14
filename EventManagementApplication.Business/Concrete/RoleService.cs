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
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [TransactionScopeAspect]
        public void Create(Role role)
        {
            _unitOfWork.Roles.Add(role);
            _unitOfWork.Save();
        }

        [TransactionScopeAspect]
        public void Delete(int id)
        {
            var user = _unitOfWork.Roles.GetById(id);
            if (user != null)
            {
                _unitOfWork.Roles.Remove(user);
                _unitOfWork.Save();
            }
        }

        [TransactionScopeAspect]
        public IEnumerable<Role> GetAll()
        {
            return _unitOfWork.Roles.GetAll();
        }

        [TransactionScopeAspect]
        public Role GetById(int id)
        {
            return _unitOfWork.Roles.GetById(id);
        }

        [TransactionScopeAspect]
        public void Update(Role role)
        {
            _unitOfWork.Roles.Update(role);
            _unitOfWork.Save();
        }
    }
}