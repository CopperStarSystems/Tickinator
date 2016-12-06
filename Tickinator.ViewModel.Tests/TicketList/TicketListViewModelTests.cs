//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TicketListViewModelTests.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Tickinator.Model;
using Tickinator.Repository;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.Infrastructure;
using Tickinator.ViewModel.TicketList;

namespace Tickinator.ViewModel.Tests.TicketList
{
    [TestFixture]
    public class TicketListViewModelTests : TestBase<TicketListViewModel>
    {
        int invocationCount;
        Mock<IShowTicketDetailsCommand> mockShowTicketDetailsCommand;
        Mock<IShowTicketDetailsCommandFactory> mockShowTicketDetailsCommandFactory;
        Mock<ITicketListItemViewModelFactory> mockTicketListItemViewModelFactory;
        Mock<ITicketRepository> mockTicketRepository;

        [Test]
        public void SelectedItem_WhenSet_RaisesSelectedItemChanged()
        {
            SystemUnderTest.SelectedItemChanged += HandleSelectedItemChanged;
            SystemUnderTest.SelectedItem = new TicketListItemViewModel(null);
            Assert.That(invocationCount, Is.EqualTo(1));
        }

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
            mockShowTicketDetailsCommandFactory = CreateMock<IShowTicketDetailsCommandFactory>();
        }

        protected override TicketListViewModel CreateSystemUnderTest()
        {
            return new TicketListViewModel(mockTicketRepository.Object, mockTicketListItemViewModelFactory.Object,
                                           mockShowTicketDetailsCommandFactory.Object);
        }

        protected override void SetupConstructorRequiredMocks()
        {
            base.SetupConstructorRequiredMocks();
            var tickets = new List<Ticket> {new Ticket(), new Ticket(), new Ticket()};
            SetupTicketRepository(tickets);
            SetupListItemFactory(tickets);
            mockShowTicketDetailsCommandFactory.Setup(p => p.Create(It.IsAny<ISelectedItem<ITicketListItemViewModel>>()))
                                               .Returns(mockShowTicketDetailsCommand.Object);
        }

        void HandleSelectedItemChanged(object sender, EventArgs e)
        {
            invocationCount++;
        }

        void SetupListItemFactory(List<Ticket> tickets)
        {
            foreach (var ticket in tickets)
            {
                var mockListItemViewModel = CreateMock<ITicketListItemViewModel>();
                mockTicketListItemViewModelFactory.Setup(p => p.Create(ticket)).Returns(mockListItemViewModel.Object);
            }
        }

        void SetupTicketRepository(List<Ticket> tickets)
        {
            mockTicketRepository.Setup(p => p.GetAll()).Returns(tickets);
        }
    }
}