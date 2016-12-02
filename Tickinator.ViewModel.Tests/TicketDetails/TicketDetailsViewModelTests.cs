//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TicketDetailsViewModelTests.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using Moq;
using Tickinator.Model;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.TicketDetails;

namespace Tickinator.ViewModel.Tests.TicketDetails
{
    public class TicketDetailsViewModelTests : TestBase<TicketDetailsViewModel>
    {
        readonly Ticket ticket = new Ticket();
        Mock<ICloseCommand> mockCloseCommand;

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockCloseCommand = CreateMock<ICloseCommand>();
        }

        protected override TicketDetailsViewModel CreateSystemUnderTest()
        {
            return new TicketDetailsViewModel(ticket, mockCloseCommand.Object);
        }
    }
}