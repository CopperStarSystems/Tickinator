//  --------------------------------------------------------------------------------------
// Tickinator.Model.IModelFactory.cs
// 2016/12/07
//  --------------------------------------------------------------------------------------

namespace Tickinator.Model
{
    public interface IModelFactory
    {
        T Create<T>() where T : class, IModel, new();
    }
}