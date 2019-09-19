//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.DashboardViewModelBaseTests.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Tickinator.Model;
using Tickinator.Repository;
using Tickinator.ViewModel.Dashboard;

namespace Tickinator.ViewModel.Tests.Dashboard
{
    [TestFixture]
    public abstract class DashboardViewModelBaseTests<T> : TestBase<T> where T : IDashboardViewModel
    {
        [SetUp]
        public override void SetUp()
        {
            Tickets = new List<Ticket>();
            base.SetUp();
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(25)]
        public void AverageTicketDuration_Always_ReturnsExpectedDuration(int closedTodayCount)
        {
            var duration = SetupTicketsForAverageDurationTest(closedTodayCount);
            SetupMockTicketRepository();
            var expectedDuration = TimeSpan.FromMilliseconds(duration);
            Assert.That(SystemUnderTest.AverageTicketDuration, Is.EqualTo(expectedDuration));
        }

        [TestCase(1, 0)]
        [TestCase(5, 2)]
        [TestCase(25, 24)]
        public void ClosedTodayCount_Always_ReturnsExpectedCount(int totalTicketCount, int expectedClosedTodayCount)
        {
            SetupTicketsForClosedTodayCountTest(totalTicketCount, expectedClosedTodayCount);
            SetupMockTicketRepository();
            SetupMocksForClosedTodayCountTest();
            Assert.That(SystemUnderTest.ClosedTodayCount, Is.EqualTo(expectedClosedTodayCount));
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(25)]
        public void OpenTicketCount_Always_ReturnsExpectedCount(int expectedOpenTicketCount)
        {
            AddTickets(expectedOpenTicketCount);
            SetupMocksForOpenTicketCountTest();
            SetupMockTicketRepository();
            Assert.That(SystemUnderTest.OpenTicketCount, Is.EqualTo(expectedOpenTicketCount));
        }

        protected abstract string GetExpectedTitle();

        protected void AddTicket(int id, DateTime? dateClosed, DateTime dateOpened, int assignedToId = 1)
        {
            Tickets.Add(new Ticket
            {
                Id = id,
                DateClosed = dateClosed,
                DateOpened = dateOpened,
                AssignedToId = assignedToId
            });
        }

        protected void AddTickets(int ticketCount, DateTime? dateClosed = null, int assignedToId = 1)
        {
            for (var ctr = 0; ctr < ticketCount; ctr++)
                AddTicket(ctr + 1, dateClosed, DateTime.Today.AddDays(-1), assignedToId);
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            MockTicketRepository = CreateMock<ITicketRepository>();
        }

        protected Mock<ITicketRepository> MockTicketRepository { get; private set; }

        protected virtual void SetupMocksForClosedTodayCountTest()
        {
        }

        protected virtual void SetupMocksForOpenTicketCountTest()
        {
        }

        protected IList<Ticket> Tickets { get; private set; }

        private void SetupMockTicketRepository()
        {
            MockTicketRepository.Setup(p => p.GetAll()).Returns(Tickets);
        }

        private double SetupTicketsForAverageDurationTest(int closedTicketCount)
        {
            var expectedDuration = 0.0;
            for (var ctr = closedTicketCount; ctr < closedTicketCount; ctr++)
            {
                var duration = new Random().NextDouble() * int.MaxValue;
                expectedDuration += duration;
                var timeSpan = TimeSpan.FromMilliseconds(duration);
                AddTicket(ctr + 1, DateTime.Today, DateTime.Today.AddHours(-timeSpan.TotalHours));
            }

            return expectedDuration;
        }

        private void SetupTicketsForClosedTodayCountTest(int totalTicketCount, int expectedClosedTodayCount)
        {
            var openTicketCount = totalTicketCount - expectedClosedTodayCount;

            // Create open tickets (i.e. null DateClosed)
            for (var ctr = 0; ctr < totalTicketCount - expectedClosedTodayCount; ctr++)
                AddTicket(ctr + 1, null, DateTime.Today);

            // Create tickets with closed date of today
            for (var ctr = openTicketCount; ctr < totalTicketCount; ctr++)
                AddTicket(ctr + 1, DateTime.Today, DateTime.Today.AddHours(-1));
        }

        [Test]
        public void Title_Always_ReturnsExpectedValue()
        {
            Assert.That(SystemUnderTest.Title, Is.EqualTo(GetExpectedTitle()));
        }
    }
}