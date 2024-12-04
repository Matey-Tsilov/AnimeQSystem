using System.Linq.Expressions;

namespace AnimeQSystem.Data.Repositories.Interfaces
{
    public interface IRepository<TItem, TId>
    {
        public TItem FirstOrDefault(Expression<Func<TItem, bool>> predicate);
        public Task<TItem?> FirstOrDefaultAsync(Expression<Func<TItem, bool>> predicate);
        public IEnumerable<TItem?> GetAll();
        public Task<IEnumerable<TItem>> GetAllAsync();
        public IQueryable<TItem> GetAllAttached();
        public TItem? GetById(TId id);
        public Task<TItem?> GetByIdAsync(TId id);
        public void Add(TItem item);
        public Task AddAsync(TItem item);
        public void AddRange(TItem[] items);
        public Task AddRangeAsync(TItem[] items);
        public bool Update(TItem item);
        public Task<bool> UpdateAsync(TItem item);
        public bool Delete(TId id);
        public bool Delete(params TId[] compositeId);
        public Task<bool> DeleteAsync(TId id);
        public Task<bool> DeleteAsync(params TId[] compositeId);
        public bool SoftDelete(TId id);
        public bool SoftDelete(params TId[] compositeId);
        public Task<bool> SoftDeleteAsync(TId id);
        public Task<bool> SoftDeleteAsync(params TId[] compositeId);
        public void SaveChanges();
        public Task SaveChangesAsync();

    }
}
