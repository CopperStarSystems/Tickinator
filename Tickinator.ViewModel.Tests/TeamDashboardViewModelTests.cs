//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TeamDashboardViewModelTests.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using System;
using Moq;
using NUnit.Framework;
using Tickinator.Repository;

namespace Tickinator.ViewModel.Tests
{
    [TestFixture]
    public class TeamDashboardViewModelTests : DashboardViewModelBaseTests<TeamDashboardViewModel>
    {
        Mock<ITicketRepository> mockTicketRepository;

        [TestCase(1, 0)]
        [TestCase(5, 2)]
        [TestCase(25, 24)]
        public void ClosedTodayCount_Always_ReturnsExpectedCount(int totalTicketCount, int expectedClosedTodayCount)
        {
            SetupTicketsForClosedTodayCountTest(totalTicketCount, expectedClosedTodayCount);
            SetupMockTicketRepository();
            Assert.That(SystemUnderTest.ClosedTodayCount, Is.EqualTo(expectedClosedTodayCount));
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(25)]
        public void OpenTicketCount_Always_ReturnsExpectedCount(int expectedOpenTicketCount)
        {
            AddTickets(expectedOpenTicketCount);
            SetupMockTicketRepository();
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

        void SetupMockTicketRepository()
        {
            mockTicketRepository.Setup(p => p.GetAll()).Returns(Tickets);
        }

        void SetupTicketsForClosedTodayCountTest(int totalTicketCount, int expectedClosedTodayCount)
        {
            var openTicketCount = totalTicketCount - expectedClosedTodayCount;

            // Create open tickets (i.e. null DateClosed)
            for (var ctr = 0; ctr < totalTicketCount - expectedClosedTodayCount; ctr++)
                AddTicket(ctr + 1, null);

            // Create tickets with closed date of today
            for (var ctr = openTicketCount; ctr < totalTicketCount; ctr++)
                AddTicket(ctr + 1, DateTime.Today);
        }
    }
}