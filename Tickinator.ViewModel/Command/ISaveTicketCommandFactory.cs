//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ISaveTicketCommandFactory.cs
// 2016/12/07
//  --------------------------------------------------------------------------------------

using Tickinator.Model;

namespace Tickinator.ViewModel.Command
{
    public interface ISaveTicketCommandFactory
    {
        ISaveTicketCommand Create(Ticket ticket);
    }
}