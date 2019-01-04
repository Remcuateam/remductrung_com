using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetMvc.Data.Interfaces
{
    public interface IMetaData
    {
        string PageAlias { set; get; }
        string PageTitle { get; set; }
        string MetaDescription { get; set; }
        string MetaKeywords { get; set; }
    }
}
