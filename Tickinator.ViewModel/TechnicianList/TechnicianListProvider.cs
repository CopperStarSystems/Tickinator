//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TechnicianListProvider.cs
// 2016/12/06
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Tickinator.ViewModel.TechnicianList
{
    public class TechnicianListProvider : ITechnicianListProvider
    {
        // Stub
        public IEnumerable<ITechnicianListItemViewModel> GetTechnicians()
        {
            return new List<ITechnicianListItemViewModel>();
        }
    }
}