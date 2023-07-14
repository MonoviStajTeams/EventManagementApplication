using EventManagementApplication.Business.Concrete;
using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EventManagementApplication.Tests
{
    public class NotificationTests
    {

        [ExpectedException(typeof(ValidationException))]
        [Fact]
        public void Notification_validaiton_check()
        {
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();

            INotificationRepository notificationRepository = new Mock<INotificationRepository>().Object;
            mockUnitOfWork.Setup(uow => uow.Notifications).Returns(notificationRepository);

            NotificationService notificationService = new NotificationService(mockUnitOfWork.Object);



            notificationService.Create(new Notification
            {
                Id= 1,
                InvitationId= 1,
                Invitation = new Invitation(),
                ReceivingId = 1,
                User = new User(),
            });
         
        }


        [Fact]
        public void Get_all_notifications()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            Mock<INotificationRepository> mockNotificationRepository = new Mock<INotificationRepository>();

            List<Notification> expectedNotifications = new List<Notification>()
            {
                new Notification { Id = 1,ReceivingId = 1, User = new User(), InvitationId = 1,Invitation = new Invitation() },
                new Notification { Id = 2,ReceivingId = 2, User = new User(), InvitationId = 2,Invitation = new Invitation() },
                new Notification { Id = 3,ReceivingId = 3, User = new User(), InvitationId = 3,Invitation = new Invitation() }
            };

            mockUnitOfWork.Setup(uow => uow.Notifications.GetAll()).Returns(expectedNotifications);

            NotificationService notificationService = new NotificationService(mockUnitOfWork.Object);

            // Act
            IEnumerable<Notification> notifications = notificationService.GetAll();

            // Assert
            Xunit.Assert.Equal(expectedNotifications, notifications);
        }

        [Fact]
        public void Update_notification_successfully()
        {
            // Arrange
            Notification existingNotification = new Notification { Id = 1, ReceivingId = 1, User = new User(), InvitationId = 1, Invitation = new Invitation() };
            Notification updatedNotification = new Notification { Id = 1, ReceivingId = 1, User = new User(), InvitationId = 2, Invitation = new Invitation() };

            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            Mock<INotificationRepository> mockNotificationRepository = new Mock<INotificationRepository>();

            mockUnitOfWork.Setup(uow => uow.Notifications.GetById(existingNotification.Id)).Returns(existingNotification);

            NotificationService notificationService = new NotificationService(mockUnitOfWork.Object);

            // Act
            notificationService.Update(updatedNotification);

            // Assert
            mockUnitOfWork.Verify(uow => uow.Notifications.Update(updatedNotification), Times.Once);
            mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
        }

        [Fact]
        public void Get_notification_by_id()
        {
            // Arrange
            int notificationId = 1;
            Notification expectedNotification = new Notification { Id = notificationId, ReceivingId = 1, User = new User(), InvitationId = 1, Invitation = new Invitation() };

            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            Mock<INotificationRepository> mockNotificationRepository = new Mock<INotificationRepository>();

            mockUnitOfWork.Setup(uow => uow.Notifications.GetById(notificationId)).Returns(expectedNotification);

            NotificationService notificationService = new NotificationService(mockUnitOfWork.Object);

            // Act
            Notification notification = notificationService.GetById(notificationId);

            // Assert
            Xunit.Assert.Equal(expectedNotification, notification);
        }
    }
}