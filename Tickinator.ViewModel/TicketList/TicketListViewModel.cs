//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TodaysTicketsListViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Tickinator.Repository;
using Tickinator.ViewModel.Factory;

namespace Tickinator.ViewModel.TicketList
{
    public class TicketListViewModel : ViewModelBase, ITicketListViewModel
    {
        ITicketListItemViewModel selectedItem;

        public TicketListViewModel(ITicketRepository ticketRepository,
            ITicketListItemViewModelFactory ticketListItemViewModelFactory,
            IShowTicketDetailsCommand showTicketDetailsCommand)
        {
            TodaysTickets = new ObservableCollection<ITicketListItemViewModel>();
            foreach (var ticket in ticketRepository.GetAll())
                // Normally we would use a factory to create TicketListItemViewModel instances...
                // We'll do a manual factory in our next checkin.
                TodaysTickets.Add(ticketListItemViewModelFactory.Create(ticket));
            ShowTicketDetailsCommand = showTicketDetailsCommand;
        }

        public ObservableCollection<ITicketListItemViewModel> TodaysTickets { get; }

        public ICommand ShowTicketDetailsCommand { get; }

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