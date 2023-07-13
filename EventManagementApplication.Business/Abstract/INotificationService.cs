using EventManagementApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        void Create(Notification entity);
        void Delete(int id);
        IEnumerable<Notification> GetAll();
        Notification GetById(int id);
        void Update(Notification entity);
    }
}
