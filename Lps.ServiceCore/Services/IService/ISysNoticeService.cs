using System.Collections.Generic;
using Lps.Model;
using Lps.Model.System;
using Lps.Model.System.Dto;

namespace Lps.Service.System.IService
{
    /// <summary>
    /// 通知公告表service接口
    ///
    /// @author Lean365
    /// @date 2021-12-15
    /// </summary>
    public interface ISysNoticeService : IBaseService<SysNotice>
    {
        List<SysNotice> GetSysNotices();

        PagedInfo<SysNotice> GetPageList(SysNoticeQueryDto parm);
    }
}
