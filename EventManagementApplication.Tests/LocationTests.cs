using EventManagementApplication.Business.Concrete;
using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;
using Moq;
using Xunit;
namespace EventManagementApplication.Tests
{
    public class LocationTests
    {
        
        [Fact]
        public void Create_AddsLocationToUnitOfWorkAndSaves()
        {
            
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var locationRepositoryMock = new Mock<ILocationRepository>();
            var locationToCreate = new Location();

            unitOfWorkMock.SetupGet(uow => uow.Locations).Returns(locationRepositoryMock.Object);

            var locationService = new LocationService(unitOfWorkMock.Object);

           
            locationService.Create(locationToCreate);

          
            locationRepositoryMock.Verify(repo => repo.Add(locationToCreate), Times.Once);

            unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
        }

        [Fact]
        public void Update_UpdatesLocationInUnitOfWorkAndSaves()
        {
            
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var locationRepositoryMock = new Mock<ILocationRepository>();

            var locationToUpdate = new Location();

            unitOfWorkMock.SetupGet(uow => uow.Locations).Returns(locationRepositoryMock.Object);

            var locationService = new LocationService(unitOfWorkMock.Object);

            
            locationService.Update(locationToUpdate);

           
            locationRepositoryMock.Verify(repo => repo.Update(locationToUpdate), Times.Once);

            unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
        }

        [Fact]
        public void Delete_ExistingLocation_SuccessfullyDeleted()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var locationRepositoryMock = new Mock<ILocationRepository>();

            var locationToDelete = new Location();

            unitOfWorkMock.SetupGet(uow => uow.Locations).Returns(locationRepositoryMock.Object);

            var locationService = new LocationService(unitOfWorkMock.Object);
            
            locationService.Delete(locationToDelete);
           
            locationRepositoryMock.Verify(repo => repo.Delete(locationToDelete), Times.Once);

            unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
        }

        [Fact]
        public void GetById_ExistingLocation_ReturnsLocation()
        {
            
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var locationRepositoryMock = new Mock<ILocationRepository>();

            var locationId = 1;

            var expectedLocation = new Location { Id = locationId };

            locationRepositoryMock.Setup(repo => repo.GetById(locationId)).Returns(expectedLocation);

            unitOfWorkMock.SetupGet(uow => uow.Locations).Returns(locationRepositoryMock.Object);

            var locationService = new LocationService(unitOfWorkMock.Object);

            
            var result = locationService.GetById(locationId);

            
            Assert.Equal(expectedLocation, result);
        }
    }
}