//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.MainViewModelTests.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using Moq;
using NUnit.Framework;
using Tickinator.ViewModel.Dashboard;
using Tickinator.ViewModel.TicketList;

namespace Tickinator.ViewModel.Tests
{
    [TestFixture]
    public class MainViewModelTests : TestBase<MainViewModel>
    {
        Mock<IMyDashboardViewModel> mockMyDashboardViewModel;
        Mock<ITeamDashboardViewModel> mockTeamDashboardViewModel;
        Mock<ITodaysTicketsListViewModel> mockTodaysTicketsViewModel;

        [Test]
        public void TeamDashboardViewModel_AfterConstruction_IsInjectedInstance()
        {
            Assert.That(SystemUnderTest.TeamDashboardViewModel, Is.SameAs(mockTeamDashboardViewModel.Object));
        }

        [Test]
        public void TeamDashboardViewModel_AfterConstruction_IsNotNull()
        {
            Assert.That(SystemUnderTest.TeamDashboardViewModel, Is.Not.Null);
        }

        [Test]
        public void TodaysTicketsViewModel_AfterConstruction_IsInjectedInstance()
        {
            Assert.That(SystemUnderTest.TodaysTicketsViewModel, Is.SameAs(mockTodaysTicketsViewModel.Object));
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockTeamDashboardViewModel = CreateMock<ITeamDashboardViewModel>();
            mockMyDashboardViewModel = CreateMock<IMyDashboardViewModel>();
            mockTodaysTicketsViewModel = CreateMock<ITodaysTicketsListViewModel>();
        }

        protected override MainViewModel CreateSystemUnderTest()
        {
            return new MainViewModel(mockTeamDashboardViewModel.Object, mockMyDashboardViewModel.Object,
                mockTodaysTicketsViewModel.Object);
        }
    }
}