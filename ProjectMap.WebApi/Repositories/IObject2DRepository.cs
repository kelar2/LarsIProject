using LarsIProject.WebApi.Models;

namespace LarsIProject.WebApi.Repositories
{
    public interface IObject2DRepository
    {
        Task DeleteAsync(string id);
        Task<Object2D> InsertAsync(Object2D object2D);
        Task<IEnumerable<Object2D>> ReadAsync(string environmentId);
        Task<Object2D?> ReadAsync(Guid id);
        Task UpdateAsync(Object2D environment);
    }
}