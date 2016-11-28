//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TodaysTicketsListViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System.Collections.ObjectModel;
using Tickinator.Model;
using Tickinator.Repository;
using Tickinator.ViewModel.Core;

namespace Tickinator.ViewModel.TicketList
{
    public class TodaysTicketsListViewModel : ViewModelBase, ITodaysTicketsListViewModel
    {
        public TodaysTicketsListViewModel(ITicketRepository ticketRepository)
        {
            TodaysTickets = new ObservableCollection<ITicketListItemViewModel>();
            foreach (var ticket in ticketRepository.GetAll())
                // Normally we would use a factory to create TicketListItemViewModel instances...
                // We'll do a manual factory in our next checkin.
                TodaysTickets.Add(new TicketListItemViewModel(ticket));
        }

        public ObservableCollection<ITicketListItemViewModel> TodaysTickets { get; }
    }
}