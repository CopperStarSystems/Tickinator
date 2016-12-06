//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITechnicianListProvider.cs
// 2016/12/06
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Tickinator.ViewModel.TechnicianList
{
    public interface ITechnicianListProvider
    {
        IEnumerable<ITechnicianListItemViewModel> GetTechnicians();
    }
}