//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.MyDashboardViewModelTests.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using Moq;
using Tickinator.ViewModel.Dashboard;
using Tickinator.ViewModel.User;

namespace Tickinator.ViewModel.Tests.Dashboard
{
    public class MyDashboardViewModelTests : DashboardViewModelBaseTests<MyDashboardViewModel>
    {
        Mock<ICurrentUserViewModel> mockCurrentUserViewModel;

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockCurrentUserViewModel = CreateMock<ICurrentUserViewModel>();
        }

        protected override MyDashboardViewModel CreateSystemUnderTest()
        {
            return new MyDashboardViewModel(MockTicketRepository.Object, mockCurrentUserViewModel.Object);
        }

        protected override void SetupMocksForClosedTodayCountTest()
        {
            base.SetupMocksForClosedTodayCountTest();
            mockCurrentUserViewModel.SetupGet(p => p.Id).Returns(1);
        }
    }
}