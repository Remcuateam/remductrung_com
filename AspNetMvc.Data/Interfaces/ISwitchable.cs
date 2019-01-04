using System;
using System.Collections.Generic;
using System.Text;
using AspNetMvc.Infrastructure.Enums;

namespace AspNetMvc.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
