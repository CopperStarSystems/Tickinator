//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.IStatusListProvider.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Tickinator.ViewModel.StatusList
{
    public interface IStatusListProvider
    {
        IEnumerable<IStatusListItemViewModel> GetStatuses();
    }
}