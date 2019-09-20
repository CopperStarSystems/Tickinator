//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.MyDashboardViewModelTests.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using Moq;
using Tickinator.Common;
using Tickinator.ViewModel.Dashboard;
using Tickinator.ViewModel.User;

namespace Tickinator.ViewModel.Tests.Dashboard
{
    public class MyDashboardViewModelTests : DashboardViewModelBaseTests<MyDashboardViewModel>
    {
        private Mock<ICurrentUserViewModel> mockCurrentUserViewModel;

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockCurrentUserViewModel = CreateMock<ICurrentUserViewModel>();
        }

        protected override MyDashboardViewModel CreateSystemUnderTest()
        {
            return new MyDashboardViewModel(MockTicketRepository.Object, mockCurrentUserViewModel.Object);
        }

        protected override string GetExpectedTitle()
        {
            return Strings.Dashboard.MyDashboardTitle;
        }

        protected override void SetupMocksForClosedTodayCountTest()
        {
            base.SetupMocksForClosedTodayCountTest();
            mockCurrentUserViewModel.SetupGet(p => p.Id).Returns(1);
        }

        protected override void SetupMocksForOpenTicketCountTest()
        {
            base.SetupMocksForOpenTicketCountTest();
            mockCurrentUserViewModel.SetupGet(p => p.Id).Returns(1);
        }
    }
}