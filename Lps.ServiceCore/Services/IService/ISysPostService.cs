using System;
using System.Collections.Generic;
using System.Text;
using Lps.Repository;
using Lps.ServiceCore.Model.System;

namespace Lps.ServiceCore.Service.IService
{
    public interface ISysPostService : IBaseService<SysPost>
    {
        string CheckPostNameUnique(SysPost sysPost);
        string CheckPostCodeUnique(SysPost sysPost);
        List<SysPost> GetAll();
    }
}
