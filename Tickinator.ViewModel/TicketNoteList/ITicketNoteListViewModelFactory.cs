//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITicketNoteListViewModelFactory.cs
// 2016/12/13
//  --------------------------------------------------------------------------------------

namespace Tickinator.ViewModel.TicketNoteList
{
    public interface ITicketNoteListViewModelFactory
    {
        ITicketNoteListViewModel Create(int ticketId);
    }
}