//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.ShowTicketDetailsCommandTests.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Tickinator.Model;
using Tickinator.Repository;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.Infrastructure;
using Tickinator.ViewModel.Tests.Command.Core;
using Tickinator.ViewModel.TicketDetails;
using Tickinator.ViewModel.TicketList;
using Tickinator.ViewModel.View;
using Tickinator.ViewModel.View.Core;

namespace Tickinator.ViewModel.Tests.Command
{
    [TestFixture]
    public class ShowTicketDetailsCommandTests : CommandBaseTests<ShowTicketDetailsCommand>
    {
        Mock<ICloseCommand> mockCloseCommand;
        Mock<ICloseCommandFactory> mockCloseCommandFactory;
        Mock<ITicketDetailsView> mockTicketDetailsView;
        Mock<ITicketDetailsViewModel> mockTicketDetailsViewModel;
        Mock<ITicketDetailsViewModelFactory> mockTicketDetailsViewModelFactory;
        Mock<ITicketRepository> mockTicketRepository;
        Mock<IViewFactory> mockViewFactory;
        Mock<ITicketListItemViewModel> mockViewModel;
        Mock<ISelectedItem<ITicketListItemViewModel>> mockSelectedItem;
        IList<Ticket> tickets;

        [TestCase(1)]
        [TestCase(3)]
        public void Execute_Always_PerformsExpectedWork(int ticketId)
        {
            CreateTickets();
            SetupMocksForExecuteTest(ticketId);
            Execute(mockViewModel.Object);
            MockRepository.VerifyAll();
        }

        static IEnumerable<TestCaseData> CanExecuteTestData
        {
            get
            {
                yield return new TestCaseData(null, false);
                yield return new TestCaseData(new TicketListItemViewModel(null), true);
            }
        }

        [TestCaseSource(nameof(CanExecuteTestData))]
        public void CanExecute_Always_ReturnsExpectedResult(ITicketListItemViewModel ticketListItemViewModel,
            bool expectedResult)
        {
            mockSelectedItem.Setup(p => p.SelectedItem).Returns(ticketListItemViewModel);
            Assert.That(CanExecute(), Is.EqualTo(expectedResult));
        }

        int invocationCount;

        void CanExecuteChangedHandler(object sender, EventArgs e)
        {
            invocationCount++;
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockViewFactory = CreateMock<IViewFactory>();
            mockTicketDetailsView = CreateMock<ITicketDetailsView>();
            mockViewModel = CreateMock<ITicketListItemViewModel>();
            mockTicketDetailsViewModelFactory = CreateMock<ITicketDetailsViewModelFactory>();
            mockTicketRepository = CreateMock<ITicketRepository>();
            mockCloseCommandFactory = CreateMock<ICloseCommandFactory>();
            mockCloseCommand = CreateMock<ICloseCommand>();
            mockTicketDetailsViewModel = CreateMock<ITicketDetailsViewModel>();
            mockSelectedItem = CreateMock<ISelectedItem<ITicketListItemViewModel>>();
        }

        protected override ShowTicketDetailsCommand CreateSystemUnderTest()
        {
            return new ShowTicketDetailsCommand(mockViewFactory.Object, mockTicketDetailsViewModelFactory.Object,
                mockTicketRepository.Object, mockCloseCommandFactory.Object, mockSelectedItem.Object);
        }

        void CreateTickets()
        {
            tickets = new List<Ticket>();

            for (var i = 0; i < 5; i++)
                tickets.Add(new Ticket {Id = i + 1});
        }

        void SetupMocksForExecuteTest(int ticketId)
        {
            mockViewFactory.Setup(p => p.Create<ITicketDetailsView>()).Returns(mockTicketDetailsView.Object);
            mockTicketRepository.Setup(p => p.GetAll()).Returns(tickets);
            mockViewModel.SetupGet(p => p.Id).Returns(ticketId);
            mockTicketDetailsViewModelFactory.Setup(p => p.Create(tickets[ticketId - 1], mockCloseCommand.Object))
                .Returns(mockTicketDetailsViewModel.Object);
            mockTicketDetailsView.SetupSet(p => p.DataContext = mockTicketDetailsViewModel.Object);
            mockCloseCommandFactory.Setup(p => p.Create(mockTicketDetailsView.Object)).Returns(mockCloseCommand.Object);
            mockSelectedItem.SetupGet(p => p.SelectedItem).Returns(new TicketListItemViewModel(null));
            mockTicketDetailsView.Setup(p => p.ShowDialog()).Returns(true);
        }

        [Test]
        public void Command_WhenSelectedItemChanges_RaisesCanExecuteChanged()
        {
            invocationCount = 0;
            SystemUnderTest.CanExecuteChanged += CanExecuteChangedHandler;
            var ticketListItem = new TicketListItemViewModel(null);
            mockSelectedItem.Raise(p=>p.SelectedItemChanged += null, EventArgs.Empty);
            Assert.That(invocationCount, Is.EqualTo(1));
        }
    }
}