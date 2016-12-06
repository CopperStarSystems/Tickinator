//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITicketDetailsViewModel.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Input;
using Tickinator.ViewModel.StatusList;
using Tickinator.ViewModel.TechnicianList;

namespace Tickinator.ViewModel.TicketDetails
{
    public interface ITicketDetailsViewModel : IViewModel
    {
        ICommand CloseCommand { get; }

        IEnumerable<IStatusListItemViewModel> Statuses { get; }

        IEnumerable<ITechnicianListItemViewModel> Technicians { get; }

        int AssignedToId { get; set; }

        DateTime? DateClosed { get; set; }

        DateTime DateOpened { get; set; }

        int Id { get; set; }
    }
}