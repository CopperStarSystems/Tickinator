//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TodaysTicketsListViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Tickinator.Model;
using Tickinator.Repository;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.TicketList;

namespace Tickinator.ViewModel.Tests.TicketList
{
    [TestFixture]
    public class TicketListViewModelTests : TestBase<TicketListViewModel>
    {
        Mock<IShowTicketDetailsCommand> mockShowTicketDetailsCommand;
        Mock<ITicketListItemViewModelFactory> mockTicketListItemViewModelFactory;
        Mock<ITicketRepository> mockTicketRepository;

        [Test]
        public void ShowTicketDetailsCommand_AfterConstruction_IsExpectedValue()
        {
            Assert.That(SystemUnderTest.ShowTicketDetailsCommand, Is.Not.Null);
            Assert.That(SystemUnderTest.ShowTicketDetailsCommand, Is.SameAs(mockShowTicketDetailsCommand.Object));
        }

        [Test]
        public void TodaysTickets_AfterConstruction_IsNotNull()
        {
            Assert.That(SystemUnderTest.TodaysTickets, Is.Not.Null);
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockTicketRepository = CreateMock<ITicketRepository>();
            mockTicketListItemViewModelFactory = CreateMock<ITicketListItemViewModelFactory>();
            mockShowTicketDetailsCommand = CreateMock<IShowTicketDetailsCommand>();
        }

        protected override TicketListViewModel CreateSystemUnderTest()
        {
            return new TicketListViewModel(mockTicketRepository.Object, mockTicketListItemViewModelFactory.Object,
                mockShowTicketDetailsCommand.Object);
        }

        protected override void SetupConstructorRequiredMocks()
        {
            base.SetupConstructorRequiredMocks();
            var tickets = new List<Ticket> {new Ticket(), new Ticket(), new Ticket()};

            mockTicketRepository.Setup(p => p.GetAll()).Returns(tickets);
            foreach (var ticket in tickets)
            {
                var mockListItemViewModel = CreateMock<ITicketListItemViewModel>();
                mockTicketListItemViewModelFactory.Setup(p => p.Create(ticket)).Returns(mockListItemViewModel.Object);
            }
        }
    }
}