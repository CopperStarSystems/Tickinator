//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TechnicianListProvider.cs
// 2016/12/06
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using Tickinator.Model;
using Tickinator.Repository;

namespace Tickinator.ViewModel.TechnicianList
{
    public class TechnicianListProvider : ITechnicianListProvider
    {
        readonly ITechnicianRepository technicianRepository;
        IList<ITechnicianListItemViewModel> technicians;

        public TechnicianListProvider(ITechnicianRepository technicianRepository,
                                      ITechnicianListItemViewModelFactory listItemViewModelFactory)
        {
            CreateList(technicianRepository.GetAll(), listItemViewModelFactory);
        }

        public IEnumerable<ITechnicianListItemViewModel> GetTechnicians()
        {
            return technicians;
        }

        void CreateList(IEnumerable<Technician> technicianEntities, ITechnicianListItemViewModelFactory factory)
        {
            technicians = new List<ITechnicianListItemViewModel>();
            foreach (var technicianEntity in technicianEntities)
            {
                var technician = factory.Create(technicianEntity);
                technicians.Add(technician);
            }
        }
    }
}