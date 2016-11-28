//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TicketListItemViewModelTests.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using Tickinator.ViewModel.TicketList;

namespace Tickinator.ViewModel.Tests.TicketList
{
    public class TicketListItemViewModelTests : TestBase<TicketListItemViewModel>
    {
        protected override TicketListItemViewModel CreateSystemUnderTest()
        {
            return new TicketListItemViewModel();
        }
    }
}