//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.SaveTicketCommand.cs
// 2016/12/07
//  --------------------------------------------------------------------------------------

using Tickinator.Model;
using Tickinator.Repository;
using Tickinator.ViewModel.Command.Core;

namespace Tickinator.ViewModel.Command
{
    public class SaveTicketCommand : CommandBase, ISaveTicketCommand
    {
        readonly ITicketRepository ticketRepository;
        Ticket ticket;

        public SaveTicketCommand(Ticket ticket, ITicketRepository ticketRepository)
        {
            this.ticket = ticket;
            this.ticketRepository = ticketRepository;
        }

        public override void Execute(object parameter)
        {
            ticket = ticketRepository.Insert(ticket);
        }
    }
}