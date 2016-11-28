//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.MyDashboardViewModelTests.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using Tickinator.ViewModel.Dashboard;

namespace Tickinator.ViewModel.Tests.Dashboard
{
    public class MyDashboardViewModelTests : DashboardViewModelBaseTests<MyDashboardViewModel>
    {
        protected override MyDashboardViewModel CreateSystemUnderTest()
        {
            return new MyDashboardViewModel(MockTicketRepository.Object);
        }
    }
}