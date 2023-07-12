using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.ValidationRules.FluentValidation;
using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.Concrete
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
        public void Create(Location entity)
        {

            _unitOfWork.Locations.Add(entity);
            _unitOfWork.Save();
        }

        
        public void Delete(int id)
        {
            var location = _unitOfWork.Locations.GetById(id);
            if (location != null)
            {
                _unitOfWork.Locations.Remove(location);
                _unitOfWork.Save();
            }
        }

       
        public IEnumerable<Location> GetAll()
        {
            return _unitOfWork.Locations.GetAll();
        }

        public Location GetById(int id)
        {
            return _unitOfWork.Locations.GetById(id);
        }

       
        public void Update(Location entity)
        {

            _unitOfWork.Locations.Update(entity);
            _unitOfWork.Save();
        }
    }
}
