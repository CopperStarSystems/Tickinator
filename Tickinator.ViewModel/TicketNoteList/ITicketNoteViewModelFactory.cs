//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITicketNoteViewModelFactory.cs
// 2016/12/13
//  --------------------------------------------------------------------------------------

using Tickinator.Model;

namespace Tickinator.ViewModel.TicketNoteList
{
    public interface ITicketNoteViewModelFactory
    {
        ITicketNoteViewModel Create(TicketNote note);
    }
}