using System.Linq.Expressions;
using InventorySystem.DTO;
namespace InventorySystem.Interfaces
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        void Add(T category);
        void Update(T category);
        void Remove(int id);
        T GetByID(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> expression);

        Task SaveChangesAsync();
    }
}
