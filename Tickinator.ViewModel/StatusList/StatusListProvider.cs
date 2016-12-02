//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.StatusListProvider.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Tickinator.ViewModel.StatusList
{
    public class StatusListProvider : IStatusListProvider
    {
        public IEnumerable<IStatusListItemViewModel> GetStatuses()
        {
            return new List<IStatusListItemViewModel>();
        }
    }
}