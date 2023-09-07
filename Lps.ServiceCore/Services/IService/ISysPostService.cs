using System;
using System.Collections.Generic;
using System.Text;
using Lps.Model.System;
using Lps.Repository;

namespace Lps.Service.System.IService
{
    public interface ISysPostService : IBaseService<SysPost>
    {
        string CheckPostNameUnique(SysPost sysPost);
        string CheckPostCodeUnique(SysPost sysPost);
        List<SysPost> GetAll();
    }
}
