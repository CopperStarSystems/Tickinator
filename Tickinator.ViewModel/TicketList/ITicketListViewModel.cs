﻿//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITodaysTicketsListViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Tickinator.ViewModel.TicketList
{
    public interface ITicketListViewModel : IViewModel
    {
        ObservableCollection<ITicketListItemViewModel> TodaysTickets { get; }

        ICommand ShowTicketDetailsCommand { get; }
    }
}