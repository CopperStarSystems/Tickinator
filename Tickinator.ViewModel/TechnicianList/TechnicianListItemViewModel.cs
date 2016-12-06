//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TechnicianListItemViewModel.cs
// 2016/12/04
//  --------------------------------------------------------------------------------------

using GalaSoft.MvvmLight;

namespace Tickinator.ViewModel.TechnicianList
{
    public class TechnicianListItemViewModel : ViewModelBase, ITechnicianListItemViewModel
    {
        public string FullName { get; }
        // Stub for now
        public int Id { get; }
    }
}