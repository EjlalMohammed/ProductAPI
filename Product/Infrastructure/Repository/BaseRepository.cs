using Domain.IRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class BaseRepository<T>(ProductDbContext productDbContext) : IBaseRepository<T> where T : class
    {
        private readonly ProductDbContext _dbContext = productDbContext;
        
        public async Task<IEnumerable<T>> GetAllAsync() =>
            await _dbContext.Set<T>().ToListAsync();

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }
    }
}
