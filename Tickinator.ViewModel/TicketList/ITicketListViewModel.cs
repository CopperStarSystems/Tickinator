//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITicketListViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows.Input;
using Tickinator.ViewModel.Infrastructure;

namespace Tickinator.ViewModel.TicketList
{
    public interface ITicketListViewModel : IViewModel, ISelectedItem<ITicketListItemViewModel>
    {
        bool ShowOnlyMyTickets { get; set; }

        bool ShowOnlyOpenTickets { get; set; }

        ICommand ShowTicketDetailsCommand { get; }

        ICollectionView Tickets { get; }
    }
}