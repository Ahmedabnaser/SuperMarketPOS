using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketPOS.Abstraction.RepositoreiesInterfaces
{
    public interface IGenricRepository<T>where T : class
    {
        public Task<IList<T>> FindByCondition(Expression<Func<T, bool>> expression);
        public Task<IList<T>> GetAll();
        public Task AddAsync(T entity);
        public Task<T?> GetByIdAsync(Guid id); 
        void Update(T entity);
        void  Delete(T entity);
        
    }
}
