using EventManagementApplication.Business.Concrete;
using EventManagementApplication.DataAccess.Abstract;
using EventManagementApplication.Entities.Concrete;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace EventManagementApplication.Tests
{
    public class RoleServiceTests
    {
        [ExpectedException(typeof(ValidationException))]
        [Fact]
        public void Create_AddsRoleToUnitOfWorkAndSaves()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var roleToCreate = new Role();

            unitOfWorkMock.SetupGet(uow => uow.Roles).Returns(roleRepositoryMock.Object);

            var roleService = new RoleService(unitOfWorkMock.Object);

            // Act
            roleService.Create(roleToCreate);

            // Assert
            roleRepositoryMock.Verify(repo => repo.Add(roleToCreate), Times.Once);
            unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
        }

        [ExpectedException(typeof(ValidationException))]
        [Fact]
        public void Delete_RemovesRoleFromUnitOfWorkAndSaves_WhenRoleExists()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var roleId = 1;
            var existingRole = new Role { Id = roleId };

            roleRepositoryMock.Setup(repo => repo.GetById(roleId)).Returns(existingRole);
            unitOfWorkMock.SetupGet(uow => uow.Roles).Returns(roleRepositoryMock.Object);

            var roleService = new RoleService(unitOfWorkMock.Object);

            // Act
            roleService.Delete(roleId);

            // Assert
            roleRepositoryMock.Verify(repo => repo.Remove(existingRole), Times.Once);
            unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
        }

        [ExpectedException(typeof(ValidationException))]
        [Fact]
        public void Delete_DoesNotRemoveRoleFromUnitOfWork_WhenRoleDoesNotExist()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var roleId = 1;

            roleRepositoryMock.Setup(repo => repo.GetById(roleId)).Returns((Role)null);
            unitOfWorkMock.SetupGet(uow => uow.Roles).Returns(roleRepositoryMock.Object);

            var roleService = new RoleService(unitOfWorkMock.Object);

            // Act
            roleService.Delete(roleId);

            // Assert
            roleRepositoryMock.Verify(repo => repo.Remove(It.IsAny<Role>()), Times.Never);
            unitOfWorkMock.Verify(uow => uow.Save(), Times.Never);
        }

        [ExpectedException(typeof(ValidationException))]
        [Fact]
        public void GetAll_ReturnsAllRolesFromUnitOfWork()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var expectedRoles = new List<Role> { new Role(), new Role() };

            roleRepositoryMock.Setup(repo => repo.GetAll()).Returns(expectedRoles);
            unitOfWorkMock.SetupGet(uow => uow.Roles).Returns(roleRepositoryMock.Object);

            var roleService = new RoleService(unitOfWorkMock.Object);

            // Act
            var roles = roleService.GetAll();

            // Assert
            CollectionAssert.AreEqual(expectedRoles, roles.ToList());
        }

        [ExpectedException(typeof(ValidationException))]
        [Fact]
        public void GetById_ReturnsRoleFromUnitOfWork()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var roleId = 1;
            var expectedRole = new Role { Id = roleId };

            roleRepositoryMock.Setup(repo => repo.GetById(roleId)).Returns(expectedRole);
            unitOfWorkMock.SetupGet(uow => uow.Roles).Returns(roleRepositoryMock.Object);

            var roleService = new RoleService(unitOfWorkMock.Object);

            // Act
            var roleResult = roleService.GetById(roleId);

            // Assert
            Assert.AreEqual(expectedRole, roleResult);
        }

        [ExpectedException(typeof(ValidationException))]
        [Fact]
        public void Update_UpdatesRoleInUnitOfWorkAndSaves()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var roleToUpdate = new Role();

            unitOfWorkMock.SetupGet(uow => uow.Roles).Returns(roleRepositoryMock.Object);

            var roleService = new RoleService(unitOfWorkMock.Object);

            // Act
            roleService.Update(roleToUpdate);

            // Assert
            roleRepositoryMock.Verify(repo => repo.Update(roleToUpdate), Times.Once);
            unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
        }
    }
}