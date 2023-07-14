using EventManagementApplication.Business.Concrete;
using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;
using Moq;

namespace EventManagementApplication.Tests
{
    public class EventTests
    {
        [Fact]
        public void Create_AddsEventToUnitOfWorkAndSaves()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var eventRepositoryMock = new Mock<IEventRepository>();
            var eventToCreate = new Event();

            unitOfWorkMock.SetupGet(uow => uow.Events).Returns(eventRepositoryMock.Object);

            var eventService = new EventService(unitOfWorkMock.Object);

            // Act
            eventService.Create(eventToCreate);

            // Assert
            eventRepositoryMock.Verify(repo => repo.Add(eventToCreate), Times.Once);
            unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
        }

        [Fact]
        public void Update_UpdatesEventInUnitOfWorkAndSaves()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var eventRepositoryMock = new Mock<IEventRepository>();
            var eventToUpdate = new Event();

            unitOfWorkMock.SetupGet(uow => uow.Events).Returns(eventRepositoryMock.Object);

            var eventService = new EventService(unitOfWorkMock.Object);

            // Act
            eventService.Update(eventToUpdate);

            // Assert
            eventRepositoryMock.Verify(repo => repo.Update(eventToUpdate), Times.Once);
            unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
        }

        [Fact]
        public void ActivateEvent_DoesNotUpdateEvent_WhenEventDoesNotExist()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var eventRepositoryMock = new Mock<IEventRepository>();
            var eventId = 1;
            var newDate = DateTime.Now.AddDays(1);
            var newStartTime = "9:00 AM";
            var newEndTime = "11:00 AM";

            eventRepositoryMock.Setup(repo => repo.GetById(eventId)).Returns((Event)null);
            unitOfWorkMock.SetupGet(uow => uow.Events).Returns(eventRepositoryMock.Object);

            var eventService = new EventService(unitOfWorkMock.Object);

            // Act
            eventService.ActivateEvent(eventId, newDate, newStartTime, newEndTime);

            // Assert
            eventRepositoryMock.Verify(repo => repo.Update(It.IsAny<Event>()), Times.Never);
            unitOfWorkMock.Verify(uow => uow.Save(), Times.Never);
        }

        [Fact]
        public void ActivateEvent_UpdatesExistingEventAndSaves()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var eventRepositoryMock = new Mock<IEventRepository>();
            var eventId = 1;
            var existingEvent = new Event { Id = eventId };
            var newDate = DateTime.Now.AddDays(1);
            var newStartTime = "9:00 AM";
            var newEndTime = "11:00 AM";

            eventRepositoryMock.Setup(repo => repo.GetById(eventId)).Returns(existingEvent);
            unitOfWorkMock.SetupGet(uow => uow.Events).Returns(eventRepositoryMock.Object);

            var eventService = new EventService(unitOfWorkMock.Object);

            // Act
            eventService.ActivateEvent(eventId, newDate, newStartTime, newEndTime);

            // Assert
            Assert.Equal(newDate, existingEvent.Date);
            Assert.Equal(newStartTime, existingEvent.StartTime);
            Assert.Equal(newEndTime, existingEvent.EndTime);
            Assert.True(existingEvent.Status);
            eventRepositoryMock.Verify(repo => repo.Update(existingEvent), Times.Once);
            unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
        }

        [Fact]
        public void CreateEvent_ValidEvent_SuccessfullyCreated()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            IEventRepository eventRepository = new Mock<IEventRepository>().Object;
            mockUnitOfWork.Setup(uow => uow.Events).Returns(eventRepository);

            EventService eventService = new EventService(mockUnitOfWork.Object);

            Event eventToCreate = new Event
            {
                Title = "Test Event",
                Description = "Event Description",
                Date = DateTime.Now,
                Type = "Event Type",
                Status = true,
                StartTime = "10:00 AM",
                EndTime = "12:00 PM",
                UserId = 1,
                User = new User()
            };

            // Act
            eventService.Create(eventToCreate);


            mockUnitOfWork.Verify(uow => uow.Events.Add(eventToCreate), Times.Once);
            mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
        }

        [Fact]
        public void DeleteEvent_ExistingEvent_SuccessfullyDeleted()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            IEventRepository eventRepository = new Mock<IEventRepository>().Object;
            mockUnitOfWork.Setup(uow => uow.Events).Returns(eventRepository);

            EventService eventService = new EventService(mockUnitOfWork.Object);

            int eventIdToDelete = 1;

            // Act
            eventService.Delete(eventIdToDelete);


        }

        [Fact]
        public void GetAllEvents_ReturnsAllEvents()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            IEventRepository eventRepository = new Mock<IEventRepository>().Object;
            mockUnitOfWork.Setup(uow => uow.Events).Returns(eventRepository);

            EventService eventService = new EventService(mockUnitOfWork.Object);

            // Act
            var result = eventService.GetAll();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetById_ExistingEvent_ReturnsEvent()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            IEventRepository eventRepository = new Mock<IEventRepository>().Object;
            mockUnitOfWork.Setup(uow => uow.Events).Returns(eventRepository);

            EventService eventService = new EventService(mockUnitOfWork.Object);

            int eventId = 1;
            Event expectedEvent = new Event
            {
                Id = eventId,
                Title = "Test Event",
                Description = "Event Description",
                Date = DateTime.Now,
                Type = "Event Type",
                Status = true,
                StartTime = "10:00 AM",
                EndTime = "12:00 PM",
                UserId = 1,
                User = new User()
            };

            // Mock the GetById method of the event repository
            mockUnitOfWork.Setup(uow => uow.Events.GetById(eventId)).Returns(expectedEvent);

            // Act
            var result = eventService.GetById(eventId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedEvent.Id, result.Id);
            Assert.Equal(expectedEvent.Title, result.Title);
            // Perform additional assertions based on your specific implementation
        }

        [Fact]
        public void Update_ExistingEvent_SuccessfullyUpdated()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            IEventRepository eventRepository = new Mock<IEventRepository>().Object;
            mockUnitOfWork.Setup(uow => uow.Events).Returns(eventRepository);

            EventService eventService = new EventService(mockUnitOfWork.Object);

            Event eventToUpdate = new Event
            {
                Id = 1,
                Title = "Test Event",
                Description = "Event Description",
                Date = DateTime.Now,
                Type = "Event Type",
                Status = true,
                StartTime = "10:00 AM",
                EndTime = "12:00 PM",
                UserId = 1,
                User = new User()
            };

            // Act
            eventService.Update(eventToUpdate);

            // Assert or further test steps if needed
            // Verify that the event is updated as expected
            mockUnitOfWork.Verify(uow => uow.Events.Update(eventToUpdate), Times.Once);
            mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
        }

        [Fact]
        public void GetInactiveEventsByUserId_ExistingUser_ReturnsInactiveEvents()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            IEventRepository eventRepository = new Mock<IEventRepository>().Object;
            mockUnitOfWork.Setup(uow => uow.Events).Returns(eventRepository);

            EventService eventService = new EventService(mockUnitOfWork.Object);

            int userId = 1;
            List<Event> events = new List<Event>
            {
                new Event
                {
                    Id = 1,
                    Title = "Event 1",
                    Description = "Event Description 1",
                    Date = DateTime.Now.AddDays(-2),
                    Type = "Event Type 1",
                    Status = false,
                    StartTime = "10:00 AM",
                    EndTime = "12:00 PM",
                    UserId = userId,
                    User = new User()
                },
                new Event
                {
                    Id = 2,
                    Title = "Event 2",
                    Description = "Event Description 2",
                    Date = DateTime.Now.AddDays(-1),
                    Type = "Event Type 2",
                    Status = false,
                    StartTime = "1:00 PM",
                    EndTime = "3:00 PM",
                    UserId = userId,
                    User = new User()
                },
                new Event
                {
                    Id = 3,
                    Title = "Event 3",
                    Description = "Event Description 3",
                    Date = DateTime.Now.AddDays(-3),
                    Type = "Event Type 3",
                    Status = true,
                    StartTime = "4:00 PM",
                    EndTime = "6:00 PM",
                    UserId = userId,
                    User = new User()
                }
            };

            // Mock the GetAll method of the event repository
            mockUnitOfWork.Setup(uow => uow.Events.GetAll()).Returns(events);

            // Act
            var result = eventService.GetInactiveEventsByUserId(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            // Perform additional assertions based on your specific implementation
        }

        [Fact]
        public void ActivateEvent_ExistingEvent_SuccessfullyActivated()
        {
            // Arrange
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            IEventRepository eventRepository = new Mock<IEventRepository>().Object;
            mockUnitOfWork.Setup(uow => uow.Events).Returns(eventRepository);

            EventService eventService = new EventService(mockUnitOfWork.Object);

            int eventId = 1;
            DateTime newDate = DateTime.Now.AddDays(7);
            string newStartTime = "9:00 AM";
            string newEndTime = "11:00 AM";

            Event existingEvent = new Event
            {
                Id = eventId,
                Title = "Existing Event",
                Description = "Existing Event Description",
                Date = DateTime.Now,
                Type = "Existing Event Type",
                Status = false,
                StartTime = "10:00 AM",
                EndTime = "12:00 PM",
                UserId = 1,
                User = new User()
            };

            // Mock the GetById method of the event repository
            mockUnitOfWork.Setup(uow => uow.Events.GetById(eventId)).Returns(existingEvent);

            // Act
            eventService.ActivateEvent(eventId, newDate, newStartTime, newEndTime);

            // Assert or further test steps if needed
            // Verify that the event is activated and updated as expected
            Assert.True(existingEvent.Status);
            Assert.Equal(newDate, existingEvent.Date);
            Assert.Equal(newStartTime, existingEvent.StartTime);
            Assert.Equal(newEndTime, existingEvent.EndTime);
            mockUnitOfWork.Verify(uow => uow.Events.Update(existingEvent), Times.Once);
            mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
        }
    }
}