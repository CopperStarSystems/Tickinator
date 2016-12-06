//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITechnicianListItemViewModel.cs
// 2016/12/04
//  --------------------------------------------------------------------------------------

namespace Tickinator.ViewModel.TechnicianList
{
    public interface ITechnicianListItemViewModel
    {
        string FullName { get; }

        int Id { get; }
    }
}