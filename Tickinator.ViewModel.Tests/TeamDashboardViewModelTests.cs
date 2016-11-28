﻿//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TeamDashboardViewModelTests.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using NUnit.Framework;

namespace Tickinator.ViewModel.Tests
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