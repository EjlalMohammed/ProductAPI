using Domain.IRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class BaseRepository<T>(ProductDbContext productDbContext) : IBaseRepository<T> where T : class
    {
        private readonly ProductDbContext _context = productDbContext;

        public async Task<int> Delete<Type>(Type id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                return _context.SaveChanges();
            }
            return 0; 
        }

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await _context.Set<T>().ToListAsync();

        
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, bool includeSons = false)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includeSons)
            {
                var propertiesToInclude = typeof(T).GetProperties()
                    .Where(prop => prop.PropertyType.IsClass && prop.PropertyType != typeof(string));

                query = propertiesToInclude.Aggregate(query, (current, property) => current.Include(property.Name));
            }

            return await (filter != null ? query.Where(filter) : query).ToListAsync();
        }
        public async Task<T> GetByIdAsync<Type>(Type id)=> _context.Set<T>().Find(id);

        public async Task<int> Update(T value)
        {
            _context.Entry(value).State = EntityState.Modified;
            return _context.SaveChanges();
        }
        public async Task<int> InsertAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChanges();
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter)=>
            await _context.Set<T>().FirstOrDefaultAsync(filter);
        
    }
}
