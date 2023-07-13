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

            Bind<IInvitationService>().To<InvitationService>().InSingletonScope(); 
            Bind<IInvitationRepository>().To<InvitationRepository>().InSingletonScope();

            Bind<INotificationService>().To<NotificationService>().InSingletonScope();
            Bind<INotificationRepository>().To<NotificationRepository>().InSingletonScope();

            Bind<IRoleService>().To<RoleService>().InSingletonScope();
            Bind<IRoleRepository>().To<RoleRepository>().InSingletonScope();

            Bind<IUserDetailService>().To<UserDetailService>().InSingletonScope();
            Bind<IUserDetailRepository>().To<UserDetailRepository>().InSingletonScope();

            Bind<IUserInvitationMappingService>().To<UserInvitationMappingService>().InSingletonScope();
            Bind<IUserInvitationMappingRepository>().To<UserInvitationMappingRepository>().InSingletonScope();

            Bind<IUserService>().To<UserService>().InSingletonScope();
            Bind<IUserRepository>().To<UserRepository>().InSingletonScope();

        }
    }
}
