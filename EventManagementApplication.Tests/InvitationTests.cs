using EventManagementApplication.Business.Concrete;
using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EventManagementApplication.Tests
{
    public class InvitationTests
    {
        [ExpectedException(typeof(ValidationException))]
        [Fact]
        public void Create_Invitation_SuccessfullyCreated()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            IInvitationRepository invitationRepository = new Mock<IInvitationRepository>().Object;
            mockUnitOfWork.Setup(uow => uow.Invitations).Returns(invitationRepository);

            InvitationService invitationService = new InvitationService(mockUnitOfWork.Object);

            Invitation invitationToCreate = new Invitation
            {
                Title = "Test Invitation",
                Description = "Invitation Description",
                UserId = 1,
                User = new User(),
                EventId = 1,
                Event = new Event()
            };

            // Act
            invitationService.Create(invitationToCreate);


            mockUnitOfWork.Verify(uow => uow.Invitations.Add(invitationToCreate), Times.Once);
            mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
        }

        [ExpectedException(typeof(ValidationException))]
        [Fact]
        public void Delete_ExistingInvitation_SuccessfullyDeleted()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            IInvitationRepository invitationRepository = new Mock<IInvitationRepository>().Object;
            mockUnitOfWork.Setup(uow => uow.Invitations).Returns(invitationRepository);

            InvitationService invitationService = new InvitationService(mockUnitOfWork.Object);

            int invitationIdToDelete = 1;

            // Act
            invitationService.Delete(invitationIdToDelete);


        }

        [ExpectedException(typeof(ValidationException))]
        [Fact]
        public void Get_All_Invitations()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            Mock<IInvitationRepository> mockInvitationRepository = new Mock<IInvitationRepository>();

            List<Invitation> expectedInvitations = new List<Invitation>()
            {
                new Invitation { Id = 1,Title = "Test Invitation",Description = "Invitation Description", User = new User(),UserId=1,Event = new Event(), EventId = 1 },
                new Invitation { Id = 2,Title = "Test Invitation 2",Description = "Invitation Description 2", User = new User(),UserId=2,Event = new Event(), EventId = 2 },

            };

            mockUnitOfWork.Setup(uow => uow.Invitations.GetAll()).Returns(expectedInvitations);

            InvitationService invitationService = new InvitationService(mockUnitOfWork.Object);

            // Act
            IEnumerable<Invitation> invitations = invitationService.GetAll();

            // Assert
            Xunit.Assert.Equal(expectedInvitations, invitations);
        }

        [ExpectedException(typeof(ValidationException))]
        [Fact]
        public void Update_Invitation_SuccessfullyUpdated()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            IInvitationRepository invitationRepository = new Mock<IInvitationRepository>().Object;
            mockUnitOfWork.Setup(uow => uow.Invitations).Returns(invitationRepository);

            InvitationService invitationService = new InvitationService(mockUnitOfWork.Object);

            Invitation invitationToUpdate = new Invitation
            {
                Id = 1,
                Title = "Test Event 2",
                Description = "Event Description 2",
                UserId = 2,
                User = new User()
            };

            // Act
            invitationService.Update(invitationToUpdate);

            // Assert or further test steps if needed
            // Verify that the event is updated as expected
            mockUnitOfWork.Verify(uow => uow.Invitations.Update(invitationToUpdate), Times.Once);
            mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
        }

        [ExpectedException(typeof(ValidationException))]
        [Fact]
        public void GetById_Invitation()
        {
            // Arrange
            int invitationId = 1;
            Invitation expectedInvitation = new Invitation { Id = invitationId, Title = "Test Invitation", Description = "Invitation Description", User = new User(), UserId = 1, Event = new Event(), EventId = 1 };

            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            Mock<IInvitationRepository> mockInvitationRepository = new Mock<IInvitationRepository>();

            mockUnitOfWork.Setup(uow => uow.Invitations.GetById(invitationId)).Returns(expectedInvitation);

            InvitationService invitationService = new InvitationService(mockUnitOfWork.Object);

            // Act
            Invitation invitation = invitationService.GetById(invitationId);

            // Assert
            Xunit.Assert.Equal(expectedInvitation, invitation);
        }


    }
}