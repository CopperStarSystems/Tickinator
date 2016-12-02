//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TicketDetailsViewModel.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Tickinator.ViewModel.StatusList;

namespace Tickinator.ViewModel.TicketDetails
{
    public class TicketDetailsViewModel : ViewModelBase, ITicketDetailsViewModel
    {
        int assignedToId;
        DateTime? dateClosed;
        DateTime dateOpened;
        int id;

        IEnumerable<IStatusListItemViewModel> statuses;

        public IEnumerable<IStatusListItemViewModel> Statuses
        {
            get
            {
                return statuses;
            }
            private set
            {
                statuses = value;
                RaisePropertyChanged(nameof(Statuses));
            }
        }

        public ICommand CloseCommand { get; }

        public DateTime? DateClosed
        {
            get
            {
                return dateClosed;
            }
            set
            {
                dateClosed = value;
                RaisePropertyChanged(nameof(DateClosed));
            }
        }

        public DateTime DateOpened
        {
            get
            {
                return dateOpened;
            }
            set
            {
                dateOpened = value;
                RaisePropertyChanged(nameof(DateOpened));
            }
        }

        public int AssignedToId
        {
            get
            {
                return assignedToId;
            }
            set
            {
                assignedToId = value;
                RaisePropertyChanged(nameof(AssignedToId));
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }
    }
}