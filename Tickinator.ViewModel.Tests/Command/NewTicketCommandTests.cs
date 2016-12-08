//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.NewTicketCommandTests.cs
// 2016/12/07
//  --------------------------------------------------------------------------------------

using Moq;
using NUnit.Framework;
using Tickinator.Common;
using Tickinator.Model;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.Tests.Command.Core;
using Tickinator.ViewModel.TicketDialog;
using Tickinator.ViewModel.View;
using Tickinator.ViewModel.View.Core;

namespace Tickinator.ViewModel.Tests.Command
{
    [TestFixture]
    public class NewTicketCommandTests : CommandBaseTests<NewTicketCommand>
    {
        const string Header = "Header";
        Mock<ICloseCommand> mockCloseCommand;
        Mock<ICloseCommandFactory> mockCloseCommandFactory;
        Mock<IModelFactory> mockModelFactory;
        Mock<ISaveTicketCommand> mockSaveTicketCommand;
        Mock<ISaveTicketCommandFactory> mockSaveTicketCommandFactory;
        Mock<ITicketDetailsView> mockTicketDetailsView;
        Mock<ITicketDialogViewModel> mockTicketDialogViewModel;
        Mock<IViewFactory> mockViewFactory;
        Mock<ITicketDialogViewModelFactory> mockViewModelFactory;

        [Test]
        public void Execute_Always_PerformsExpectedWork()
        {
            var ticket = new Ticket();
            mockModelFactory.Setup(p => p.Create<Ticket>()).Returns(ticket);
            mockCloseCommandFactory.Setup(p => p.Create(mockTicketDetailsView.Object)).Returns(mockCloseCommand.Object);
            mockViewModelFactory.Setup(
                                    p =>
                                        p.Create(ticket, mockCloseCommand.Object, mockSaveTicketCommand.Object,
                                                 Strings.TicketDetails.AddHeaderText))
                                .Returns(mockTicketDialogViewModel.Object);
            mockViewFactory.Setup(p => p.Create<ITicketDetailsView>()).Returns(mockTicketDetailsView.Object);
            mockTicketDetailsView.SetupSet(p => p.DataContext = mockTicketDialogViewModel.Object);
            mockTicketDetailsView.Setup(p => p.ShowDialog()).Returns(true);
            mockSaveTicketCommandFactory.Setup(p => p.Create(ticket, mockTicketDetailsView.As<IClosable>().Object))
                                        .Returns(mockSaveTicketCommand.Object);
            Execute();
            MockRepository.VerifyAll();
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockModelFactory = CreateMock<IModelFactory>();
            mockViewFactory = CreateMock<IViewFactory>();
            mockViewModelFactory = CreateMock<ITicketDialogViewModelFactory>();
            mockTicketDialogViewModel = CreateMock<ITicketDialogViewModel>();
            mockCloseCommand = CreateMock<ICloseCommand>();
            mockTicketDetailsView = CreateMock<ITicketDetailsView>();
            mockCloseCommandFactory = CreateMock<ICloseCommandFactory>();
            mockSaveTicketCommand = CreateMock<ISaveTicketCommand>();
            mockSaveTicketCommandFactory = CreateMock<ISaveTicketCommandFactory>();
        }

        protected override NewTicketCommand CreateSystemUnderTest()
        {
            return new NewTicketCommand(mockModelFactory.Object, mockViewFactory.Object, mockViewModelFactory.Object,
                                        mockCloseCommandFactory.Object, mockSaveTicketCommandFactory.Object);
        }
    }
}