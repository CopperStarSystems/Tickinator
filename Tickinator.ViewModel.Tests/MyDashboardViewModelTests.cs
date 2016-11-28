//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.MyDashboardViewModelTests.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------
namespace Tickinator.ViewModel.Tests
{
    public class MyDashboardViewModelTests : DashboardViewModelBaseTests<MyDashboardViewModel>
    {
        protected override MyDashboardViewModel CreateSystemUnderTest()
        {
            return new MyDashboardViewModel(MockTicketRepository.Object);
        }
    }
}