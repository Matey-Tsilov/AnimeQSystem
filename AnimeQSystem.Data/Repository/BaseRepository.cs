using AnimeQSystem.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimeQSystem.Data.Repository
{
    public class BaseRepository<TItem, TId> : IRepository<TItem, TId>
        where TItem : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<TItem> _dbSet;
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TItem>();
        }

        public TItem? GetById(TId id) => _dbSet.Find(id);

        public TItem? GetById(params TId[] compositeId) => _dbSet.Find(compositeId[0], compositeId[1]);

        public async Task<TItem?> GetByIdAsync(TId id) => await _dbSet.FindAsync(id);

        public async Task<TItem?> GetByIdAsync(params TId[] compositeId) => await _dbSet.FindAsync(compositeId[0], compositeId[1]);

        public IEnumerable<TItem> GetAll() => _dbSet.ToList();

        public async Task<IEnumerable<TItem>> GetAllAsync() => await _dbSet.ToListAsync();

        public IQueryable<TItem> GetAllAttached() => _dbSet.AsQueryable();

        public void Add(TItem item)
        {
            _dbSet.Add(item);
            _dbContext.SaveChanges();
        }

        public async Task AddAsync(TItem item)
        {
            await _dbSet.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public bool Delete(TId id)
        {
            TItem? item = _dbSet.Find(id);

            if (item == null)
            {
                return false;
            }

            _dbSet.Remove(item);
            _dbContext.SaveChanges();

            return true;
        }

        public bool Delete(params TId[] compositeId)
        {
            TItem? item = _dbSet.Find(compositeId[0], compositeId[1]);

            if (item == null)
            {
                return false;
            }

            _dbSet.Remove(item);
            _dbContext.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteAsync(TId id)
        {
            TItem? item = await _dbSet.FindAsync(id);

            if (item == null)
            {
                return false;
            }

            _dbSet.Remove(item);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(params TId[] compositeId)
        {
            TItem? item = await _dbSet.FindAsync(compositeId[0], compositeId[1]);

            if (item == null)
            {
                return false;
            }

            _dbSet.Remove(item);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public bool SoftDelete(TId id)
        {
            TItem? item = _dbSet.Find(id);

            if (item == null)
            {
                return false;
            }

            var isDeletedProperty = typeof(TItem).GetProperty("IsDeleted");
            if (isDeletedProperty != null && isDeletedProperty.PropertyType == typeof(bool))
            {
                isDeletedProperty.SetValue(item, true); // Set IsDeleted to true
                _dbContext.SaveChanges(); // Persist changes
                return true;
            }

            return false;
        }

        public bool SoftDelete(params TId[] compositeId)
        {
            TItem? item = _dbSet.Find(compositeId[0], compositeId[1]);

            if (item == null)
            {
                return false;
            }

            var isDeletedProperty = typeof(TItem).GetProperty("IsDeleted");
            if (isDeletedProperty != null && isDeletedProperty.PropertyType == typeof(bool))
            {
                isDeletedProperty.SetValue(item, true); // Set IsDeleted to true
                _dbContext.SaveChanges(); // Persist changes
                return true;
            }

            return false;
        }

        public async Task<bool> SoftDeleteAsync(TId id)
        {
            TItem? item = await _dbSet.FindAsync(id);

            if (item == null)
            {
                return false;
            }

            var isDeletedProperty = typeof(TItem).GetProperty("IsDeleted");
            if (isDeletedProperty != null && isDeletedProperty.PropertyType == typeof(bool))
            {
                isDeletedProperty.SetValue(item, true); // Set IsDeleted to true
                await _dbContext.SaveChangesAsync(); // Persist changes
                return true;
            }

            return false;
        }

        public async Task<bool> SoftDeleteAsync(params TId[] compositeId)
        {
            TItem? item = await _dbSet.FindAsync(compositeId[0], compositeId[1]);

            if (item == null)
            {
                return false;
            }

            var isDeletedProperty = typeof(TItem).GetProperty("IsDeleted");
            if (isDeletedProperty != null && isDeletedProperty.PropertyType == typeof(bool))
            {
                isDeletedProperty.SetValue(item, true); // Set IsDeleted to true
                await _dbContext.SaveChangesAsync(); // Persist changes
                return true;
            }

            return false;
        }

        public bool Update(TItem item)
        {
            try
            {
                _dbSet.Attach(item);
                _dbContext.Entry(item).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> UpdateAsync(TItem item)
        {
            try
            {
                _dbSet.Attach(item);
                _dbContext.Entry(item).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void AddRange(TItem[] items)
        {
            _dbSet.AddRange(items);
            _dbContext.SaveChanges();
        }

        public async Task AddRangeAsync(TItem[] items)
        {
            await _dbSet.AddRangeAsync(items);
            await _dbContext.SaveChangesAsync();
        }
    }
}
