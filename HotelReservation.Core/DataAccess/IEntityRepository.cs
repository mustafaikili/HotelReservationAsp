using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Core.DataAccess
{
     public interface IEntityRepository<T> where T : class
     {
          void Add(T entity);
          void Delete(T entity);
          void Update(T entity);
          T Get(Expression<Func<T, bool>> filter = null);
          ICollection<T> GetAll(Expression<Func<T, bool>> filter = null);
     }
}
