//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TicketListViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
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

        readonly CollectionViewSource ticketsViewSource;

        ITicketListItemViewModel selectedItem;
        bool showOnlyMyTickets;
        bool showOnlyOpenTickets;

        public TicketListViewModel(ITicketRepository ticketRepository,
                                   ITicketListItemViewModelFactory ticketListItemViewModelFactory,
                                   IShowTicketDetailsCommandFactory showTicketDetailsCommandFactory,
                                   IMessenger messenger)
        {
            this.ticketRepository = ticketRepository;
            this.ticketListItemViewModelFactory = ticketListItemViewModelFactory;
            TicketList = new ObservableCollection<ITicketListItemViewModel>();
            PopulateTicketList();
            CreateShowDetailsCommand(showTicketDetailsCommandFactory);
            ticketsViewSource = CreateViewSource();
            RegisterForTicketUpdatedMessage(messenger);
            ShowOnlyOpenTickets = true;
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

        public bool ShowOnlyMyTickets
        {
            get { return showOnlyMyTickets; }
            set
            {
                showOnlyMyTickets = value;
                RefreshTicketsView();
                RaisePropertyChanged(nameof(ShowOnlyMyTickets));
            }
        }

        public bool ShowOnlyOpenTickets
        {
            get { return showOnlyOpenTickets; }
            set
            {
                showOnlyOpenTickets = value;
                RefreshTicketsView();
                RaisePropertyChanged(nameof(ShowOnlyOpenTickets));
            }
        }

        public ICommand ShowTicketDetailsCommand { get; private set; }

        ObservableCollection<ITicketListItemViewModel> TicketList { get; }

        public ICollectionView Tickets
        {
            get { return ticketsViewSource.View; }
        }

        void ApplyFilter(object sender, FilterEventArgs e)
        {
            var accepted = true;
            var item = (ITicketListItemViewModel) e.Item;
            if (ShowOnlyOpenTickets)
                accepted &= !item.DateClosed.HasValue;
            if (ShowOnlyMyTickets)
                accepted &= item.AssignedToId == 1;
            e.Accepted = accepted;
        }

        void CreateShowDetailsCommand(IShowTicketDetailsCommandFactory showTicketDetailsCommandFactory)
        {
            ShowTicketDetailsCommand = showTicketDetailsCommandFactory.Create(this);
        }

        CollectionViewSource CreateViewSource()
        {
            var viewSource = new CollectionViewSource();
            viewSource.Source = TicketList;
            viewSource.Filter += ApplyFilter;
            return viewSource;
        }

        void HandleTicketUpdated(ITicketUpdatedMessage payload)
        {
            PopulateTicketList();
        }

        void PopulateTicketList()
        {
            TicketList.Clear();
            foreach (var ticket in ticketRepository.GetAll())
                TicketList.Add(ticketListItemViewModelFactory.Create(ticket));
        }

        void RaiseSelectedItemChanged()
        {
            var handler = SelectedItemChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        void RefreshTicketsView()
        {
            Tickets.Refresh();
        }

        void RegisterForTicketUpdatedMessage(IMessenger messenger)
        {
            messenger.Register<ITicketUpdatedMessage>(this, HandleTicketUpdated);
        }
    }
}