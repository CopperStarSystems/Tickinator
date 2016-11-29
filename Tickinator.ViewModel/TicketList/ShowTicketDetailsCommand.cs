//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ShowTicketDetailsCommand.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

using Tickinator.ViewModel.Command;

namespace Tickinator.ViewModel.TicketList
{
    public class ShowTicketDetailsCommand : GenericCommandBase<TicketListItemViewModel>, IShowTicketDetailsCommand
    {
        protected override void ExecuteInternal(TicketListItemViewModel parameter)
        {
        }
    }
}