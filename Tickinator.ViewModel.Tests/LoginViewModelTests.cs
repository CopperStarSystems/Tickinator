using Moq;
using NUnit.Framework;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.Login;
using Tickinator.ViewModel.User;
using Tickinator.ViewModel.View;

namespace Tickinator.ViewModel.Tests
{
    [TestFixture]
    public class LoginViewModelTests : TestBase<LoginViewModel>
    {
        private Mock<ICloseCommandFactory> mockCloseCommandFactory;
        private Mock<ICloseCommand> mockCloseCommand;
        private Mock<IClosable> mockClosable;
        private Mock<ICurrentUserViewModelFactory> mockCurrentUserViewModelFactory;

        [Test]
        public void CloseCommand_AfterConstruction_IsCreatedInstance()
        {
            Assert.That(SystemUnderTest.CloseCommand, Is.SameAs(mockCloseCommand.Object));
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockCloseCommand = CreateMock<ICloseCommand>();
            mockCloseCommandFactory = CreateMock<ICloseCommandFactory>();
            mockClosable = CreateMock<IClosable>();
            mockCurrentUserViewModelFactory = CreateMock<ICurrentUserViewModelFactory>();
        }

        protected override LoginViewModel CreateSystemUnderTest()
        {
            return new LoginViewModel(mockCloseCommandFactory.Object, mockClosable.Object, mockCurrentUserViewModelFactory.Object);
        }

        protected override void SetupConstructorRequiredMocks()
        {
            base.SetupConstructorRequiredMocks();
            mockCloseCommandFactory.Setup(p => p.Create(mockClosable.Object)).Returns(mockCloseCommand.Object);
        }
    }
}