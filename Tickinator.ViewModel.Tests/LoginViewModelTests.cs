using Moq;
using NUnit.Framework;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.Command.Login;
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
        private Mock<ILoginCommandFactory> mockLoginCommandFactory;
        private Mock<ILoginCommand> mockLoginCommand;

        [Test]
        public void CloseCommand_AfterConstruction_IsCreatedInstance()
        {
            
        }

        [Test]
        public void Constructor_Always_SetsExpectedDefaults()
        {
            Assert.That(SystemUnderTest.CloseCommand, Is.SameAs(mockCloseCommand.Object));
            Assert.That(SystemUnderTest.ShowLoginFailure, Is.False);
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockCloseCommand = CreateMock<ICloseCommand>();
            mockCloseCommandFactory = CreateMock<ICloseCommandFactory>();
            mockClosable = CreateMock<IClosable>();
            mockCurrentUserViewModelFactory = CreateMock<ICurrentUserViewModelFactory>();
            mockLoginCommandFactory = CreateMock<ILoginCommandFactory>();
            mockLoginCommand = CreateMock<ILoginCommand>();
        }

        protected override LoginViewModel CreateSystemUnderTest()
        {
            return new LoginViewModel(mockCloseCommandFactory.Object, mockClosable.Object, mockCurrentUserViewModelFactory.Object, mockLoginCommandFactory.Object);
        }

        protected override void SetupConstructorRequiredMocks()
        {
            base.SetupConstructorRequiredMocks();
            mockCloseCommandFactory.Setup(p => p.Create(mockClosable.Object)).Returns(mockCloseCommand.Object);
            mockLoginCommandFactory.Setup(p => p.Create(It.IsAny<ILoginViewModel>(), mockClosable.Object)).Returns(mockLoginCommand.Object);
        }
    }
}