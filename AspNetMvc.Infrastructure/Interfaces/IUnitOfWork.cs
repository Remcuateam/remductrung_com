using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetMvc.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Call save change from database context
        /// </summary>
        void Commit();
    }
}
