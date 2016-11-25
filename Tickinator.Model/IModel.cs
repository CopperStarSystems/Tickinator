//  --------------------------------------------------------------------------------------
// Tickinator.Model.IModel.cs
// 2016/11/25
//  --------------------------------------------------------------------------------------

namespace Tickinator.Model
{
    public interface IModel
    {
        // Marker interface used for generic constraints
        // (see IRepository.cs)
        int Id { get; set; }
    }
}