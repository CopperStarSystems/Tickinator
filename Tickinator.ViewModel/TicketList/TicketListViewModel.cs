//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TicketListViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Tickinator.Repository;
using Tickinator.ViewModel.Command;

namespace Tickinator.ViewModel.TicketList
{
    public class TicketListViewModel : ViewModelBase, ITicketListViewModel
    {
        public event EventHandler SelectedItemChanged;

        ITicketListItemViewModel selectedItem;

        public ICommand ShowTicketDetailsCommand { get; }

        public ObservableCollection<ITicketListItemViewModel> TodaysTickets { get; }

        public TicketListViewModel(ITicketRepository ticketRepository,
                                   ITicketListItemViewModelFactory ticketListItemViewModelFactory,
                                   IShowTicketDetailsCommandFactory showTicketDetailsCommandFactory)
        {
            TodaysTickets = new ObservableCollection<ITicketListItemViewModel>();
            foreach (var ticket in ticketRepository.GetAll())
                TodaysTickets.Add(ticketListItemViewModelFactory.Create(ticket));
            ShowTicketDetailsCommand = showTicketDetailsCommandFactory.Create(this);
        }

        public ITicketListItemViewModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                RaisePropertyChanged(nameof(SelectedItem));
                RaiseSelectedItemChanged();
            }
        }

        void RaiseSelectedItemChanged()
        {
            var handler = SelectedItemChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}