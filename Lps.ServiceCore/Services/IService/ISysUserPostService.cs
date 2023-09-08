using System.Collections.Generic;
using Lps.ServiceCore.Model.System;

namespace Lps.ServiceCore.Service.IService
{
    public interface ISysUserPostService
    {
        public void InsertUserPost(SysUser user);

        public List<long> GetUserPostsByUserId(long userId);

        public string GetPostsStrByUserId(long userId);
        bool Delete(long userId);
    }
}
