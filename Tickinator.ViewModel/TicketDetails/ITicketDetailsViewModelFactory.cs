//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITicketDetailsViewModelFactory.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using Tickinator.Model;
using Tickinator.ViewModel.Command;

namespace Tickinator.ViewModel.TicketDetails
{
    public interface ITicketDetailsViewModelFactory
    {
        ITicketDetailsViewModel Create(Ticket ticket, ICloseCommand closeCommand, string header);
    }
}