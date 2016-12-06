//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TicketDetailsViewModel.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Tickinator.Model;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.StatusList;
using Tickinator.ViewModel.TechnicianList;

#endregion

namespace Tickinator.ViewModel.TicketDetails
{
    public class TicketDetailsViewModel : ViewModelBase, ITicketDetailsViewModel
    {
        readonly Ticket ticket;

        IEnumerable<IStatusListItemViewModel> statuses;

        public TicketDetailsViewModel(Ticket ticket, ICloseCommand closeCommand, IStatusListProvider statusListProvider,
            ITechnicianListProvider technicianListProvider)
        {
            this.ticket = ticket;
            CloseCommand = closeCommand;
            Statuses = statusListProvider.GetStatuses();
            Technicians = technicianListProvider.GetTechnicians();
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

        public IEnumerable<ITechnicianListItemViewModel> Technicians { get; }
    }
}