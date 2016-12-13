//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITicketNoteViewModel.cs
// 2016/12/13
//  --------------------------------------------------------------------------------------

using System;

namespace Tickinator.ViewModel.TicketNoteList
{
    public interface ITicketNoteViewModel : IViewModel
    {
        DateTime Created { get; set; }

        string Note { get; set; }

        int TicketId { get; set; }
    }
}