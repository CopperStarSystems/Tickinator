//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TicketNoteViewModel.cs
// 2016/12/13
//  --------------------------------------------------------------------------------------

using System;
using GalaSoft.MvvmLight;
using Tickinator.Model;

namespace Tickinator.ViewModel.TicketNoteList
{
    public class TicketNoteViewModel : ViewModelBase, ITicketNoteViewModel
    {
        readonly TicketNote ticketNote;

        public TicketNoteViewModel(TicketNote note)
        {
            this.ticketNote = note;
        }

        public DateTime Created
        {
            get { return ticketNote.Created; }
            set
            {
                ticketNote.Created = value;
                RaisePropertyChanged(nameof(Created));
            }
        }

        public string Note
        {
            get { return ticketNote.Note; }
            set
            {
                ticketNote.Note = value;
                RaisePropertyChanged(nameof(Note));
            }
        }

        public int TicketId
        {
            get { return ticketNote.TicketId; }
            set
            {
                ticketNote.TicketId = value;
                RaisePropertyChanged(nameof(TicketId));
            }
        }
    }
}