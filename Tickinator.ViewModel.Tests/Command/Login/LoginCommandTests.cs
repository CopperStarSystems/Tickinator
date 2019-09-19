using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Tickinator.Repository;
using Tickinator.ViewModel.Command.Login;
using Tickinator.ViewModel.Login;
using Tickinator.ViewModel.Tests.Command.Core;
using Tickinator.ViewModel.User;
using Tickinator.ViewModel.View;

namespace Tickinator.ViewModel.Tests.Command.Login
{
    [TestFixture]
    public class LoginCommandTests : CommandBaseTests<LoginCommand>
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            CreateUsers();
        }

        private Mock<ILoginViewModel> mockLoginViewModel;
        private Mock<IUserRepository> mockUserRepository;
        private Mock<ICurrentUserViewModelFactory> mockCurrentUserViewModelFactory;
        private Mock<ICurrentUserViewModel> mockCurrentUserViewModel;
        private Mock<IClosable> mockClosable;

        private IList<Model.User> users;

        private void CreateUsers()
        {
            users = new List<Model.User>();
            users.Add(new Model.User {Id = 1, UserName = "user", Password = "password"});
        }


        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockLoginViewModel = CreateMock<ILoginViewModel>();
            mockUserRepository = CreateMock<IUserRepository>();
            mockCurrentUserViewModelFactory = CreateMock<ICurrentUserViewModelFactory>();
            mockCurrentUserViewModel = CreateMock<ICurrentUserViewModel>();
            mockClosable = CreateMock<IClosable>();
        }

        protected override LoginCommand CreateSystemUnderTest()
        {
            return new LoginCommand(mockLoginViewModel.Object, mockUserRepository.Object,
                mockCurrentUserViewModelFactory.Object, mockClosable.Object);
        }

        [Test]
        public void Execute_WhenLoginFails_PerformsExpectedWork()
        {
            mockLoginViewModel.SetupGet(p => p.UserName).Returns("user");
            mockLoginViewModel.SetupGet(p => p.Password).Returns("badPassword");
            mockUserRepository.Setup(p => p.GetAll()).Returns(users);
            mockLoginViewModel.SetupSet(p => p.ShowLoginFailure = true);
            mockLoginViewModel.SetupSet(p => p.UserName = string.Empty);
            mockLoginViewModel.SetupSet(p => p.Password = string.Empty);
            Execute();
            VerifyAllMocks();
        }

        [Test]
        public void Execute_WhenLoginSucceeds_PerformsExpectedWork()
        {
            mockLoginViewModel.SetupGet(p => p.UserName).Returns("user");
            mockLoginViewModel.SetupGet(p => p.Password).Returns("password");
            mockUserRepository.Setup(p => p.GetAll()).Returns(users);
            mockCurrentUserViewModelFactory.Setup(p => p.Create(1)).Returns(mockCurrentUserViewModel.Object);
            mockLoginViewModel.SetupSet(p => p.CurrentUser = mockCurrentUserViewModel.Object);
            mockClosable.Setup(p => p.Close());
            Execute();
            VerifyAllMocks();
        }
    }
}