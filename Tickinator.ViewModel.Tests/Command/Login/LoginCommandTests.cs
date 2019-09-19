using System;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Tickinator.ViewModel.Command.Login;
using Tickinator.ViewModel.Login;

namespace Tickinator.ViewModel.Tests.Command.Login
{
    [TestFixture()]
    public class LoginCommandTests : TestBase<LoginCommand>
    {
        private Mock<ILoginViewModel> mockLoginViewModel;

        [Test]
        public void Execute_Always_PerformsExpectedWork()
        {
            Assert.Throws<NotImplementedException>(() => SystemUnderTest.Execute(null));
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockLoginViewModel = CreateMock<ILoginViewModel>();
        }

        protected override LoginCommand CreateSystemUnderTest()
        {
            return new LoginCommand(mockLoginViewModel.Object);
        }
    }
}