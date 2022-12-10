using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat.Core.RepositoryInterfaces
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        List<TEntity> GetAllList();
        TEntity Get(TEntity entity);
        TEntity GetById(string id);


    }
}
