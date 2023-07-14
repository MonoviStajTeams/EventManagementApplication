using EventManagementApplication.Business.Concrete;
using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;
using Moq;

namespace EventManagementApplication.Tests
{
    public class UserInvitationMappingTests
    {

        [Fact]
        public void Create_UserInvitationMapping_SuccessfullyCreated()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            IUserInvitationMappingRepository userInvitationMappingRepository = new Mock<IUserInvitationMappingRepository>().Object;
            mockUnitOfWork.Setup(uow => uow.UserInvitationMappings).Returns(userInvitationMappingRepository);

            UserInvitationMappingService userInvitationMappingService = new UserInvitationMappingService(mockUnitOfWork.Object);

            UserInvitationMapping userInvitationMappingToCreate = new UserInvitationMapping
            {
                InvitedId = 1,
                User = new User(),
                Status = true,
                InvitationId = 1,
                Invitation = new Invitation()
            };

            // Act
            userInvitationMappingService.Create(userInvitationMappingToCreate);

            // Assert or further test steps if needed
            // Verify that the userInvitationMapping is created as expected
            mockUnitOfWork.Verify(uow => uow.UserInvitationMappings.Add(userInvitationMappingToCreate), Times.Once);
            mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
        }

        [Fact]
        public void Delete_UserInvitationMapping_SuccessfullyDeleted()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            Mock<IUserInvitationMappingRepository> mockUserInvitationMappingRepository = new Mock<IUserInvitationMappingRepository>();
            mockUnitOfWork.Setup(uow => uow.UserInvitationMappings).Returns(mockUserInvitationMappingRepository.Object);

            UserInvitationMappingService userInvitationMappingService = new UserInvitationMappingService(mockUnitOfWork.Object);

            int userInvitationMappingId = 1;

            UserInvitationMapping existingUserInvitationMapping = new UserInvitationMapping
            {
                Id = userInvitationMappingId,
                InvitedId = 1,
                User = new User(),
                Status = true,
                InvitationId = 1,
                Invitation = new Invitation()
            };

            // Mock the GetById method of the userInvitationMapping repository
            mockUserInvitationMappingRepository.Setup(r => r.GetById(userInvitationMappingId)).Returns(existingUserInvitationMapping);

            // Act
            userInvitationMappingService.Delete(userInvitationMappingId);

            // Assert or further test steps if needed
            // Verify that the userInvitationMapping is deleted as expected
            mockUserInvitationMappingRepository.Verify(r => r.Remove(existingUserInvitationMapping), Times.Once);
            mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
        }

        [Fact]
        public void GetAll_UserInvitationMappings_ReturnsAllUserInvitationMappings()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            IUserInvitationMappingRepository userInvitationMappingRepository = new Mock<IUserInvitationMappingRepository>().Object;
            mockUnitOfWork.Setup(uow => uow.UserInvitationMappings).Returns(userInvitationMappingRepository);

            UserInvitationMappingService userInvitationMappingService = new UserInvitationMappingService(mockUnitOfWork.Object);

            List<UserInvitationMapping> expectedUserInvitationMappings = new List<UserInvitationMapping>
            {
                new UserInvitationMapping
                {
                    Id = 1,
                    InvitedId = 1,
                    User = new User(),
                    Status = true,
                    InvitationId = 1,
                    Invitation = new Invitation()
                },
                new UserInvitationMapping
                {
                    Id = 2,
                    InvitedId = 2,
                    User = new User(),
                    Status = false,
                    InvitationId = 2,
                    Invitation = new Invitation()
                }
            };

            // Mock the GetAll method of the userInvitationMapping repository
            mockUnitOfWork.Setup(uow => uow.UserInvitationMappings.GetAll()).Returns(expectedUserInvitationMappings);

            // Act
            var result = userInvitationMappingService.GetAll();

            // Assert
            Assert.NotNull(result);
            // Perform additional assertions based on your specific implementation
        }

        [Fact]
        public void GetById_ExistingUserInvitationMapping_ReturnsUserInvitationMapping()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            IUserInvitationMappingRepository userInvitationMappingRepository = new Mock<IUserInvitationMappingRepository>().Object;
            mockUnitOfWork.Setup(uow => uow.UserInvitationMappings).Returns(userInvitationMappingRepository);

            UserInvitationMappingService userInvitationMappingService = new UserInvitationMappingService(mockUnitOfWork.Object);

            int existingUserInvitationMappingId = 1;
            UserInvitationMapping expectedUserInvitationMapping = new UserInvitationMapping
            {
                Id = existingUserInvitationMappingId,
                InvitedId = 1,
                User = new User(),
                Status = true,
                InvitationId = 1,
                Invitation = new Invitation()
            };

            // Mock the GetById method of the userInvitationMapping repository
            mockUnitOfWork.Setup(uow => uow.UserInvitationMappings.GetById(existingUserInvitationMappingId)).Returns(expectedUserInvitationMapping);

            // Act
            var result = userInvitationMappingService.GetById(existingUserInvitationMappingId);

            // Assert
            Assert.NotNull(result);
            // Perform additional assertions based on your specific implementation
        }

        [Fact]
        public void Update_ExistingUserInvitationMapping_SuccessfullyUpdated()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            IUserInvitationMappingRepository userInvitationMappingRepository = new Mock<IUserInvitationMappingRepository>().Object;
            mockUnitOfWork.Setup(uow => uow.UserInvitationMappings).Returns(userInvitationMappingRepository);

            UserInvitationMappingService userInvitationMappingService = new UserInvitationMappingService(mockUnitOfWork.Object);

            UserInvitationMapping existingUserInvitationMapping = new UserInvitationMapping
            {
                Id = 1,
                InvitedId = 1,
                User = new User(),
                Status = true,
                InvitationId = 1,
                Invitation = new Invitation()
            };

            // Act
            userInvitationMappingService.Update(existingUserInvitationMapping);

            // Assert or further test steps if needed
            // Verify that the userInvitationMapping is updated as expected
            mockUnitOfWork.Verify(uow => uow.UserInvitationMappings.Update(existingUserInvitationMapping), Times.Once);
            mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
        }
    }
}