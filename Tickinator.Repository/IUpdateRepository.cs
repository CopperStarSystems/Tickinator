//  --------------------------------------------------------------------------------------
// Tickinator.Repository.IUpdateRepository.cs
// 2016/12/08
//  --------------------------------------------------------------------------------------

using Tickinator.Model;

namespace Tickinator.Repository
{
    public interface IUpdateRepository<T> : IRepository<T> where T : ModelBase
    {
        T Update(T item);
    }
}