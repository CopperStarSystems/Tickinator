//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITicketDialogViewModelFactory.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using Tickinator.Model;
using Tickinator.ViewModel.Command;

namespace Tickinator.ViewModel.TicketDialog
{
    public interface ITicketDialogViewModelFactory
    {
        ITicketDialogViewModel Create(Ticket ticket, ICloseCommand closeCommand, ISaveTicketCommand saveTicketCommand,
                                      string header);
    }
}