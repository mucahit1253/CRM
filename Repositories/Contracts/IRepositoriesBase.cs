using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoriesBase<T>
    {
        //burada degişiklikleri izliyoruz.
        IQueryable<T> FindAll(bool trackChanges);

        //Kosula bağlı Liste alma okuma 
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
