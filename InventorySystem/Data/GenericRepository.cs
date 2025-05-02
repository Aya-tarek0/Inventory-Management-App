using System.Linq.Expressions;
using InventorySystem.DTO;
using InventorySystem.Interfaces;
using InventorySystem.Models;
using Microsoft.EntityFrameworkCore;
namespace InventorySystem.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        private readonly InventoryContext _context;

        public GenericRepository(InventoryContext context )
            {
           _context = context;
        }

            public void Add(T category)
            {
                _context.Set<T>().Add(category);
            }

        public void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Remove(int id)
        {
            T t = Get(x => x.Id == id).FirstOrDefault();
            _context.Remove(t);
        }

        public IQueryable<T> GetAll()
            {
                return _context.Set<T>();
            }

            public IQueryable<T> Get(Expression<Func<T, bool>> expression)
            {
                return _context.Set<T>().Where(expression);
            }

            public T GetByID(int id)
            {
                return Get(x => x.Id == id).FirstOrDefault();
            }

            public async Task SaveChangesAsync()
            {
                await _context.SaveChangesAsync();
            }
        }
    }
