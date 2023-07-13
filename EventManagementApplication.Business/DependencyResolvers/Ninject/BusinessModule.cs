using EventManagementApplication.Business.Abstract;
using EventManagementApplication.Business.Concrete;
using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.DataAccess.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEventService>().To<EventService>().InSingletonScope();
            Bind<IEventRepository>().To<EventRepository>().InSingletonScope();

            Bind<ILocationService>().To<LocationService>().InSingletonScope();
            Bind<ILocationRepository>().To<LocationRepository>().InSingletonScope();

            Bind<IEventService>().To<EventService>().InSingletonScope(); // Değiştirilecek
            Bind<IInvitationRepository>().To<InvitationRepository>().InSingletonScope();

            Bind<IEventService>().To<EventService>().InSingletonScope();// Değiştirilecek
            Bind<INotificationRepository>().To<NotificationRepository>().InSingletonScope();

            Bind<IRoleService>().To<RoleService>().InSingletonScope();
            Bind<IRoleRepository>().To<RoleRepository>().InSingletonScope();

            Bind<IEventService>().To<EventService>().InSingletonScope();// Değiştirilecek
            Bind<IUserDetailRepository>().To<UserDetailRepository>().InSingletonScope();

            Bind<IEventService>().To<EventService>().InSingletonScope();// Değiştirilecek
            Bind<IUserInvitationMappingRepository>().To<UserInvitationMappingRepository>().InSingletonScope();

            Bind<IUserService>().To<UserService>().InSingletonScope();// Değiştirilecek
            Bind<IUserRepository>().To<UserRepository>().InSingletonScope();

        }
    }
}
