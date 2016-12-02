//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ShowTicketDetailsCommand.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

using Tickinator.ViewModel.Command.Core;
using Tickinator.ViewModel.TicketList;
using Tickinator.ViewModel.View;
using Tickinator.ViewModel.View.Core;

namespace Tickinator.ViewModel.Command
{
    public class ShowTicketDetailsCommand : GenericCommandBase<ITicketListItemViewModel>, IShowTicketDetailsCommand
    {
        readonly IViewFactory viewFactory;

        public ShowTicketDetailsCommand(IViewFactory viewFactory)
        {
            this.viewFactory = viewFactory;
        }

        protected override void ExecuteInternal(ITicketListItemViewModel parameter)
        {
            var view = viewFactory.Create<ITicketDetailsView>();
            view.DataContext = parameter;
            view.ShowDialog();
        }
    }
}