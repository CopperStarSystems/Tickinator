//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TeamDashboardViewModelTests.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using NUnit.Framework;

namespace Tickinator.ViewModel.Tests
{
    [TestFixture]
    public class TeamDashboardViewModelTests : TestBase<TeamDashboardViewModel>
    {
        [Test]
        public void Constructor_Always_Succeeds()
        {
            Assert.That(SystemUnderTest, Is.Not.Null);
        }

        protected override TeamDashboardViewModel CreateSystemUnderTest()
        {
            return new TeamDashboardViewModel();
        }
    }
}