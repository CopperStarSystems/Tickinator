//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ShowTicketDetailsCommand.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using System;
using System.Linq;
using Tickinator.Common;
using Tickinator.Repository;
using Tickinator.ViewModel.Command.Core;
using Tickinator.ViewModel.Infrastructure;
using Tickinator.ViewModel.TicketDialog;
using Tickinator.ViewModel.TicketList;
using Tickinator.ViewModel.View;
using Tickinator.ViewModel.View.Core;

namespace Tickinator.ViewModel.Command
{
    public class ShowTicketDetailsCommand : GenericCommandBase<ITicketListItemViewModel>, IShowTicketDetailsCommand
    {
        readonly ICloseCommandFactory closeCommandFactory;
        readonly ISaveTicketCommandFactory saveTicketCommandFactory;
        readonly ISelectedItem<ITicketListItemViewModel> selectedItem;
        readonly ITicketDialogViewModelFactory ticketDialogViewModelFactory;
        readonly ITicketRepository ticketRepository;
        readonly IViewFactory viewFactory;

        public ShowTicketDetailsCommand(IViewFactory viewFactory,
                                        ITicketDialogViewModelFactory ticketDialogViewModelFactory,
                                        ITicketRepository ticketRepository, ICloseCommandFactory closeCommandFactory,
                                        ISaveTicketCommandFactory saveTicketCommandFactory,
                                        ISelectedItem<ITicketListItemViewModel> selectedItem)
        {
            this.viewFactory = viewFactory;
            this.ticketDialogViewModelFactory = ticketDialogViewModelFactory;
            this.ticketRepository = ticketRepository;
            this.closeCommandFactory = closeCommandFactory;
            this.saveTicketCommandFactory = saveTicketCommandFactory;
            this.selectedItem = selectedItem;
            selectedItem.SelectedItemChanged += HandleSelectedItemChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return selectedItem.SelectedItem != null;
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

        ITicketDialogViewModel CreateViewModel(ITicketListItemViewModel parameter, ITicketDetailsView view)
        {
            var closeCommand = closeCommandFactory.Create(view);

            var ticket = ticketRepository.GetAll().FirstOrDefault(p => p.Id == parameter.Id);
            var saveCommand = saveTicketCommandFactory.Create(ticket, view);
            var viewModel = ticketDialogViewModelFactory.Create(ticket, closeCommand, saveCommand,
                                                                Strings.TicketDetails.EditHeaderText);
            return viewModel;
        }

        void HandleSelectedItemChanged(object sender, EventArgs e)
        {
            RaiseCanExecuteChanged();
        }
    }
}