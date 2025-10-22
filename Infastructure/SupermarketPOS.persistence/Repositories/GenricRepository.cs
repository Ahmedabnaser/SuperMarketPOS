using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SupermarketPOS.Abstraction.RepositoreiesInterfaces;
using SupermarketPOS.persistence.Data;
using System.Linq.Expressions;


namespace SupermarketPOS.persistence.Repositoriess
{
    public class GenricRepository<T> : IGenricRepository<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<GenricRepository<T>> logger;
        private readonly DbSet<T> dbset;
        

        public GenricRepository(ApplicationDbContext dbContext,ILogger<GenricRepository<T>>logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            dbset= dbContext.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            try
            {
            await dbset.AddAsync(entity);      
            }catch(Exception ex)
            {
                logger.LogError(ex, "Error adding entity of type {EntityType}", typeof(T).Name);
                throw new ApplicationException($"Could not add entity of type {typeof(T).Name}", ex);
            }
        }

        public  async Task<IList<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            try
            {
                return await dbset.Where(expression).ToListAsync();
            }catch(Exception ex)
            {
                logger.LogError(ex, $"Error finding entities of type {typeof(T).Name} by condition", typeof(T).Name);
                throw new ApplicationException($"Could not find entities of type {typeof(T).Name} by condition", ex);
            }
        }   

        public async Task<IList<T>> GetAll()
        {
            try
            {
                return await dbset.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error retrieving all entities of type {EntityType}", typeof(T).Name);
                throw new ApplicationException($"Could not retrieve entities of type {typeof(T).Name}", ex);
            }
        }


        public void Delete(T  entity)
        {
         
            if (entity == null)
            {
                logger.LogWarning("Entity of type {EntityType}  not found for deletion", typeof(T).Name);
                throw new Exception($"Entity of type {typeof(T).Name}  not found");
            }
            dbset.Remove(entity);
        }


        public void Update(T entity)
        {
            var getEntity=dbset.Find(entity);
            if (getEntity == null)
            {
                logger.LogWarning("Entity of type {EntityType} not found for update", typeof(T).Name);
                throw new KeyNotFoundException($"Entity of type {typeof(T).Name} not found");
            }
            else
            {
                dbset.Update(entity);
            }
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            try
            {
                logger.LogInformation("Finding entity of type {EntityType} with ID {EntityId}", typeof(T).Name, id);
                return await dbset.FindAsync(id);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Error finding entity of type {EntityType} with ID {EntityId}", typeof(T).Name, id);
                throw new Exception($"Cann't find a Entity by that id {id}",ex);
            }
        }
    }
}
