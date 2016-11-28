//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TeamDashboardViewModelTests.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using NUnit.Framework;
using Tickinator.ViewModel.Dashboard;

namespace Tickinator.ViewModel.Tests.Dashboard
{
    [TestFixture]
    public class TeamDashboardViewModelTests : DashboardViewModelBaseTests<TeamDashboardViewModel>
    {
        protected override TeamDashboardViewModel CreateSystemUnderTest()
        {
            return new TeamDashboardViewModel(MockTicketRepository.Object);
        }
    }
}