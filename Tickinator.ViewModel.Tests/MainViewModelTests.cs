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
        Mock<ITicketListViewModel> mockTodaysTicketsViewModel;

        [Test]
        public void MyDashboardViewModel_AfterConstruction_IsExpectedValue()
        {
            Assert.That(SystemUnderTest.MyDashboardViewModel, Is.Not.Null);
            Assert.That(SystemUnderTest.MyDashboardViewModel, Is.SameAs(mockMyDashboardViewModel.Object));
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
            mockMyDashboardViewModel = CreateMock<IMyDashboardViewModel>();
            mockTodaysTicketsViewModel = CreateMock<ITicketListViewModel>();
        }

        protected override MainViewModel CreateSystemUnderTest()
        {
            return new MainViewModel(mockTeamDashboardViewModel.Object, mockMyDashboardViewModel.Object,
                mockTodaysTicketsViewModel.Object);
        }
    }
}