//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.CloseCommandTests.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using Moq;
using NUnit.Framework;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.Tests.Command.Core;
using Tickinator.ViewModel.View;

namespace Tickinator.ViewModel.Tests.Command
{
    [TestFixture]
    public class CloseCommandTests : CommandBaseTests<CloseCommand>
    {
        Mock<IClosable> mockClosable;

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockClosable = CreateMock<IClosable>();
        }

        protected override CloseCommand CreateSystemUnderTest()
        {
            return new CloseCommand(mockClosable.Object);
        }

        [Test]
        public void Execute_Always_PerformsExpectedWork()
        {
            mockClosable.Setup(p => p.Close());
            SystemUnderTest.Execute(null);
            MockRepository.VerifyAll();
        }
    }
}