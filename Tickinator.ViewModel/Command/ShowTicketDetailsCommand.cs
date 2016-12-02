//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ShowTicketDetailsCommand.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

using System.Linq;
using Tickinator.Repository;
using Tickinator.ViewModel.Command.Core;
using Tickinator.ViewModel.TicketDetails;
using Tickinator.ViewModel.TicketList;
using Tickinator.ViewModel.View;
using Tickinator.ViewModel.View.Core;

namespace Tickinator.ViewModel.Command
{
    public class ShowTicketDetailsCommand : GenericCommandBase<ITicketListItemViewModel>, IShowTicketDetailsCommand
    {
        readonly ICloseCommandFactory closeCommandFactory;
        readonly ITicketDetailsViewModelFactory ticketDetailsViewModelFactory;
        readonly ITicketRepository ticketRepository;
        readonly IViewFactory viewFactory;

        public ShowTicketDetailsCommand(IViewFactory viewFactory,
            ITicketDetailsViewModelFactory ticketDetailsViewModelFactory, ITicketRepository ticketRepository,
            ICloseCommandFactory closeCommandFactory)
        {
            this.viewFactory = viewFactory;
            this.ticketDetailsViewModelFactory = ticketDetailsViewModelFactory;
            this.ticketRepository = ticketRepository;
            this.closeCommandFactory = closeCommandFactory;
        }

        protected override void ExecuteInternal(ITicketListItemViewModel parameter)
        {
            var view = CreateView();
            var viewModel = CreateViewModel(parameter, view);
            view.DataContext = viewModel;
            view.ShowDialog();
        }

        ITicketDetailsView CreateView()
        {
            var view = viewFactory.Create<ITicketDetailsView>();
            return view;
        }

        ITicketDetailsViewModel CreateViewModel(ITicketListItemViewModel parameter, ITicketDetailsView view)
        {
            var closeCommand = closeCommandFactory.Create(view);
            var ticket = ticketRepository.GetAll().FirstOrDefault(p => p.Id == parameter.Id);
            var viewModel = ticketDetailsViewModelFactory.Create(ticket, closeCommand);
            return viewModel;
        }
    }
}