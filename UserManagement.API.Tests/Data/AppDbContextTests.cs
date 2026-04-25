using Xunit;
using Microsoft.EntityFrameworkCore;
using UserManagement.API.Data;
using UserManagement.API.Models;
using FluentAssertions;

namespace UserManagement.API.Tests.Data;

public class AppDbContextTests
{
    [Fact]
    public void CanAddUserToDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
        
        using var context = new AppDbContext(options);
        
        var user = new User
        {
            Name = "Test User",
            Email = "test@test.com",
            UserName = "testuser",
            Password = "hashedpassword",
            Role = "User",
            UserRole = "User"
        };

        // Act
        context.Users.Add(user);
        context.SaveChanges();

        // Assert
        context.Users.Count().Should().Be(1);
        context.Users.First().Name.Should().Be("Test User");
    }
}
