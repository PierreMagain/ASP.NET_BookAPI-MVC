using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_Devops_2024_DemoAspMvc.DAL.Interfaces
{
    public interface IBaseRepository<TEntity,TId> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity? GetById(TId id);
        int Count();
        TId Create(TEntity e);
        bool Update(TId id, TEntity e);
        bool Delete(TId id);
    }
}
