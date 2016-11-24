//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.MainViewModel.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

namespace Tickinator.ViewModel
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        public MainViewModel(ITeamDashboardViewModel teamDashboardViewModel)
        {
            TeamDashboardViewModel = teamDashboardViewModel;
        }

        public ITeamDashboardViewModel TeamDashboardViewModel { get; }
    }
}