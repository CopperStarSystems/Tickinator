//  --------------------------------------------------------------------------------------
// Tickinator.Repository.MockData.TechnicianRepository.cs
// 2016/12/06
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using Tickinator.Model;

namespace Tickinator.Repository.MockData
{
    public class TechnicianRepository : ITechnicianRepository
    {
        IList<Technician> technicians;

        public TechnicianRepository()
        {
            Seed();
        }

        public IEnumerable<Technician> GetAll()
        {
            return technicians;
        }

        void Seed()
        {
            technicians = new List<Technician>();
            technicians.Add(new Technician {Id = 1, FirstName = "Bob", LastName = "Jones"});
            technicians.Add(new Technician {Id = 2, FirstName = "Bill", LastName = "Smith"});
            technicians.Add(new Technician {Id = 3, FirstName = "Sally", LastName = "Roe"});
        }
    }
}