//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TicketNoteListViewModelTests.cs
// 2016/12/13
//  --------------------------------------------------------------------------------------

using Tickinator.ViewModel.TicketNoteList;

namespace Tickinator.ViewModel.Tests.TicketNoteList
{
    public class TicketNoteListViewModelTests : TestBase<TicketNoteListViewModel>
    {
        protected override TicketNoteListViewModel CreateSystemUnderTest()
        {
            return new TicketNoteListViewModel();
        }
    }
}