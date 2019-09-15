//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TicketListViewModelTests.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;
using Moq;
using NUnit.Framework;
using Tickinator.Model;
using Tickinator.Repository;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.Infrastructure;
using Tickinator.ViewModel.Messages.TicketUpdated;
using Tickinator.ViewModel.TicketList;

namespace Tickinator.ViewModel.Tests.TicketList
{
    [TestFixture]
    public class TicketListViewModelTests : TestBase<TicketListViewModel>
    {
        int invocationCount;
        Mock<IMessenger> mockMessenger;
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
        public void ShowOnlyMyTickets_AfterConstruction_IsFalse()
        {
            Assert.That(SystemUnderTest.ShowOnlyMyTickets, Is.False);
        }

        [Test]
        public void ShowOnlyOpenTickets_AfterConstruction_IsTrue()
        {
            Assert.That(SystemUnderTest.ShowOnlyOpenTickets, Is.True);
        }

        [Test]
        public void ShowTicketDetailsCommand_AfterConstruction_IsExpectedValue()
        {
            Assert.That(SystemUnderTest.ShowTicketDetailsCommand, Is.Not.Null);
            Assert.That(SystemUnderTest.ShowTicketDetailsCommand, Is.SameAs(mockShowTicketDetailsCommand.Object));
        }

        [Test]
        public void TicketsView_AfterConstruction_IsNotNull()
        {
            Assert.That(SystemUnderTest.Tickets, Is.Not.Null);
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockTicketRepository = CreateMock<ITicketRepository>();
            mockTicketListItemViewModelFactory = CreateMock<ITicketListItemViewModelFactory>();
            mockShowTicketDetailsCommand = CreateMock<IShowTicketDetailsCommand>();
            mockShowTicketDetailsCommandFactory = CreateMock<IShowTicketDetailsCommandFactory>();
            mockMessenger = CreateMock<IMessenger>();
        }

        protected override TicketListViewModel CreateSystemUnderTest()
        {
            return new TicketListViewModel(mockTicketRepository.Object, mockTicketListItemViewModelFactory.Object,
                                           mockShowTicketDetailsCommandFactory.Object, mockMessenger.Object);
        }

        protected override void SetupConstructorRequiredMocks()
        {
            base.SetupConstructorRequiredMocks();
            var tickets = new List<Ticket> {new Ticket(), new Ticket(), new Ticket()};
            SetupTicketRepository(tickets);
            SetupListItemFactory(tickets);
            mockShowTicketDetailsCommandFactory.Setup(p => p.Create(It.IsAny<ISelectedItem<ITicketListItemViewModel>>()))
                                               .Returns(mockShowTicketDetailsCommand.Object);
            mockMessenger.Setup(
                p => p.Register(It.IsAny<TicketListViewModel>(), It.IsAny<Action<ITicketUpdatedMessage>>(), false));
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
                mockListItemViewModel.SetupGet(p => p.DateClosed).Returns(DateTime.Today);
            }
        }

        void SetupTicketRepository(List<Ticket> tickets)
        {
            mockTicketRepository.Setup(p => p.GetAll()).Returns(tickets);
        }
    }
}