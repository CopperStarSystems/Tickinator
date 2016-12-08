//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ISaveTicketCommandFactory.cs
// 2016/12/07
//  --------------------------------------------------------------------------------------

using Tickinator.Model;
using Tickinator.ViewModel.View;

namespace Tickinator.ViewModel.Command
{
    public interface ISaveTicketCommandFactory
    {
        ISaveTicketCommand Create(Ticket ticket, IClosable closable);
    }
}