//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITicketDialogViewModel.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Input;
using Tickinator.Common.Enums;
using Tickinator.ViewModel.StatusList;
using Tickinator.ViewModel.TechnicianList;
using Tickinator.ViewModel.TicketNoteList;

namespace Tickinator.ViewModel.TicketDialog
{
    public interface ITicketDialogViewModel : IViewModel
    {
        int AssignedToId { get; set; }

        ICommand CloseCommand { get; }

        DateTime? DateClosed { get; set; }

        DateTime DateOpened { get; set; }

        string Header { get; set; }

        string Title { get; set; }

        int Id { get; set; }

        ITicketNoteListViewModel Notes { get; }

        ICommand SaveCommand { get; }

        StatusEnum Status { get; set; }

        IEnumerable<IStatusListItemViewModel> Statuses { get; }

        IEnumerable<ITechnicianListItemViewModel> Technicians { get; }
    }
}