//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TodaysTicketsListViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Tickinator.Model;
using Tickinator.Repository;
using Tickinator.ViewModel.Core;
using Tickinator.ViewModel.Factory;

namespace Tickinator.ViewModel.TicketList
{
    public class TicketListViewModel : ViewModelBase, ITicketListViewModel
    {
        ITicketListItemViewModel selectedItem;

        public TicketListViewModel(ITicketRepository ticketRepository,
            ITicketListItemViewModelFactory ticketListItemViewModelFactory)
        {
            TodaysTickets = new ObservableCollection<ITicketListItemViewModel>();
            foreach (var ticket in ticketRepository.GetAll())
                // Normally we would use a factory to create TicketListItemViewModel instances...
                // We'll do a manual factory in our next checkin.
                TodaysTickets.Add(ticketListItemViewModelFactory.Create(ticket));
        }

        public ObservableCollection<ITicketListItemViewModel> TodaysTickets { get; }

        public ITicketListItemViewModel SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                RaisePropertyChanged(nameof(SelectedItem));
            }
        }
    }
}