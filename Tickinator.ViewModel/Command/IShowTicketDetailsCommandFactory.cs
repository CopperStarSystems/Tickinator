//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.IShowTicketDetailsCommandFactory.cs
// 2016/12/06
//  --------------------------------------------------------------------------------------

using Tickinator.ViewModel.Infrastructure;
using Tickinator.ViewModel.TicketList;

namespace Tickinator.ViewModel.Command
{
    public interface IShowTicketDetailsCommandFactory
    {
        IShowTicketDetailsCommand Create(ISelectedItem<ITicketListItemViewModel> selectedItem);
    }
}