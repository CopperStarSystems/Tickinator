//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.DashboardViewModelBase.cs
// 2016/11/25
//  --------------------------------------------------------------------------------------

using Tickinator.Repository;

namespace Tickinator.ViewModel
{
    public abstract class DashboardViewModelBase : ViewModelBase, IDashboardViewModel
    {
        protected DashboardViewModelBase(ITicketRepository ticketRepository)
        {
            Repository = ticketRepository;
        }

        public abstract int OpenTicketCount { get; }

        protected ITicketRepository Repository { get; private set; }
    }
}