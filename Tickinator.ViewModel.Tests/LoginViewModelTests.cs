using Moq;
using NUnit.Framework;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.Login;
using Tickinator.ViewModel.View;

namespace Tickinator.ViewModel.Tests
{
    [TestFixture]
    public class LoginViewModelTests : TestBase<LoginViewModel>
    {
        private Mock<ICloseCommandFactory> mockCloseCommandFactory;
        private Mock<ICloseCommand> mockCloseCommand;
        private Mock<IClosable> mockClosable;

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockCloseCommand = CreateMock<ICloseCommand>();
            mockCloseCommandFactory = CreateMock<ICloseCommandFactory>();
            mockClosable = CreateMock<IClosable>();
        }

        protected override LoginViewModel CreateSystemUnderTest()
        {
            return new LoginViewModel(mockCloseCommandFactory.Object, mockClosable.Object);
        }

        protected override void SetupConstructorRequiredMocks()
        {
            base.SetupConstructorRequiredMocks();
            mockCloseCommandFactory.Setup(p => p.Create(mockClosable.Object)).Returns(mockCloseCommand.Object);
        }
    }
}