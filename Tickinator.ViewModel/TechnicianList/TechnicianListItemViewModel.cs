//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TechnicianListItemViewModel.cs
// 2016/12/04
//  --------------------------------------------------------------------------------------

using GalaSoft.MvvmLight;

namespace Tickinator.ViewModel.TechnicianList
{
    public class TechnicianListItemViewModel : ViewModelBase, ITechnicianListItemViewModel
    {
        // Stub for now
        public int Id { get; }
        public string FullName { get; }
    }
}