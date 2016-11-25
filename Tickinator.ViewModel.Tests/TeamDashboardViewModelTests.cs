//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TeamDashboardViewModelTests.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Tickinator.Model;
using Tickinator.Repository;

namespace Tickinator.ViewModel.Tests
{
    [TestFixture]
    public class TeamDashboardViewModelTests : TestBase<TeamDashboardViewModel>
    {
        Mock<ITicketRepository> mockTicketRepository;
        IList<Ticket> ticketList;

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(25)]
        public void OpenTicketCount_AfterConstruction_IsExpectedCount(int expectedOpenTicketCount)
        {
            AddTickets(expectedOpenTicketCount);
            RecreateSystemUnderTest();
            Assert.That(SystemUnderTest.OpenTicketCount, Is.EqualTo(expectedOpenTicketCount));
        }

        [Test]
        public void Constructor_Always_Succeeds()
        {
            Assert.That(SystemUnderTest, Is.Not.Null);
        }

        [SetUp]
        public override void SetUp()
        {
            ticketList = new List<Ticket>();
            base.SetUp();
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

        protected override void SetupConstructorRequiredMocks()
        {
            base.SetupConstructorRequiredMocks();
            mockTicketRepository.Setup(p => p.GetAll()).Returns(ticketList);
        }

        void AddTickets(int ticketCount)
        {
            for (var ctr = 0; ctr < ticketCount; ctr++)
                ticketList.Add(new Ticket {Id = ctr + 1});
        }
    }
}