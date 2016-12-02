//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TicketListItemViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using Tickinator.Model;
using Tickinator.ViewModel.StatusList;

namespace Tickinator.ViewModel.TicketList
{
    public class TicketListItemViewModel : ViewModelBase, ITicketListItemViewModel
    {
        readonly IStatusListProvider statusListProvider;
        readonly Ticket ticket;

        public TicketListItemViewModel(Ticket ticket, IStatusListProvider statusListProvider)
        {
            this.ticket = ticket;
            this.statusListProvider = statusListProvider;
        }

        public int Id
        {
            get
            {
                return ticket.Id;
            }
            set
            {
                ticket.Id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }

        public DateTime? DateClosed
        {
            get
            {
                return ticket.DateClosed;
            }
            set
            {
                ticket.DateClosed = value;
                RaisePropertyChanged(nameof(DateClosed));
            }
        }

        public DateTime DateOpened
        {
            get
            {
                return ticket.DateOpened;
            }
            set
            {
                ticket.DateOpened = value;
                RaisePropertyChanged(nameof(DateOpened));
            }
        }

        public int AssignedToId
        {
            get
            {
                return ticket.AssignedToId;
            }
            set
            {
                ticket.AssignedToId = value;
                RaisePropertyChanged(nameof(AssignedToId));
            }
        }

        public IEnumerable<IStatusListItemViewModel> Statuses { get; }
    }
}