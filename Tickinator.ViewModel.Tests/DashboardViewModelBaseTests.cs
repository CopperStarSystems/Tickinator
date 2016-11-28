//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.DashboardViewModelBaseTests.cs
// 2016/11/25
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Tickinator.Model;
using Tickinator.Repository;

namespace Tickinator.ViewModel.Tests
{
    [TestFixture]
    public abstract class DashboardViewModelBaseTests<T> : TestBase<T> where T : IDashboardViewModel
    {
        protected IList<Ticket> Tickets { get; private set; }

        protected Mock<ITicketRepository> MockTicketRepository { get; private set; }

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

        [SetUp]
        public override void SetUp()
        {
            Tickets = new List<Ticket>();
            base.SetUp();
        }

        protected void AddTicket(int id, DateTime? dateClosed, DateTime dateOpened)
        {
            Tickets.Add(new Ticket {Id = id, DateClosed = dateClosed, DateOpened = dateOpened, AssignedToId = 1});
        }

        protected void AddTickets(int ticketCount)
        {
            for (var ctr = 0; ctr < ticketCount; ctr++)
                Tickets.Add(new Ticket {Id = ctr + 1, AssignedToId = 1});
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            MockTicketRepository = CreateMock<ITicketRepository>();
        }

        void SetupMockTicketRepository()
        {
            MockTicketRepository.Setup(p => p.GetAll()).Returns(Tickets);
        }

        double SetupTicketsForAverageDurationTest(int closedTicketCount)
        {
            var expectedDuration = 0.0;
            for (var ctr = closedTicketCount; ctr < closedTicketCount; ctr++)
            {
                var duration = new Random().NextDouble()*int.MaxValue;
                expectedDuration += duration;
                var timeSpan = TimeSpan.FromMilliseconds(duration);
                AddTicket(ctr + 1, DateTime.Today, DateTime.Today.AddHours(-timeSpan.TotalHours));
            }

            return expectedDuration;
        }

        void SetupTicketsForClosedTodayCountTest(int totalTicketCount, int expectedClosedTodayCount)
        {
            var openTicketCount = totalTicketCount - expectedClosedTodayCount;

            // Create open tickets (i.e. null DateClosed)
            for (var ctr = 0; ctr < totalTicketCount - expectedClosedTodayCount; ctr++)
                AddTicket(ctr + 1, null, DateTime.Today);

            // Create tickets with closed date of today
            for (var ctr = openTicketCount; ctr < totalTicketCount; ctr++)
                AddTicket(ctr + 1, DateTime.Today, DateTime.Today.AddHours(-1));
        }
    }
}