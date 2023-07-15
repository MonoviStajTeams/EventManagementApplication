using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManagementApplication.Business.Concrete;
using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;

using EventManagementApplication.DataAccess.Abstract;
using Moq;
using Xunit;

namespace EventManagementApplication.Tests
{
    public class CachingTests
    {
        [Fact]
        public void GetAllEvents_ReturnsCachedEvents_WhenCacheIsNotEmpty()
        {
            
            var eventRepositoryMock = new Mock<IEventRepository>();
            var cachingService = new CachingService(eventRepositoryMock.Object);

            
            var cachedEvents = new List<Event> { new Event(), new Event() };
            cachingService.SetCachedEvents(cachedEvents);

            
            var result = cachingService.GetAllEvents();

            
            Assert.Equal(cachedEvents, result);
            eventRepositoryMock.Verify(repo => repo.GetAllEvents(), Times.Never);
        }

        [Fact]
        public void GetAllEvents_ReturnsFreshData_WhenCacheIsEmpty()
        {
            
            var eventRepositoryMock = new Mock<IEventRepository>();
            var cachingService = new CachingService(eventRepositoryMock.Object);

           
            cachingService.ClearCache();

            var freshData = new List<Event> { new Event(), new Event() };
            eventRepositoryMock.Setup(repo => repo.GetAllEvents()).Returns(freshData);

            
            var result = cachingService.GetAllEvents();

            
            Assert.Equal(freshData, result);
            eventRepositoryMock.Verify(repo => repo.GetAllEvents(), Times.Once);
        }
    }
}