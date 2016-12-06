//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITicketListItemViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System;

namespace Tickinator.ViewModel.TicketList
{
    public interface ITicketListItemViewModel
    {
        int AssignedToId { get; set; }

        DateTime? DateClosed { get; set; }

        DateTime DateOpened { get; set; }
        int Id { get; set; }
    }
}