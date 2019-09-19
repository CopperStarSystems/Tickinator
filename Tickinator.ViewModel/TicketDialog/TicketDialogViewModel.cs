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
using Tickinator.ViewModel.TicketNoteList;

namespace Tickinator.ViewModel.TicketDialog
{
    public class TicketDialogViewModel : ViewModelBase, ITicketDialogViewModel
    {
        private readonly Ticket ticket;
        private string header;

        private IEnumerable<IStatusListItemViewModel> statuses;

        public TicketDialogViewModel(Ticket ticket, ICloseCommand closeCommand, IStatusListProvider statusListProvider,
            ITechnicianListProvider technicianListProvider,
            ITicketNoteListViewModelFactory noteListViewModelFactory,
            ISaveTicketCommand saveTicketCommand, string header)
        {
            this.ticket = ticket;
            CloseCommand = closeCommand;
            SaveCommand = saveTicketCommand;
            Statuses = statusListProvider.GetStatuses();
            Technicians = technicianListProvider.GetTechnicians();
            Header = header;
            Notes = noteListViewModelFactory.Create(ticket.Id);
        }

        public int AssignedToId
        {
            get => ticket.AssignedToId;
            set
            {
                ticket.AssignedToId = value;
                RaisePropertyChanged(nameof(AssignedToId));
            }
        }

        public ICommand CloseCommand { get; }

        public DateTime? DateClosed
        {
            get => ticket.DateClosed;
            set
            {
                ticket.DateClosed = value;
                RaisePropertyChanged(nameof(DateClosed));
            }
        }

        public DateTime DateOpened
        {
            get => ticket.DateOpened;
            set
            {
                ticket.DateOpened = value;
                RaisePropertyChanged(nameof(DateOpened));
            }
        }

        public string Header
        {
            get => header;
            set
            {
                header = value;
                RaisePropertyChanged(nameof(Header));
            }
        }

        public string Title
        {
            get => ticket.Title;
            set
            {
                ticket.Title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        public int Id
        {
            get => ticket.Id;
            set
            {
                ticket.Id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }

        public ITicketNoteListViewModel Notes { get; }

        public ICommand SaveCommand { get; }

        public StatusEnum Status
        {
            get => ticket.Status;
            set
            {
                ticket.Status = value;
                RaisePropertyChanged(nameof(Status));
            }
        }

        public IEnumerable<IStatusListItemViewModel> Statuses
        {
            get => statuses;
            private set
            {
                statuses = value;
                RaisePropertyChanged(nameof(Statuses));
            }
        }

        public IEnumerable<ITechnicianListItemViewModel> Technicians { get; }
    }
}