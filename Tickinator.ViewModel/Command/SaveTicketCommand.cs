//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.SaveTicketCommand.cs
// 2016/12/07
//  --------------------------------------------------------------------------------------

using GalaSoft.MvvmLight.Messaging;
using Tickinator.Model;
using Tickinator.Repository;
using Tickinator.ViewModel.Command.Core;
using Tickinator.ViewModel.Messages.TicketUpdated;

namespace Tickinator.ViewModel.Command
{
    public class SaveTicketCommand : CommandBase, ISaveTicketCommand
    {
        readonly ITicketUpdatedMessageFactory messageFactory;
        readonly IMessenger messenger;
        readonly ITicketRepository ticketRepository;
        Ticket ticket;

        public SaveTicketCommand(Ticket ticket, ITicketRepository ticketRepository, IMessenger messenger,
                                 ITicketUpdatedMessageFactory messageFactory)
        {
            this.ticket = ticket;
            this.ticketRepository = ticketRepository;
            this.messenger = messenger;
            this.messageFactory = messageFactory;
        }

        public override void Execute(object parameter)
        {
            if (ticket.Id == 0)
                ticket = ticketRepository.Insert(ticket);
            messenger.Send(messageFactory.Create());
        }
    }
}