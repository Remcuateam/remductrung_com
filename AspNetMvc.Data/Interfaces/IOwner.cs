using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetMvc.Data.Interfaces
{
    public interface IOwner<T>
    {
        T OwnerId { set; get; }
    }
}
