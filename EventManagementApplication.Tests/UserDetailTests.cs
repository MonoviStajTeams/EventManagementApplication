using EventManagementApplication.Business.Concrete;
using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace EventManagementApplication.Tests
{
    public class UserDetailTests
    {
        [ExpectedException(typeof(ValidationException))]
        [Fact]
        public void Create_UserDetail_SuccessfullyCreated()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            IUserDetailRepository userDetailRepository = new Mock<IUserDetailRepository>().Object;
            mockUnitOfWork.Setup(uow => uow.UserDetails).Returns(userDetailRepository);

            UserDetailService userDetailService = new UserDetailService(mockUnitOfWork.Object);

            UserDetail userDetailToCreate = new UserDetail
            {

                PhoneNumber = "123456789",
                ProfileImagePath = "",
                UserId = 1,
                User = new User()
            };

            // Act
            userDetailService.Create(userDetailToCreate);


            mockUnitOfWork.Verify(uow => uow.UserDetails.Add(userDetailToCreate), Times.Once);
            mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
        }
        [ExpectedException(typeof(ValidationException))]
        [Fact]
        public void Delete_ExistingId_SuccessfullyDeleted()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            IUserDetailRepository userDetailRepository = new Mock<IUserDetailRepository>().Object;
            mockUnitOfWork.Setup(uow => uow.UserDetails).Returns(userDetailRepository);

            UserDetailService userDetailService = new UserDetailService(mockUnitOfWork.Object);

            int userIdToDelete = 1;

            // Act
            userDetailService.Delete(userIdToDelete);


        }
        [ExpectedException(typeof(ValidationException))]
        [Fact]
        public void GetAll_ReturnsAllUserDetails()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            IUserDetailRepository userDetailRepository = new Mock<IUserDetailRepository>().Object;
            mockUnitOfWork.Setup(uow => uow.UserDetails).Returns(userDetailRepository);

            UserDetailService userDetailService = new UserDetailService(mockUnitOfWork.Object);

            // Act
            var result = userDetailService.GetAll();

            Xunit.Assert.NotNull(result);
        }
        [ExpectedException(typeof(ValidationException))]
        [Fact]
        public void GetById_ExistingUserDetail_ReturnsUserDetail()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            IUserDetailRepository userDetailRepository = new Mock<IUserDetailRepository>().Object;
            mockUnitOfWork.Setup(uow => uow.UserDetails).Returns(userDetailRepository);

            UserDetailService userDetailService = new UserDetailService(mockUnitOfWork.Object);

            int userDetailId = 1;
            UserDetail expectedUserDetail = new UserDetail
            {
                Id = userDetailId,
                PhoneNumber = "123456789",
                ProfileImagePath = "",
                UserId = 1,
                User = new User()
            };

      
            mockUnitOfWork.Setup(uow => uow.UserDetails.GetById(userDetailId)).Returns(expectedUserDetail);

            // Act
            var result = userDetailService.GetById(userDetailId);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(expectedUserDetail.Id, result.Id);
            Xunit.Assert.Equal(expectedUserDetail.PhoneNumber, result.PhoneNumber);
            Xunit.Assert.Equal(expectedUserDetail.ProfileImagePath, result.ProfileImagePath);
            
        }
        [ExpectedException(typeof(ValidationException))]
        [Fact]
        public void Update_UserDetail_SuccessfullyUpdated()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            IUserDetailRepository userDetailRepository = new Mock<IUserDetailRepository>().Object;
            mockUnitOfWork.Setup(uow => uow.UserDetails).Returns(userDetailRepository);

            UserDetailService userDetailService = new UserDetailService(mockUnitOfWork.Object);

            UserDetail userDetailToUpdate = new UserDetail
            {
                Id = 1,
                PhoneNumber = "234567891",
                ProfileImagePath = "",
                UserId = 1,
                User = new User()
            };

            // Act
            userDetailService.Update(userDetailToUpdate);

            // Assert or further test steps if needed
            // Verify that the event is updated as expected
            mockUnitOfWork.Verify(uow => uow.UserDetails.Update(userDetailToUpdate), Times.Once);
            mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
        }

    }
}