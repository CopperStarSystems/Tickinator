//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TicketListItemViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System;
using GalaSoft.MvvmLight;
using Tickinator.Model;

namespace Tickinator.ViewModel.TicketList
{
    public class TicketListItemViewModel : ViewModelBase, ITicketListItemViewModel
    {
        readonly Ticket ticket;

        public TicketListItemViewModel(Ticket ticket)
        {
            this.ticket = ticket;
        }

        public int AssignedToId
        {
            get { return ticket.AssignedToId; }
            set
            {
                ticket.AssignedToId = value;
                RaisePropertyChanged(nameof(AssignedToId));
            }
        }

        public DateTime? DateClosed
        {
            get { return ticket.DateClosed; }
            set
            {
                ticket.DateClosed = value;
                RaisePropertyChanged(nameof(DateClosed));
            }
        }

        public DateTime DateOpened
        {
            get { return ticket.DateOpened; }
            set
            {
                ticket.DateOpened = value;
                RaisePropertyChanged(nameof(DateOpened));
            }
        }

        public int Id
        {
            get { return ticket.Id; }
            set
            {
                ticket.Id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }
    }
}