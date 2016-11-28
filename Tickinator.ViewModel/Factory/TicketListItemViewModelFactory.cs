//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TicketListItemViewModelFactory.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using Tickinator.Model;
using Tickinator.ViewModel.TicketList;

namespace Tickinator.ViewModel.Factory
{
    public class TicketListItemViewModelFactory : ITicketListItemViewModelFactory
    {
        public ITicketListItemViewModel Create(Ticket ticket)
        {
            // This is a concrete factory, we will remove it once
            // we introduce Castle Windsor and can move to the 
            // TypedFactoryFacility approach.
            //
            // The way this is implemented now sets the stage
            // for the factory approach.
            return new TicketListItemViewModel(ticket);
        }
    }
}