using Lps.Model;
using Lps.Model.System;
using Lps.Model.System.Dto;

namespace Lps.Service.System.IService
{
    /// <summary>
    /// 数据差异日志service接口
    /// </summary>
    public interface ISqlDiffLogService : IBaseService<SqlDiffLog>
    {
        PagedInfo<SqlDiffLogDto> GetList(SqlDiffLogQueryDto parm);

        SqlDiffLog GetInfo(long PId);

        SqlDiffLog AddSqlDiffLog(SqlDiffLog parm);

        int UpdateSqlDiffLog(SqlDiffLog parm);

    }
}
