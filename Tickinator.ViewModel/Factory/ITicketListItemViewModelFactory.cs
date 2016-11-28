//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITicketListItemViewModelFactory.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using Tickinator.Model;
using Tickinator.ViewModel.TicketList;

namespace Tickinator.ViewModel.Factory
{
    public interface ITicketListItemViewModelFactory
    {
        ITicketListItemViewModel Create(Ticket ticket);
    }
}