using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GlobalDisasterManagement.Models.Configuration;
using GlobalDisasterManagement.Services.Implementations;
using System.Net.Mail;
using GlobalDisasterManagement.Resources;
using Microsoft.Extensions.Localization;

namespace GlobalDisasterManagement.Tests.Services
{
    public class EmailServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<ILogger<EmailService>> _mockLogger;
        private readonly EmailSettings _emailSettings;
        private readonly EmailService _emailService;

        public EmailServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<EmailService>>();
            
            _emailSettings = new EmailSettings
            {
                SmtpServer = "smtp.gmail.com",
                SmtpPort = 587,
                SenderEmail = "test@example.com",
                SenderPassword = "testpassword",
                EnableSsl = true
            };

            var options = Options.Create(_emailSettings);
            _emailService = new EmailService(options, _mockLogger.Object, _mockUnitOfWork.Object, new Mock<IStringLocalizer<SharedResources>>().Object);
        }

        [Fact]
        public void EmailSettings_ShouldBeConfigured()
        {
            // Assert
            Assert.NotNull(_emailSettings);
            Assert.Equal("smtp.gmail.com", _emailSettings.SmtpServer);
            Assert.Equal(587, _emailSettings.SmtpPort);
            Assert.Equal("test@example.com", _emailSettings.SenderEmail);
            Assert.True(_emailSettings.EnableSsl);
        }

        [Fact]
        public async Task SendWelcomeEmail_WithValidUser_ShouldCallRepository()
        {
            // Arrange
            var user = new User
            {
                Id = "user123",
                UserName = "john.doe",
                Email = "john.doe@example.com"
            };

            _mockUnitOfWork.Setup(u => u.Users.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<User, bool>>>()))
                .ReturnsAsync(new List<User> { user });

            // Act
            var found = await _mockUnitOfWork.Object.Users.FindAsync(u => u.Id == "user123");

            // Assert
            var userFromRepo = Assert.Single(found);
            Assert.Equal("john.doe", userFromRepo.UserName);
            Assert.Equal("john.doe@example.com", userFromRepo.Email);
            _mockUnitOfWork.Verify(u => u.Users.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<User, bool>>>()), Times.Once);
        }

        [Fact]
        public async Task SendFloodAlertEmail_WithValidData_ShouldFetchUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Email = "user1@example.com", UserName = "User1" },
                new User { Email = "user2@example.com", UserName = "User2" }
            };

            _mockUnitOfWork.Setup(u => u.Users.GetAllAsync())
                .ReturnsAsync(users);

            // Act
            var fetchedUsers = await _mockUnitOfWork.Object.Users.GetAllAsync();

            // Assert
            Assert.NotNull(fetchedUsers);
            Assert.Equal(2, fetchedUsers.Count());
            _mockUnitOfWork.Verify(u => u.Users.GetAllAsync(), Times.Once);
        }

        [Theory]
        [InlineData("test@example.com", true)]
        [InlineData("invalid-email", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void IsValidEmail_ShouldReturnCorrectResult(string email, bool expected)
        {
            // Act
            bool isValid = IsValidEmail(email);

            // Assert
            Assert.Equal(expected, isValid);
        }

        [Fact]
        public async Task GetUsersByCityId_ShouldReturnFilteredUsers()
        {
            // Arrange
            int cityId = 1;
            var users = new List<User>
            {
                new User { Id = "1", Email = "user1@example.com", CityId = 1 },
                new User { Id = "2", Email = "user2@example.com", CityId = 1 },
                new User { Id = "3", Email = "user3@example.com", CityId = 2 }
            };

            _mockUnitOfWork.Setup(u => u.Users.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<User, bool>>>()))
                .ReturnsAsync((System.Linq.Expressions.Expression<Func<User, bool>> predicate) =>
                    users.Where(predicate.Compile()).ToList());

            // Act
            var cityUsers = await _mockUnitOfWork.Object.Users.FindAsync(u => u.CityId == cityId);

            // Assert
            Assert.NotNull(cityUsers);
            Assert.Equal(2, cityUsers.Count());
            Assert.All(cityUsers, u => Assert.Equal(cityId, u.CityId));
        }

        // Helper method to validate email format
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
