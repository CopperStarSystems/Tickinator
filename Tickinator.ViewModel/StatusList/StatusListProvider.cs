//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.StatusListProvider.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Tickinator.Common.Enums;

namespace Tickinator.ViewModel.StatusList
{
    public class StatusListProvider : IStatusListProvider
    {
        readonly IStatusListItemViewModelFactory statusListItemViewModelFactory;

        IList<IStatusListItemViewModel> statusList;

        public StatusListProvider(IStatusListItemViewModelFactory statusListItemViewModelFactory)
        {
            this.statusListItemViewModelFactory = statusListItemViewModelFactory;
        }

        public IEnumerable<IStatusListItemViewModel> GetStatuses()
        {
            if (statusList == null)
                CreateStatusList();
            return statusList;
        }

        void CreateStatusList()
        {
            statusList = new List<IStatusListItemViewModel>();
            foreach (var status in Enum.GetValues(typeof(StatusEnum)).Cast<StatusEnum>())
                statusList.Add(statusListItemViewModelFactory.Create(status));
        }
    }
}