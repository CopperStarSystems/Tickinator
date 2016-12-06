//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITicketListItemViewModelFactory.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using Tickinator.Model;

namespace Tickinator.ViewModel.TicketList
{
    public interface ITicketListItemViewModelFactory
    {
        ITicketListItemViewModel Create(Ticket ticket);
    }
}