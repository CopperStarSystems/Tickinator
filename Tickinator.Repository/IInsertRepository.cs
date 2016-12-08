//  --------------------------------------------------------------------------------------
// Tickinator.Repository.IInsertRepository.cs
// 2016/12/07
//  --------------------------------------------------------------------------------------

using Tickinator.Model;

namespace Tickinator.Repository
{
    public interface IInsertRepository<T> : IRepository<T> where T : ModelBase
    {
        T Insert(T item);
    }
}