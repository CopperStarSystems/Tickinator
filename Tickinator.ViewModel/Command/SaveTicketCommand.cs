//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.SaveTicketCommand.cs
// 2016/12/07
//  --------------------------------------------------------------------------------------

using GalaSoft.MvvmLight.Messaging;
using Tickinator.Model;
using Tickinator.Repository;
using Tickinator.ViewModel.Command.Core;
using Tickinator.ViewModel.Messages.TicketUpdated;
using Tickinator.ViewModel.View;

namespace Tickinator.ViewModel.Command
{
    public class SaveTicketCommand : CommandBase, ISaveTicketCommand
    {
        readonly IClosable closable;
        readonly ITicketUpdatedMessageFactory messageFactory;
        readonly IMessenger messenger;
        readonly ITicketRepository ticketRepository;
        Ticket ticket;

        public SaveTicketCommand(Ticket ticket, IClosable closable, ITicketRepository ticketRepository,
                                 IMessenger messenger, ITicketUpdatedMessageFactory messageFactory)
        {
            this.ticket = ticket;
            this.closable = closable;
            this.ticketRepository = ticketRepository;
            this.messenger = messenger;
            this.messageFactory = messageFactory;
        }

        public override void Execute(object parameter)
        {
            if (ticket.Id == 0)
                ticket = ticketRepository.Insert(ticket);
            else
                ticket = ticketRepository.Update(ticket);
            messenger.Send(messageFactory.Create());
            closable.Close();
        }
    }
}