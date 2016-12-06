//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITechnicianListItemViewModelFactory.cs
// 2016/12/06
//  --------------------------------------------------------------------------------------

using Tickinator.Model;

namespace Tickinator.ViewModel.TechnicianList
{
    public interface ITechnicianListItemViewModelFactory
    {
        ITechnicianListItemViewModel Create(Technician technician);
    }
}