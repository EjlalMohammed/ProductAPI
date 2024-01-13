using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IBaseRepository<T> where T : class 
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, bool All = true);
        Task<int> InsertAsync(T entity);
        Task<T> GetByIdAsync<Type>(Type Id);
        Task<int> Update(T value);
        Task<int> Delete<Type>(Type Id);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter);
    }
}
