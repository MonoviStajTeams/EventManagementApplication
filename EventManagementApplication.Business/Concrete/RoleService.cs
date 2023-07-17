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

    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [FluentValidateAspect(typeof(RoleValidator))]
        public void Create(Role role)
        {
            _unitOfWork.Roles.Add(role);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var user = _unitOfWork.Roles.GetById(id);
            if (user != null)
            {
                _unitOfWork.Roles.Remove(user);
                _unitOfWork.Save();
            }
        }

        public IEnumerable<Role> GetAll()
        {
            return _unitOfWork.Roles.GetAll();
        }

        public Role GetById(int id)
        {
            return _unitOfWork.Roles.GetById(id);
        }


        [FluentValidateAspect(typeof(RoleValidator))]
        public void Update(Role role)
        {
            _unitOfWork.Roles.Update(role);
            _unitOfWork.Save();
        }
    }
}