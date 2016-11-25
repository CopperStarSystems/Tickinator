//  --------------------------------------------------------------------------------------
// Tickinator.Repository.IRepository.cs
// 2016/11/25
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using Tickinator.Model;

namespace Tickinator.Repository
{
    // This is a simple implementation to begin with, we will
    // segregate repository responsibilities in the future.
    public interface IRepository<T> where T : IModel
    {
        IEnumerable<T> GetAll();
    }
}