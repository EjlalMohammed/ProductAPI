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
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
    }
}
