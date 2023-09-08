using Lps.Model;
using Lps.ServiceCore.Model.Dto;
using Lps.ServiceCore.Model.System;

namespace Lps.ServiceCore.Service.IService
{
    /// <summary>
    /// 数据差异日志service接口
    /// </summary>
    public interface ISysSqldiffLogService : IBaseService<SysSqldiffLog>
    {
        PagedInfo<SysSqldiffLogDto> GetList(SqlDiffLogQueryDto parm);

        SysSqldiffLog GetInfo(long PId);

        SysSqldiffLog AddSqlDiffLog(SysSqldiffLog parm);

        int UpdateSqlDiffLog(SysSqldiffLog parm);

    }
}
