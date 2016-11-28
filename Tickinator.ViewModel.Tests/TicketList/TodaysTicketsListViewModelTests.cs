//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TodaysTicketsListViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Tickinator.Model;
using Tickinator.Repository;
using Tickinator.ViewModel.TicketList;

namespace Tickinator.ViewModel.Tests.TicketList
{
    [TestFixture]
    public class TodaysTicketsListViewModelTests : TestBase<TodaysTicketsListViewModel>
    {
        Mock<ITicketRepository> mockTicketRepository;

        [Test]
        public void TodaysTickets_AfterConstruction_IsNotNull()
        {
            Assert.That(SystemUnderTest.TodaysTickets, Is.Not.Null);
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockTicketRepository = CreateMock<ITicketRepository>();
        }

        protected override TodaysTicketsListViewModel CreateSystemUnderTest()
        {
            return new TodaysTicketsListViewModel(mockTicketRepository.Object);
        }

        protected override void SetupConstructorRequiredMocks()
        {
            base.SetupConstructorRequiredMocks();
            mockTicketRepository.Setup(p => p.GetAll()).Returns(new List<Ticket>());
        }
    }
}