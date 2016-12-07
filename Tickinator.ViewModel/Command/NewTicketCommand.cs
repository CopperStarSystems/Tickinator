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
        readonly IViewFactory viewFactory;
        readonly ITicketDialogViewModelFactory viewModelFactory;

        public NewTicketCommand(IModelFactory modelFactory, IViewFactory viewFactory,
                                ITicketDialogViewModelFactory viewModelFactory, ICloseCommandFactory closeCommandFactory)
        {
            this.modelFactory = modelFactory;
            this.viewFactory = viewFactory;
            this.viewModelFactory = viewModelFactory;
            this.closeCommandFactory = closeCommandFactory;
        }

        public override void Execute(object parameter)
        {
            var view = CreateView();
            var model = CreateModel();
            var closeCommand = CreateCloseCommand(view);
            var viewModel = CreateViewModel(model, closeCommand);
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

        ITicketDialogViewModel CreateViewModel(Ticket model, ICloseCommand closeCommand)
        {
            return viewModelFactory.Create(model, closeCommand, Strings.TicketDetails.AddHeaderText);
        }
    }
}