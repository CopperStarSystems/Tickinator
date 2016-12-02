//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TicketDetailsViewModel.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Tickinator.Model;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.StatusList;

namespace Tickinator.ViewModel.TicketDetails
{
    public class TicketDetailsViewModel : ViewModelBase, ITicketDetailsViewModel
    {
        readonly Ticket ticket;
        int assignedToId;
        DateTime? dateClosed;
        DateTime dateOpened;
        int id;
        IEnumerable<IStatusListItemViewModel> statuses;

        public TicketDetailsViewModel(Ticket ticket, ICloseCommand closeCommand)
        {
            this.ticket = ticket;
            CloseCommand = closeCommand;
        }

        public IEnumerable<IStatusListItemViewModel> Statuses
        {
            get
            {
                return statuses;
            }
            private set
            {
                statuses = value;
                RaisePropertyChanged(nameof(Statuses));
            }
        }

        public ICommand CloseCommand { get; }

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
    }
}