//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITodaysTicketsListViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Windows.Input;
using Tickinator.ViewModel.Infrastructure;

namespace Tickinator.ViewModel.TicketList
{
    public interface ITicketListViewModel : IViewModel, ISelectedItem<ITicketListItemViewModel>
    {
        ICommand ShowTicketDetailsCommand { get; }
        ObservableCollection<ITicketListItemViewModel> TodaysTickets { get; }
    }
}