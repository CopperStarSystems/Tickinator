//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TeamDashboardViewModelTests.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using Moq;
using NUnit.Framework;
using Tickinator.Repository;

namespace Tickinator.ViewModel.Tests
{
    [TestFixture]
    public class TeamDashboardViewModelTests : DashboardViewModelBaseTests<TeamDashboardViewModel>
    {
        Mock<ITicketRepository> mockTicketRepository;

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(25)]
        public void OpenTicketCount_Always_ReturnsExpectedCount(int expectedOpenTicketCount)
        {
            AddTickets(expectedOpenTicketCount);
            mockTicketRepository.Setup(p => p.GetAll()).Returns(Tickets);
            Assert.That(SystemUnderTest.OpenTicketCount, Is.EqualTo(expectedOpenTicketCount));
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockTicketRepository = CreateMock<ITicketRepository>();
        }

        protected override TeamDashboardViewModel CreateSystemUnderTest()
        {
            return new TeamDashboardViewModel(mockTicketRepository.Object);
        }
    }
}