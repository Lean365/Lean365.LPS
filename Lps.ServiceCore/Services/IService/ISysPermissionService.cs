using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lps.ServiceCore.Model.System;

namespace Lps.ServiceCore.Service.IService
{
    public interface ISysPermissionService
    {
        public List<string> GetRolePermission(SysUser user);
        public List<string> GetMenuPermission(SysUser user);
    }
}
