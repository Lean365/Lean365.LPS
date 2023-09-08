using Lps.Infrastructure;
using System;
using Lps.Model;
using Lps.ServiceCore.Model.Dto;
using Lps.ServiceCore.Model.System;

namespace Lps.ServiceCore.Service.IService
{ 
    public interface ISysLoginService : IBaseService<SysLogininfor>
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginBody"></param>
        /// <param name="logininfor"></param>
        /// <returns></returns>
        public SysUser Login(LoginBodyDto loginBody, SysLogininfor logininfor);

        /// <summary>
        /// 查询操作日志
        /// </summary>
        /// <param name="logininfoDto"></param>
        /// <param name="pager">分页</param>
        /// <returns></returns>
        public PagedInfo<SysLogininfor> GetLoginLog(SysLogininfor logininfoDto, PagerInfo pager);

        /// <summary>
        /// 记录登录日志
        /// </summary>
        /// <param name="sysLogininfor"></param>
        /// <returns></returns>
        public void AddLoginInfo(SysLogininfor sysLogininfor);

        /// <summary>
        /// 清空登录日志
        /// </summary>
        public void TruncateLogininfo();

        /// <summary>
        /// 删除登录日志
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int DeleteLogininforByIds(long[] ids);

        void CheckLockUser(string userName);
    }
}
