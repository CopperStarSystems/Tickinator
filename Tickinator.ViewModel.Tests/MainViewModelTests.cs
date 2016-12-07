//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.MainViewModelTests.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using Moq;
using NUnit.Framework;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.Dashboard;
using Tickinator.ViewModel.TicketList;
using Tickinator.ViewModel.User;

namespace Tickinator.ViewModel.Tests
{
    [TestFixture]
    public class MainViewModelTests : TestBase<MainViewModel>
    {
        Mock<ICurrentUserViewModel> mockCurrentUserViewModel;
        Mock<IMyDashboardViewModel> mockMyDashboardViewModel;
        Mock<IMyDashboardViewModelFactory> mockMyDashboardViewModelFactory;
        Mock<INewTicketCommand> mockNewTicketCommand;
        Mock<ITeamDashboardViewModel> mockTeamDashboardViewModel;
        Mock<ITicketListViewModel> mockTodaysTicketsViewModel;

        [Test]
        public void NewTicketCommand_Always_ReturnsInjectedCommand()
        {
            Assert.That(SystemUnderTest.NewTicketCommand, Is.Not.Null);
            Assert.That(SystemUnderTest.NewTicketCommand, Is.SameAs(mockNewTicketCommand.Object));
        }

        [Test]
        public void TeamDashboardViewModel_AfterConstruction_IsExpectedValue()
        {
            Assert.That(SystemUnderTest.TeamDashboardViewModel, Is.Not.Null);
            Assert.That(SystemUnderTest.TeamDashboardViewModel, Is.SameAs(mockTeamDashboardViewModel.Object));
        }

        [Test]
        public void TodaysTicketsViewModel_AfterConstruction_ExpectedValue()
        {
            Assert.That(SystemUnderTest.TodaysTicketsViewModel, Is.Not.Null);
            Assert.That(SystemUnderTest.TodaysTicketsViewModel, Is.SameAs(mockTodaysTicketsViewModel.Object));
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockTeamDashboardViewModel = CreateMock<ITeamDashboardViewModel>();
            mockMyDashboardViewModelFactory = CreateMock<IMyDashboardViewModelFactory>();
            mockMyDashboardViewModel = CreateMock<IMyDashboardViewModel>();
            mockTodaysTicketsViewModel = CreateMock<ITicketListViewModel>();
            mockCurrentUserViewModel = CreateMock<ICurrentUserViewModel>();
            mockNewTicketCommand = CreateMock<INewTicketCommand>();
        }

        protected override MainViewModel CreateSystemUnderTest()
        {
            return new MainViewModel(mockTeamDashboardViewModel.Object, mockMyDashboardViewModelFactory.Object,
                                     mockTodaysTicketsViewModel.Object, mockCurrentUserViewModel.Object,
                                     mockNewTicketCommand.Object);
        }

        protected override void SetupConstructorRequiredMocks()
        {
            base.SetupConstructorRequiredMocks();
            mockMyDashboardViewModelFactory.Setup(p => p.Create(mockCurrentUserViewModel.Object))
                                           .Returns(mockMyDashboardViewModel.Object);
        }
    }
}