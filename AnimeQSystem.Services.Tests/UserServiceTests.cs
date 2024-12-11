using AnimeQSystem.Data.Models;
using AnimeQSystem.Data.Repositories.Interfaces;
using AnimeQSystem.Web.Models.Mix;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Linq.Expressions;

namespace AnimeQSystem.Services.Tests
{
    public class UserServiceTests
    {
        private Mock<IRepository<User, Guid>> _userRepoMock;
        private Mock<UserManager<IdentityUser>> _userManagerMock;
        private UserService _userService;

        [SetUp]
        public void SetUp()
        {
            _userRepoMock = new Mock<IRepository<User, Guid>>();
            _userManagerMock = new Mock<UserManager<IdentityUser>>(
                Mock.Of<IUserStore<IdentityUser>>(),
                null, null, null, null, null, null, null, null
            );
            _userService = new UserService(_userRepoMock.Object, _userManagerMock.Object);
        }

        [Test]
        public async Task GetByEmail_ReturnsUser_WhenUserExists()
        {
            var email = "test@example.com";
            var user = new User { Id = Guid.NewGuid(), FirstName = "Test", LastName = "User", IdentityUser = new IdentityUser { Email = email } };

            _userRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<User> { user });

            var result = await _userService.GetByEmail(email);

            Assert.NotNull(result);
            Assert.AreEqual(user, result);
        }

        [Test]
        public async Task GetByEmail_ReturnsNull_WhenUserDoesNotExist()
        {
            var email = "nonexistent@example.com";
            _userRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<User>());

            var result = await _userService.GetByEmail(email);

            Assert.IsNull(result);
        }

        [Test]
        public async Task AddRewardPoints_UpdatesUserPoints()
        {
            var user = new User { Id = Guid.NewGuid(), Points = 100 };
            var realResult = 50;

            await _userService.AddRewardPoints(user, realResult);

            Assert.AreEqual(150, user.Points);
            _userRepoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        // TODO: Make it work
        //[Test]
        //public async Task UserDidQuiz_ReturnsTrue_WhenUserHasCompletedQuiz()
        //{
        //    var user = new User
        //    {
        //        Id = Guid.NewGuid(),
        //        UserQuizzes = new List<QuizzesUsers> { new QuizzesUsers { QuizId = Guid.NewGuid() } }
        //    };
        //    var quizId = user.UserQuizzes.First().QuizId;
        //    _userRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<User> { user });

        //    var result = await _userService.UserDidQuiz("test@example.com", quizId);

        //    Assert.IsTrue(result);
        //}

        [Test]
        public void UserDidQuiz_ThrowsException_WhenUserNotFound()
        {
            _userRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<User>());

            Assert.ThrowsAsync<NullReferenceException>(() => _userService.UserDidQuiz("nonexistent@example.com", Guid.NewGuid()));
        }

        // TODO: Make it work
        //[Test]
        //public async Task CreateUserBasedOnIdentity_CreatesUserSuccessfully()
        //{
        //    var identityUser = new IdentityUser { Id = Guid.NewGuid().ToString() };
        //    var fName = "John";
        //    var lName = "Doe";
        //    var country = "Country";

        //    _userRepoMock.Setup(r => r.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

        //    await _userService.CreateUserBasedOnIdentity(identityUser, fName, lName, country);

        //    _userRepoMock.Verify(r => r.AddAsync(It.Is<User>(u =>
        //        u.FirstName == fName &&
        //        u.LastName == lName &&
        //        u.Country == country
        //    )), Times.Once);
        //}

        [Test]
        public async Task FindUserByIdentityUserId_ReturnsUser_WhenUserExists()
        {
            var identityUserId = Guid.NewGuid().ToString();
            var user = new User { Id = Guid.NewGuid(), IdentityUserId = identityUserId };
            _userRepoMock.Setup(r => r.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(user);

            var result = await _userService.FindUserByIdentityUserId(identityUserId);

            Assert.NotNull(result);
            Assert.AreEqual(user, result);
        }

        [Test]
        public void FindUserByIdentityUserId_ThrowsException_WhenUserDoesNotExist()
        {
            _userRepoMock.Setup(r => r.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync((User?)null);

            Assert.ThrowsAsync<NullReferenceException>(() => _userService.FindUserByIdentityUserId(Guid.NewGuid().ToString()));
        }

        // TODO: Make it work
        //[Test]
        //public async Task UpdateUserDetails_UpdatesUserSuccessfully()
        //{
        //    var formModel = new UserDetailsVFModel { Id = Guid.NewGuid(), FirstName = "Updated", LastName = "Name", Role = "Admin" };
        //    var existingUser = new User { Id = formModel.Id, FirstName = "Old", LastName = "Name" };
        //    _userRepoMock.Setup(r => r.GetByIdAsync(formModel.Id)).ReturnsAsync(existingUser);
        //    _userRepoMock.Setup(r => r.UpdateAsync(It.IsAny<User>())).ReturnsAsync(true);

        //    await _userService.UpdateUserDetails(formModel);

        //    Assert.AreEqual(formModel.FirstName, existingUser.FirstName);
        //    Assert.AreEqual(formModel.LastName, existingUser.LastName);
        //    _userRepoMock.Verify(r => r.UpdateAsync(It.IsAny<User>()), Times.Once);
        //}

        [Test]
        public void UpdateUserDetails_ThrowsException_WhenUserNotFound()
        {
            var formModel = new UserDetailsVFModel { Id = Guid.NewGuid() };
            _userRepoMock.Setup(r => r.GetByIdAsync(formModel.Id)).ReturnsAsync((User?)null);

            Assert.ThrowsAsync<NullReferenceException>(() => _userService.UpdateUserDetails(formModel));
        }

        // TODO: Make it work
        //[Test]
        //public async Task GetAllRanked_ReturnsRankedUsers()
        //{
        //    var users = new List<User>
        //    {
        //        new User { Points = 100 },
        //        new User { Points = 200 },
        //        new User { Points = 150 }
        //    };
        //    _userRepoMock.Setup(r => r.GetAllAttached()).Returns(users.AsQueryable());

        //    var result = await _userService.GetAllRanked();

        //    Assert.AreEqual(3, result.Count);
        //    Assert.AreEqual(200, result.First().Points);
        //}

        [Test]
        public async Task GetByIdAndSoftDelete_DeletesUser()
        {
            var userId = Guid.NewGuid();

            await _userService.GetByIdAndSoftDelete(userId);

            _userRepoMock.Verify(r => r.SoftDeleteAsync(userId), Times.Once);
        }

        [Test]
        public async Task GetByIdAndRecover_RecoversUserSuccessfully()
        {
            var userId = Guid.NewGuid();
            var user = new User { Id = userId, IsDeleted = true };
            _userRepoMock.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync(user);

            await _userService.GetByIdAndRecover(userId);

            Assert.IsFalse(user.IsDeleted);
            _userRepoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public void GetByIdAndRecover_ThrowsException_WhenUserNotFound()
        {
            var userId = Guid.NewGuid();
            _userRepoMock.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync((User?)null);

            Assert.ThrowsAsync<Exception>(() => _userService.GetByIdAndRecover(userId));
        }
    }
}