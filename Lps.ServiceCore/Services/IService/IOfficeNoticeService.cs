using System.Collections.Generic;
using Lps.Model;
using Lps.ServiceCore.Model.Dto;
using Lps.ServiceCore.Model.System;

namespace Lps.ServiceCore.Service.IService
{
    /// <summary>
    /// 通知公告表service接口
    ///
    /// @author Lean365
    /// @date 2021-12-15
    /// </summary>
    public interface IOfficeNoticeService : IBaseService<OfficeNotice>
    {
        List<OfficeNotice> GetSysNotices();

        PagedInfo<OfficeNotice> GetPageList(SysNoticeQueryDto parm);
    }
}
