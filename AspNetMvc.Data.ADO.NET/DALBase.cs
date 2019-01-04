using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.ADO.NET
{
    public abstract class DALBase<TEntity, TPrimaryKey> : IDALBase<TEntity, TPrimaryKey>
    where TEntity : DomainEntity<TPrimaryKey>
    {
        public virtual int Delete(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetById(TPrimaryKey Id)
        {
            throw new NotImplementedException();
        }

        public virtual List<TEntity> GetList()
        {
            throw new NotImplementedException();
        }

        public virtual int Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual int Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
