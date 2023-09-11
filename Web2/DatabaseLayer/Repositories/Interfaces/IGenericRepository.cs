using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task<T> Delete(T entity);
        Task<T> Update(T entity, object id);
        Task<T> FindAsync(Expression<Func<T, bool>> filter);
    }
}
