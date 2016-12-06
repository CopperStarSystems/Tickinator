//  --------------------------------------------------------------------------------------
// Tickinator.Repository.ITechnicianRepository.cs
// 2016/12/06
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using Tickinator.Model;

namespace Tickinator.Repository
{
    public interface ITechnicianRepository
    {
        IEnumerable<Technician> GetAll();
    }
}