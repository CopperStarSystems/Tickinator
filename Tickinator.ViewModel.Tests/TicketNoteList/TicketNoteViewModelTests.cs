//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TicketNoteViewModelTests.cs
// 2016/12/13
//  --------------------------------------------------------------------------------------

using Tickinator.ViewModel.TicketNoteList;

namespace Tickinator.ViewModel.Tests.TicketNoteList
{
    public class TicketNoteViewModelTests : TestBase<TicketNoteViewModel>
    {
        protected override TicketNoteViewModel CreateSystemUnderTest()
        {
            return new TicketNoteViewModel();
        }
    }
}