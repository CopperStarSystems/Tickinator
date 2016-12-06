//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TechnicianListItemViewModel.cs
// 2016/12/04
//  --------------------------------------------------------------------------------------

using GalaSoft.MvvmLight;
using Tickinator.Model;

namespace Tickinator.ViewModel.TechnicianList
{
    public class TechnicianListItemViewModel : ViewModelBase, ITechnicianListItemViewModel
    {
        readonly Technician technician;

        public TechnicianListItemViewModel(Technician technician)
        {
            this.technician = technician;
        }

        public string FullName
        {
            get { return $"{technician.LastName}, {technician.FirstName}"; }
        }

        public int Id
        {
            get { return technician.Id; }
        }
    }
}