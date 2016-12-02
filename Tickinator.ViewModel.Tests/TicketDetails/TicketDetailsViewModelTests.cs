//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TicketDetailsViewModelTests.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using Tickinator.ViewModel.TicketDetails;

namespace Tickinator.ViewModel.Tests.TicketDetails
{
    public class TicketDetailsViewModelTests : TestBase<TicketDetailsViewModel>
    {
        protected override TicketDetailsViewModel CreateSystemUnderTest()
        {
            return new TicketDetailsViewModel();
        }
    }
}