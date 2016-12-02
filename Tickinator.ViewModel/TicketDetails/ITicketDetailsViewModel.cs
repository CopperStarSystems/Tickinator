//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITicketDetailsViewModel.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Input;
using Tickinator.ViewModel.StatusList;

namespace Tickinator.ViewModel.TicketDetails
{
    public interface ITicketDetailsViewModel : IViewModel
    {
        IEnumerable<IStatusListItemViewModel> Statuses { get; }
        ICommand CloseCommand { get; }
        DateTime? DateClosed { get; set; }
        DateTime DateOpened { get; set; }
        int AssignedToId { get; set; }
        int Id { get; set; }
    }
}