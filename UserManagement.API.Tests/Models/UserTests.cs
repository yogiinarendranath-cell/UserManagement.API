using Xunit;
using UserManagement.API.Models;
using FluentAssertions;

namespace UserManagement.API.Tests.Models;

public class UserTests
{
    [Fact]
    public void User_ShouldHaveDefaultValues()
    {
        // Arrange & Act
        var user = new User();

        // Assert
        user.Id.Should().Be(0);
        user.Name.Should().BeEmpty();
        user.Email.Should().BeEmpty();
        user.UserName.Should().BeEmpty();
        user.Password.Should().BeEmpty();
        user.Role.Should().BeEmpty();
        user.UserRole.Should().BeEmpty();
    }

    [Fact]
    public void User_ShouldSetPropertiesCorrectly()
    {
        // Arrange & Act
        var user = new User
        {
            Id = 1,
            Name = "John Doe",
            Email = "john@example.com",
            UserName = "johndoe",
            Password = "password123",
            Role = "Admin",
            UserRole = "Administrator"
        };

        // Assert
        user.Id.Should().Be(1);
        user.Name.Should().Be("John Doe");
        user.Email.Should().Be("john@example.com");
        user.UserName.Should().Be("johndoe");
        user.Password.Should().Be("password123");
        user.Role.Should().Be("Admin");
        user.UserRole.Should().Be("Administrator");
    }
}
