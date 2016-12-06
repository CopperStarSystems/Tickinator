//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITechnicianListProvider.cs
// 2016/12/06
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using Tickinator.Model;

namespace Tickinator.ViewModel.TechnicianList
{
    public interface ITechnicianListProvider
    {
        IEnumerable<ITechnicianListItemViewModel> GetTechnicians();
    }
}