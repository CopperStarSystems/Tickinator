//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.IDashboardViewModel.cs
// 2016/11/25
//  --------------------------------------------------------------------------------------

namespace Tickinator.ViewModel
{
    public interface IDashboardViewModel : IViewModel
    {
        int OpenTicketCount { get; }

        int ClosedTodayCount { get; }
    }
}