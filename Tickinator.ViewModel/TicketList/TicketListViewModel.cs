//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TicketListViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Tickinator.Repository;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.Messages.TicketUpdated;

namespace Tickinator.ViewModel.TicketList
{
    public class TicketListViewModel : ViewModelBase, ITicketListViewModel
    {
        public event EventHandler SelectedItemChanged;

        readonly ITicketListItemViewModelFactory ticketListItemViewModelFactory;
        readonly ITicketRepository ticketRepository;

        ITicketListItemViewModel selectedItem;

        public TicketListViewModel(ITicketRepository ticketRepository,
                                   ITicketListItemViewModelFactory ticketListItemViewModelFactory,
                                   IShowTicketDetailsCommandFactory showTicketDetailsCommandFactory,
                                   IMessenger messenger)
        {
            this.ticketRepository = ticketRepository;
            this.ticketListItemViewModelFactory = ticketListItemViewModelFactory;
            TodaysTickets = new ObservableCollection<ITicketListItemViewModel>();
            PopulateTicketList();
            CreateShowDetailsCommand(showTicketDetailsCommandFactory);
            RegisterForTicketUpdatedMessage(messenger);
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

        public ICommand ShowTicketDetailsCommand { get; private set; }

        public ObservableCollection<ITicketListItemViewModel> TodaysTickets { get; }

        void CreateShowDetailsCommand(IShowTicketDetailsCommandFactory showTicketDetailsCommandFactory)
        {
            ShowTicketDetailsCommand = showTicketDetailsCommandFactory.Create(this);
        }

        void HandleTicketUpdated(ITicketUpdatedMessage payload)
        {
            PopulateTicketList();
        }

        void PopulateTicketList()
        {
            TodaysTickets.Clear();
            foreach (var ticket in ticketRepository.GetAll())
                TodaysTickets.Add(ticketListItemViewModelFactory.Create(ticket));
        }

        void RaiseSelectedItemChanged()
        {
            var handler = SelectedItemChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        void RegisterForTicketUpdatedMessage(IMessenger messenger)
        {
            messenger.Register<ITicketUpdatedMessage>(this, HandleTicketUpdated);
        }
    }
}