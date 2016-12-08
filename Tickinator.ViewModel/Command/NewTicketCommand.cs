//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.NewTicketCommand.cs
// 2016/12/07
//  --------------------------------------------------------------------------------------

using Tickinator.Common;
using Tickinator.Model;
using Tickinator.ViewModel.Command.Core;
using Tickinator.ViewModel.TicketDialog;
using Tickinator.ViewModel.View;
using Tickinator.ViewModel.View.Core;

namespace Tickinator.ViewModel.Command
{
    public class NewTicketCommand : CommandBase, INewTicketCommand
    {
        readonly ICloseCommandFactory closeCommandFactory;
        readonly IModelFactory modelFactory;
        readonly ISaveTicketCommandFactory saveTicketCommandFactory;
        readonly IViewFactory viewFactory;
        readonly ITicketDialogViewModelFactory viewModelFactory;

        public NewTicketCommand(IModelFactory modelFactory, IViewFactory viewFactory,
                                ITicketDialogViewModelFactory viewModelFactory, ICloseCommandFactory closeCommandFactory,
                                ISaveTicketCommandFactory saveTicketCommandFactory)
        {
            this.modelFactory = modelFactory;
            this.viewFactory = viewFactory;
            this.viewModelFactory = viewModelFactory;
            this.closeCommandFactory = closeCommandFactory;
            this.saveTicketCommandFactory = saveTicketCommandFactory;
        }

        public override void Execute(object parameter)
        {
            var view = CreateView();
            var model = CreateModel();
            var closeCommand = CreateCloseCommand(view);
            var saveTicketCommand = saveTicketCommandFactory.Create(model, view);
            var viewModel = CreateViewModel(model, closeCommand, saveTicketCommand);
            view.DataContext = viewModel;
            view.ShowDialog();
        }

        ICloseCommand CreateCloseCommand(ITicketDetailsView view)
        {
            return closeCommandFactory.Create(view);
        }

        Ticket CreateModel()
        {
            return modelFactory.Create<Ticket>();
        }

        ITicketDetailsView CreateView()
        {
            return viewFactory.Create<ITicketDetailsView>();
        }

        ITicketDialogViewModel CreateViewModel(Ticket model, ICloseCommand closeCommand,
                                               ISaveTicketCommand saveTicketCommand)
        {
            return viewModelFactory.Create(model, closeCommand, saveTicketCommand, Strings.TicketDetails.AddHeaderText);
        }
    }
}