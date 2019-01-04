using AspNetMvc.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetMvc.Data.ADO.NET
{
    public interface IDALBase<TEntity, TPrimaryKey> where TEntity: DomainEntity<TPrimaryKey>
    {
        List<TEntity> GetList();
        TEntity GetById(TPrimaryKey Id);
        int Insert(TEntity entity);
        int Update(TEntity entity);
        int Delete(TPrimaryKey id);

        DataTable GetAll();
    }
}
