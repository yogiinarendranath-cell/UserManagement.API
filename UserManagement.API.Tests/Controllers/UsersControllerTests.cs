using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using UserManagement.API.Controllers;
using UserManagement.API.Data;
using UserManagement.API.Models;
using FluentAssertions;

namespace UserManagement.API.Tests.Controllers;

public class UsersControllerTests
{
    private AppDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        
        return new AppDbContext(options);
    }

    [Fact]
    public async Task GetUsers_ReturnsAllUsers()
    {
        // Arrange
        var dbContext = GetDbContext();
        var logger = new Mock<ILogger<UsersController>>();
        var controller = new UsersController(dbContext, logger.Object, null!);

        dbContext.Users.AddRange(
            new User { Id = 1, Name = "User1", Email = "user1@test.com", UserName = "user1", Password = "hash1", Role = "User", UserRole = "User" },
            new User { Id = 2, Name = "User2", Email = "user2@test.com", UserName = "user2", Password = "hash2", Role = "Admin", UserRole = "Admin" }
        );
        await dbContext.SaveChangesAsync();

        // Act
        var result = await controller.GetUsers();

        // Assert
        var okResult = result.Result as OkObjectResult;
        okResult.Should().NotBeNull();
        var users = okResult!.Value as IEnumerable<User>;
        users.Should().HaveCount(2);
    }

    [Fact]
    public async Task GetUser_WithValidId_ReturnsUser()
    {
        // Arrange
        var dbContext = GetDbContext();
        var logger = new Mock<ILogger<UsersController>>();
        var controller = new UsersController(dbContext, logger.Object, null!);

        var user = new User { Id = 99, Name = "Test User", Email = "test@test.com", UserName = "testuser", Password = "hash", Role = "User", UserRole = "User" };
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();

        // Act
        var result = await controller.GetUser(99);

        // Assert
        var okResult = result.Result as OkObjectResult;
        okResult.Should().NotBeNull();
        var returnedUser = okResult!.Value as User;
        returnedUser.Should().NotBeNull();
        returnedUser!.Id.Should().Be(99);
        returnedUser.Name.Should().Be("Test User");
    }

    [Fact]
    public async Task GetUser_WithInvalidId_ReturnsNotFound()
    {
        // Arrange
        var dbContext = GetDbContext();
        var logger = new Mock<ILogger<UsersController>>();
        var controller = new UsersController(dbContext, logger.Object, null!);

        // Act
        var result = await controller.GetUser(999);

        // Assert
        result.Result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task DeleteUser_WithValidId_ReturnsNoContent()
    {
        // Arrange
        var dbContext = GetDbContext();
        var logger = new Mock<ILogger<UsersController>>();
        var controller = new UsersController(dbContext, logger.Object, null!);

        var user = new User { Id = 77, Name = "ToDelete", Email = "delete@test.com", UserName = "deleteuser", Password = "hash", Role = "User", UserRole = "User" };
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();

        // Act
        var result = await controller.DeleteUser(77);

        // Assert
        result.Should().BeOfType<NoContentResult>();
    }

    [Fact]
    public async Task DeleteUser_WithInvalidId_ReturnsNotFound()
    {
        // Arrange
        var dbContext = GetDbContext();
        var logger = new Mock<ILogger<UsersController>>();
        var controller = new UsersController(dbContext, logger.Object, null!);

        // Act
        var result = await controller.DeleteUser(999);

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }
}
