//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TicketDialogViewModel.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Tickinator.Common.Enums;
using Tickinator.Model;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.StatusList;
using Tickinator.ViewModel.TechnicianList;

namespace Tickinator.ViewModel.TicketDialog
{
    public class TicketDialogViewModel : ViewModelBase, ITicketDialogViewModel
    {
        readonly Ticket ticket;
        string header;

        IEnumerable<IStatusListItemViewModel> statuses;

        public TicketDialogViewModel(Ticket ticket, ICloseCommand closeCommand, IStatusListProvider statusListProvider,
                                     ITechnicianListProvider technicianListProvider, string header)
        {
            this.ticket = ticket;
            CloseCommand = closeCommand;
            Statuses = statusListProvider.GetStatuses();
            Technicians = technicianListProvider.GetTechnicians();
            Header = header;
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

        public ICommand CloseCommand { get; }

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

        public string Header
        {
            get { return header; }
            set
            {
                header = value;
                RaisePropertyChanged(nameof(Header));
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

        public StatusEnum Status
        {
            get { return ticket.Status; }
            set
            {
                ticket.Status = value;
                RaisePropertyChanged(nameof(Status));
            }
        }

        public IEnumerable<IStatusListItemViewModel> Statuses
        {
            get { return statuses; }
            private set
            {
                statuses = value;
                RaisePropertyChanged(nameof(Statuses));
            }
        }

        public IEnumerable<ITechnicianListItemViewModel> Technicians { get; }
    }
}