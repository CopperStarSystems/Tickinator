//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITodaysTicketsListViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System.Collections.ObjectModel;
using Tickinator.ViewModel.Core;

namespace Tickinator.ViewModel.TicketList
{
    public interface ITodaysTicketsListViewModel : IViewModel
    {
        ObservableCollection<ITicketListItemViewModel> TodaysTickets { get; }
    }
}